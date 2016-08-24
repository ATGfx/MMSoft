namespace MMSoft
{
   partial class JobsState
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JobsState));
         this.MainFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
         this.splitContainer1 = new System.Windows.Forms.SplitContainer();
         this.ToolStripStatusFilter = new System.Windows.Forms.ToolStrip();
         this.ToolStripBtnRecorded = new System.Windows.Forms.ToolStripButton();
         this.ToolStripBtnInProgress = new System.Windows.Forms.ToolStripButton();
         this.ToolStripBtnDone = new System.Windows.Forms.ToolStripButton();
         this.ToolStripBtnSent = new System.Windows.Forms.ToolStripButton();
         this.ToolStripBtnBilled = new System.Windows.Forms.ToolStripButton();
         this.PanelFilterHeader = new System.Windows.Forms.Panel();
         this.label = new System.Windows.Forms.Label();
         this.ToolStripJobInfos1 = new System.Windows.Forms.ToolStrip();
         this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
         this.ToolStripTxtRefNumber = new System.Windows.Forms.ToolStripTextBox();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.toolStripLabel7 = new System.Windows.Forms.ToolStripLabel();
         this.ToolStripTxtClient = new System.Windows.Forms.ToolStripTextBox();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
         this.ToolStripTxtJobNb = new System.Windows.Forms.ToolStripTextBox();
         this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
         this.toolStripLabel9 = new System.Windows.Forms.ToolStripLabel();
         this.ToolStripTxtJobLib = new System.Windows.Forms.ToolStripTextBox();
         this.PanelJobLifeCycleHeader = new System.Windows.Forms.Panel();
         this.label1 = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         this.ToolStripStatusFilter.SuspendLayout();
         this.PanelFilterHeader.SuspendLayout();
         this.ToolStripJobInfos1.SuspendLayout();
         this.PanelJobLifeCycleHeader.SuspendLayout();
         this.SuspendLayout();
         // 
         // MainFlowLayoutPanel
         // 
         this.MainFlowLayoutPanel.AutoScroll = true;
         this.MainFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
         this.MainFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
         this.MainFlowLayoutPanel.Location = new System.Drawing.Point(3, 33);
         this.MainFlowLayoutPanel.Name = "MainFlowLayoutPanel";
         this.MainFlowLayoutPanel.Size = new System.Drawing.Size(1299, 439);
         this.MainFlowLayoutPanel.TabIndex = 0;
         this.MainFlowLayoutPanel.WrapContents = false;
         this.MainFlowLayoutPanel.Resize += new System.EventHandler(this.MainFlowLayoutPanel_Resize);
         // 
         // splitContainer1
         // 
         this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer1.Location = new System.Drawing.Point(0, 0);
         this.splitContainer1.Name = "splitContainer1";
         // 
         // splitContainer1.Panel1
         // 
         this.splitContainer1.Panel1.Controls.Add(this.ToolStripStatusFilter);
         this.splitContainer1.Panel1.Controls.Add(this.PanelFilterHeader);
         this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(3);
         // 
         // splitContainer1.Panel2
         // 
         this.splitContainer1.Panel2.Controls.Add(this.MainFlowLayoutPanel);
         this.splitContainer1.Panel2.Controls.Add(this.ToolStripJobInfos1);
         this.splitContainer1.Panel2.Controls.Add(this.PanelJobLifeCycleHeader);
         this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(3);
         this.splitContainer1.Size = new System.Drawing.Size(1389, 502);
         this.splitContainer1.SplitterDistance = 80;
         this.splitContainer1.TabIndex = 1;
         // 
         // ToolStripStatusFilter
         // 
         this.ToolStripStatusFilter.Dock = System.Windows.Forms.DockStyle.Fill;
         this.ToolStripStatusFilter.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this.ToolStripStatusFilter.ImageScalingSize = new System.Drawing.Size(48, 48);
         this.ToolStripStatusFilter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripBtnRecorded,
            this.ToolStripBtnInProgress,
            this.ToolStripBtnDone,
            this.ToolStripBtnSent,
            this.ToolStripBtnBilled});
         this.ToolStripStatusFilter.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
         this.ToolStripStatusFilter.Location = new System.Drawing.Point(3, 33);
         this.ToolStripStatusFilter.Name = "ToolStripStatusFilter";
         this.ToolStripStatusFilter.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
         this.ToolStripStatusFilter.Size = new System.Drawing.Size(74, 466);
         this.ToolStripStatusFilter.TabIndex = 60;
         this.ToolStripStatusFilter.Text = "toolStrip1";
         // 
         // ToolStripBtnRecorded
         // 
         this.ToolStripBtnRecorded.Checked = true;
         this.ToolStripBtnRecorded.CheckState = System.Windows.Forms.CheckState.Checked;
         this.ToolStripBtnRecorded.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnRecorded.Image")));
         this.ToolStripBtnRecorded.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnRecorded.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
         this.ToolStripBtnRecorded.Name = "ToolStripBtnRecorded";
         this.ToolStripBtnRecorded.Size = new System.Drawing.Size(69, 67);
         this.ToolStripBtnRecorded.Tag = "1";
         this.ToolStripBtnRecorded.Text = "Enregistré";
         this.ToolStripBtnRecorded.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
         this.ToolStripBtnRecorded.Visible = false;
         this.ToolStripBtnRecorded.Click += new System.EventHandler(this.FilterStatusChanged);
         // 
         // ToolStripBtnInProgress
         // 
         this.ToolStripBtnInProgress.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnInProgress.Image")));
         this.ToolStripBtnInProgress.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnInProgress.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
         this.ToolStripBtnInProgress.Name = "ToolStripBtnInProgress";
         this.ToolStripBtnInProgress.Size = new System.Drawing.Size(69, 67);
         this.ToolStripBtnInProgress.Tag = "2";
         this.ToolStripBtnInProgress.Text = "En cours";
         this.ToolStripBtnInProgress.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
         this.ToolStripBtnInProgress.Visible = false;
         this.ToolStripBtnInProgress.Click += new System.EventHandler(this.FilterStatusChanged);
         // 
         // ToolStripBtnDone
         // 
         this.ToolStripBtnDone.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnDone.Image")));
         this.ToolStripBtnDone.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnDone.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
         this.ToolStripBtnDone.Name = "ToolStripBtnDone";
         this.ToolStripBtnDone.Size = new System.Drawing.Size(69, 67);
         this.ToolStripBtnDone.Tag = "3";
         this.ToolStripBtnDone.Text = "Clôturé";
         this.ToolStripBtnDone.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
         this.ToolStripBtnDone.Click += new System.EventHandler(this.FilterStatusChanged);
         // 
         // ToolStripBtnSent
         // 
         this.ToolStripBtnSent.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnSent.Image")));
         this.ToolStripBtnSent.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnSent.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
         this.ToolStripBtnSent.Name = "ToolStripBtnSent";
         this.ToolStripBtnSent.Size = new System.Drawing.Size(69, 67);
         this.ToolStripBtnSent.Tag = "4";
         this.ToolStripBtnSent.Text = "Livré";
         this.ToolStripBtnSent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
         this.ToolStripBtnSent.Click += new System.EventHandler(this.FilterStatusChanged);
         // 
         // ToolStripBtnBilled
         // 
         this.ToolStripBtnBilled.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnBilled.Image")));
         this.ToolStripBtnBilled.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnBilled.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
         this.ToolStripBtnBilled.Name = "ToolStripBtnBilled";
         this.ToolStripBtnBilled.Size = new System.Drawing.Size(69, 67);
         this.ToolStripBtnBilled.Tag = "5";
         this.ToolStripBtnBilled.Text = "Facturé";
         this.ToolStripBtnBilled.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
         this.ToolStripBtnBilled.Click += new System.EventHandler(this.FilterStatusChanged);
         // 
         // PanelFilterHeader
         // 
         this.PanelFilterHeader.BackColor = System.Drawing.SystemColors.ActiveBorder;
         this.PanelFilterHeader.Controls.Add(this.label);
         this.PanelFilterHeader.Dock = System.Windows.Forms.DockStyle.Top;
         this.PanelFilterHeader.Location = new System.Drawing.Point(3, 3);
         this.PanelFilterHeader.Name = "PanelFilterHeader";
         this.PanelFilterHeader.Size = new System.Drawing.Size(74, 30);
         this.PanelFilterHeader.TabIndex = 59;
         // 
         // label
         // 
         this.label.AutoSize = true;
         this.label.Dock = System.Windows.Forms.DockStyle.Left;
         this.label.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F);
         this.label.ForeColor = System.Drawing.Color.White;
         this.label.Location = new System.Drawing.Point(0, 0);
         this.label.Name = "label";
         this.label.Size = new System.Drawing.Size(54, 25);
         this.label.TabIndex = 43;
         this.label.Text = "Filtre";
         // 
         // ToolStripJobInfos1
         // 
         this.ToolStripJobInfos1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
         this.ToolStripJobInfos1.CanOverflow = false;
         this.ToolStripJobInfos1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.ToolStripJobInfos1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this.ToolStripJobInfos1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.ToolStripTxtRefNumber,
            this.toolStripSeparator1,
            this.toolStripLabel7,
            this.ToolStripTxtClient,
            this.toolStripSeparator2,
            this.toolStripLabel6,
            this.ToolStripTxtJobNb,
            this.toolStripSeparator3,
            this.toolStripLabel9,
            this.ToolStripTxtJobLib});
         this.ToolStripJobInfos1.Location = new System.Drawing.Point(3, 472);
         this.ToolStripJobInfos1.Name = "ToolStripJobInfos1";
         this.ToolStripJobInfos1.Padding = new System.Windows.Forms.Padding(2);
         this.ToolStripJobInfos1.Size = new System.Drawing.Size(1299, 27);
         this.ToolStripJobInfos1.TabIndex = 60;
         this.ToolStripJobInfos1.Text = "toolStrip1";
         // 
         // toolStripLabel1
         // 
         this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.toolStripLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.toolStripLabel1.Name = "toolStripLabel1";
         this.toolStripLabel1.Size = new System.Drawing.Size(93, 20);
         this.toolStripLabel1.Text = "N° ref. interne :";
         // 
         // ToolStripTxtRefNumber
         // 
         this.ToolStripTxtRefNumber.BackColor = System.Drawing.Color.Gainsboro;
         this.ToolStripTxtRefNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.ToolStripTxtRefNumber.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.ToolStripTxtRefNumber.Name = "ToolStripTxtRefNumber";
         this.ToolStripTxtRefNumber.Size = new System.Drawing.Size(100, 23);
         this.ToolStripTxtRefNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.ToolStripTxtRefNumber.TextChanged += new System.EventHandler(this.Filter);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
         // 
         // toolStripLabel7
         // 
         this.toolStripLabel7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.toolStripLabel7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.toolStripLabel7.Name = "toolStripLabel7";
         this.toolStripLabel7.Size = new System.Drawing.Size(45, 20);
         this.toolStripLabel7.Text = "Client :";
         // 
         // ToolStripTxtClient
         // 
         this.ToolStripTxtClient.BackColor = System.Drawing.Color.Gainsboro;
         this.ToolStripTxtClient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.ToolStripTxtClient.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.ToolStripTxtClient.Name = "ToolStripTxtClient";
         this.ToolStripTxtClient.Size = new System.Drawing.Size(200, 23);
         this.ToolStripTxtClient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.ToolStripTxtClient.TextChanged += new System.EventHandler(this.Filter);
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
         // 
         // toolStripLabel6
         // 
         this.toolStripLabel6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.toolStripLabel6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.toolStripLabel6.Name = "toolStripLabel6";
         this.toolStripLabel6.Size = new System.Drawing.Size(41, 20);
         this.toolStripLabel6.Text = "Job n°";
         // 
         // ToolStripTxtJobNb
         // 
         this.ToolStripTxtJobNb.BackColor = System.Drawing.Color.Gainsboro;
         this.ToolStripTxtJobNb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.ToolStripTxtJobNb.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.ToolStripTxtJobNb.Name = "ToolStripTxtJobNb";
         this.ToolStripTxtJobNb.Size = new System.Drawing.Size(40, 23);
         this.ToolStripTxtJobNb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.ToolStripTxtJobNb.TextChanged += new System.EventHandler(this.Filter);
         // 
         // toolStripSeparator3
         // 
         this.toolStripSeparator3.Name = "toolStripSeparator3";
         this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
         // 
         // toolStripLabel9
         // 
         this.toolStripLabel9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.toolStripLabel9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.toolStripLabel9.Name = "toolStripLabel9";
         this.toolStripLabel9.Size = new System.Drawing.Size(49, 20);
         this.toolStripLabel9.Text = "Libellé :";
         // 
         // ToolStripTxtJobLib
         // 
         this.ToolStripTxtJobLib.BackColor = System.Drawing.Color.Gainsboro;
         this.ToolStripTxtJobLib.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.ToolStripTxtJobLib.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
         this.ToolStripTxtJobLib.Name = "ToolStripTxtJobLib";
         this.ToolStripTxtJobLib.Size = new System.Drawing.Size(600, 23);
         this.ToolStripTxtJobLib.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.ToolStripTxtJobLib.TextChanged += new System.EventHandler(this.Filter);
         // 
         // PanelJobLifeCycleHeader
         // 
         this.PanelJobLifeCycleHeader.BackColor = System.Drawing.SystemColors.ActiveBorder;
         this.PanelJobLifeCycleHeader.Controls.Add(this.label1);
         this.PanelJobLifeCycleHeader.Dock = System.Windows.Forms.DockStyle.Top;
         this.PanelJobLifeCycleHeader.Location = new System.Drawing.Point(3, 3);
         this.PanelJobLifeCycleHeader.Name = "PanelJobLifeCycleHeader";
         this.PanelJobLifeCycleHeader.Size = new System.Drawing.Size(1299, 30);
         this.PanelJobLifeCycleHeader.TabIndex = 59;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Dock = System.Windows.Forms.DockStyle.Left;
         this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F);
         this.label1.ForeColor = System.Drawing.Color.White;
         this.label1.Location = new System.Drawing.Point(0, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(186, 25);
         this.label1.TabIndex = 43;
         this.label1.Text = "Cycle de vie des jobs";
         // 
         // JobsState
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.splitContainer1);
         this.Name = "JobsState";
         this.Size = new System.Drawing.Size(1389, 502);
         this.splitContainer1.Panel1.ResumeLayout(false);
         this.splitContainer1.Panel1.PerformLayout();
         this.splitContainer1.Panel2.ResumeLayout(false);
         this.splitContainer1.Panel2.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
         this.splitContainer1.ResumeLayout(false);
         this.ToolStripStatusFilter.ResumeLayout(false);
         this.ToolStripStatusFilter.PerformLayout();
         this.PanelFilterHeader.ResumeLayout(false);
         this.PanelFilterHeader.PerformLayout();
         this.ToolStripJobInfos1.ResumeLayout(false);
         this.ToolStripJobInfos1.PerformLayout();
         this.PanelJobLifeCycleHeader.ResumeLayout(false);
         this.PanelJobLifeCycleHeader.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.FlowLayoutPanel MainFlowLayoutPanel;
      private System.Windows.Forms.SplitContainer splitContainer1;
      private System.Windows.Forms.Panel PanelFilterHeader;
      private System.Windows.Forms.Label label;
      private System.Windows.Forms.Panel PanelJobLifeCycleHeader;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.ToolStrip ToolStripStatusFilter;
      private System.Windows.Forms.ToolStripButton ToolStripBtnRecorded;
      private System.Windows.Forms.ToolStripButton ToolStripBtnInProgress;
      private System.Windows.Forms.ToolStripButton ToolStripBtnDone;
      private System.Windows.Forms.ToolStripButton ToolStripBtnSent;
      private System.Windows.Forms.ToolStripButton ToolStripBtnBilled;
      private System.Windows.Forms.ToolStrip ToolStripJobInfos1;
      private System.Windows.Forms.ToolStripLabel toolStripLabel1;
      private System.Windows.Forms.ToolStripTextBox ToolStripTxtRefNumber;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripLabel toolStripLabel7;
      private System.Windows.Forms.ToolStripTextBox ToolStripTxtClient;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripLabel toolStripLabel6;
      private System.Windows.Forms.ToolStripTextBox ToolStripTxtJobNb;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
      private System.Windows.Forms.ToolStripLabel toolStripLabel9;
      private System.Windows.Forms.ToolStripTextBox ToolStripTxtJobLib;
   }
}
