using System.Collections;
using System.Collections.Generic;

namespace IG_P1_Wikipedia_Scrapper
{
    public struct Href
    {
        public string link, text;

        public Href(string link, string text)
        {
            this.link = link;
            this.text = text;
        }
    }
    
    public class WikipediaPage
    {
        public List<Href> Index;
        public Hashtable Paragraphs;

        public WikipediaPage()
        {
            Index = new List<Href>();
            Paragraphs = new Hashtable();
        }
    }
}