namespace MMSoft
{
   partial class FormVersion
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVersion));
         this.ToolStripBtnValidate = new System.Windows.Forms.ToolStripButton();
         this.ToolStripValidatePref = new System.Windows.Forms.ToolStrip();
         this.ToolStripLblVersion = new System.Windows.Forms.ToolStripLabel();
         this.PanelUserPref = new System.Windows.Forms.Panel();
         this.ToolStripValidatePref.SuspendLayout();
         this.PanelUserPref.SuspendLayout();
         this.SuspendLayout();
         // 
         // ToolStripBtnValidate
         // 
         this.ToolStripBtnValidate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.ToolStripBtnValidate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnValidate.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnValidate.Image")));
         this.ToolStripBtnValidate.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnValidate.Name = "ToolStripBtnValidate";
         this.ToolStripBtnValidate.Size = new System.Drawing.Size(36, 41);
         this.ToolStripBtnValidate.Text = "Valider";
         this.ToolStripBtnValidate.Click += new System.EventHandler(this.ToolStripBtnValidate_Click);
         // 
         // ToolStripValidatePref
         // 
         this.ToolStripValidatePref.BackColor = System.Drawing.SystemColors.ActiveCaption;
         this.ToolStripValidatePref.Dock = System.Windows.Forms.DockStyle.Fill;
         this.ToolStripValidatePref.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this.ToolStripValidatePref.ImageScalingSize = new System.Drawing.Size(32, 32);
         this.ToolStripValidatePref.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripBtnValidate,
            this.ToolStripLblVersion});
         this.ToolStripValidatePref.Location = new System.Drawing.Point(0, 0);
         this.ToolStripValidatePref.Name = "ToolStripValidatePref";
         this.ToolStripValidatePref.Size = new System.Drawing.Size(559, 44);
         this.ToolStripValidatePref.TabIndex = 8;
         this.ToolStripValidatePref.Text = "toolStrip1";
         this.ToolStripValidatePref.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ToolStripValidatePref_KeyDown);
         // 
         // ToolStripLblVersion
         // 
         this.ToolStripLblVersion.Font = new System.Drawing.Font("Segoe UI", 12F);
         this.ToolStripLblVersion.ForeColor = System.Drawing.Color.White;
         this.ToolStripLblVersion.Name = "ToolStripLblVersion";
         this.ToolStripLblVersion.Size = new System.Drawing.Size(116, 41);
         this.ToolStripLblVersion.Text = "toolStripLabel1";
         // 
         // PanelUserPref
         // 
         this.PanelUserPref.BackColor = System.Drawing.SystemColors.Control;
         this.PanelUserPref.Controls.Add(this.ToolStripValidatePref);
         this.PanelUserPref.Dock = System.Windows.Forms.DockStyle.Fill;
         this.PanelUserPref.Location = new System.Drawing.Point(3, 3);
         this.PanelUserPref.Name = "PanelUserPref";
         this.PanelUserPref.Size = new System.Drawing.Size(559, 44);
         this.PanelUserPref.TabIndex = 1;
         // 
         // FormVersion
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(565, 50);
         this.Controls.Add(this.PanelUserPref);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "FormVersion";
         this.Padding = new System.Windows.Forms.Padding(3);
         this.Text = "FormAskString";
         this.ToolStripValidatePref.ResumeLayout(false);
         this.ToolStripValidatePref.PerformLayout();
         this.PanelUserPref.ResumeLayout(false);
         this.PanelUserPref.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.ToolStripButton ToolStripBtnValidate;
      private System.Windows.Forms.ToolStrip ToolStripValidatePref;
      private System.Windows.Forms.Panel PanelUserPref;
      private System.Windows.Forms.ToolStripLabel ToolStripLblVersion;
   }
}