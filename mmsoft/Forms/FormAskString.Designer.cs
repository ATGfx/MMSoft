namespace MMSoft
{
   partial class FormAskString
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAskString));
         this.LblFormTitle = new System.Windows.Forms.Label();
         this.TxtEnteredString = new System.Windows.Forms.TextBox();
         this.PanelFormHeader = new System.Windows.Forms.Panel();
         this.ToolStripButtonCancel = new System.Windows.Forms.ToolStripButton();
         this.ToolStripBtnValidate = new System.Windows.Forms.ToolStripButton();
         this.panel1 = new System.Windows.Forms.Panel();
         this.ToolStripValidatePref = new System.Windows.Forms.ToolStrip();
         this.PanelInfo = new System.Windows.Forms.Panel();
         this.PanelUserPref = new System.Windows.Forms.Panel();
         this.PanelFormHeader.SuspendLayout();
         this.panel1.SuspendLayout();
         this.ToolStripValidatePref.SuspendLayout();
         this.PanelInfo.SuspendLayout();
         this.PanelUserPref.SuspendLayout();
         this.SuspendLayout();
         // 
         // LblFormTitle
         // 
         this.LblFormTitle.AutoSize = true;
         this.LblFormTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.LblFormTitle.ForeColor = System.Drawing.Color.White;
         this.LblFormTitle.Location = new System.Drawing.Point(4, 5);
         this.LblFormTitle.Name = "LblFormTitle";
         this.LblFormTitle.Size = new System.Drawing.Size(41, 21);
         this.LblFormTitle.TabIndex = 1;
         this.LblFormTitle.Text = "Titre";
         this.LblFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // TxtEnteredString
         // 
         this.TxtEnteredString.Location = new System.Drawing.Point(8, 6);
         this.TxtEnteredString.Name = "TxtEnteredString";
         this.TxtEnteredString.Size = new System.Drawing.Size(548, 20);
         this.TxtEnteredString.TabIndex = 1;
         this.TxtEnteredString.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtEnteredString_KeyDown);
         // 
         // PanelFormHeader
         // 
         this.PanelFormHeader.BackColor = System.Drawing.SystemColors.AppWorkspace;
         this.PanelFormHeader.Controls.Add(this.LblFormTitle);
         this.PanelFormHeader.Dock = System.Windows.Forms.DockStyle.Top;
         this.PanelFormHeader.Location = new System.Drawing.Point(0, 0);
         this.PanelFormHeader.Name = "PanelFormHeader";
         this.PanelFormHeader.Size = new System.Drawing.Size(559, 32);
         this.PanelFormHeader.TabIndex = 0;
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
         // panel1
         // 
         this.panel1.Controls.Add(this.ToolStripValidatePref);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.panel1.Location = new System.Drawing.Point(0, 65);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(559, 40);
         this.panel1.TabIndex = 2;
         // 
         // ToolStripValidatePref
         // 
         this.ToolStripValidatePref.BackColor = System.Drawing.SystemColors.ActiveCaption;
         this.ToolStripValidatePref.Dock = System.Windows.Forms.DockStyle.Fill;
         this.ToolStripValidatePref.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this.ToolStripValidatePref.ImageScalingSize = new System.Drawing.Size(32, 32);
         this.ToolStripValidatePref.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripButtonCancel,
            this.ToolStripBtnValidate});
         this.ToolStripValidatePref.Location = new System.Drawing.Point(0, 0);
         this.ToolStripValidatePref.Name = "ToolStripValidatePref";
         this.ToolStripValidatePref.Size = new System.Drawing.Size(559, 40);
         this.ToolStripValidatePref.TabIndex = 8;
         this.ToolStripValidatePref.Text = "toolStrip1";
         // 
         // PanelInfo
         // 
         this.PanelInfo.Controls.Add(this.TxtEnteredString);
         this.PanelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
         this.PanelInfo.Location = new System.Drawing.Point(0, 32);
         this.PanelInfo.Name = "PanelInfo";
         this.PanelInfo.Size = new System.Drawing.Size(559, 33);
         this.PanelInfo.TabIndex = 4;
         // 
         // PanelUserPref
         // 
         this.PanelUserPref.BackColor = System.Drawing.SystemColors.Control;
         this.PanelUserPref.Controls.Add(this.PanelInfo);
         this.PanelUserPref.Controls.Add(this.panel1);
         this.PanelUserPref.Controls.Add(this.PanelFormHeader);
         this.PanelUserPref.Dock = System.Windows.Forms.DockStyle.Fill;
         this.PanelUserPref.Location = new System.Drawing.Point(3, 3);
         this.PanelUserPref.Name = "PanelUserPref";
         this.PanelUserPref.Size = new System.Drawing.Size(559, 105);
         this.PanelUserPref.TabIndex = 1;
         // 
         // FormAskString
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(565, 111);
         this.Controls.Add(this.PanelUserPref);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "FormAskString";
         this.Padding = new System.Windows.Forms.Padding(3);
         this.Text = "FormAskString";
         this.PanelFormHeader.ResumeLayout(false);
         this.PanelFormHeader.PerformLayout();
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         this.ToolStripValidatePref.ResumeLayout(false);
         this.ToolStripValidatePref.PerformLayout();
         this.PanelInfo.ResumeLayout(false);
         this.PanelInfo.PerformLayout();
         this.PanelUserPref.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Label LblFormTitle;
      private System.Windows.Forms.TextBox TxtEnteredString;
      private System.Windows.Forms.Panel PanelFormHeader;
      private System.Windows.Forms.ToolStripButton ToolStripButtonCancel;
      private System.Windows.Forms.ToolStripButton ToolStripBtnValidate;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.ToolStrip ToolStripValidatePref;
      private System.Windows.Forms.Panel PanelInfo;
      private System.Windows.Forms.Panel PanelUserPref;
   }
}