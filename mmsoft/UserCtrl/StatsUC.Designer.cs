namespace MMSoft
{
   partial class StatsUC
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatsUC));
         this.PanelStats = new System.Windows.Forms.Panel();
         this.CustomDateTimePickerCtrl = new MMSoft.CustomDateTimePicker();
         this.ToolStripMonthSumHours = new System.Windows.Forms.ToolStrip();
         this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
         this.ToolStripBtnMonthHours = new System.Windows.Forms.ToolStripButton();
         this.ToolStripBtnDateTimePick = new System.Windows.Forms.ToolStripButton();
         this.PanelHeader = new System.Windows.Forms.Panel();
         this.LblHeader = new System.Windows.Forms.Label();
         this.PanelStats.SuspendLayout();
         this.ToolStripMonthSumHours.SuspendLayout();
         this.PanelHeader.SuspendLayout();
         this.SuspendLayout();
         // 
         // PanelStats
         // 
         this.PanelStats.Controls.Add(this.CustomDateTimePickerCtrl);
         this.PanelStats.Controls.Add(this.ToolStripMonthSumHours);
         this.PanelStats.Dock = System.Windows.Forms.DockStyle.Fill;
         this.PanelStats.Location = new System.Drawing.Point(3, 33);
         this.PanelStats.Name = "PanelStats";
         this.PanelStats.Size = new System.Drawing.Size(1174, 525);
         this.PanelStats.TabIndex = 1;
         // 
         // CustomDateTimePickerCtrl
         // 
         this.CustomDateTimePickerCtrl.BackColor = System.Drawing.SystemColors.ControlDark;
         this.CustomDateTimePickerCtrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.CustomDateTimePickerCtrl.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
         this.CustomDateTimePickerCtrl.Location = new System.Drawing.Point(391, 6);
         this.CustomDateTimePickerCtrl.Name = "CustomDateTimePickerCtrl";
         this.CustomDateTimePickerCtrl.Size = new System.Drawing.Size(127, 26);
         this.CustomDateTimePickerCtrl.TabIndex = 49;
         // 
         // ToolStripMonthSumHours
         // 
         this.ToolStripMonthSumHours.BackColor = System.Drawing.SystemColors.ButtonShadow;
         this.ToolStripMonthSumHours.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this.ToolStripMonthSumHours.ImageScalingSize = new System.Drawing.Size(32, 32);
         this.ToolStripMonthSumHours.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.ToolStripBtnMonthHours,
            this.ToolStripBtnDateTimePick});
         this.ToolStripMonthSumHours.Location = new System.Drawing.Point(0, 0);
         this.ToolStripMonthSumHours.Name = "ToolStripMonthSumHours";
         this.ToolStripMonthSumHours.Padding = new System.Windows.Forms.Padding(3);
         this.ToolStripMonthSumHours.Size = new System.Drawing.Size(1174, 45);
         this.ToolStripMonthSumHours.TabIndex = 48;
         this.ToolStripMonthSumHours.Text = "toolStrip1";
         // 
         // toolStripLabel1
         // 
         this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.toolStripLabel1.Name = "toolStripLabel1";
         this.toolStripLabel1.Size = new System.Drawing.Size(215, 36);
         this.toolStripLabel1.Text = "Cumul des heures pointées";
         // 
         // ToolStripBtnMonthHours
         // 
         this.ToolStripBtnMonthHours.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnMonthHours.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnMonthHours.Image")));
         this.ToolStripBtnMonthHours.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnMonthHours.Name = "ToolStripBtnMonthHours";
         this.ToolStripBtnMonthHours.Size = new System.Drawing.Size(36, 36);
         this.ToolStripBtnMonthHours.Text = "Rapport de cumul des heures pointées";
         this.ToolStripBtnMonthHours.Click += new System.EventHandler(this.ToolStripBtnMonthHours_Click);
         // 
         // ToolStripBtnDateTimePick
         // 
         this.ToolStripBtnDateTimePick.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnDateTimePick.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnDateTimePick.Image")));
         this.ToolStripBtnDateTimePick.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnDateTimePick.Name = "ToolStripBtnDateTimePick";
         this.ToolStripBtnDateTimePick.Size = new System.Drawing.Size(36, 36);
         this.ToolStripBtnDateTimePick.Text = "Calendrier (Ctrl + C)";
         this.ToolStripBtnDateTimePick.Click += new System.EventHandler(this.ToolStripBtnDateTimePick_Click);
         // 
         // PanelHeader
         // 
         this.PanelHeader.BackColor = System.Drawing.SystemColors.ActiveBorder;
         this.PanelHeader.Controls.Add(this.LblHeader);
         this.PanelHeader.Dock = System.Windows.Forms.DockStyle.Top;
         this.PanelHeader.Location = new System.Drawing.Point(3, 3);
         this.PanelHeader.Name = "PanelHeader";
         this.PanelHeader.Size = new System.Drawing.Size(1174, 30);
         this.PanelHeader.TabIndex = 59;
         // 
         // LblHeader
         // 
         this.LblHeader.AutoSize = true;
         this.LblHeader.Dock = System.Windows.Forms.DockStyle.Left;
         this.LblHeader.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F);
         this.LblHeader.ForeColor = System.Drawing.Color.White;
         this.LblHeader.Location = new System.Drawing.Point(0, 0);
         this.LblHeader.Name = "LblHeader";
         this.LblHeader.Size = new System.Drawing.Size(108, 25);
         this.LblHeader.TabIndex = 43;
         this.LblHeader.Text = "Statistiques";
         // 
         // StatsUC
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.PanelStats);
         this.Controls.Add(this.PanelHeader);
         this.ForeColor = System.Drawing.Color.Black;
         this.Name = "StatsUC";
         this.Padding = new System.Windows.Forms.Padding(3);
         this.Size = new System.Drawing.Size(1180, 561);
         this.PanelStats.ResumeLayout(false);
         this.PanelStats.PerformLayout();
         this.ToolStripMonthSumHours.ResumeLayout(false);
         this.ToolStripMonthSumHours.PerformLayout();
         this.PanelHeader.ResumeLayout(false);
         this.PanelHeader.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel PanelStats;
      private System.Windows.Forms.Panel PanelHeader;
      private System.Windows.Forms.Label LblHeader;
      private System.Windows.Forms.ToolStrip ToolStripMonthSumHours;
      private System.Windows.Forms.ToolStripLabel toolStripLabel1;
      private System.Windows.Forms.ToolStripButton ToolStripBtnMonthHours;
      private System.Windows.Forms.ToolStripButton ToolStripBtnDateTimePick;
      private CustomDateTimePicker CustomDateTimePickerCtrl;
   }
}
