namespace MMSoft
{
   partial class DayCheckingViewer
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DayCheckingViewer));
         this.PanelCheckings = new System.Windows.Forms.Panel();
         this.CustomDateTimePickerCtrl = new MMSoft.CustomDateTimePicker();
         this.FormCheckingToolStrip = new System.Windows.Forms.ToolStrip();
         this.ToolStripBtnFastDayBack = new System.Windows.Forms.ToolStripButton();
         this.ToolStripBtnDayBack = new System.Windows.Forms.ToolStripButton();
         this.ToolStripBtnDayFwd = new System.Windows.Forms.ToolStripButton();
         this.ToolStripBtnDayFastFwd = new System.Windows.Forms.ToolStripButton();
         this.ToolStripBtnDateTimePick = new System.Windows.Forms.ToolStripButton();
         this.ToolStripBtnEdit = new System.Windows.Forms.ToolStripButton();
         this.ToolStripBtnDelete = new System.Windows.Forms.ToolStripButton();
         this.DBListViewCheckings = new MMSoft.DBListView();
         this.PanelFooter = new System.Windows.Forms.Panel();
         this.LblSumHours = new System.Windows.Forms.Label();
         this.LblSumHoursLbl = new System.Windows.Forms.Label();
         this.PanelFooterPadding = new System.Windows.Forms.Panel();
         this.PanelCheckings.SuspendLayout();
         this.FormCheckingToolStrip.SuspendLayout();
         this.PanelFooter.SuspendLayout();
         this.PanelFooterPadding.SuspendLayout();
         this.SuspendLayout();
         // 
         // PanelCheckings
         // 
         this.PanelCheckings.AutoScroll = true;
         this.PanelCheckings.Controls.Add(this.CustomDateTimePickerCtrl);
         this.PanelCheckings.Controls.Add(this.FormCheckingToolStrip);
         this.PanelCheckings.Controls.Add(this.DBListViewCheckings);
         this.PanelCheckings.Dock = System.Windows.Forms.DockStyle.Fill;
         this.PanelCheckings.Location = new System.Drawing.Point(0, 0);
         this.PanelCheckings.Margin = new System.Windows.Forms.Padding(0);
         this.PanelCheckings.Name = "PanelCheckings";
         this.PanelCheckings.Size = new System.Drawing.Size(1489, 311);
         this.PanelCheckings.TabIndex = 0;
         // 
         // CustomDateTimePickerCtrl
         // 
         this.CustomDateTimePickerCtrl.BackColor = System.Drawing.SystemColors.ControlDark;
         this.CustomDateTimePickerCtrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.CustomDateTimePickerCtrl.Format = System.Windows.Forms.DateTimePickerFormat.Short;
         this.CustomDateTimePickerCtrl.Location = new System.Drawing.Point(895, 227);
         this.CustomDateTimePickerCtrl.Name = "CustomDateTimePickerCtrl";
         this.CustomDateTimePickerCtrl.Size = new System.Drawing.Size(127, 26);
         this.CustomDateTimePickerCtrl.TabIndex = 11;
         this.CustomDateTimePickerCtrl.ValueChanged += new System.EventHandler(this.CustomDateTimePickerCtrl_ValueChanged);
         // 
         // FormCheckingToolStrip
         // 
         this.FormCheckingToolStrip.AutoSize = false;
         this.FormCheckingToolStrip.BackColor = System.Drawing.SystemColors.ActiveBorder;
         this.FormCheckingToolStrip.Dock = System.Windows.Forms.DockStyle.None;
         this.FormCheckingToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
         this.FormCheckingToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripBtnFastDayBack,
            this.ToolStripBtnDayBack,
            this.ToolStripBtnDayFwd,
            this.ToolStripBtnDayFastFwd,
            this.ToolStripBtnDateTimePick,
            this.ToolStripBtnEdit,
            this.ToolStripBtnDelete});
         this.FormCheckingToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
         this.FormCheckingToolStrip.Location = new System.Drawing.Point(638, 181);
         this.FormCheckingToolStrip.Name = "FormCheckingToolStrip";
         this.FormCheckingToolStrip.Size = new System.Drawing.Size(522, 43);
         this.FormCheckingToolStrip.TabIndex = 9;
         this.FormCheckingToolStrip.Text = "toolStrip1";
         // 
         // ToolStripBtnFastDayBack
         // 
         this.ToolStripBtnFastDayBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnFastDayBack.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnFastDayBack.Image")));
         this.ToolStripBtnFastDayBack.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnFastDayBack.Name = "ToolStripBtnFastDayBack";
         this.ToolStripBtnFastDayBack.Size = new System.Drawing.Size(36, 36);
         this.ToolStripBtnFastDayBack.Text = "Semaine précédente (Ctrl + Shift + B)";
         this.ToolStripBtnFastDayBack.Click += new System.EventHandler(this.PreviousWeekToolStripMenuItem_Click);
         // 
         // ToolStripBtnDayBack
         // 
         this.ToolStripBtnDayBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnDayBack.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnDayBack.Image")));
         this.ToolStripBtnDayBack.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnDayBack.Name = "ToolStripBtnDayBack";
         this.ToolStripBtnDayBack.Size = new System.Drawing.Size(36, 36);
         this.ToolStripBtnDayBack.Text = "Jour précédent (Ctrl + B)";
         this.ToolStripBtnDayBack.Click += new System.EventHandler(this.PreviousDayToolStripMenuItem_Click);
         // 
         // ToolStripBtnDayFwd
         // 
         this.ToolStripBtnDayFwd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnDayFwd.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnDayFwd.Image")));
         this.ToolStripBtnDayFwd.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnDayFwd.Name = "ToolStripBtnDayFwd";
         this.ToolStripBtnDayFwd.Size = new System.Drawing.Size(36, 36);
         this.ToolStripBtnDayFwd.Text = "Jour suivant (Ctrl + F)";
         this.ToolStripBtnDayFwd.Click += new System.EventHandler(this.NextDayToolStripMenuItem_Click);
         // 
         // ToolStripBtnDayFastFwd
         // 
         this.ToolStripBtnDayFastFwd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnDayFastFwd.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnDayFastFwd.Image")));
         this.ToolStripBtnDayFastFwd.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnDayFastFwd.Name = "ToolStripBtnDayFastFwd";
         this.ToolStripBtnDayFastFwd.Size = new System.Drawing.Size(36, 36);
         this.ToolStripBtnDayFastFwd.Text = "Semaine suivante (Ctrl + Shift + F)";
         this.ToolStripBtnDayFastFwd.Click += new System.EventHandler(this.NextWeekToolStripMenuItem_Click);
         // 
         // ToolStripBtnDateTimePick
         // 
         this.ToolStripBtnDateTimePick.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnDateTimePick.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnDateTimePick.Image")));
         this.ToolStripBtnDateTimePick.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnDateTimePick.Name = "ToolStripBtnDateTimePick";
         this.ToolStripBtnDateTimePick.Size = new System.Drawing.Size(36, 36);
         this.ToolStripBtnDateTimePick.Text = "Calendrier (Ctrl + C)";
         this.ToolStripBtnDateTimePick.Click += new System.EventHandler(this.CalendarToolStripMenuItem_Click);
         // 
         // ToolStripBtnEdit
         // 
         this.ToolStripBtnEdit.BackColor = System.Drawing.Color.Transparent;
         this.ToolStripBtnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnEdit.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnEdit.Image")));
         this.ToolStripBtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnEdit.Name = "ToolStripBtnEdit";
         this.ToolStripBtnEdit.Size = new System.Drawing.Size(36, 36);
         this.ToolStripBtnEdit.Text = "Modifier";
         this.ToolStripBtnEdit.Click += new System.EventHandler(this.ToolStripBtnEdit_Click);
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
         // DBListViewCheckings
         // 
         this.DBListViewCheckings.AllowMultipleSelecion = false;
         this.DBListViewCheckings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
         this.DBListViewCheckings.Dock = System.Windows.Forms.DockStyle.Fill;
         this.DBListViewCheckings.ListTitle = "List";
         this.DBListViewCheckings.Location = new System.Drawing.Point(0, 0);
         this.DBListViewCheckings.Margin = new System.Windows.Forms.Padding(0);
         this.DBListViewCheckings.Name = "DBListViewCheckings";
         this.DBListViewCheckings.Size = new System.Drawing.Size(1489, 311);
         this.DBListViewCheckings.TabIndex = 0;
         // 
         // PanelFooter
         // 
         this.PanelFooter.Controls.Add(this.LblSumHours);
         this.PanelFooter.Controls.Add(this.LblSumHoursLbl);
         this.PanelFooter.Dock = System.Windows.Forms.DockStyle.Fill;
         this.PanelFooter.Location = new System.Drawing.Point(0, 1);
         this.PanelFooter.Margin = new System.Windows.Forms.Padding(0);
         this.PanelFooter.Name = "PanelFooter";
         this.PanelFooter.Size = new System.Drawing.Size(1489, 49);
         this.PanelFooter.TabIndex = 3;
         // 
         // LblSumHours
         // 
         this.LblSumHours.AutoSize = true;
         this.LblSumHours.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.LblSumHours.Location = new System.Drawing.Point(168, 8);
         this.LblSumHours.Name = "LblSumHours";
         this.LblSumHours.Size = new System.Drawing.Size(37, 30);
         this.LblSumHours.TabIndex = 1;
         this.LblSumHours.Text = "XX";
         this.LblSumHours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // LblSumHoursLbl
         // 
         this.LblSumHoursLbl.AutoSize = true;
         this.LblSumHoursLbl.Font = new System.Drawing.Font("Segoe UI Symbol", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.LblSumHoursLbl.Location = new System.Drawing.Point(3, 8);
         this.LblSumHoursLbl.Name = "LblSumHoursLbl";
         this.LblSumHoursLbl.Size = new System.Drawing.Size(174, 30);
         this.LblSumHoursLbl.TabIndex = 0;
         this.LblSumHoursLbl.Text = "Heures pointées :";
         this.LblSumHoursLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // PanelFooterPadding
         // 
         this.PanelFooterPadding.Controls.Add(this.PanelFooter);
         this.PanelFooterPadding.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.PanelFooterPadding.Location = new System.Drawing.Point(0, 311);
         this.PanelFooterPadding.Name = "PanelFooterPadding";
         this.PanelFooterPadding.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
         this.PanelFooterPadding.Size = new System.Drawing.Size(1489, 50);
         this.PanelFooterPadding.TabIndex = 5;
         // 
         // DayCheckingViewer
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.PanelCheckings);
         this.Controls.Add(this.PanelFooterPadding);
         this.Name = "DayCheckingViewer";
         this.Size = new System.Drawing.Size(1489, 361);
         this.PanelCheckings.ResumeLayout(false);
         this.FormCheckingToolStrip.ResumeLayout(false);
         this.FormCheckingToolStrip.PerformLayout();
         this.PanelFooter.ResumeLayout(false);
         this.PanelFooter.PerformLayout();
         this.PanelFooterPadding.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel PanelCheckings;
      private System.Windows.Forms.Panel PanelFooter;
      private System.Windows.Forms.Label LblSumHours;
      private System.Windows.Forms.Label LblSumHoursLbl;
      private System.Windows.Forms.Panel PanelFooterPadding;
      private DBListView DBListViewCheckings;
      private System.Windows.Forms.ToolStrip FormCheckingToolStrip;
      private System.Windows.Forms.ToolStripButton ToolStripBtnFastDayBack;
      private System.Windows.Forms.ToolStripButton ToolStripBtnDayBack;
      private System.Windows.Forms.ToolStripButton ToolStripBtnDayFwd;
      private System.Windows.Forms.ToolStripButton ToolStripBtnDayFastFwd;
      private System.Windows.Forms.ToolStripButton ToolStripBtnDateTimePick;
      private CustomDateTimePicker CustomDateTimePickerCtrl;
      private System.Windows.Forms.ToolStripButton ToolStripBtnEdit;
      private System.Windows.Forms.ToolStripButton ToolStripBtnDelete;
   }
}
