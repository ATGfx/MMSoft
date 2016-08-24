namespace MMSoft
{
   partial class DBListView
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBListView));
         this.PanelListView = new System.Windows.Forms.Panel();
         this.PanelFilter = new System.Windows.Forms.Panel();
         this.MainToolStrip = new System.Windows.Forms.ToolStrip();
         this.ToolStripLblListViewName = new System.Windows.Forms.ToolStripLabel();
         this.ToolStripBtnExportCSV = new System.Windows.Forms.ToolStripButton();
         this.MainToolStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // PanelListView
         // 
         this.PanelListView.BackColor = System.Drawing.Color.Transparent;
         this.PanelListView.Dock = System.Windows.Forms.DockStyle.Fill;
         this.PanelListView.Location = new System.Drawing.Point(0, 39);
         this.PanelListView.Name = "PanelListView";
         this.PanelListView.Size = new System.Drawing.Size(611, 347);
         this.PanelListView.TabIndex = 0;
         // 
         // PanelFilter
         // 
         this.PanelFilter.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.PanelFilter.Location = new System.Drawing.Point(0, 386);
         this.PanelFilter.Margin = new System.Windows.Forms.Padding(0);
         this.PanelFilter.Name = "PanelFilter";
         this.PanelFilter.Size = new System.Drawing.Size(611, 22);
         this.PanelFilter.TabIndex = 1;
         // 
         // MainToolStrip
         // 
         this.MainToolStrip.BackColor = System.Drawing.SystemColors.ControlDarkDark;
         this.MainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this.MainToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
         this.MainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripLblListViewName,
            this.ToolStripBtnExportCSV});
         this.MainToolStrip.Location = new System.Drawing.Point(0, 0);
         this.MainToolStrip.Name = "MainToolStrip";
         this.MainToolStrip.Size = new System.Drawing.Size(611, 39);
         this.MainToolStrip.TabIndex = 2;
         this.MainToolStrip.Text = "toolStrip1";
         // 
         // ToolStripLblListViewName
         // 
         this.ToolStripLblListViewName.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F);
         this.ToolStripLblListViewName.Name = "ToolStripLblListViewName";
         this.ToolStripLblListViewName.Size = new System.Drawing.Size(40, 36);
         this.ToolStripLblListViewName.Text = "List";
         // 
         // ToolStripBtnExportCSV
         // 
         this.ToolStripBtnExportCSV.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.ToolStripBtnExportCSV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnExportCSV.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnExportCSV.Image")));
         this.ToolStripBtnExportCSV.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnExportCSV.Name = "ToolStripBtnExportCSV";
         this.ToolStripBtnExportCSV.Size = new System.Drawing.Size(36, 36);
         this.ToolStripBtnExportCSV.Text = "Export to Excel";
         this.ToolStripBtnExportCSV.Click += new System.EventHandler(this.ToolStripBtnExportCSV_Click);
         // 
         // DBListView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
         this.Controls.Add(this.PanelListView);
         this.Controls.Add(this.MainToolStrip);
         this.Controls.Add(this.PanelFilter);
         this.Margin = new System.Windows.Forms.Padding(0);
         this.Name = "DBListView";
         this.Size = new System.Drawing.Size(611, 408);
         this.MainToolStrip.ResumeLayout(false);
         this.MainToolStrip.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Panel PanelListView;
      private System.Windows.Forms.Panel PanelFilter;
      private System.Windows.Forms.ToolStrip MainToolStrip;
      private System.Windows.Forms.ToolStripButton ToolStripBtnExportCSV;
      private System.Windows.Forms.ToolStripLabel ToolStripLblListViewName;
   }
}
