namespace MMSoft
{
   partial class FormDocumentViewer
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDocumentViewer));
         this.PanelDocumentViewerHeader = new System.Windows.Forms.Panel();
         this.ToolStripTools = new System.Windows.Forms.ToolStrip();
         this.ToolStripBtnSaveAs = new System.Windows.Forms.ToolStripButton();
         this.ToolStripBtnPrint = new System.Windows.Forms.ToolStripButton();
         this.SaveDlg = new System.Windows.Forms.SaveFileDialog();
         this.WebBrowser = new System.Windows.Forms.WebBrowser();
         this.PanelDocumentViewerHeader.SuspendLayout();
         this.ToolStripTools.SuspendLayout();
         this.SuspendLayout();
         // 
         // PanelDocumentViewerHeader
         // 
         this.PanelDocumentViewerHeader.Controls.Add(this.ToolStripTools);
         this.PanelDocumentViewerHeader.Dock = System.Windows.Forms.DockStyle.Top;
         this.PanelDocumentViewerHeader.Location = new System.Drawing.Point(0, 0);
         this.PanelDocumentViewerHeader.Name = "PanelDocumentViewerHeader";
         this.PanelDocumentViewerHeader.Size = new System.Drawing.Size(712, 43);
         this.PanelDocumentViewerHeader.TabIndex = 1;
         // 
         // ToolStripTools
         // 
         this.ToolStripTools.Dock = System.Windows.Forms.DockStyle.Fill;
         this.ToolStripTools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this.ToolStripTools.ImageScalingSize = new System.Drawing.Size(32, 32);
         this.ToolStripTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripBtnSaveAs,
            this.ToolStripBtnPrint});
         this.ToolStripTools.Location = new System.Drawing.Point(0, 0);
         this.ToolStripTools.Name = "ToolStripTools";
         this.ToolStripTools.Size = new System.Drawing.Size(712, 43);
         this.ToolStripTools.TabIndex = 0;
         this.ToolStripTools.Text = "toolStrip1";
         // 
         // ToolStripBtnSaveAs
         // 
         this.ToolStripBtnSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnSaveAs.Image")));
         this.ToolStripBtnSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnSaveAs.Name = "ToolStripBtnSaveAs";
         this.ToolStripBtnSaveAs.Size = new System.Drawing.Size(36, 40);
         this.ToolStripBtnSaveAs.Text = "toolStripButton1";
         this.ToolStripBtnSaveAs.Click += new System.EventHandler(this.ToolStripBtnSaveAs_Click);
         // 
         // ToolStripBtnPrint
         // 
         this.ToolStripBtnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnPrint.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnPrint.Image")));
         this.ToolStripBtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnPrint.Name = "ToolStripBtnPrint";
         this.ToolStripBtnPrint.Size = new System.Drawing.Size(36, 40);
         this.ToolStripBtnPrint.Text = "toolStripButton2";
         this.ToolStripBtnPrint.Click += new System.EventHandler(this.ToolStripBtnPrint_Click);
         // 
         // SaveDlg
         // 
         this.SaveDlg.FileName = "MMSoft_Rapport.docx";
         // 
         // WebBrowser
         // 
         this.WebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
         this.WebBrowser.Location = new System.Drawing.Point(0, 43);
         this.WebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
         this.WebBrowser.Name = "WebBrowser";
         this.WebBrowser.Size = new System.Drawing.Size(712, 471);
         this.WebBrowser.TabIndex = 3;
         this.WebBrowser.Url = new System.Uri("", System.UriKind.Relative);
         // 
         // FormDocumentViewer
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(712, 514);
         this.Controls.Add(this.WebBrowser);
         this.Controls.Add(this.PanelDocumentViewerHeader);
         this.Name = "FormDocumentViewer";
         this.Text = "JobInfoForm";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDocumentViewer_FormClosing);
         this.PanelDocumentViewerHeader.ResumeLayout(false);
         this.PanelDocumentViewerHeader.PerformLayout();
         this.ToolStripTools.ResumeLayout(false);
         this.ToolStripTools.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel PanelDocumentViewerHeader;
      private System.Windows.Forms.ToolStrip ToolStripTools;
      private System.Windows.Forms.ToolStripButton ToolStripBtnSaveAs;
      private System.Windows.Forms.ToolStripButton ToolStripBtnPrint;
      private System.Windows.Forms.SaveFileDialog SaveDlg;
      private System.Windows.Forms.WebBrowser WebBrowser;

   }
}