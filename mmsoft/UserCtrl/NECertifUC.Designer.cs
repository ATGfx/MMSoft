namespace MMSoft
{
   partial class NECertifUC
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NECertifUC));
         this.ToolStripNeCertif = new System.Windows.Forms.ToolStrip();
         this.ToolStripLblDate = new System.Windows.Forms.ToolStripLabel();
         this.ToolStripButtonNE = new System.Windows.Forms.ToolStripButton();
         this.ToolStripBtnCertif = new System.Windows.Forms.ToolStripButton();
         this.ToolStripBtnDelete = new System.Windows.Forms.ToolStripButton();
         this.ToolStripNeCertif.SuspendLayout();
         this.SuspendLayout();
         // 
         // ToolStripNeCertif
         // 
         this.ToolStripNeCertif.Dock = System.Windows.Forms.DockStyle.Fill;
         this.ToolStripNeCertif.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this.ToolStripNeCertif.ImageScalingSize = new System.Drawing.Size(48, 48);
         this.ToolStripNeCertif.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripLblDate,
            this.ToolStripButtonNE,
            this.ToolStripBtnCertif,
            this.ToolStripBtnDelete});
         this.ToolStripNeCertif.Location = new System.Drawing.Point(0, 0);
         this.ToolStripNeCertif.Name = "ToolStripNeCertif";
         this.ToolStripNeCertif.Size = new System.Drawing.Size(221, 55);
         this.ToolStripNeCertif.TabIndex = 0;
         this.ToolStripNeCertif.Text = "toolStrip1";
         // 
         // ToolStripLblDate
         // 
         this.ToolStripLblDate.Name = "ToolStripLblDate";
         this.ToolStripLblDate.Size = new System.Drawing.Size(31, 52);
         this.ToolStripLblDate.Text = "Date";
         // 
         // ToolStripButtonNE
         // 
         this.ToolStripButtonNE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripButtonNE.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButtonNE.Image")));
         this.ToolStripButtonNE.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripButtonNE.Name = "ToolStripButtonNE";
         this.ToolStripButtonNE.Size = new System.Drawing.Size(52, 52);
         this.ToolStripButtonNE.Text = "Note d\'envoi";
         this.ToolStripButtonNE.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
         this.ToolStripButtonNE.Click += new System.EventHandler(this.ToolStripButtonNE_Click);
         // 
         // ToolStripBtnCertif
         // 
         this.ToolStripBtnCertif.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnCertif.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnCertif.Image")));
         this.ToolStripBtnCertif.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnCertif.Name = "ToolStripBtnCertif";
         this.ToolStripBtnCertif.Size = new System.Drawing.Size(52, 52);
         this.ToolStripBtnCertif.Text = "Certificat";
         this.ToolStripBtnCertif.Click += new System.EventHandler(this.ToolStripBtnCertif_Click);
         // 
         // ToolStripBtnDelete
         // 
         this.ToolStripBtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnDelete.Image")));
         this.ToolStripBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnDelete.Name = "ToolStripBtnDelete";
         this.ToolStripBtnDelete.Size = new System.Drawing.Size(52, 52);
         this.ToolStripBtnDelete.Text = "Supprimer";
         this.ToolStripBtnDelete.Click += new System.EventHandler(this.ToolStripBtnDelete_Click);
         // 
         // NECertifUC
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.AutoSize = true;
         this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this.Controls.Add(this.ToolStripNeCertif);
         this.Name = "NECertifUC";
         this.Size = new System.Drawing.Size(221, 55);
         this.ToolStripNeCertif.ResumeLayout(false);
         this.ToolStripNeCertif.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ToolStrip ToolStripNeCertif;
      private System.Windows.Forms.ToolStripButton ToolStripButtonNE;
      private System.Windows.Forms.ToolStripButton ToolStripBtnCertif;
      private System.Windows.Forms.ToolStripButton ToolStripBtnDelete;
      private System.Windows.Forms.ToolStripLabel ToolStripLblDate;
   }
}
