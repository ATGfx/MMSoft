namespace MMSoft
{
   partial class FormManager
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
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormManager));
         this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
         this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.PrefToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.DecoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.QuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.WhatAboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.ModulesToolStrip = new System.Windows.Forms.ToolStrip();
         this.ToolStripBtnHome = new System.Windows.Forms.ToolStripButton();
         this.ToolStripBtnClient = new System.Windows.Forms.ToolStripButton();
         this.ToolStripBtnProvider = new System.Windows.Forms.ToolStripButton();
         this.ToolStripBtnMembers = new System.Windows.Forms.ToolStripButton();
         this.ToolStripBtnJobs = new System.Windows.Forms.ToolStripButton();
         this.ToolStripBtnChecking = new System.Windows.Forms.ToolStripButton();
         this.ToolStripBtnJobStates = new System.Windows.Forms.ToolStripButton();
         this.ToolStripBtnJobsCorrection = new System.Windows.Forms.ToolStripButton();
         this.ToolStripBtnStats = new System.Windows.Forms.ToolStripButton();
         this.ToolStripBtnHalls = new System.Windows.Forms.ToolStripButton();
         this.ModuleContainerPanel = new System.Windows.Forms.Panel();
         this.StatusStripFormChecking = new System.Windows.Forms.StatusStrip();
         this.LblDBImg = new System.Windows.Forms.ToolStripStatusLabel();
         this.LblConnectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
         this.LblUserImg = new System.Windows.Forms.ToolStripStatusLabel();
         this.LblUsername = new System.Windows.Forms.ToolStripStatusLabel();
         this.HomeImgList = new System.Windows.Forms.ImageList(this.components);
         this.FormDragBar = new MMSoft.UsrCtrl.FormDragBar();
         this.MainMenuStrip.SuspendLayout();
         this.ModulesToolStrip.SuspendLayout();
         this.StatusStripFormChecking.SuspendLayout();
         this.SuspendLayout();
         // 
         // MainMenuStrip
         // 
         this.MainMenuStrip.BackColor = System.Drawing.SystemColors.ControlDark;
         this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.HelpToolStripMenuItem});
         this.MainMenuStrip.Location = new System.Drawing.Point(1, 33);
         this.MainMenuStrip.Name = "MainMenuStrip";
         this.MainMenuStrip.Size = new System.Drawing.Size(1028, 24);
         this.MainMenuStrip.TabIndex = 11;
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
         // ModulesToolStrip
         // 
         this.ModulesToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this.ModulesToolStrip.ImageScalingSize = new System.Drawing.Size(72, 72);
         this.ModulesToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripBtnHome,
            this.ToolStripBtnClient,
            this.ToolStripBtnProvider,
            this.ToolStripBtnMembers,
            this.ToolStripBtnJobs,
            this.ToolStripBtnChecking,
            this.ToolStripBtnJobStates,
            this.ToolStripBtnJobsCorrection,
            this.ToolStripBtnStats,
            this.ToolStripBtnHalls});
         this.ModulesToolStrip.Location = new System.Drawing.Point(1, 57);
         this.ModulesToolStrip.Name = "ModulesToolStrip";
         this.ModulesToolStrip.Size = new System.Drawing.Size(1028, 79);
         this.ModulesToolStrip.TabIndex = 12;
         // 
         // ToolStripBtnHome
         // 
         this.ToolStripBtnHome.CheckOnClick = true;
         this.ToolStripBtnHome.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnHome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.ToolStripBtnHome.ForeColor = System.Drawing.Color.Black;
         this.ToolStripBtnHome.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnHome.Image")));
         this.ToolStripBtnHome.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnHome.Name = "ToolStripBtnHome";
         this.ToolStripBtnHome.Size = new System.Drawing.Size(76, 76);
         this.ToolStripBtnHome.Text = "Acceuil";
         this.ToolStripBtnHome.Click += new System.EventHandler(this.ModuleChanged);
         // 
         // ToolStripBtnClient
         // 
         this.ToolStripBtnClient.CheckOnClick = true;
         this.ToolStripBtnClient.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnClient.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.ToolStripBtnClient.ForeColor = System.Drawing.Color.Black;
         this.ToolStripBtnClient.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnClient.Image")));
         this.ToolStripBtnClient.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnClient.Name = "ToolStripBtnClient";
         this.ToolStripBtnClient.Size = new System.Drawing.Size(76, 76);
         this.ToolStripBtnClient.Text = "Clients";
         this.ToolStripBtnClient.Click += new System.EventHandler(this.ModuleChanged);
         // 
         // ToolStripBtnProvider
         // 
         this.ToolStripBtnProvider.CheckOnClick = true;
         this.ToolStripBtnProvider.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnProvider.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.ToolStripBtnProvider.ForeColor = System.Drawing.Color.Black;
         this.ToolStripBtnProvider.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnProvider.Image")));
         this.ToolStripBtnProvider.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnProvider.Name = "ToolStripBtnProvider";
         this.ToolStripBtnProvider.Size = new System.Drawing.Size(76, 76);
         this.ToolStripBtnProvider.Text = "Fournisseurs";
         this.ToolStripBtnProvider.Click += new System.EventHandler(this.ModuleChanged);
         // 
         // ToolStripBtnMembers
         // 
         this.ToolStripBtnMembers.CheckOnClick = true;
         this.ToolStripBtnMembers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnMembers.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.ToolStripBtnMembers.ForeColor = System.Drawing.Color.Black;
         this.ToolStripBtnMembers.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnMembers.Image")));
         this.ToolStripBtnMembers.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnMembers.Name = "ToolStripBtnMembers";
         this.ToolStripBtnMembers.Size = new System.Drawing.Size(76, 76);
         this.ToolStripBtnMembers.Text = "Personnel";
         this.ToolStripBtnMembers.Click += new System.EventHandler(this.ModuleChanged);
         // 
         // ToolStripBtnJobs
         // 
         this.ToolStripBtnJobs.CheckOnClick = true;
         this.ToolStripBtnJobs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnJobs.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.ToolStripBtnJobs.ForeColor = System.Drawing.Color.Black;
         this.ToolStripBtnJobs.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnJobs.Image")));
         this.ToolStripBtnJobs.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnJobs.Name = "ToolStripBtnJobs";
         this.ToolStripBtnJobs.Size = new System.Drawing.Size(76, 76);
         this.ToolStripBtnJobs.Text = "Commandes et jobs";
         this.ToolStripBtnJobs.Click += new System.EventHandler(this.ModuleChanged);
         // 
         // ToolStripBtnChecking
         // 
         this.ToolStripBtnChecking.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.ToolStripBtnChecking.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnChecking.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnChecking.Image")));
         this.ToolStripBtnChecking.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnChecking.Name = "ToolStripBtnChecking";
         this.ToolStripBtnChecking.Size = new System.Drawing.Size(76, 76);
         this.ToolStripBtnChecking.Text = "Pointages";
         this.ToolStripBtnChecking.Click += new System.EventHandler(this.ToolStripBtnChecking_Click);
         // 
         // ToolStripBtnJobStates
         // 
         this.ToolStripBtnJobStates.CheckOnClick = true;
         this.ToolStripBtnJobStates.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnJobStates.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.ToolStripBtnJobStates.ForeColor = System.Drawing.Color.Black;
         this.ToolStripBtnJobStates.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnJobStates.Image")));
         this.ToolStripBtnJobStates.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnJobStates.Name = "ToolStripBtnJobStates";
         this.ToolStripBtnJobStates.Size = new System.Drawing.Size(76, 76);
         this.ToolStripBtnJobStates.Text = "Cycle de vie des jobs";
         this.ToolStripBtnJobStates.Click += new System.EventHandler(this.ModuleChanged);
         // 
         // ToolStripBtnJobsCorrection
         // 
         this.ToolStripBtnJobsCorrection.CheckOnClick = true;
         this.ToolStripBtnJobsCorrection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnJobsCorrection.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnJobsCorrection.Image")));
         this.ToolStripBtnJobsCorrection.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnJobsCorrection.Name = "ToolStripBtnJobsCorrection";
         this.ToolStripBtnJobsCorrection.Size = new System.Drawing.Size(76, 76);
         this.ToolStripBtnJobsCorrection.Text = "En cours";
         this.ToolStripBtnJobsCorrection.Click += new System.EventHandler(this.ModuleChanged);
         // 
         // ToolStripBtnStats
         // 
         this.ToolStripBtnStats.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnStats.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnStats.Image")));
         this.ToolStripBtnStats.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnStats.Name = "ToolStripBtnStats";
         this.ToolStripBtnStats.Size = new System.Drawing.Size(76, 76);
         this.ToolStripBtnStats.Text = "Statistiques";
         this.ToolStripBtnStats.Click += new System.EventHandler(this.ModuleChanged);
         // 
         // ToolStripBtnHalls
         // 
         this.ToolStripBtnHalls.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnHalls.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnHalls.Image")));
         this.ToolStripBtnHalls.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnHalls.Name = "ToolStripBtnHalls";
         this.ToolStripBtnHalls.Size = new System.Drawing.Size(76, 76);
         this.ToolStripBtnHalls.Text = "ToolStripBtnHall";
         this.ToolStripBtnHalls.ToolTipText = "Halls et machines";
         this.ToolStripBtnHalls.Click += new System.EventHandler(this.ModuleChanged);
         // 
         // ModuleContainerPanel
         // 
         this.ModuleContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
         this.ModuleContainerPanel.Location = new System.Drawing.Point(1, 136);
         this.ModuleContainerPanel.Name = "ModuleContainerPanel";
         this.ModuleContainerPanel.Size = new System.Drawing.Size(1028, 299);
         this.ModuleContainerPanel.TabIndex = 13;
         // 
         // StatusStripFormChecking
         // 
         this.StatusStripFormChecking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
         this.StatusStripFormChecking.ImageScalingSize = new System.Drawing.Size(24, 24);
         this.StatusStripFormChecking.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LblDBImg,
            this.LblConnectionStatus,
            this.LblUserImg,
            this.LblUsername});
         this.StatusStripFormChecking.Location = new System.Drawing.Point(1, 435);
         this.StatusStripFormChecking.Name = "StatusStripFormChecking";
         this.StatusStripFormChecking.Size = new System.Drawing.Size(1028, 29);
         this.StatusStripFormChecking.TabIndex = 14;
         this.StatusStripFormChecking.Text = "Base de données";
         // 
         // LblDBImg
         // 
         this.LblDBImg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.LblDBImg.Image = ((System.Drawing.Image)(resources.GetObject("LblDBImg.Image")));
         this.LblDBImg.Name = "LblDBImg";
         this.LblDBImg.Size = new System.Drawing.Size(24, 24);
         this.LblDBImg.Text = "Base de données";
         // 
         // LblConnectionStatus
         // 
         this.LblConnectionStatus.Name = "LblConnectionStatus";
         this.LblConnectionStatus.Size = new System.Drawing.Size(137, 24);
         this.LblConnectionStatus.Text = "StatusStripLblConnected";
         // 
         // LblUserImg
         // 
         this.LblUserImg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.LblUserImg.Image = ((System.Drawing.Image)(resources.GetObject("LblUserImg.Image")));
         this.LblUserImg.Name = "LblUserImg";
         this.LblUserImg.Size = new System.Drawing.Size(24, 24);
         this.LblUserImg.Text = "Utilisateur";
         // 
         // LblUsername
         // 
         this.LblUsername.Name = "LblUsername";
         this.LblUsername.Size = new System.Drawing.Size(102, 24);
         this.LblUsername.Text = "StatusStripLblUser";
         // 
         // HomeImgList
         // 
         this.HomeImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
         this.HomeImgList.ImageSize = new System.Drawing.Size(76, 76);
         this.HomeImgList.TransparentColor = System.Drawing.Color.Transparent;
         // 
         // FormDragBar
         // 
         this.FormDragBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
         this.FormDragBar.Dock = System.Windows.Forms.DockStyle.Top;
         this.FormDragBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
         this.FormDragBar.Location = new System.Drawing.Point(1, 1);
         this.FormDragBar.Name = "FormDragBar";
         this.FormDragBar.Size = new System.Drawing.Size(1028, 32);
         this.FormDragBar.TabIndex = 0;
         // 
         // FormManager
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         this.ClientSize = new System.Drawing.Size(1030, 465);
         this.Controls.Add(this.ModuleContainerPanel);
         this.Controls.Add(this.StatusStripFormChecking);
         this.Controls.Add(this.ModulesToolStrip);
         this.Controls.Add(this.MainMenuStrip);
         this.Controls.Add(this.FormDragBar);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "FormManager";
         this.Padding = new System.Windows.Forms.Padding(1);
         this.Text = "FormManager";
         this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormManager_FormClosing);
         this.MainMenuStrip.ResumeLayout(false);
         this.MainMenuStrip.PerformLayout();
         this.ModulesToolStrip.ResumeLayout(false);
         this.ModulesToolStrip.PerformLayout();
         this.StatusStripFormChecking.ResumeLayout(false);
         this.StatusStripFormChecking.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private UsrCtrl.FormDragBar FormDragBar;
      private System.Windows.Forms.MenuStrip MainMenuStrip;
      private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem PrefToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem DecoToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem QuitToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem WhatAboutToolStripMenuItem;
      private System.Windows.Forms.ToolStrip ModulesToolStrip;
      private System.Windows.Forms.ToolStripButton ToolStripBtnClient;
      private System.Windows.Forms.ToolStripButton ToolStripBtnProvider;
      private System.Windows.Forms.ToolStripButton ToolStripBtnMembers;
      private System.Windows.Forms.ToolStripButton ToolStripBtnJobs;
      private System.Windows.Forms.Panel ModuleContainerPanel;
      private System.Windows.Forms.StatusStrip StatusStripFormChecking;
      private System.Windows.Forms.ToolStripStatusLabel LblUsername;
      private System.Windows.Forms.ToolStripStatusLabel LblConnectionStatus;
      private System.Windows.Forms.ToolStripButton ToolStripBtnChecking;
      private System.Windows.Forms.ToolStripStatusLabel LblDBImg;
      private System.Windows.Forms.ToolStripStatusLabel LblUserImg;
      private System.Windows.Forms.ToolStripButton ToolStripBtnHome;
      private System.Windows.Forms.ImageList HomeImgList;
      private System.Windows.Forms.ToolStripButton ToolStripBtnJobStates;
      private System.Windows.Forms.ToolStripButton ToolStripBtnJobsCorrection;
      private System.Windows.Forms.ToolStripButton ToolStripBtnStats;
      private System.Windows.Forms.ToolStripButton ToolStripBtnHalls;
   }
}