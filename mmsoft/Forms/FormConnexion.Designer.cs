namespace MMSoft
{
    partial class FormConnexion
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConnexion));
         this.TxtUserName = new System.Windows.Forms.TextBox();
         this.TxtPwd = new System.Windows.Forms.TextBox();
         this.LblUsername = new System.Windows.Forms.Label();
         this.LblPwd = new System.Windows.Forms.Label();
         this.BtnLogIn = new System.Windows.Forms.Button();
         this.CheckRememberMe = new System.Windows.Forms.CheckBox();
         this.LblExit = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // TxtUserName
         // 
         this.TxtUserName.BackColor = System.Drawing.Color.LightGray;
         this.TxtUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.TxtUserName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.TxtUserName.Location = new System.Drawing.Point(533, 192);
         this.TxtUserName.Name = "TxtUserName";
         this.TxtUserName.Size = new System.Drawing.Size(260, 18);
         this.TxtUserName.TabIndex = 0;
         this.TxtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtUserName_KeyDown);
         // 
         // TxtPwd
         // 
         this.TxtPwd.BackColor = System.Drawing.Color.LightGray;
         this.TxtPwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.TxtPwd.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.TxtPwd.Location = new System.Drawing.Point(533, 243);
         this.TxtPwd.Name = "TxtPwd";
         this.TxtPwd.Size = new System.Drawing.Size(260, 18);
         this.TxtPwd.TabIndex = 1;
         this.TxtPwd.UseSystemPasswordChar = true;
         this.TxtPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPwd_KeyDown);
         // 
         // LblUsername
         // 
         this.LblUsername.AutoSize = true;
         this.LblUsername.BackColor = System.Drawing.Color.Transparent;
         this.LblUsername.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.LblUsername.ForeColor = System.Drawing.Color.Black;
         this.LblUsername.Location = new System.Drawing.Point(530, 174);
         this.LblUsername.Name = "LblUsername";
         this.LblUsername.Size = new System.Drawing.Size(71, 15);
         this.LblUsername.TabIndex = 7;
         this.LblUsername.Text = "Utilisateur :";
         // 
         // LblPwd
         // 
         this.LblPwd.AutoSize = true;
         this.LblPwd.BackColor = System.Drawing.Color.Transparent;
         this.LblPwd.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.LblPwd.ForeColor = System.Drawing.Color.Black;
         this.LblPwd.Location = new System.Drawing.Point(530, 225);
         this.LblPwd.Name = "LblPwd";
         this.LblPwd.Size = new System.Drawing.Size(87, 15);
         this.LblPwd.TabIndex = 8;
         this.LblPwd.Text = "Mot de passe :";
         // 
         // BtnLogIn
         // 
         this.BtnLogIn.BackColor = System.Drawing.Color.Transparent;
         this.BtnLogIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.BtnLogIn.Location = new System.Drawing.Point(687, 277);
         this.BtnLogIn.Name = "BtnLogIn";
         this.BtnLogIn.Size = new System.Drawing.Size(106, 23);
         this.BtnLogIn.TabIndex = 3;
         this.BtnLogIn.Text = "Log In";
         this.BtnLogIn.UseVisualStyleBackColor = false;
         this.BtnLogIn.Click += new System.EventHandler(this.BtnLogIn_Click);
         // 
         // CheckRememberMe
         // 
         this.CheckRememberMe.AutoSize = true;
         this.CheckRememberMe.BackColor = System.Drawing.Color.Transparent;
         this.CheckRememberMe.ForeColor = System.Drawing.Color.Black;
         this.CheckRememberMe.Location = new System.Drawing.Point(533, 281);
         this.CheckRememberMe.Name = "CheckRememberMe";
         this.CheckRememberMe.Size = new System.Drawing.Size(148, 17);
         this.CheckRememberMe.TabIndex = 2;
         this.CheckRememberMe.Text = "Se souvenir de l\'utilisateur";
         this.CheckRememberMe.UseVisualStyleBackColor = false;
         // 
         // LblExit
         // 
         this.LblExit.BackColor = System.Drawing.Color.Transparent;
         this.LblExit.Image = ((System.Drawing.Image)(resources.GetObject("LblExit.Image")));
         this.LblExit.Location = new System.Drawing.Point(782, 9);
         this.LblExit.Name = "LblExit";
         this.LblExit.Size = new System.Drawing.Size(54, 46);
         this.LblExit.TabIndex = 4;
         this.LblExit.Click += new System.EventHandler(this.LblExit_Click);
         // 
         // FormConnexion
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
         this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
         this.ClientSize = new System.Drawing.Size(848, 575);
         this.Controls.Add(this.CheckRememberMe);
         this.Controls.Add(this.BtnLogIn);
         this.Controls.Add(this.LblPwd);
         this.Controls.Add(this.LblUsername);
         this.Controls.Add(this.TxtPwd);
         this.Controls.Add(this.TxtUserName);
         this.Controls.Add(this.LblExit);
         this.DoubleBuffered = true;
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "FormConnexion";
         this.Text = "Connexion à MMSOFT";
         this.Load += new System.EventHandler(this.FormConnexion_Load);
         this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormConnexion_KeyDown);
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtUserName;
        private System.Windows.Forms.TextBox TxtPwd;
        private System.Windows.Forms.Label LblUsername;
        private System.Windows.Forms.Label LblPwd;
        private System.Windows.Forms.Button BtnLogIn;
        private System.Windows.Forms.CheckBox CheckRememberMe;
        private System.Windows.Forms.Label LblExit;
    }
}