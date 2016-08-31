namespace MMSoft
{
    partial class FormReturnListView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReturnListView));
            this.ToolStripValidate = new System.Windows.Forms.ToolStrip();
            this.ToolStripBtnValidate = new System.Windows.Forms.ToolStripButton();
            this.DBListViewJobReturn = new MMSoft.DBListView();
            this.ToolStripValidate.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStripValidate
            // 
            this.ToolStripValidate.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ToolStripValidate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ToolStripValidate.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStripValidate.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ToolStripValidate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripBtnValidate});
            this.ToolStripValidate.Location = new System.Drawing.Point(3, 399);
            this.ToolStripValidate.Name = "ToolStripValidate";
            this.ToolStripValidate.Size = new System.Drawing.Size(894, 39);
            this.ToolStripValidate.TabIndex = 9;
            this.ToolStripValidate.Text = "toolStrip1";
            // 
            // ToolStripBtnValidate
            // 
            this.ToolStripBtnValidate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolStripBtnValidate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripBtnValidate.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnValidate.Image")));
            this.ToolStripBtnValidate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripBtnValidate.Name = "ToolStripBtnValidate";
            this.ToolStripBtnValidate.Size = new System.Drawing.Size(36, 36);
            this.ToolStripBtnValidate.Text = "Valider";
            this.ToolStripBtnValidate.Click += new System.EventHandler(this.ToolStripBtnValidate_Click);
            // 
            // DBListViewJobReturn
            // 
            this.DBListViewJobReturn.AllowMultipleSelecion = false;
            this.DBListViewJobReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.DBListViewJobReturn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DBListViewJobReturn.ListTitle = "List";
            this.DBListViewJobReturn.Location = new System.Drawing.Point(3, 3);
            this.DBListViewJobReturn.Margin = new System.Windows.Forms.Padding(0);
            this.DBListViewJobReturn.Name = "DBListViewJobReturn";
            this.DBListViewJobReturn.Size = new System.Drawing.Size(894, 396);
            this.DBListViewJobReturn.TabIndex = 0;
            // 
            // FormReturnListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 441);
            this.Controls.Add(this.DBListViewJobReturn);
            this.Controls.Add(this.ToolStripValidate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormReturnListView";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "FormReturnListView";
            this.ToolStripValidate.ResumeLayout(false);
            this.ToolStripValidate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DBListView DBListViewJobReturn;
        private System.Windows.Forms.ToolStrip ToolStripValidate;
        private System.Windows.Forms.ToolStripButton ToolStripBtnValidate;

    }
}