﻿namespace MMSoft
{
   partial class ComJobSelector
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
         this.splitContainer1 = new System.Windows.Forms.SplitContainer();
         this.DBListViewCom = new MMSoft.DBListView();
         this.DBListViewJob = new MMSoft.DBListView();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         this.SuspendLayout();
         // 
         // splitContainer1
         // 
         this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer1.Location = new System.Drawing.Point(0, 0);
         this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
         this.splitContainer1.Name = "splitContainer1";
         this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // splitContainer1.Panel1
         // 
         this.splitContainer1.Panel1.Controls.Add(this.DBListViewCom);
         // 
         // splitContainer1.Panel2
         // 
         this.splitContainer1.Panel2.Controls.Add(this.DBListViewJob);
         this.splitContainer1.Size = new System.Drawing.Size(803, 598);
         this.splitContainer1.SplitterDistance = 288;
         this.splitContainer1.TabIndex = 2;
         // 
         // DBListViewCom
         // 
         this.DBListViewCom.AllowMultipleSelecion = false;
         this.DBListViewCom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
         this.DBListViewCom.Dock = System.Windows.Forms.DockStyle.Fill;
         this.DBListViewCom.ListTitle = "List";
         this.DBListViewCom.Location = new System.Drawing.Point(0, 0);
         this.DBListViewCom.Margin = new System.Windows.Forms.Padding(0);
         this.DBListViewCom.Name = "DBListViewCom";
         this.DBListViewCom.Size = new System.Drawing.Size(803, 288);
         this.DBListViewCom.TabIndex = 0;
         // 
         // DBListViewJob
         // 
         this.DBListViewJob.AllowMultipleSelecion = false;
         this.DBListViewJob.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
         this.DBListViewJob.Dock = System.Windows.Forms.DockStyle.Fill;
         this.DBListViewJob.ListTitle = "List";
         this.DBListViewJob.Location = new System.Drawing.Point(0, 0);
         this.DBListViewJob.Margin = new System.Windows.Forms.Padding(0);
         this.DBListViewJob.Name = "DBListViewJob";
         this.DBListViewJob.Size = new System.Drawing.Size(803, 306);
         this.DBListViewJob.TabIndex = 0;
         // 
         // ComJobSelector
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.splitContainer1);
         this.Name = "ComJobSelector";
         this.Size = new System.Drawing.Size(803, 598);
         this.splitContainer1.Panel1.ResumeLayout(false);
         this.splitContainer1.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
         this.splitContainer1.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.SplitContainer splitContainer1;
      private DBListView DBListViewCom;
      private DBListView DBListViewJob;

   }
}
