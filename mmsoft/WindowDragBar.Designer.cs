namespace TestCustomFormStyleCSharp
{
   partial class WindowDragBar
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowDragBar));
         this.toolStrip1 = new System.Windows.Forms.ToolStrip();
         this.toolStripBtnDock = new System.Windows.Forms.ToolStripButton();
         this.toolStripBtnMaximize = new System.Windows.Forms.ToolStripButton();
         this.LblTitle = new System.Windows.Forms.Label();
         this.toolStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // toolStrip1
         // 
         this.toolStrip1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnDock,
            this.toolStripBtnMaximize});
         this.toolStrip1.Location = new System.Drawing.Point(0, 0);
         this.toolStrip1.Name = "toolStrip1";
         this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
         this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
         this.toolStrip1.Size = new System.Drawing.Size(500, 25);
         this.toolStrip1.TabIndex = 0;
         this.toolStrip1.Text = "toolStrip1";
         this.toolStrip1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.toolStrip1_MouseDoubleClick);
         this.toolStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStrip1_MouseDown);
         this.toolStrip1.MouseLeave += new System.EventHandler(this.toolStrip1_MouseLeave);
         this.toolStrip1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toolStrip1_MouseMove);
         this.toolStrip1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStrip1_MouseUp);
         // 
         // toolStripBtnDock
         // 
         this.toolStripBtnDock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripBtnDock.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnDock.Image")));
         this.toolStripBtnDock.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripBtnDock.Name = "toolStripBtnDock";
         this.toolStripBtnDock.Size = new System.Drawing.Size(23, 22);
         this.toolStripBtnDock.Text = "Dock Window";
         this.toolStripBtnDock.Click += new System.EventHandler(this.toolStripBtnDock_Click);
         // 
         // toolStripBtnMaximize
         // 
         this.toolStripBtnMaximize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripBtnMaximize.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnMaximize.Image")));
         this.toolStripBtnMaximize.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripBtnMaximize.Name = "toolStripBtnMaximize";
         this.toolStripBtnMaximize.Size = new System.Drawing.Size(23, 22);
         this.toolStripBtnMaximize.Text = "Maximize";
         this.toolStripBtnMaximize.Click += new System.EventHandler(this.toolStripBtnMaximize_Click);
         // 
         // LblTitle
         // 
         this.LblTitle.AutoSize = true;
         this.LblTitle.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.LblTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.LblTitle.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
         this.LblTitle.Location = new System.Drawing.Point(3, 3);
         this.LblTitle.Name = "LblTitle";
         this.LblTitle.Size = new System.Drawing.Size(44, 17);
         this.LblTitle.TabIndex = 1;
         this.LblTitle.Text = "Frame";
         // 
         // WindowDragBar
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.Controls.Add(this.LblTitle);
         this.Controls.Add(this.toolStrip1);
         this.Name = "WindowDragBar";
         this.Size = new System.Drawing.Size(500, 25);
         this.toolStrip1.ResumeLayout(false);
         this.toolStrip1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ToolStrip toolStrip1;
      private System.Windows.Forms.ToolStripButton toolStripBtnDock;
      private System.Windows.Forms.ToolStripButton toolStripBtnMaximize;
      private System.Windows.Forms.Label LblTitle;
   }
}
