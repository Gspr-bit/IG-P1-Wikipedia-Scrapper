using System.Collections;
using System.Collections.Generic;

namespace IG_P1_Wikipedia_Scrapper
{
    public struct IndexElement
    {
        public string Link, Text;
        public int Level;
        
        public IndexElement(string link, string text, int level)
        {
            this.Link = link;
            this.Text = text;
            this.Level = level;
        }
    }
    
    public class WikipediaPage
    {
        public List<IndexElement> Index = new List<IndexElement>();
        public Dictionary<string, string> Paragraphs = new Dictionary<string, string>();
    }
}