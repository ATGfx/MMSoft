namespace MMSoft.UsrCtrl
{
   partial class FormDragBar
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDragBar));
         this.toolStrip1 = new System.Windows.Forms.ToolStrip();
         this.toolStripButtonExit = new System.Windows.Forms.ToolStripButton();
         this.toolStripButtonMaximize = new System.Windows.Forms.ToolStripButton();
         this.toolStripButtonMinimize = new System.Windows.Forms.ToolStripButton();
         this.LblAppLogo = new System.Windows.Forms.Label();
         this.LblAppTitle = new System.Windows.Forms.Label();
         this.toolStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // toolStrip1
         // 
         this.toolStrip1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Right;
         this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
         this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonExit,
            this.toolStripButtonMaximize,
            this.toolStripButtonMinimize});
         this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
         this.toolStrip1.Location = new System.Drawing.Point(587, 0);
         this.toolStrip1.Name = "toolStrip1";
         this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
         this.toolStrip1.Size = new System.Drawing.Size(85, 32);
         this.toolStrip1.TabIndex = 0;
         this.toolStrip1.Text = "toolStrip1";
         // 
         // toolStripButtonExit
         // 
         this.toolStripButtonExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButtonExit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonExit.Image")));
         this.toolStripButtonExit.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButtonExit.Name = "toolStripButtonExit";
         this.toolStripButtonExit.Size = new System.Drawing.Size(28, 28);
         this.toolStripButtonExit.Text = "Fermer";
         this.toolStripButtonExit.Click += new System.EventHandler(this.toolStripButtonExit_Click);
         // 
         // toolStripButtonMaximize
         // 
         this.toolStripButtonMaximize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButtonMaximize.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonMaximize.Image")));
         this.toolStripButtonMaximize.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButtonMaximize.Name = "toolStripButtonMaximize";
         this.toolStripButtonMaximize.Size = new System.Drawing.Size(28, 28);
         this.toolStripButtonMaximize.Text = "Maximiser";
         this.toolStripButtonMaximize.Click += new System.EventHandler(this.toolStripButtonMaximize_Click);
         // 
         // toolStripButtonMinimize
         // 
         this.toolStripButtonMinimize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButtonMinimize.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonMinimize.Image")));
         this.toolStripButtonMinimize.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButtonMinimize.Name = "toolStripButtonMinimize";
         this.toolStripButtonMinimize.RightToLeft = System.Windows.Forms.RightToLeft.No;
         this.toolStripButtonMinimize.Size = new System.Drawing.Size(28, 28);
         this.toolStripButtonMinimize.Text = "Minimiser";
         this.toolStripButtonMinimize.Click += new System.EventHandler(this.toolStripButtonMinimize_Click);
         // 
         // LblAppLogo
         // 
         this.LblAppLogo.Image = ((System.Drawing.Image)(resources.GetObject("LblAppLogo.Image")));
         this.LblAppLogo.Location = new System.Drawing.Point(0, 0);
         this.LblAppLogo.Margin = new System.Windows.Forms.Padding(0);
         this.LblAppLogo.Name = "LblAppLogo";
         this.LblAppLogo.Size = new System.Drawing.Size(32, 32);
         this.LblAppLogo.TabIndex = 1;
         this.LblAppLogo.Paint += new System.Windows.Forms.PaintEventHandler(this.label1_Paint);
         // 
         // LblAppTitle
         // 
         this.LblAppTitle.AutoSize = true;
         this.LblAppTitle.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.LblAppTitle.Location = new System.Drawing.Point(32, 4);
         this.LblAppTitle.Name = "LblAppTitle";
         this.LblAppTitle.Size = new System.Drawing.Size(110, 25);
         this.LblAppTitle.TabIndex = 2;
         this.LblAppTitle.Text = "Default title";
         // 
         // FormDragBar
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.SystemColors.ButtonShadow;
         this.Controls.Add(this.LblAppTitle);
         this.Controls.Add(this.LblAppLogo);
         this.Controls.Add(this.toolStrip1);
         this.Name = "FormDragBar";
         this.Size = new System.Drawing.Size(672, 32);
         this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FormDragBar_MouseDoubleClick);
         this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormDragBar_MouseDown);
         this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormDragBar_MouseMove);
         this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormDragBar_MouseUp);
         this.toolStrip1.ResumeLayout(false);
         this.toolStrip1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ToolStrip toolStrip1;
      private System.Windows.Forms.ToolStripButton toolStripButtonExit;
      private System.Windows.Forms.ToolStripButton toolStripButtonMaximize;
      private System.Windows.Forms.ToolStripButton toolStripButtonMinimize;
      private System.Windows.Forms.Label LblAppLogo;
      private System.Windows.Forms.Label LblAppTitle;
   }
}
