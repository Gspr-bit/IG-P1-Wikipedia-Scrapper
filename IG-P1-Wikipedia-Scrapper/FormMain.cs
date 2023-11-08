using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IG_P1_Wikipedia_Scrapper
{
    public partial class FormMain : Form
    {
        private WikipediaPage page;

        public FormMain()
        {
            page = new WikipediaPage();
            InitializeComponent();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            DeleteData();

            page = Scrapper.Query(TxtSearch.Text);

            FillData();
        }

        private void DeleteData()
        {
            TreeIndex.Nodes.Clear();
        }

        private void FillData()
        {
            FillIndex();
            ShowParagraph("");
        }

        private void ShowParagraph(string title)
        {
            string text = "";
            if (page.Paragraphs.TryGetValue(title, out text))
            {
                // RtbMain.Text = text;
                MainWebBrowser.DocumentText = text;
            }
        }

    private void FillIndex()
        {
            TreeNode root = new TreeNode("Índice");

            Dictionary<int, TreeNode> roots = new Dictionary<int, TreeNode>();

            foreach (var indexElement in page.Index)
            {
                TreeNode node = new TreeNode(indexElement.Text);
    
                // save this node as the latest
                // node in that level
                roots[indexElement.Level] = node;
                
                // add this node to the latest node
                // in the prev level
                if (indexElement.Level == 0)
                {
                    root.Nodes.Add(node);
                }
                else
                {
                    // it is ensured that a node with a lower level
                    // is always going to exist
                    roots[indexElement.Level - 1].Nodes.Add(node);
                }
                
            }

            TreeIndex.Nodes.Add(root);
            
            TreeIndex.ExpandAll();
        }

        private void TreeIndex_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selectedIndex = TreeIndex.SelectedNode.Text;
            ShowParagraph(selectedIndex);
        }
    }
}
