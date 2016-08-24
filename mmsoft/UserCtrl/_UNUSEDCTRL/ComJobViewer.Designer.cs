namespace MMSoft
{
    partial class ComJobViewer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComJobViewer));
         this.FilterPanel = new System.Windows.Forms.Panel();
         this.BtnClearFilter = new System.Windows.Forms.Button();
         this.TxtNumPlan = new System.Windows.Forms.TextBox();
         this.TxtDelaiPromis = new System.Windows.Forms.TextBox();
         this.TxtDateEncod = new System.Windows.Forms.TextBox();
         this.TxtStatut = new System.Windows.Forms.TextBox();
         this.TxtJobNumOrdre = new System.Windows.Forms.TextBox();
         this.TxtJobLib = new System.Windows.Forms.TextBox();
         this.TxtQte = new System.Windows.Forms.TextBox();
         this.TxtLibCmd = new System.Windows.Forms.TextBox();
         this.TxtNumCmdClient = new System.Windows.Forms.TextBox();
         this.TxtNomClient = new System.Windows.Forms.TextBox();
         this.TxtNumCmdInt = new System.Windows.Forms.TextBox();
         this.ListViewPanel = new System.Windows.Forms.Panel();
         this.FilterPanelPadding = new System.Windows.Forms.Panel();
         this.CustomComJobListView = new MMSoft.CustomListView();
         this.FilterPanel.SuspendLayout();
         this.ListViewPanel.SuspendLayout();
         this.FilterPanelPadding.SuspendLayout();
         this.SuspendLayout();
         // 
         // FilterPanel
         // 
         this.FilterPanel.Controls.Add(this.BtnClearFilter);
         this.FilterPanel.Controls.Add(this.TxtNumPlan);
         this.FilterPanel.Controls.Add(this.TxtDelaiPromis);
         this.FilterPanel.Controls.Add(this.TxtDateEncod);
         this.FilterPanel.Controls.Add(this.TxtStatut);
         this.FilterPanel.Controls.Add(this.TxtJobNumOrdre);
         this.FilterPanel.Controls.Add(this.TxtJobLib);
         this.FilterPanel.Controls.Add(this.TxtQte);
         this.FilterPanel.Controls.Add(this.TxtLibCmd);
         this.FilterPanel.Controls.Add(this.TxtNumCmdClient);
         this.FilterPanel.Controls.Add(this.TxtNomClient);
         this.FilterPanel.Controls.Add(this.TxtNumCmdInt);
         this.FilterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
         this.FilterPanel.Location = new System.Drawing.Point(0, 1);
         this.FilterPanel.Margin = new System.Windows.Forms.Padding(0);
         this.FilterPanel.Name = "FilterPanel";
         this.FilterPanel.Size = new System.Drawing.Size(1624, 22);
         this.FilterPanel.TabIndex = 0;
         // 
         // BtnClearFilter
         // 
         this.BtnClearFilter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnClearFilter.BackgroundImage")));
         this.BtnClearFilter.Location = new System.Drawing.Point(1566, 3);
         this.BtnClearFilter.Name = "BtnClearFilter";
         this.BtnClearFilter.Size = new System.Drawing.Size(41, 23);
         this.BtnClearFilter.TabIndex = 11;
         this.BtnClearFilter.Text = "Clear";
         this.BtnClearFilter.UseVisualStyleBackColor = true;
         this.BtnClearFilter.Click += new System.EventHandler(this.BtnClearFilter_Click);
         // 
         // TxtNumPlan
         // 
         this.TxtNumPlan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.TxtNumPlan.Location = new System.Drawing.Point(1163, 3);
         this.TxtNumPlan.Name = "TxtNumPlan";
         this.TxtNumPlan.Size = new System.Drawing.Size(100, 20);
         this.TxtNumPlan.TabIndex = 10;
         // 
         // TxtDelaiPromis
         // 
         this.TxtDelaiPromis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.TxtDelaiPromis.Location = new System.Drawing.Point(1262, 3);
         this.TxtDelaiPromis.Name = "TxtDelaiPromis";
         this.TxtDelaiPromis.Size = new System.Drawing.Size(100, 20);
         this.TxtDelaiPromis.TabIndex = 9;
         // 
         // TxtDateEncod
         // 
         this.TxtDateEncod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.TxtDateEncod.Location = new System.Drawing.Point(1460, 3);
         this.TxtDateEncod.Name = "TxtDateEncod";
         this.TxtDateEncod.Size = new System.Drawing.Size(100, 20);
         this.TxtDateEncod.TabIndex = 8;
         // 
         // TxtStatut
         // 
         this.TxtStatut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.TxtStatut.Location = new System.Drawing.Point(1361, 3);
         this.TxtStatut.Name = "TxtStatut";
         this.TxtStatut.Size = new System.Drawing.Size(100, 20);
         this.TxtStatut.TabIndex = 7;
         // 
         // TxtJobNumOrdre
         // 
         this.TxtJobNumOrdre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.TxtJobNumOrdre.Location = new System.Drawing.Point(466, 3);
         this.TxtJobNumOrdre.Name = "TxtJobNumOrdre";
         this.TxtJobNumOrdre.Size = new System.Drawing.Size(50, 20);
         this.TxtJobNumOrdre.TabIndex = 6;
         // 
         // TxtJobLib
         // 
         this.TxtJobLib.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.TxtJobLib.Location = new System.Drawing.Point(515, 3);
         this.TxtJobLib.Name = "TxtJobLib";
         this.TxtJobLib.Size = new System.Drawing.Size(600, 20);
         this.TxtJobLib.TabIndex = 5;
         // 
         // TxtQte
         // 
         this.TxtQte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.TxtQte.Location = new System.Drawing.Point(1114, 3);
         this.TxtQte.Name = "TxtQte";
         this.TxtQte.Size = new System.Drawing.Size(50, 20);
         this.TxtQte.TabIndex = 4;
         // 
         // TxtLibCmd
         // 
         this.TxtLibCmd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.TxtLibCmd.Location = new System.Drawing.Point(99, 3);
         this.TxtLibCmd.Name = "TxtLibCmd";
         this.TxtLibCmd.Size = new System.Drawing.Size(100, 20);
         this.TxtLibCmd.TabIndex = 3;
         // 
         // TxtNumCmdClient
         // 
         this.TxtNumCmdClient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.TxtNumCmdClient.Location = new System.Drawing.Point(198, 3);
         this.TxtNumCmdClient.Name = "TxtNumCmdClient";
         this.TxtNumCmdClient.Size = new System.Drawing.Size(150, 20);
         this.TxtNumCmdClient.TabIndex = 2;
         // 
         // TxtNomClient
         // 
         this.TxtNomClient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.TxtNomClient.Location = new System.Drawing.Point(347, 3);
         this.TxtNomClient.Name = "TxtNomClient";
         this.TxtNomClient.Size = new System.Drawing.Size(120, 20);
         this.TxtNomClient.TabIndex = 1;
         // 
         // TxtNumCmdInt
         // 
         this.TxtNumCmdInt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.TxtNumCmdInt.Location = new System.Drawing.Point(0, 2);
         this.TxtNumCmdInt.Name = "TxtNumCmdInt";
         this.TxtNumCmdInt.Size = new System.Drawing.Size(100, 20);
         this.TxtNumCmdInt.TabIndex = 0;
         // 
         // ListViewPanel
         // 
         this.ListViewPanel.Controls.Add(this.CustomComJobListView);
         this.ListViewPanel.Controls.Add(this.FilterPanelPadding);
         this.ListViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
         this.ListViewPanel.Location = new System.Drawing.Point(0, 0);
         this.ListViewPanel.Name = "ListViewPanel";
         this.ListViewPanel.Size = new System.Drawing.Size(1624, 327);
         this.ListViewPanel.TabIndex = 1;
         // 
         // FilterPanelPadding
         // 
         this.FilterPanelPadding.Controls.Add(this.FilterPanel);
         this.FilterPanelPadding.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.FilterPanelPadding.Location = new System.Drawing.Point(0, 304);
         this.FilterPanelPadding.Name = "FilterPanelPadding";
         this.FilterPanelPadding.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
         this.FilterPanelPadding.Size = new System.Drawing.Size(1624, 23);
         this.FilterPanelPadding.TabIndex = 2;
         // 
         // CustomComJobListView
         // 
         this.CustomComJobListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.CustomComJobListView.Dock = System.Windows.Forms.DockStyle.Fill;
         this.CustomComJobListView.ForeColor = System.Drawing.Color.White;
         this.CustomComJobListView.FullRowSelect = true;
         this.CustomComJobListView.Location = new System.Drawing.Point(0, 0);
         this.CustomComJobListView.Name = "CustomComJobListView";
         this.CustomComJobListView.Size = new System.Drawing.Size(1624, 304);
         this.CustomComJobListView.TabIndex = 1;
         this.CustomComJobListView.UseCompatibleStateImageBehavior = false;
         this.CustomComJobListView.View = System.Windows.Forms.View.Details;
         this.CustomComJobListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.CustomComJobListView_ColumnClick);
         this.CustomComJobListView.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.CustomComJobListView_ColumnWidthChanged);
         this.CustomComJobListView.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.CustomComJobListView_ColumnWidthChanging);
         this.CustomComJobListView.SelectedIndexChanged += new System.EventHandler(this.CustomComJobListView_SelectedIndexChanged);
         this.CustomComJobListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CustomComJobListView_MouseDoubleClick);
         // 
         // ComJobViewer
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.ListViewPanel);
         this.Name = "ComJobViewer";
         this.Size = new System.Drawing.Size(1624, 327);
         this.FilterPanel.ResumeLayout(false);
         this.FilterPanel.PerformLayout();
         this.ListViewPanel.ResumeLayout(false);
         this.FilterPanelPadding.ResumeLayout(false);
         this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel FilterPanel;
        private System.Windows.Forms.Panel ListViewPanel;
        private System.Windows.Forms.TextBox TxtNumCmdInt;
        private System.Windows.Forms.TextBox TxtNumPlan;
        private System.Windows.Forms.TextBox TxtDelaiPromis;
        private System.Windows.Forms.TextBox TxtDateEncod;
        private System.Windows.Forms.TextBox TxtStatut;
        private System.Windows.Forms.TextBox TxtJobNumOrdre;
        private System.Windows.Forms.TextBox TxtJobLib;
        private System.Windows.Forms.TextBox TxtQte;
        private System.Windows.Forms.TextBox TxtLibCmd;
        private System.Windows.Forms.TextBox TxtNumCmdClient;
        private System.Windows.Forms.TextBox TxtNomClient;
        private System.Windows.Forms.Button BtnClearFilter;
        private CustomListView CustomComJobListView;
        private System.Windows.Forms.Panel FilterPanelPadding;
    }
}
