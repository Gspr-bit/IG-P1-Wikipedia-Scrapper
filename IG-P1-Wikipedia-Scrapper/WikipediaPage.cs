using System.Collections;
using System.Collections.Generic;

namespace IG_P1_Wikipedia_Scrapper
{
    public struct IndexElement
    {
        public string Link, Text;

        public IndexElement(string link, string text)
        {
            this.Link = link;
            this.Text = text;
        }
    }
    
    public class WikipediaPage
    {
        public List<IndexElement> Index = new List<IndexElement>();
        public Dictionary<string, string> Paragraphs = new Dictionary<string, string>();
    }
}