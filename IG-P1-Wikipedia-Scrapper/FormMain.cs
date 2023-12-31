﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            UpdateData();
        }

        private void UpdateData()
        {
            DeleteData();

            page = Scrapper.Query(TxtSearch.Text);

            FillData();
            ShowParagraph("");
        }

        private void DeleteData()
        {
            TreeIndex.Nodes.Clear();
            MainWebBrowser.Refresh();
        }

        private void FillData()
        {
            FillIndex();
        }

        private void ShowParagraph(string title)
        {
            if (!page.Paragraphs.TryGetValue(title, out var text))
            {
                // If doesn't find the key, use the first value
                text = page.Paragraphs.First().Value;
            }

            string html = $"<html><body>{text}</body></html>";
            MainWebBrowser.DocumentText = html;
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
                    // it is granted that a node with a lower level
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

        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            TxtSearch.SelectAll();
        }

        private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                UpdateData();
            }
        }

        private void TxtSearch_Click(object sender, EventArgs e)
        {
            TxtSearch.SelectAll();
        }

        private void MainWebBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            string uri = e.Url.ToString();
            
            Console.WriteLine(uri);

            if (uri != "about:blank")
            {
                e.Cancel = true;
                
                // Check if it's a wikipedia Link
                if (uri.Contains("about:/wiki/"))
                {
                    // Extract the page name
                    string pageName = uri.Replace("about:/wiki/", "");
                    // Make a query with this new page
                    TxtSearch.Text = pageName.Replace('_', ' ');
                    UpdateData();
                }
                else if(uri.StartsWith("about:blank#"))
                {
                    // Check if it's a link to the same page
                    string paragraphName = uri.Replace("about:blank#", "");
                    ShowParagraph(paragraphName);
                }
                else
                {
                    // Open in default browser
                    OpenUrlInDefaultBrowser(uri);
                }
            }
        }
        
        private void OpenUrlInDefaultBrowser(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur
                Console.WriteLine("Cannot open url: " + url + '\n' + ex.Message);
            }
        }
    }
}
