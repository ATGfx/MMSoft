namespace MMSoft
{
   partial class FormAskClient
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAskClient));
         this.panel1 = new System.Windows.Forms.Panel();
         this.ToolStripValidate = new System.Windows.Forms.ToolStrip();
         this.ToolStripButtonCancel = new System.Windows.Forms.ToolStripButton();
         this.ToolStripBtnValidate = new System.Windows.Forms.ToolStripButton();
         this.PanelInfo = new System.Windows.Forms.Panel();
         this.DBListViewClient = new MMSoft.DBListView();
         this.PanelUserPref = new System.Windows.Forms.Panel();
         this.panel1.SuspendLayout();
         this.ToolStripValidate.SuspendLayout();
         this.PanelInfo.SuspendLayout();
         this.PanelUserPref.SuspendLayout();
         this.SuspendLayout();
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.ToolStripValidate);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.panel1.Location = new System.Drawing.Point(0, 417);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(902, 40);
         this.panel1.TabIndex = 2;
         // 
         // ToolStripValidate
         // 
         this.ToolStripValidate.BackColor = System.Drawing.SystemColors.ActiveCaption;
         this.ToolStripValidate.Dock = System.Windows.Forms.DockStyle.Fill;
         this.ToolStripValidate.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this.ToolStripValidate.ImageScalingSize = new System.Drawing.Size(32, 32);
         this.ToolStripValidate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripButtonCancel,
            this.ToolStripBtnValidate});
         this.ToolStripValidate.Location = new System.Drawing.Point(0, 0);
         this.ToolStripValidate.Name = "ToolStripValidate";
         this.ToolStripValidate.Size = new System.Drawing.Size(902, 40);
         this.ToolStripValidate.TabIndex = 8;
         this.ToolStripValidate.Text = "toolStrip1";
         // 
         // ToolStripButtonCancel
         // 
         this.ToolStripButtonCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.ToolStripButtonCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripButtonCancel.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButtonCancel.Image")));
         this.ToolStripButtonCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripButtonCancel.Name = "ToolStripButtonCancel";
         this.ToolStripButtonCancel.Size = new System.Drawing.Size(36, 37);
         this.ToolStripButtonCancel.Text = "Annuler";
         this.ToolStripButtonCancel.Click += new System.EventHandler(this.ToolStripButtonCancel_Click);
         // 
         // ToolStripBtnValidate
         // 
         this.ToolStripBtnValidate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.ToolStripBtnValidate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnValidate.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnValidate.Image")));
         this.ToolStripBtnValidate.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnValidate.Name = "ToolStripBtnValidate";
         this.ToolStripBtnValidate.Size = new System.Drawing.Size(36, 37);
         this.ToolStripBtnValidate.Text = "Valider";
         this.ToolStripBtnValidate.Click += new System.EventHandler(this.ToolStripBtnValidate_Click);
         // 
         // PanelInfo
         // 
         this.PanelInfo.Controls.Add(this.DBListViewClient);
         this.PanelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
         this.PanelInfo.Location = new System.Drawing.Point(0, 0);
         this.PanelInfo.Name = "PanelInfo";
         this.PanelInfo.Size = new System.Drawing.Size(902, 417);
         this.PanelInfo.TabIndex = 4;
         // 
         // DBListViewClient
         // 
         this.DBListViewClient.AllowMultipleSelecion = false;
         this.DBListViewClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
         this.DBListViewClient.Dock = System.Windows.Forms.DockStyle.Fill;
         this.DBListViewClient.ListTitle = "List";
         this.DBListViewClient.Location = new System.Drawing.Point(0, 0);
         this.DBListViewClient.Margin = new System.Windows.Forms.Padding(0);
         this.DBListViewClient.Name = "DBListViewClient";
         this.DBListViewClient.Size = new System.Drawing.Size(902, 417);
         this.DBListViewClient.TabIndex = 0;
         // 
         // PanelUserPref
         // 
         this.PanelUserPref.BackColor = System.Drawing.SystemColors.ActiveCaption;
         this.PanelUserPref.Controls.Add(this.PanelInfo);
         this.PanelUserPref.Controls.Add(this.panel1);
         this.PanelUserPref.Dock = System.Windows.Forms.DockStyle.Fill;
         this.PanelUserPref.Location = new System.Drawing.Point(2, 2);
         this.PanelUserPref.Name = "PanelUserPref";
         this.PanelUserPref.Size = new System.Drawing.Size(902, 457);
         this.PanelUserPref.TabIndex = 2;
         // 
         // FormAskClient
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
         this.ClientSize = new System.Drawing.Size(906, 461);
         this.Controls.Add(this.PanelUserPref);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "FormAskClient";
         this.Padding = new System.Windows.Forms.Padding(2);
         this.Text = "FormAskClient";
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         this.ToolStripValidate.ResumeLayout(false);
         this.ToolStripValidate.PerformLayout();
         this.PanelInfo.ResumeLayout(false);
         this.PanelUserPref.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Panel PanelInfo;
      private System.Windows.Forms.Panel PanelUserPref;
      private System.Windows.Forms.ToolStrip ToolStripValidate;
      private System.Windows.Forms.ToolStripButton ToolStripButtonCancel;
      private System.Windows.Forms.ToolStripButton ToolStripBtnValidate;
      private DBListView DBListViewClient;
   }
}