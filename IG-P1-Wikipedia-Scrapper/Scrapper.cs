using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace IG_P1_Wikipedia_Scrapper
{
    internal class Scrapper
    {
        public static WikipediaPage Query(string name)
        {
            // Construir la url. Hay que reemplazar los espacios por guiones bajos.
            string url = "https://es.wikipedia.org/wiki/" + name.Trim().Replace(' ', '_');

            // Inicializar la clase donde guardamos toda la información
            WikipediaPage page = new WikipediaPage();

            // Obtener el documento HTML
            HtmlDocument doc = MakeRequest(url);
            // Obtener el índice de la página
            page.Index = PageIndex(doc);
            
            // Para cada elemento del índice, obtener su contenido
            foreach (IndexElement index in page.Index)
            {
                string content = GetParagraph(doc, index.Link);
                page.Paragraphs[index.Text] = content;
            }
            
            return page;
        }

        /**
         * Encuentra el índice de la página de wikipedia y regresa un List con los nombres
         * y las url de las páginas
         * */
        private static List<IndexElement> PageIndex(HtmlDocument doc)
        {
            List<IndexElement> indexElements = new List<IndexElement>();

            // Buscar el id del elemento que tiene el índice
            HtmlNode docIndex = doc.GetElementbyId("mw-panel-toc-list");
            
            try
            {
                // Encontrar todas las etiquetas <a>
                var links = docIndex.SelectNodes(".//a[@href]");

                foreach (var link in links)
                {
                    string href = link.Attributes["href"].Value.Replace("#", "");
                    string text = "";

                    var textNodes = link
                        .DescendantsAndSelf()
                        .Where(n => n.NodeType == HtmlNodeType.Text && n.InnerText.Trim() != "");
                    if (textNodes.Any())
                    {
                        text = textNodes.Last().InnerText;
                    }
                    
                    indexElements.Add(new IndexElement(href, text));
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            
            return indexElements;
        }
        
        private static bool IsHeaderTag(HtmlNode node)
        {
            // Use a regular expression to match "h" followed by one or more digits
            return Regex.IsMatch(node.Name, "h\\d");
        }

        /**
         * Encuentra el parrafo bajo el id
         */
        private static string GetParagraph(HtmlDocument doc, string id)
        {
            if (id == "") return "";
            
            HtmlNode paragraphHeader = doc.GetElementbyId(id);
            HtmlNode iterator = paragraphHeader.ParentNode.NextSibling;
            
            string content = iterator.OuterHtml;

            while (iterator != null)
            {
                if (IsHeaderTag(iterator))
                    break;

                if (iterator.Name == "span")
                {
                    iterator = iterator.NextSibling;
                    continue;
                }

                content += iterator.OuterHtml;
                iterator = iterator.NextSibling;
            }

            return content;
        }

        private static HtmlDocument MakeRequest(string url)
        {
            WebRequest request = WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Console.Write(response.StatusCode.ToString());

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Could not get response. Status = " + response.StatusCode);
            }

            Stream dataStream = response.GetResponseStream();
            if (dataStream == null)
            {
                throw new Exception("No response received");
            }

            StreamReader reader = new StreamReader(dataStream);
            string txtResponse = reader.ReadToEnd();

            reader.Close();
            dataStream.Close();
            response.Close();

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(txtResponse);

            return doc;
        }
    }
}
