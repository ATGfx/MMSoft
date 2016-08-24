namespace MMSoft
{
   partial class JobsCorrectionUC
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JobsCorrectionUC));
         this.ToolStripJobCorrectionFooter = new System.Windows.Forms.ToolStrip();
         this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
         this.ToolStripLblSumHours = new System.Windows.Forms.ToolStripLabel();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
         this.ToolStripLblSumHoursCorrected = new System.Windows.Forms.ToolStripLabel();
         this.JobCorrectionToolStrip = new System.Windows.Forms.ToolStrip();
         this.ToolStripBtnPreviousMonth = new System.Windows.Forms.ToolStripButton();
         this.ToolStripBtnNextMonth = new System.Windows.Forms.ToolStripButton();
         this.ToolStripBtnDTPFrom = new System.Windows.Forms.ToolStripButton();
         this.ToolStripBtnDTPTo = new System.Windows.Forms.ToolStripButton();
         this.CustomDTPTo = new MMSoft.CustomDateTimePicker();
         this.CustomDTPFrom = new MMSoft.CustomDateTimePicker();
         this.DBListViewJobs = new MMSoft.DBListView();
         this.ToolStripJobCorrectionFooter.SuspendLayout();
         this.JobCorrectionToolStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // ToolStripJobCorrectionFooter
         // 
         this.ToolStripJobCorrectionFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.ToolStripJobCorrectionFooter.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this.ToolStripJobCorrectionFooter.ImageScalingSize = new System.Drawing.Size(32, 32);
         this.ToolStripJobCorrectionFooter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.ToolStripLblSumHours,
            this.toolStripSeparator1,
            this.toolStripLabel3,
            this.ToolStripLblSumHoursCorrected});
         this.ToolStripJobCorrectionFooter.Location = new System.Drawing.Point(3, 541);
         this.ToolStripJobCorrectionFooter.Name = "ToolStripJobCorrectionFooter";
         this.ToolStripJobCorrectionFooter.Size = new System.Drawing.Size(1418, 25);
         this.ToolStripJobCorrectionFooter.TabIndex = 0;
         this.ToolStripJobCorrectionFooter.Text = "toolStrip1";
         // 
         // toolStripLabel1
         // 
         this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.toolStripLabel1.Name = "toolStripLabel1";
         this.toolStripLabel1.Size = new System.Drawing.Size(161, 22);
         this.toolStripLabel1.Text = "Somme des heures :";
         // 
         // ToolStripLblSumHours
         // 
         this.ToolStripLblSumHours.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.ToolStripLblSumHours.Name = "ToolStripLblSumHours";
         this.ToolStripLblSumHours.Size = new System.Drawing.Size(19, 22);
         this.ToolStripLblSumHours.Text = "0";
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
         // 
         // toolStripLabel3
         // 
         this.toolStripLabel3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.toolStripLabel3.Name = "toolStripLabel3";
         this.toolStripLabel3.Size = new System.Drawing.Size(235, 22);
         this.toolStripLabel3.Text = "Somme des heures corrigées :";
         // 
         // ToolStripLblSumHoursCorrected
         // 
         this.ToolStripLblSumHoursCorrected.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.ToolStripLblSumHoursCorrected.Name = "ToolStripLblSumHoursCorrected";
         this.ToolStripLblSumHoursCorrected.Size = new System.Drawing.Size(19, 22);
         this.ToolStripLblSumHoursCorrected.Text = "0";
         // 
         // JobCorrectionToolStrip
         // 
         this.JobCorrectionToolStrip.AutoSize = false;
         this.JobCorrectionToolStrip.BackColor = System.Drawing.SystemColors.ActiveBorder;
         this.JobCorrectionToolStrip.Dock = System.Windows.Forms.DockStyle.None;
         this.JobCorrectionToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
         this.JobCorrectionToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripBtnPreviousMonth,
            this.ToolStripBtnNextMonth,
            this.ToolStripBtnDTPFrom,
            this.ToolStripBtnDTPTo});
         this.JobCorrectionToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
         this.JobCorrectionToolStrip.Location = new System.Drawing.Point(14, 66);
         this.JobCorrectionToolStrip.Name = "JobCorrectionToolStrip";
         this.JobCorrectionToolStrip.Size = new System.Drawing.Size(522, 43);
         this.JobCorrectionToolStrip.TabIndex = 65;
         this.JobCorrectionToolStrip.Text = "toolStrip1";
         // 
         // ToolStripBtnPreviousMonth
         // 
         this.ToolStripBtnPreviousMonth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnPreviousMonth.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnPreviousMonth.Image")));
         this.ToolStripBtnPreviousMonth.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnPreviousMonth.Name = "ToolStripBtnPreviousMonth";
         this.ToolStripBtnPreviousMonth.Size = new System.Drawing.Size(36, 36);
         this.ToolStripBtnPreviousMonth.Text = "Mois précédent";
         this.ToolStripBtnPreviousMonth.Click += new System.EventHandler(this.ToolStripBtnPreviousMonth_Click);
         // 
         // ToolStripBtnNextMonth
         // 
         this.ToolStripBtnNextMonth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnNextMonth.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnNextMonth.Image")));
         this.ToolStripBtnNextMonth.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnNextMonth.Name = "ToolStripBtnNextMonth";
         this.ToolStripBtnNextMonth.Size = new System.Drawing.Size(36, 36);
         this.ToolStripBtnNextMonth.Text = "Mois suivant";
         this.ToolStripBtnNextMonth.Click += new System.EventHandler(this.ToolStripBtnNextMonth_Click);
         // 
         // ToolStripBtnDTPFrom
         // 
         this.ToolStripBtnDTPFrom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnDTPFrom.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnDTPFrom.Image")));
         this.ToolStripBtnDTPFrom.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnDTPFrom.Name = "ToolStripBtnDTPFrom";
         this.ToolStripBtnDTPFrom.Size = new System.Drawing.Size(36, 36);
         this.ToolStripBtnDTPFrom.Text = "Calendrier date de début ";
         this.ToolStripBtnDTPFrom.Click += new System.EventHandler(this.ToolStripBtnDTPFrom_Click);
         // 
         // ToolStripBtnDTPTo
         // 
         this.ToolStripBtnDTPTo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnDTPTo.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnDTPTo.Image")));
         this.ToolStripBtnDTPTo.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnDTPTo.Name = "ToolStripBtnDTPTo";
         this.ToolStripBtnDTPTo.Size = new System.Drawing.Size(36, 36);
         this.ToolStripBtnDTPTo.Text = "Calendrier date de fin";
         this.ToolStripBtnDTPTo.Click += new System.EventHandler(this.ToolStripBtnDTPTo_Click);
         // 
         // CustomDTPTo
         // 
         this.CustomDTPTo.BackColor = System.Drawing.SystemColors.ControlDark;
         this.CustomDTPTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.CustomDTPTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
         this.CustomDTPTo.Location = new System.Drawing.Point(92, 144);
         this.CustomDTPTo.Name = "CustomDTPTo";
         this.CustomDTPTo.Size = new System.Drawing.Size(118, 26);
         this.CustomDTPTo.TabIndex = 67;
         this.CustomDTPTo.ValueChanged += new System.EventHandler(this.DateChanged);
         // 
         // CustomDTPFrom
         // 
         this.CustomDTPFrom.BackColor = System.Drawing.SystemColors.ControlDark;
         this.CustomDTPFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.CustomDTPFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
         this.CustomDTPFrom.Location = new System.Drawing.Point(92, 112);
         this.CustomDTPFrom.Name = "CustomDTPFrom";
         this.CustomDTPFrom.Size = new System.Drawing.Size(118, 26);
         this.CustomDTPFrom.TabIndex = 66;
         this.CustomDTPFrom.ValueChanged += new System.EventHandler(this.DateChanged);
         // 
         // DBListViewJobs
         // 
         this.DBListViewJobs.AllowMultipleSelecion = false;
         this.DBListViewJobs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
         this.DBListViewJobs.Dock = System.Windows.Forms.DockStyle.Fill;
         this.DBListViewJobs.ListTitle = "List";
         this.DBListViewJobs.Location = new System.Drawing.Point(3, 3);
         this.DBListViewJobs.Margin = new System.Windows.Forms.Padding(0);
         this.DBListViewJobs.Name = "DBListViewJobs";
         this.DBListViewJobs.Size = new System.Drawing.Size(1418, 538);
         this.DBListViewJobs.TabIndex = 61;
         // 
         // JobsCorrectionUC
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.CustomDTPTo);
         this.Controls.Add(this.CustomDTPFrom);
         this.Controls.Add(this.JobCorrectionToolStrip);
         this.Controls.Add(this.DBListViewJobs);
         this.Controls.Add(this.ToolStripJobCorrectionFooter);
         this.Name = "JobsCorrectionUC";
         this.Padding = new System.Windows.Forms.Padding(3);
         this.Size = new System.Drawing.Size(1424, 569);
         this.ToolStripJobCorrectionFooter.ResumeLayout(false);
         this.ToolStripJobCorrectionFooter.PerformLayout();
         this.JobCorrectionToolStrip.ResumeLayout(false);
         this.JobCorrectionToolStrip.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DBListView DBListViewJobs;
      private System.Windows.Forms.ToolStrip ToolStripJobCorrectionFooter;
      private System.Windows.Forms.ToolStripLabel toolStripLabel1;
      private System.Windows.Forms.ToolStripLabel ToolStripLblSumHours;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripLabel toolStripLabel3;
      private System.Windows.Forms.ToolStripLabel ToolStripLblSumHoursCorrected;
      private CustomDateTimePicker CustomDTPTo;
      private CustomDateTimePicker CustomDTPFrom;
      private System.Windows.Forms.ToolStrip JobCorrectionToolStrip;
      private System.Windows.Forms.ToolStripButton ToolStripBtnPreviousMonth;
      private System.Windows.Forms.ToolStripButton ToolStripBtnNextMonth;
      private System.Windows.Forms.ToolStripButton ToolStripBtnDTPFrom;
      private System.Windows.Forms.ToolStripButton ToolStripBtnDTPTo;
   }
}
