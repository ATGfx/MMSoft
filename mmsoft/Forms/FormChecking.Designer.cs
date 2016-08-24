namespace MMSoft
{
    partial class FormChecking
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChecking));
         this.StatusStripFormChecking = new System.Windows.Forms.StatusStrip();
         this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
         this.LblConnectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
         this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
         this.LblUsername = new System.Windows.Forms.ToolStripStatusLabel();
         this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
         this.splitContainer1 = new System.Windows.Forms.SplitContainer();
         this.FormCheckingToolStrip = new System.Windows.Forms.ToolStrip();
         this.ToolStripBtnAddChecking = new System.Windows.Forms.ToolStripButton();
         this.ToolStripBtnCloseJob = new System.Windows.Forms.ToolStripButton();
         this.ToolStripBtnAll = new System.Windows.Forms.ToolStripButton();
         this.DbListViewComJobs = new MMSoft.DBListView();
         this.DayCheckingViewerCtrl = new MMSoft.DayCheckingViewer();
         this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
         this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.PrefToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.DecoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.QuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.JobsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.ResetFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.WhatAboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.FormDragBar = new MMSoft.UsrCtrl.FormDragBar();
         this.StatusStripFormChecking.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         this.FormCheckingToolStrip.SuspendLayout();
         this.MainMenuStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // StatusStripFormChecking
         // 
         this.StatusStripFormChecking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
         this.StatusStripFormChecking.ImageScalingSize = new System.Drawing.Size(24, 24);
         this.StatusStripFormChecking.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.LblConnectionStatus,
            this.toolStripStatusLabel2,
            this.LblUsername});
         this.StatusStripFormChecking.Location = new System.Drawing.Point(2, 588);
         this.StatusStripFormChecking.Name = "StatusStripFormChecking";
         this.StatusStripFormChecking.Size = new System.Drawing.Size(1137, 29);
         this.StatusStripFormChecking.TabIndex = 0;
         this.StatusStripFormChecking.Text = "statusStrip1";
         // 
         // toolStripStatusLabel1
         // 
         this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripStatusLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel1.Image")));
         this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
         this.toolStripStatusLabel1.Size = new System.Drawing.Size(24, 24);
         this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
         // 
         // LblConnectionStatus
         // 
         this.LblConnectionStatus.Name = "LblConnectionStatus";
         this.LblConnectionStatus.Size = new System.Drawing.Size(137, 24);
         this.LblConnectionStatus.Text = "StatusStripLblConnected";
         // 
         // toolStripStatusLabel2
         // 
         this.toolStripStatusLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripStatusLabel2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusLabel2.Image")));
         this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
         this.toolStripStatusLabel2.Size = new System.Drawing.Size(24, 24);
         this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
         // 
         // LblUsername
         // 
         this.LblUsername.Name = "LblUsername";
         this.LblUsername.Size = new System.Drawing.Size(102, 24);
         this.LblUsername.Text = "StatusStripLblUser";
         // 
         // splitContainer1
         // 
         this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
         this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer1.Location = new System.Drawing.Point(2, 58);
         this.splitContainer1.Name = "splitContainer1";
         this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // splitContainer1.Panel1
         // 
         this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Black;
         this.splitContainer1.Panel1.Controls.Add(this.FormCheckingToolStrip);
         this.splitContainer1.Panel1.Controls.Add(this.DbListViewComJobs);
         this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(3);
         // 
         // splitContainer1.Panel2
         // 
         this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
         this.splitContainer1.Panel2.Controls.Add(this.DayCheckingViewerCtrl);
         this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(3);
         this.splitContainer1.Size = new System.Drawing.Size(1137, 530);
         this.splitContainer1.SplitterDistance = 189;
         this.splitContainer1.TabIndex = 9;
         // 
         // FormCheckingToolStrip
         // 
         this.FormCheckingToolStrip.AutoSize = false;
         this.FormCheckingToolStrip.BackColor = System.Drawing.SystemColors.ActiveBorder;
         this.FormCheckingToolStrip.Dock = System.Windows.Forms.DockStyle.None;
         this.FormCheckingToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
         this.FormCheckingToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripBtnAddChecking,
            this.ToolStripBtnCloseJob,
            this.ToolStripBtnAll});
         this.FormCheckingToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
         this.FormCheckingToolStrip.Location = new System.Drawing.Point(233, 75);
         this.FormCheckingToolStrip.Name = "FormCheckingToolStrip";
         this.FormCheckingToolStrip.Size = new System.Drawing.Size(522, 43);
         this.FormCheckingToolStrip.TabIndex = 10;
         this.FormCheckingToolStrip.Text = "toolStrip1";
         // 
         // ToolStripBtnAddChecking
         // 
         this.ToolStripBtnAddChecking.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnAddChecking.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnAddChecking.Image")));
         this.ToolStripBtnAddChecking.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnAddChecking.Name = "ToolStripBtnAddChecking";
         this.ToolStripBtnAddChecking.Size = new System.Drawing.Size(36, 36);
         this.ToolStripBtnAddChecking.Text = "Ajouter pointage";
         this.ToolStripBtnAddChecking.Click += new System.EventHandler(this.ToolStripBtnAddChecking_Click);
         // 
         // ToolStripBtnCloseJob
         // 
         this.ToolStripBtnCloseJob.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnCloseJob.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnCloseJob.Image")));
         this.ToolStripBtnCloseJob.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnCloseJob.Name = "ToolStripBtnCloseJob";
         this.ToolStripBtnCloseJob.Size = new System.Drawing.Size(36, 36);
         this.ToolStripBtnCloseJob.Text = "Clôturer job";
         this.ToolStripBtnCloseJob.Click += new System.EventHandler(this.ToolStripBtnCloseJob_Click);
         // 
         // ToolStripBtnAll
         // 
         this.ToolStripBtnAll.CheckOnClick = true;
         this.ToolStripBtnAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnAll.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnAll.Image")));
         this.ToolStripBtnAll.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnAll.Name = "ToolStripBtnAll";
         this.ToolStripBtnAll.Size = new System.Drawing.Size(36, 36);
         this.ToolStripBtnAll.Text = "Complet";
         this.ToolStripBtnAll.Click += new System.EventHandler(this.ToolStripBtnAll_Click);
         // 
         // DbListViewComJobs
         // 
         this.DbListViewComJobs.AllowMultipleSelecion = false;
         this.DbListViewComJobs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
         this.DbListViewComJobs.Dock = System.Windows.Forms.DockStyle.Fill;
         this.DbListViewComJobs.ListTitle = "List";
         this.DbListViewComJobs.Location = new System.Drawing.Point(3, 3);
         this.DbListViewComJobs.Margin = new System.Windows.Forms.Padding(0);
         this.DbListViewComJobs.Name = "DbListViewComJobs";
         this.DbListViewComJobs.Size = new System.Drawing.Size(1129, 181);
         this.DbListViewComJobs.TabIndex = 2;
         // 
         // DayCheckingViewerCtrl
         // 
         this.DayCheckingViewerCtrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
         this.DayCheckingViewerCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
         this.DayCheckingViewerCtrl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
         this.DayCheckingViewerCtrl.Location = new System.Drawing.Point(3, 3);
         this.DayCheckingViewerCtrl.Name = "DayCheckingViewerCtrl";
         this.DayCheckingViewerCtrl.Size = new System.Drawing.Size(1129, 329);
         this.DayCheckingViewerCtrl.TabIndex = 0;
         // 
         // MainMenuStrip
         // 
         this.MainMenuStrip.BackColor = System.Drawing.SystemColors.ControlDark;
         this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.JobsToolStripMenuItem,
            this.HelpToolStripMenuItem});
         this.MainMenuStrip.Location = new System.Drawing.Point(2, 34);
         this.MainMenuStrip.Name = "MainMenuStrip";
         this.MainMenuStrip.Size = new System.Drawing.Size(1137, 24);
         this.MainMenuStrip.TabIndex = 10;
         this.MainMenuStrip.Text = "menuStrip1";
         // 
         // FileToolStripMenuItem
         // 
         this.FileToolStripMenuItem.BackColor = System.Drawing.Color.DarkRed;
         this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PrefToolStripMenuItem,
            this.DecoToolStripMenuItem,
            this.QuitToolStripMenuItem});
         this.FileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
         this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
         this.FileToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
         this.FileToolStripMenuItem.Text = "FICHIER";
         // 
         // PrefToolStripMenuItem
         // 
         this.PrefToolStripMenuItem.Name = "PrefToolStripMenuItem";
         this.PrefToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
         this.PrefToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
         this.PrefToolStripMenuItem.Text = "Préférences";
         this.PrefToolStripMenuItem.Click += new System.EventHandler(this.PrefToolStripMenuItem_Click);
         // 
         // DecoToolStripMenuItem
         // 
         this.DecoToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
         this.DecoToolStripMenuItem.Name = "DecoToolStripMenuItem";
         this.DecoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
         this.DecoToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
         this.DecoToolStripMenuItem.Text = "Déconnexion";
         this.DecoToolStripMenuItem.Click += new System.EventHandler(this.DecoToolStripMenuItem_Click);
         // 
         // QuitToolStripMenuItem
         // 
         this.QuitToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
         this.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem";
         this.QuitToolStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
         this.QuitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
         this.QuitToolStripMenuItem.Size = new System.Drawing.Size(185, 20);
         this.QuitToolStripMenuItem.Text = "Quitter";
         this.QuitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItem_Click);
         // 
         // JobsToolStripMenuItem
         // 
         this.JobsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ResetFilterToolStripMenuItem});
         this.JobsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
         this.JobsToolStripMenuItem.Name = "JobsToolStripMenuItem";
         this.JobsToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
         this.JobsToolStripMenuItem.Text = "JOBS";
         // 
         // ResetFilterToolStripMenuItem
         // 
         this.ResetFilterToolStripMenuItem.Name = "ResetFilterToolStripMenuItem";
         this.ResetFilterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
         this.ResetFilterToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
         this.ResetFilterToolStripMenuItem.Text = "Réinitialiser filtre";
         this.ResetFilterToolStripMenuItem.Click += new System.EventHandler(this.ResetFilterToolStripMenuItem_Click);
         // 
         // HelpToolStripMenuItem
         // 
         this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WhatAboutToolStripMenuItem});
         this.HelpToolStripMenuItem.ForeColor = System.Drawing.Color.White;
         this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
         this.HelpToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
         this.HelpToolStripMenuItem.Text = "HELP";
         // 
         // WhatAboutToolStripMenuItem
         // 
         this.WhatAboutToolStripMenuItem.Name = "WhatAboutToolStripMenuItem";
         this.WhatAboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F11;
         this.WhatAboutToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
         this.WhatAboutToolStripMenuItem.Text = "A propos";
         this.WhatAboutToolStripMenuItem.Click += new System.EventHandler(this.WhatAboutToolStripMenuItem_Click);
         // 
         // FormDragBar
         // 
         this.FormDragBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
         this.FormDragBar.Dock = System.Windows.Forms.DockStyle.Top;
         this.FormDragBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
         this.FormDragBar.Location = new System.Drawing.Point(2, 2);
         this.FormDragBar.MaximumSize = new System.Drawing.Size(1920, 1040);
         this.FormDragBar.Name = "FormDragBar";
         this.FormDragBar.Size = new System.Drawing.Size(1137, 32);
         this.FormDragBar.TabIndex = 7;
         // 
         // FormChecking
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         this.ClientSize = new System.Drawing.Size(1141, 619);
         this.Controls.Add(this.splitContainer1);
         this.Controls.Add(this.MainMenuStrip);
         this.Controls.Add(this.FormDragBar);
         this.Controls.Add(this.StatusStripFormChecking);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "FormChecking";
         this.Padding = new System.Windows.Forms.Padding(2);
         this.Text = "MMSoft - Pointages";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormChecking_FormClosing);
         this.Load += new System.EventHandler(this.FormChecking_Load);
         this.StatusStripFormChecking.ResumeLayout(false);
         this.StatusStripFormChecking.PerformLayout();
         this.splitContainer1.Panel1.ResumeLayout(false);
         this.splitContainer1.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
         this.splitContainer1.ResumeLayout(false);
         this.FormCheckingToolStrip.ResumeLayout(false);
         this.FormCheckingToolStrip.PerformLayout();
         this.MainMenuStrip.ResumeLayout(false);
         this.MainMenuStrip.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip StatusStripFormChecking;
        private System.Windows.Forms.ToolStripStatusLabel LblUsername;
        private System.Windows.Forms.ToolStripStatusLabel LblConnectionStatus;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private UsrCtrl.FormDragBar FormDragBar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DecoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QuitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem JobsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ResetFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WhatAboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PrefToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private DayCheckingViewer DayCheckingViewerCtrl;
        private DBListView DbListViewComJobs;
        private System.Windows.Forms.ToolStrip FormCheckingToolStrip;
        private System.Windows.Forms.ToolStripButton ToolStripBtnAddChecking;
        private System.Windows.Forms.ToolStripButton ToolStripBtnCloseJob;
        private System.Windows.Forms.ToolStripButton ToolStripBtnAll;
    }
}