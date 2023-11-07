using System;
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
                RtbMain.Text = text;
        }

    private void FillIndex()
        {
            TreeNode root = new TreeNode("Índice");

            foreach (var indexElement in page.Index)
            {
                root.Nodes.Add(indexElement.Text);
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
