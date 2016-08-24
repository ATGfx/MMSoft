namespace MMSoft
{
   partial class CheckingViewer
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckingViewer));
         this.PanelChecking = new System.Windows.Forms.Panel();
         this.ToolStripCheckActions = new System.Windows.Forms.ToolStrip();
         this.ToolStripBtnEdit = new System.Windows.Forms.ToolStripButton();
         this.ToolStripBtnCopy = new System.Windows.Forms.ToolStripButton();
         this.ToolStripBtnDelete = new System.Windows.Forms.ToolStripButton();
         this.TxtRem = new System.Windows.Forms.TextBox();
         this.TxtNbrH = new System.Windows.Forms.TextBox();
         this.TxtDate = new System.Windows.Forms.TextBox();
         this.TxtQte = new System.Windows.Forms.TextBox();
         this.TxtDelai = new System.Windows.Forms.TextBox();
         this.TxtTache = new System.Windows.Forms.TextBox();
         this.TxtLibelle = new System.Windows.Forms.TextBox();
         this.TxtClient = new System.Windows.Forms.TextBox();
         this.TxtNumRefInt = new System.Windows.Forms.TextBox();
         this.PanelBorder = new System.Windows.Forms.Panel();
         this.PanelChecking.SuspendLayout();
         this.ToolStripCheckActions.SuspendLayout();
         this.PanelBorder.SuspendLayout();
         this.SuspendLayout();
         // 
         // PanelChecking
         // 
         this.PanelChecking.BackColor = System.Drawing.SystemColors.AppWorkspace;
         this.PanelChecking.Controls.Add(this.ToolStripCheckActions);
         this.PanelChecking.Controls.Add(this.TxtRem);
         this.PanelChecking.Controls.Add(this.TxtNbrH);
         this.PanelChecking.Controls.Add(this.TxtDate);
         this.PanelChecking.Controls.Add(this.TxtQte);
         this.PanelChecking.Controls.Add(this.TxtDelai);
         this.PanelChecking.Controls.Add(this.TxtTache);
         this.PanelChecking.Controls.Add(this.TxtLibelle);
         this.PanelChecking.Controls.Add(this.TxtClient);
         this.PanelChecking.Controls.Add(this.TxtNumRefInt);
         this.PanelChecking.Dock = System.Windows.Forms.DockStyle.Fill;
         this.PanelChecking.Location = new System.Drawing.Point(0, 0);
         this.PanelChecking.Name = "PanelChecking";
         this.PanelChecking.Size = new System.Drawing.Size(1687, 40);
         this.PanelChecking.TabIndex = 0;
         this.PanelChecking.MouseEnter += new System.EventHandler(this.PanelChecking_MouseEnter);
         this.PanelChecking.MouseLeave += new System.EventHandler(this.PanelChecking_MouseLeave);
         // 
         // ToolStripCheckActions
         // 
         this.ToolStripCheckActions.BackColor = System.Drawing.SystemColors.ButtonHighlight;
         this.ToolStripCheckActions.Dock = System.Windows.Forms.DockStyle.Right;
         this.ToolStripCheckActions.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this.ToolStripCheckActions.ImageScalingSize = new System.Drawing.Size(32, 32);
         this.ToolStripCheckActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripBtnEdit,
            this.ToolStripBtnCopy,
            this.ToolStripBtnDelete});
         this.ToolStripCheckActions.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
         this.ToolStripCheckActions.Location = new System.Drawing.Point(1576, 0);
         this.ToolStripCheckActions.Name = "ToolStripCheckActions";
         this.ToolStripCheckActions.Size = new System.Drawing.Size(111, 40);
         this.ToolStripCheckActions.TabIndex = 18;
         this.ToolStripCheckActions.Text = "toolStrip1";
         // 
         // ToolStripBtnEdit
         // 
         this.ToolStripBtnEdit.BackColor = System.Drawing.Color.Transparent;
         this.ToolStripBtnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnEdit.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnEdit.Image")));
         this.ToolStripBtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnEdit.Name = "ToolStripBtnEdit";
         this.ToolStripBtnEdit.Size = new System.Drawing.Size(36, 37);
         this.ToolStripBtnEdit.Text = "Modifier";
         this.ToolStripBtnEdit.Click += new System.EventHandler(this.ToolStripBtnEdit_Click);
         // 
         // ToolStripBtnCopy
         // 
         this.ToolStripBtnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnCopy.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnCopy.Image")));
         this.ToolStripBtnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnCopy.Name = "ToolStripBtnCopy";
         this.ToolStripBtnCopy.Size = new System.Drawing.Size(36, 37);
         this.ToolStripBtnCopy.Text = "Copier";
         // 
         // ToolStripBtnDelete
         // 
         this.ToolStripBtnDelete.BackColor = System.Drawing.Color.Transparent;
         this.ToolStripBtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnDelete.Image")));
         this.ToolStripBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnDelete.Name = "ToolStripBtnDelete";
         this.ToolStripBtnDelete.Size = new System.Drawing.Size(36, 37);
         this.ToolStripBtnDelete.Text = "Supprimer";
         this.ToolStripBtnDelete.Click += new System.EventHandler(this.ToolStripBtnDelete_Click);
         // 
         // TxtRem
         // 
         this.TxtRem.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.TxtRem.Location = new System.Drawing.Point(1340, 14);
         this.TxtRem.Name = "TxtRem";
         this.TxtRem.Size = new System.Drawing.Size(119, 13);
         this.TxtRem.TabIndex = 8;
         // 
         // TxtNbrH
         // 
         this.TxtNbrH.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.TxtNbrH.Location = new System.Drawing.Point(1284, 14);
         this.TxtNbrH.Name = "TxtNbrH";
         this.TxtNbrH.Size = new System.Drawing.Size(50, 13);
         this.TxtNbrH.TabIndex = 7;
         this.TxtNbrH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
         // 
         // TxtDate
         // 
         this.TxtDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.TxtDate.Location = new System.Drawing.Point(1178, 14);
         this.TxtDate.Name = "TxtDate";
         this.TxtDate.Size = new System.Drawing.Size(100, 13);
         this.TxtDate.TabIndex = 6;
         // 
         // TxtQte
         // 
         this.TxtQte.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.TxtQte.Location = new System.Drawing.Point(1016, 14);
         this.TxtQte.Name = "TxtQte";
         this.TxtQte.Size = new System.Drawing.Size(50, 13);
         this.TxtQte.TabIndex = 5;
         this.TxtQte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
         // 
         // TxtDelai
         // 
         this.TxtDelai.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.TxtDelai.Location = new System.Drawing.Point(1072, 14);
         this.TxtDelai.Name = "TxtDelai";
         this.TxtDelai.Size = new System.Drawing.Size(100, 13);
         this.TxtDelai.TabIndex = 4;
         // 
         // TxtTache
         // 
         this.TxtTache.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.TxtTache.Location = new System.Drawing.Point(234, 14);
         this.TxtTache.Name = "TxtTache";
         this.TxtTache.Size = new System.Drawing.Size(170, 13);
         this.TxtTache.TabIndex = 3;
         // 
         // TxtLibelle
         // 
         this.TxtLibelle.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.TxtLibelle.Location = new System.Drawing.Point(410, 14);
         this.TxtLibelle.Name = "TxtLibelle";
         this.TxtLibelle.Size = new System.Drawing.Size(600, 13);
         this.TxtLibelle.TabIndex = 2;
         // 
         // TxtClient
         // 
         this.TxtClient.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.TxtClient.Location = new System.Drawing.Point(108, 14);
         this.TxtClient.Name = "TxtClient";
         this.TxtClient.Size = new System.Drawing.Size(120, 13);
         this.TxtClient.TabIndex = 1;
         // 
         // TxtNumRefInt
         // 
         this.TxtNumRefInt.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this.TxtNumRefInt.Location = new System.Drawing.Point(2, 14);
         this.TxtNumRefInt.Name = "TxtNumRefInt";
         this.TxtNumRefInt.Size = new System.Drawing.Size(100, 13);
         this.TxtNumRefInt.TabIndex = 0;
         // 
         // PanelBorder
         // 
         this.PanelBorder.Controls.Add(this.PanelChecking);
         this.PanelBorder.Dock = System.Windows.Forms.DockStyle.Fill;
         this.PanelBorder.Location = new System.Drawing.Point(3, 3);
         this.PanelBorder.Name = "PanelBorder";
         this.PanelBorder.Size = new System.Drawing.Size(1687, 40);
         this.PanelBorder.TabIndex = 1;
         // 
         // CheckingViewer
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.Controls.Add(this.PanelBorder);
         this.Name = "CheckingViewer";
         this.Padding = new System.Windows.Forms.Padding(3);
         this.Size = new System.Drawing.Size(1693, 46);
         this.PanelChecking.ResumeLayout(false);
         this.PanelChecking.PerformLayout();
         this.ToolStripCheckActions.ResumeLayout(false);
         this.ToolStripCheckActions.PerformLayout();
         this.PanelBorder.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel PanelChecking;
      private System.Windows.Forms.Panel PanelBorder;
      private System.Windows.Forms.TextBox TxtQte;
      private System.Windows.Forms.TextBox TxtDelai;
      private System.Windows.Forms.TextBox TxtTache;
      private System.Windows.Forms.TextBox TxtLibelle;
      private System.Windows.Forms.TextBox TxtClient;
      private System.Windows.Forms.TextBox TxtNumRefInt;
      private System.Windows.Forms.TextBox TxtRem;
      private System.Windows.Forms.TextBox TxtNbrH;
      private System.Windows.Forms.TextBox TxtDate;
      private System.Windows.Forms.ToolStrip ToolStripCheckActions;
      private System.Windows.Forms.ToolStripButton ToolStripBtnEdit;
      private System.Windows.Forms.ToolStripButton ToolStripBtnCopy;
      private System.Windows.Forms.ToolStripButton ToolStripBtnDelete;
   }
}
