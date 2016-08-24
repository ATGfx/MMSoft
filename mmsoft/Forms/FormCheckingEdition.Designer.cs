namespace MMSoft
{
   partial class FormCheckingEdition
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCheckingEdition));
         this.CheckingEditionPanel = new System.Windows.Forms.Panel();
         this.CheckingEditionCtrl = new MMSoft.CheckingEdition();
         this.ToolStripAddChecking = new System.Windows.Forms.ToolStrip();
         this.ToolStripBtnValidate = new System.Windows.Forms.ToolStripButton();
         this.ToolStripButtonCancel = new System.Windows.Forms.ToolStripButton();
         this.CheckingEditionPanel.SuspendLayout();
         this.ToolStripAddChecking.SuspendLayout();
         this.SuspendLayout();
         // 
         // CheckingEditionPanel
         // 
         this.CheckingEditionPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
         this.CheckingEditionPanel.Controls.Add(this.CheckingEditionCtrl);
         this.CheckingEditionPanel.Controls.Add(this.ToolStripAddChecking);
         this.CheckingEditionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
         this.CheckingEditionPanel.Location = new System.Drawing.Point(0, 0);
         this.CheckingEditionPanel.Name = "CheckingEditionPanel";
         this.CheckingEditionPanel.Padding = new System.Windows.Forms.Padding(3);
         this.CheckingEditionPanel.Size = new System.Drawing.Size(653, 752);
         this.CheckingEditionPanel.TabIndex = 0;
         // 
         // CheckingEditionCtrl
         // 
         this.CheckingEditionCtrl.BackColor = System.Drawing.SystemColors.ActiveCaption;
         this.CheckingEditionCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
         this.CheckingEditionCtrl.Location = new System.Drawing.Point(3, 3);
         this.CheckingEditionCtrl.Name = "CheckingEditionCtrl";
         this.CheckingEditionCtrl.Padding = new System.Windows.Forms.Padding(1);
         this.CheckingEditionCtrl.Size = new System.Drawing.Size(647, 707);
         this.CheckingEditionCtrl.TabIndex = 0;
         // 
         // ToolStripAddChecking
         // 
         this.ToolStripAddChecking.BackColor = System.Drawing.SystemColors.ActiveCaption;
         this.ToolStripAddChecking.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.ToolStripAddChecking.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this.ToolStripAddChecking.ImageScalingSize = new System.Drawing.Size(32, 32);
         this.ToolStripAddChecking.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripBtnValidate,
            this.ToolStripButtonCancel});
         this.ToolStripAddChecking.Location = new System.Drawing.Point(3, 710);
         this.ToolStripAddChecking.Name = "ToolStripAddChecking";
         this.ToolStripAddChecking.Size = new System.Drawing.Size(647, 39);
         this.ToolStripAddChecking.TabIndex = 7;
         this.ToolStripAddChecking.Text = "toolStrip1";
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
         // FormCheckingEdition
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.Red;
         this.ClientSize = new System.Drawing.Size(653, 752);
         this.Controls.Add(this.CheckingEditionPanel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "FormCheckingEdition";
         this.Text = "FormCheckingEdition";
         this.CheckingEditionPanel.ResumeLayout(false);
         this.CheckingEditionPanel.PerformLayout();
         this.ToolStripAddChecking.ResumeLayout(false);
         this.ToolStripAddChecking.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel CheckingEditionPanel;
      private CheckingEdition CheckingEditionCtrl;
      private System.Windows.Forms.ToolStrip ToolStripAddChecking;
      private System.Windows.Forms.ToolStripButton ToolStripBtnValidate;
      private System.Windows.Forms.ToolStripButton ToolStripButtonCancel;
   }
}