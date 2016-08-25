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
            this.DBListViewJobReturn = new MMSoft.DBListView();
            this.SuspendLayout();
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
            this.DBListViewJobReturn.Size = new System.Drawing.Size(747, 435);
            this.DBListViewJobReturn.TabIndex = 0;
            // 
            // FormReturnListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 441);
            this.Controls.Add(this.DBListViewJobReturn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormReturnListView";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "FormReturnListView";
            this.ResumeLayout(false);

        }

        #endregion

        private DBListView DBListViewJobReturn;

    }
}