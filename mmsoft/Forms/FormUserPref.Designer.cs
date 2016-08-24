namespace MMSoft
{
   partial class FormUserPref
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUserPref));
         this.PanelUserPref = new System.Windows.Forms.Panel();
         this.PanelInfo = new System.Windows.Forms.Panel();
         this.LblPrefDep = new System.Windows.Forms.Label();
         this.LblPrefHall = new System.Windows.Forms.Label();
         this.DBComboxPrefHall = new MMSoft.DBComboBox();
         this.DBComboxPrefDep = new MMSoft.DBComboBox();
         this.TxtLogin = new System.Windows.Forms.TextBox();
         this.LblLogin = new System.Windows.Forms.Label();
         this.TxtConfirmPwd = new System.Windows.Forms.TextBox();
         this.LblConfirmPwd = new System.Windows.Forms.Label();
         this.TxtPwd = new System.Windows.Forms.TextBox();
         this.LblPwd = new System.Windows.Forms.Label();
         this.panel1 = new System.Windows.Forms.Panel();
         this.ToolStripValidatePref = new System.Windows.Forms.ToolStrip();
         this.ToolStripBtnValidate = new System.Windows.Forms.ToolStripButton();
         this.ToolStripButtonCancel = new System.Windows.Forms.ToolStripButton();
         this.PanelFormHeader = new System.Windows.Forms.Panel();
         this.LblFormTitle = new System.Windows.Forms.Label();
         this.PanelUserPref.SuspendLayout();
         this.PanelInfo.SuspendLayout();
         this.panel1.SuspendLayout();
         this.ToolStripValidatePref.SuspendLayout();
         this.PanelFormHeader.SuspendLayout();
         this.SuspendLayout();
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
         this.PanelUserPref.Size = new System.Drawing.Size(377, 216);
         this.PanelUserPref.TabIndex = 0;
         // 
         // PanelInfo
         // 
         this.PanelInfo.Controls.Add(this.LblPrefDep);
         this.PanelInfo.Controls.Add(this.LblPrefHall);
         this.PanelInfo.Controls.Add(this.DBComboxPrefHall);
         this.PanelInfo.Controls.Add(this.DBComboxPrefDep);
         this.PanelInfo.Controls.Add(this.TxtLogin);
         this.PanelInfo.Controls.Add(this.LblLogin);
         this.PanelInfo.Controls.Add(this.TxtConfirmPwd);
         this.PanelInfo.Controls.Add(this.LblConfirmPwd);
         this.PanelInfo.Controls.Add(this.TxtPwd);
         this.PanelInfo.Controls.Add(this.LblPwd);
         this.PanelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
         this.PanelInfo.Location = new System.Drawing.Point(0, 32);
         this.PanelInfo.Name = "PanelInfo";
         this.PanelInfo.Size = new System.Drawing.Size(377, 144);
         this.PanelInfo.TabIndex = 4;
         // 
         // LblPrefDep
         // 
         this.LblPrefDep.AutoSize = true;
         this.LblPrefDep.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.LblPrefDep.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.LblPrefDep.Location = new System.Drawing.Point(6, 89);
         this.LblPrefDep.Name = "LblPrefDep";
         this.LblPrefDep.Size = new System.Drawing.Size(120, 13);
         this.LblPrefDep.TabIndex = 23;
         this.LblPrefDep.Text = "Département préféré :";
         // 
         // LblPrefHall
         // 
         this.LblPrefHall.AutoSize = true;
         this.LblPrefHall.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.LblPrefHall.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.LblPrefHall.Location = new System.Drawing.Point(6, 116);
         this.LblPrefHall.Name = "LblPrefHall";
         this.LblPrefHall.Size = new System.Drawing.Size(73, 13);
         this.LblPrefHall.TabIndex = 22;
         this.LblPrefHall.Text = "Hall préféré :";
         // 
         // DBComboxPrefHall
         // 
         this.DBComboxPrefHall.FormattingEnabled = true;
         this.DBComboxPrefHall.Location = new System.Drawing.Point(132, 113);
         this.DBComboxPrefHall.Name = "DBComboxPrefHall";
         this.DBComboxPrefHall.Size = new System.Drawing.Size(233, 21);
         this.DBComboxPrefHall.TabIndex = 5;
         // 
         // DBComboxPrefDep
         // 
         this.DBComboxPrefDep.FormattingEnabled = true;
         this.DBComboxPrefDep.Location = new System.Drawing.Point(132, 86);
         this.DBComboxPrefDep.Name = "DBComboxPrefDep";
         this.DBComboxPrefDep.Size = new System.Drawing.Size(233, 21);
         this.DBComboxPrefDep.TabIndex = 4;
         // 
         // TxtLogin
         // 
         this.TxtLogin.Location = new System.Drawing.Point(132, 8);
         this.TxtLogin.Name = "TxtLogin";
         this.TxtLogin.Size = new System.Drawing.Size(233, 20);
         this.TxtLogin.TabIndex = 1;
         // 
         // LblLogin
         // 
         this.LblLogin.AutoSize = true;
         this.LblLogin.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.LblLogin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.LblLogin.Location = new System.Drawing.Point(6, 11);
         this.LblLogin.Name = "LblLogin";
         this.LblLogin.Size = new System.Drawing.Size(42, 13);
         this.LblLogin.TabIndex = 18;
         this.LblLogin.Text = "Login :";
         // 
         // TxtConfirmPwd
         // 
         this.TxtConfirmPwd.Location = new System.Drawing.Point(132, 60);
         this.TxtConfirmPwd.Name = "TxtConfirmPwd";
         this.TxtConfirmPwd.PasswordChar = '*';
         this.TxtConfirmPwd.Size = new System.Drawing.Size(233, 20);
         this.TxtConfirmPwd.TabIndex = 3;
         // 
         // LblConfirmPwd
         // 
         this.LblConfirmPwd.AutoSize = true;
         this.LblConfirmPwd.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.LblConfirmPwd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.LblConfirmPwd.Location = new System.Drawing.Point(6, 63);
         this.LblConfirmPwd.Name = "LblConfirmPwd";
         this.LblConfirmPwd.Size = new System.Drawing.Size(81, 13);
         this.LblConfirmPwd.TabIndex = 16;
         this.LblConfirmPwd.Text = "Confirmation :";
         // 
         // TxtPwd
         // 
         this.TxtPwd.Location = new System.Drawing.Point(132, 34);
         this.TxtPwd.Name = "TxtPwd";
         this.TxtPwd.PasswordChar = '*';
         this.TxtPwd.Size = new System.Drawing.Size(233, 20);
         this.TxtPwd.TabIndex = 2;
         // 
         // LblPwd
         // 
         this.LblPwd.AutoSize = true;
         this.LblPwd.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.LblPwd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.LblPwd.Location = new System.Drawing.Point(6, 37);
         this.LblPwd.Name = "LblPwd";
         this.LblPwd.Size = new System.Drawing.Size(82, 13);
         this.LblPwd.TabIndex = 14;
         this.LblPwd.Text = "Mot de passe :";
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.ToolStripValidatePref);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.panel1.Location = new System.Drawing.Point(0, 176);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(377, 40);
         this.panel1.TabIndex = 2;
         // 
         // ToolStripValidatePref
         // 
         this.ToolStripValidatePref.BackColor = System.Drawing.SystemColors.ActiveCaption;
         this.ToolStripValidatePref.Dock = System.Windows.Forms.DockStyle.Fill;
         this.ToolStripValidatePref.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this.ToolStripValidatePref.ImageScalingSize = new System.Drawing.Size(32, 32);
         this.ToolStripValidatePref.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripBtnValidate,
            this.ToolStripButtonCancel});
         this.ToolStripValidatePref.Location = new System.Drawing.Point(0, 0);
         this.ToolStripValidatePref.Name = "ToolStripValidatePref";
         this.ToolStripValidatePref.Size = new System.Drawing.Size(377, 40);
         this.ToolStripValidatePref.TabIndex = 8;
         this.ToolStripValidatePref.Text = "toolStrip1";
         // 
         // ToolStripBtnValidate
         // 
         this.ToolStripBtnValidate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnValidate.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnValidate.Image")));
         this.ToolStripBtnValidate.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnValidate.Name = "ToolStripBtnValidate";
         this.ToolStripBtnValidate.Size = new System.Drawing.Size(36, 37);
         this.ToolStripBtnValidate.Text = "Valider";
         this.ToolStripBtnValidate.Click += new System.EventHandler(this.ToolStripBtnValidate_Click);
         // 
         // ToolStripButtonCancel
         // 
         this.ToolStripButtonCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripButtonCancel.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripButtonCancel.Image")));
         this.ToolStripButtonCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripButtonCancel.Name = "ToolStripButtonCancel";
         this.ToolStripButtonCancel.Size = new System.Drawing.Size(36, 37);
         this.ToolStripButtonCancel.Text = "Annuler";
         this.ToolStripButtonCancel.Click += new System.EventHandler(this.ToolStripButtonCancel_Click);
         // 
         // PanelFormHeader
         // 
         this.PanelFormHeader.Controls.Add(this.LblFormTitle);
         this.PanelFormHeader.Dock = System.Windows.Forms.DockStyle.Top;
         this.PanelFormHeader.Location = new System.Drawing.Point(0, 0);
         this.PanelFormHeader.Name = "PanelFormHeader";
         this.PanelFormHeader.Size = new System.Drawing.Size(377, 32);
         this.PanelFormHeader.TabIndex = 0;
         // 
         // LblFormTitle
         // 
         this.LblFormTitle.AutoSize = true;
         this.LblFormTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.LblFormTitle.ForeColor = System.Drawing.Color.White;
         this.LblFormTitle.Location = new System.Drawing.Point(4, 5);
         this.LblFormTitle.Name = "LblFormTitle";
         this.LblFormTitle.Size = new System.Drawing.Size(164, 21);
         this.LblFormTitle.TabIndex = 1;
         this.LblFormTitle.Text = "Préférences utilisateur";
         this.LblFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // FormUserPref
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.ClientSize = new System.Drawing.Size(383, 222);
         this.Controls.Add(this.PanelUserPref);
         this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "FormUserPref";
         this.Padding = new System.Windows.Forms.Padding(3);
         this.Text = "FormUserPref";
         this.PanelUserPref.ResumeLayout(false);
         this.PanelInfo.ResumeLayout(false);
         this.PanelInfo.PerformLayout();
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         this.ToolStripValidatePref.ResumeLayout(false);
         this.ToolStripValidatePref.PerformLayout();
         this.PanelFormHeader.ResumeLayout(false);
         this.PanelFormHeader.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel PanelUserPref;
      private System.Windows.Forms.Panel PanelFormHeader;
      private System.Windows.Forms.Label LblFormTitle;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.ToolStrip ToolStripValidatePref;
      private System.Windows.Forms.ToolStripButton ToolStripBtnValidate;
      private System.Windows.Forms.ToolStripButton ToolStripButtonCancel;
      private System.Windows.Forms.Panel PanelInfo;
      private System.Windows.Forms.Label LblPrefDep;
      private System.Windows.Forms.Label LblPrefHall;
      private DBComboBox DBComboxPrefHall;
      private DBComboBox DBComboxPrefDep;
      private System.Windows.Forms.TextBox TxtLogin;
      private System.Windows.Forms.Label LblLogin;
      private System.Windows.Forms.TextBox TxtConfirmPwd;
      private System.Windows.Forms.Label LblConfirmPwd;
      private System.Windows.Forms.TextBox TxtPwd;
      private System.Windows.Forms.Label LblPwd;
   }
}