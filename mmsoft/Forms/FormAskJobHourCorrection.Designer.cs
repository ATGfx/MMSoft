namespace MMSoft
{
   partial class FormAskJobHourCorrection
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAskJobHourCorrection));
         this.ToolStripValidatePref = new System.Windows.Forms.ToolStrip();
         this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
         this.ToolStripBtnValidate = new System.Windows.Forms.ToolStripButton();
         this.ToolStripButtonCancel = new System.Windows.Forms.ToolStripButton();
         this.PanelUserPref = new System.Windows.Forms.Panel();
         this.TxtEnteredString = new System.Windows.Forms.TextBox();
         this.ToolStripValidatePref.SuspendLayout();
         this.PanelUserPref.SuspendLayout();
         this.SuspendLayout();
         // 
         // ToolStripValidatePref
         // 
         this.ToolStripValidatePref.BackColor = System.Drawing.SystemColors.ActiveCaption;
         this.ToolStripValidatePref.Dock = System.Windows.Forms.DockStyle.Fill;
         this.ToolStripValidatePref.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this.ToolStripValidatePref.ImageScalingSize = new System.Drawing.Size(32, 32);
         this.ToolStripValidatePref.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.ToolStripBtnValidate,
            this.ToolStripButtonCancel});
         this.ToolStripValidatePref.Location = new System.Drawing.Point(0, 0);
         this.ToolStripValidatePref.Name = "ToolStripValidatePref";
         this.ToolStripValidatePref.Size = new System.Drawing.Size(265, 39);
         this.ToolStripValidatePref.TabIndex = 8;
         this.ToolStripValidatePref.Text = "toolStrip1";
         // 
         // toolStripLabel1
         // 
         this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 12F);
         this.toolStripLabel1.Name = "toolStripLabel1";
         this.toolStripLabel1.Size = new System.Drawing.Size(134, 36);
         this.toolStripLabel1.Text = "Heures corrigées :";
         // 
         // ToolStripBtnValidate
         // 
         this.ToolStripBtnValidate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnValidate.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnValidate.Image")));
         this.ToolStripBtnValidate.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnValidate.Name = "ToolStripBtnValidate";
         this.ToolStripBtnValidate.Size = new System.Drawing.Size(36, 36);
         this.ToolStripBtnValidate.Text = "Valider";
         this.ToolStripBtnValidate.Click += new System.EventHandler(this.ToolStripBtnValidate_Click);
         // 
         // ToolStripButtonCancel
         // 
         this.ToolStripButtonCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripButtonCancel.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButtonCancel.Image")));
         this.ToolStripButtonCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripButtonCancel.Name = "ToolStripButtonCancel";
         this.ToolStripButtonCancel.Size = new System.Drawing.Size(36, 36);
         this.ToolStripButtonCancel.Text = "Annuler";
         this.ToolStripButtonCancel.Click += new System.EventHandler(this.ToolStripButtonCancel_Click);
         // 
         // PanelUserPref
         // 
         this.PanelUserPref.AutoSize = true;
         this.PanelUserPref.BackColor = System.Drawing.SystemColors.Control;
         this.PanelUserPref.Controls.Add(this.TxtEnteredString);
         this.PanelUserPref.Controls.Add(this.ToolStripValidatePref);
         this.PanelUserPref.Dock = System.Windows.Forms.DockStyle.Fill;
         this.PanelUserPref.Location = new System.Drawing.Point(3, 3);
         this.PanelUserPref.Name = "PanelUserPref";
         this.PanelUserPref.Size = new System.Drawing.Size(265, 39);
         this.PanelUserPref.TabIndex = 1;
         // 
         // TxtEnteredString
         // 
         this.TxtEnteredString.Location = new System.Drawing.Point(207, 10);
         this.TxtEnteredString.MaximumSize = new System.Drawing.Size(50, 20);
         this.TxtEnteredString.MinimumSize = new System.Drawing.Size(50, 20);
         this.TxtEnteredString.Name = "TxtEnteredString";
         this.TxtEnteredString.Size = new System.Drawing.Size(50, 20);
         this.TxtEnteredString.TabIndex = 2;
         this.TxtEnteredString.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtEnteredString_KeyDown);
         // 
         // FormAskJobHourCorrection
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(271, 45);
         this.Controls.Add(this.PanelUserPref);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "FormAskJobHourCorrection";
         this.Padding = new System.Windows.Forms.Padding(3);
         this.Text = "FormAskString";
         this.ToolStripValidatePref.ResumeLayout(false);
         this.ToolStripValidatePref.PerformLayout();
         this.PanelUserPref.ResumeLayout(false);
         this.PanelUserPref.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ToolStrip ToolStripValidatePref;
      private System.Windows.Forms.ToolStripLabel toolStripLabel1;
      private System.Windows.Forms.ToolStripButton ToolStripBtnValidate;
      private System.Windows.Forms.ToolStripButton ToolStripButtonCancel;
      private System.Windows.Forms.Panel PanelUserPref;
      private System.Windows.Forms.TextBox TxtEnteredString;

   }
}