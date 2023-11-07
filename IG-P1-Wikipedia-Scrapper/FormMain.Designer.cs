namespace IG_P1_Wikipedia_Scrapper
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.PnlMain = new System.Windows.Forms.Panel();
            this.PnlBottom = new System.Windows.Forms.Panel();
            this.PnlRight = new System.Windows.Forms.Panel();
            this.RtbMain = new System.Windows.Forms.RichTextBox();
            this.PnlLeft = new System.Windows.Forms.Panel();
            this.TreeIndex = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.PnlTop = new System.Windows.Forms.Panel();
            this.PnlMain.SuspendLayout();
            this.PnlBottom.SuspendLayout();
            this.PnlRight.SuspendLayout();
            this.PnlLeft.SuspendLayout();
            this.PnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtSearch
            // 
            this.TxtSearch.Location = new System.Drawing.Point(12, 12);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(100, 20);
            this.TxtSearch.TabIndex = 0;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(1128, 12);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 1;
            this.BtnSearch.Text = "Buscar";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.PnlBottom);
            this.PnlMain.Controls.Add(this.PnlTop);
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(1215, 774);
            this.PnlMain.TabIndex = 2;
            // 
            // PnlBottom
            // 
            this.PnlBottom.Controls.Add(this.PnlRight);
            this.PnlBottom.Controls.Add(this.PnlLeft);
            this.PnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBottom.Location = new System.Drawing.Point(0, 52);
            this.PnlBottom.Name = "PnlBottom";
            this.PnlBottom.Size = new System.Drawing.Size(1215, 722);
            this.PnlBottom.TabIndex = 3;
            // 
            // PnlRight
            // 
            this.PnlRight.Controls.Add(this.RtbMain);
            this.PnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlRight.Location = new System.Drawing.Point(200, 0);
            this.PnlRight.Name = "PnlRight";
            this.PnlRight.Size = new System.Drawing.Size(1015, 722);
            this.PnlRight.TabIndex = 1;
            // 
            // RtbMain
            // 
            this.RtbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RtbMain.Location = new System.Drawing.Point(0, 0);
            this.RtbMain.Name = "RtbMain";
            this.RtbMain.Size = new System.Drawing.Size(1015, 722);
            this.RtbMain.TabIndex = 0;
            this.RtbMain.Text = "";
            // 
            // PnlLeft
            // 
            this.PnlLeft.Controls.Add(this.TreeIndex);
            this.PnlLeft.Controls.Add(this.label1);
            this.PnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlLeft.Location = new System.Drawing.Point(0, 0);
            this.PnlLeft.Name = "PnlLeft";
            this.PnlLeft.Size = new System.Drawing.Size(200, 722);
            this.PnlLeft.TabIndex = 0;
            // 
            // TreeIndex
            // 
            this.TreeIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeIndex.Location = new System.Drawing.Point(0, 0);
            this.TreeIndex.Name = "TreeIndex";
            this.TreeIndex.Size = new System.Drawing.Size(200, 722);
            this.TreeIndex.TabIndex = 1;
            this.TreeIndex.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeIndex_AfterSelect);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Índice";
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.TxtSearch);
            this.PnlTop.Controls.Add(this.BtnSearch);
            this.PnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(1215, 52);
            this.PnlTop.TabIndex = 2;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 774);
            this.Controls.Add(this.PnlMain);
            this.Name = "FormMain";
            this.Text = "Buscar";
            this.PnlMain.ResumeLayout(false);
            this.PnlBottom.ResumeLayout(false);
            this.PnlRight.ResumeLayout(false);
            this.PnlLeft.ResumeLayout(false);
            this.PnlLeft.PerformLayout();
            this.PnlTop.ResumeLayout(false);
            this.PnlTop.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Panel PnlMain;
        private System.Windows.Forms.Panel PnlTop;
        private System.Windows.Forms.Panel PnlBottom;
        private System.Windows.Forms.Panel PnlRight;
        private System.Windows.Forms.Panel PnlLeft;
        private System.Windows.Forms.TreeView TreeIndex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox RtbMain;
    }
}

