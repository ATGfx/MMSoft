namespace MMSoft
{
   partial class HomeUC
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
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeUC));
         this.UpdateMsgTimer = new System.Windows.Forms.Timer(this.components);
         this.DBListViewMsg = new MMSoft.DBListView();
         this.FormMsgToolStrip = new System.Windows.Forms.ToolStrip();
         this.ToolStripBtnDelete = new System.Windows.Forms.ToolStripButton();
         this.DbListViewComJobs = new MMSoft.DBListView();
         this.splitContainer1 = new System.Windows.Forms.SplitContainer();
         this.FormMsgToolStrip.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         this.SuspendLayout();
         // 
         // UpdateMsgTimer
         // 
         this.UpdateMsgTimer.Enabled = true;
         this.UpdateMsgTimer.Tick += new System.EventHandler(this.UpdateMsgTimer_Tick);
         // 
         // DBListViewMsg
         // 
         this.DBListViewMsg.AllowMultipleSelecion = true;
         this.DBListViewMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
         this.DBListViewMsg.Dock = System.Windows.Forms.DockStyle.Fill;
         this.DBListViewMsg.ListTitle = "List";
         this.DBListViewMsg.Location = new System.Drawing.Point(0, 0);
         this.DBListViewMsg.Margin = new System.Windows.Forms.Padding(0);
         this.DBListViewMsg.Name = "DBListViewMsg";
         this.DBListViewMsg.Size = new System.Drawing.Size(956, 228);
         this.DBListViewMsg.TabIndex = 0;
         // 
         // FormMsgToolStrip
         // 
         this.FormMsgToolStrip.AutoSize = false;
         this.FormMsgToolStrip.BackColor = System.Drawing.SystemColors.ActiveBorder;
         this.FormMsgToolStrip.Dock = System.Windows.Forms.DockStyle.None;
         this.FormMsgToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
         this.FormMsgToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripBtnDelete});
         this.FormMsgToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
         this.FormMsgToolStrip.Location = new System.Drawing.Point(134, 44);
         this.FormMsgToolStrip.Name = "FormMsgToolStrip";
         this.FormMsgToolStrip.Size = new System.Drawing.Size(106, 43);
         this.FormMsgToolStrip.TabIndex = 10;
         this.FormMsgToolStrip.Text = "toolStrip1";
         // 
         // ToolStripBtnDelete
         // 
         this.ToolStripBtnDelete.BackColor = System.Drawing.Color.Transparent;
         this.ToolStripBtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnDelete.Image")));
         this.ToolStripBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnDelete.Name = "ToolStripBtnDelete";
         this.ToolStripBtnDelete.Size = new System.Drawing.Size(36, 36);
         this.ToolStripBtnDelete.Text = "Supprimer";
         this.ToolStripBtnDelete.Click += new System.EventHandler(this.ToolStripBtnDelete_Click);
         // 
         // DbListViewComJobs
         // 
         this.DbListViewComJobs.AllowMultipleSelecion = true;
         this.DbListViewComJobs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
         this.DbListViewComJobs.Dock = System.Windows.Forms.DockStyle.Fill;
         this.DbListViewComJobs.ListTitle = "List";
         this.DbListViewComJobs.Location = new System.Drawing.Point(0, 0);
         this.DbListViewComJobs.Margin = new System.Windows.Forms.Padding(0);
         this.DbListViewComJobs.Name = "DbListViewComJobs";
         this.DbListViewComJobs.Size = new System.Drawing.Size(956, 224);
         this.DbListViewComJobs.TabIndex = 11;
         // 
         // splitContainer1
         // 
         this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer1.Location = new System.Drawing.Point(3, 3);
         this.splitContainer1.Name = "splitContainer1";
         this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // splitContainer1.Panel1
         // 
         this.splitContainer1.Panel1.Controls.Add(this.DBListViewMsg);
         this.splitContainer1.Panel1.Controls.Add(this.FormMsgToolStrip);
         // 
         // splitContainer1.Panel2
         // 
         this.splitContainer1.Panel2.Controls.Add(this.DbListViewComJobs);
         this.splitContainer1.Size = new System.Drawing.Size(956, 456);
         this.splitContainer1.SplitterDistance = 228;
         this.splitContainer1.TabIndex = 12;
         // 
         // HomeUC
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
         this.Controls.Add(this.splitContainer1);
         this.DoubleBuffered = true;
         this.Name = "HomeUC";
         this.Padding = new System.Windows.Forms.Padding(3);
         this.Size = new System.Drawing.Size(962, 462);
         this.FormMsgToolStrip.ResumeLayout(false);
         this.FormMsgToolStrip.PerformLayout();
         this.splitContainer1.Panel1.ResumeLayout(false);
         this.splitContainer1.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
         this.splitContainer1.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private DBListView DBListViewMsg;
      private System.Windows.Forms.Timer UpdateMsgTimer;
      private System.Windows.Forms.ToolStrip FormMsgToolStrip;
      private System.Windows.Forms.ToolStripButton ToolStripBtnDelete;
      private DBListView DbListViewComJobs;
      private System.Windows.Forms.SplitContainer splitContainer1;

   }
}
