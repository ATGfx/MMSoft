﻿namespace MMSoft
{
   partial class DepartmentSelector
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
         this.FlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
         this.SuspendLayout();
         // 
         // FlowLayoutPanel
         // 
         this.FlowLayoutPanel.AutoScroll = true;
         this.FlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
         this.FlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
         this.FlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
         this.FlowLayoutPanel.Name = "FlowLayoutPanel";
         this.FlowLayoutPanel.Size = new System.Drawing.Size(565, 214);
         this.FlowLayoutPanel.TabIndex = 0;
         // 
         // DepartmentSelector
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.FlowLayoutPanel);
         this.Name = "DepartmentSelector";
         this.Size = new System.Drawing.Size(565, 214);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel;
   }
}
