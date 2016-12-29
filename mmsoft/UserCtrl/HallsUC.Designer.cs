namespace MMSoft
{
   partial class HallsUC
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HallsUC));
         this.splitContainer1 = new System.Windows.Forms.SplitContainer();
         this.splitContainer3 = new System.Windows.Forms.SplitContainer();
         this.PanelHallList = new System.Windows.Forms.Panel();
         this.PanelEnginesList = new System.Windows.Forms.Panel();
         this.splitContainer2 = new System.Windows.Forms.SplitContainer();
         this.PanelCheckContent = new System.Windows.Forms.Panel();
         this.groupBox4 = new System.Windows.Forms.GroupBox();
         this.label18 = new System.Windows.Forms.Label();
         this.TxtHallName = new System.Windows.Forms.TextBox();
         this.ToolStripHallEditFooter = new System.Windows.Forms.ToolStrip();
         this.ToolStripBtnHallSaveChanges = new System.Windows.Forms.ToolStripButton();
         this.ToolStripBtnHallCancelChanges = new System.Windows.Forms.ToolStripButton();
         this.PanelCheckHeader = new System.Windows.Forms.Panel();
         this.LblHall = new System.Windows.Forms.Label();
         this.PanelJobRecap = new System.Windows.Forms.Panel();
         this.PanelEngineContent = new System.Windows.Forms.Panel();
         this.ToolStipEngineEditFooter = new System.Windows.Forms.ToolStrip();
         this.ToolStripBtnEngineSaveChanges = new System.Windows.Forms.ToolStripButton();
         this.ToolStripBtnEngineCancelChanges = new System.Windows.Forms.ToolStripButton();
         this.PanelEngineHeader = new System.Windows.Forms.Panel();
         this.LblEngine = new System.Windows.Forms.Label();
         this.ToolStripUCHallTools = new System.Windows.Forms.ToolStrip();
         this.ToolStripBtnAddEngine = new System.Windows.Forms.ToolStripButton();
         this.ToolStripBtnAddHall = new System.Windows.Forms.ToolStripButton();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.label2 = new System.Windows.Forms.Label();
         this.label20 = new System.Windows.Forms.Label();
         this.TxtEngineNb = new System.Windows.Forms.TextBox();
         this.label21 = new System.Windows.Forms.Label();
         this.label22 = new System.Windows.Forms.Label();
         this.label19 = new System.Windows.Forms.Label();
         this.TxtEnginePriceH = new System.Windows.Forms.TextBox();
         this.TxtEngineLib = new System.Windows.Forms.TextBox();
         this.CheckBoxEngineProducing = new System.Windows.Forms.CheckBox();
         this.DBListViewHall = new MMSoft.DBListView();
         this.DBListViewEngines = new MMSoft.DBListView();
         this.DBComboxEngineResp = new MMSoft.DBComboBox();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
         this.splitContainer1.Panel1.SuspendLayout();
         this.splitContainer1.Panel2.SuspendLayout();
         this.splitContainer1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
         this.splitContainer3.Panel1.SuspendLayout();
         this.splitContainer3.Panel2.SuspendLayout();
         this.splitContainer3.SuspendLayout();
         this.PanelHallList.SuspendLayout();
         this.PanelEnginesList.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
         this.splitContainer2.Panel1.SuspendLayout();
         this.splitContainer2.Panel2.SuspendLayout();
         this.splitContainer2.SuspendLayout();
         this.PanelCheckContent.SuspendLayout();
         this.groupBox4.SuspendLayout();
         this.ToolStripHallEditFooter.SuspendLayout();
         this.PanelCheckHeader.SuspendLayout();
         this.PanelJobRecap.SuspendLayout();
         this.PanelEngineContent.SuspendLayout();
         this.ToolStipEngineEditFooter.SuspendLayout();
         this.PanelEngineHeader.SuspendLayout();
         this.ToolStripUCHallTools.SuspendLayout();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // splitContainer1
         // 
         this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer1.Location = new System.Drawing.Point(0, 39);
         this.splitContainer1.Name = "splitContainer1";
         // 
         // splitContainer1.Panel1
         // 
         this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
         // 
         // splitContainer1.Panel2
         // 
         this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
         this.splitContainer1.Size = new System.Drawing.Size(1152, 566);
         this.splitContainer1.SplitterDistance = 240;
         this.splitContainer1.TabIndex = 65;
         // 
         // splitContainer3
         // 
         this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer3.Location = new System.Drawing.Point(0, 0);
         this.splitContainer3.Name = "splitContainer3";
         this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // splitContainer3.Panel1
         // 
         this.splitContainer3.Panel1.Controls.Add(this.PanelHallList);
         // 
         // splitContainer3.Panel2
         // 
         this.splitContainer3.Panel2.Controls.Add(this.PanelEnginesList);
         this.splitContainer3.Size = new System.Drawing.Size(240, 566);
         this.splitContainer3.SplitterDistance = 283;
         this.splitContainer3.TabIndex = 62;
         // 
         // PanelHallList
         // 
         this.PanelHallList.Controls.Add(this.DBListViewHall);
         this.PanelHallList.Dock = System.Windows.Forms.DockStyle.Fill;
         this.PanelHallList.Location = new System.Drawing.Point(0, 0);
         this.PanelHallList.Name = "PanelHallList";
         this.PanelHallList.Padding = new System.Windows.Forms.Padding(3);
         this.PanelHallList.Size = new System.Drawing.Size(240, 283);
         this.PanelHallList.TabIndex = 60;
         // 
         // PanelEnginesList
         // 
         this.PanelEnginesList.Controls.Add(this.DBListViewEngines);
         this.PanelEnginesList.Dock = System.Windows.Forms.DockStyle.Fill;
         this.PanelEnginesList.Location = new System.Drawing.Point(0, 0);
         this.PanelEnginesList.Name = "PanelEnginesList";
         this.PanelEnginesList.Padding = new System.Windows.Forms.Padding(3);
         this.PanelEnginesList.Size = new System.Drawing.Size(240, 279);
         this.PanelEnginesList.TabIndex = 61;
         // 
         // splitContainer2
         // 
         this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer2.Location = new System.Drawing.Point(0, 0);
         this.splitContainer2.Name = "splitContainer2";
         this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // splitContainer2.Panel1
         // 
         this.splitContainer2.Panel1.Controls.Add(this.PanelCheckContent);
         this.splitContainer2.Panel1.Controls.Add(this.ToolStripHallEditFooter);
         this.splitContainer2.Panel1.Controls.Add(this.PanelCheckHeader);
         this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(3);
         // 
         // splitContainer2.Panel2
         // 
         this.splitContainer2.Panel2.Controls.Add(this.PanelJobRecap);
         this.splitContainer2.Size = new System.Drawing.Size(908, 566);
         this.splitContainer2.SplitterDistance = 155;
         this.splitContainer2.TabIndex = 63;
         // 
         // PanelCheckContent
         // 
         this.PanelCheckContent.AutoScroll = true;
         this.PanelCheckContent.Controls.Add(this.groupBox4);
         this.PanelCheckContent.Dock = System.Windows.Forms.DockStyle.Fill;
         this.PanelCheckContent.Location = new System.Drawing.Point(3, 33);
         this.PanelCheckContent.Name = "PanelCheckContent";
         this.PanelCheckContent.Padding = new System.Windows.Forms.Padding(3);
         this.PanelCheckContent.Size = new System.Drawing.Size(902, 74);
         this.PanelCheckContent.TabIndex = 59;
         // 
         // groupBox4
         // 
         this.groupBox4.Controls.Add(this.label18);
         this.groupBox4.Controls.Add(this.TxtHallName);
         this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.groupBox4.Location = new System.Drawing.Point(6, 6);
         this.groupBox4.Name = "groupBox4";
         this.groupBox4.Size = new System.Drawing.Size(355, 68);
         this.groupBox4.TabIndex = 102;
         this.groupBox4.TabStop = false;
         this.groupBox4.Text = "Informations générales";
         // 
         // label18
         // 
         this.label18.AutoSize = true;
         this.label18.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label18.Location = new System.Drawing.Point(6, 35);
         this.label18.Name = "label18";
         this.label18.Size = new System.Drawing.Size(44, 17);
         this.label18.TabIndex = 2;
         this.label18.Text = "Nom :";
         // 
         // TxtHallName
         // 
         this.TxtHallName.BackColor = System.Drawing.Color.White;
         this.TxtHallName.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
         this.TxtHallName.Location = new System.Drawing.Point(131, 32);
         this.TxtHallName.Name = "TxtHallName";
         this.TxtHallName.Size = new System.Drawing.Size(209, 25);
         this.TxtHallName.TabIndex = 24;
         this.TxtHallName.TextChanged += new System.EventHandler(this.HallValueChanged);
         // 
         // ToolStripHallEditFooter
         // 
         this.ToolStripHallEditFooter.BackColor = System.Drawing.SystemColors.ButtonShadow;
         this.ToolStripHallEditFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.ToolStripHallEditFooter.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this.ToolStripHallEditFooter.ImageScalingSize = new System.Drawing.Size(32, 32);
         this.ToolStripHallEditFooter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripBtnHallSaveChanges,
            this.ToolStripBtnHallCancelChanges});
         this.ToolStripHallEditFooter.Location = new System.Drawing.Point(3, 107);
         this.ToolStripHallEditFooter.Name = "ToolStripHallEditFooter";
         this.ToolStripHallEditFooter.Padding = new System.Windows.Forms.Padding(3);
         this.ToolStripHallEditFooter.Size = new System.Drawing.Size(902, 45);
         this.ToolStripHallEditFooter.TabIndex = 47;
         this.ToolStripHallEditFooter.Text = "toolStrip1";
         // 
         // ToolStripBtnHallSaveChanges
         // 
         this.ToolStripBtnHallSaveChanges.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnHallSaveChanges.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnHallSaveChanges.Image")));
         this.ToolStripBtnHallSaveChanges.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnHallSaveChanges.Name = "ToolStripBtnHallSaveChanges";
         this.ToolStripBtnHallSaveChanges.Size = new System.Drawing.Size(36, 36);
         this.ToolStripBtnHallSaveChanges.Text = "Save changes";
         this.ToolStripBtnHallSaveChanges.Visible = false;
         this.ToolStripBtnHallSaveChanges.Click += new System.EventHandler(this.ToolStripBtnHallSaveChanges_Click);
         // 
         // ToolStripBtnHallCancelChanges
         // 
         this.ToolStripBtnHallCancelChanges.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnHallCancelChanges.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnHallCancelChanges.Image")));
         this.ToolStripBtnHallCancelChanges.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnHallCancelChanges.Name = "ToolStripBtnHallCancelChanges";
         this.ToolStripBtnHallCancelChanges.Size = new System.Drawing.Size(36, 36);
         this.ToolStripBtnHallCancelChanges.Text = "Cancel changes";
         this.ToolStripBtnHallCancelChanges.Visible = false;
         this.ToolStripBtnHallCancelChanges.Click += new System.EventHandler(this.ToolStripBtnHallCancelChanges_Click);
         // 
         // PanelCheckHeader
         // 
         this.PanelCheckHeader.BackColor = System.Drawing.SystemColors.ActiveBorder;
         this.PanelCheckHeader.Controls.Add(this.LblHall);
         this.PanelCheckHeader.Dock = System.Windows.Forms.DockStyle.Top;
         this.PanelCheckHeader.Location = new System.Drawing.Point(3, 3);
         this.PanelCheckHeader.Name = "PanelCheckHeader";
         this.PanelCheckHeader.Size = new System.Drawing.Size(902, 30);
         this.PanelCheckHeader.TabIndex = 58;
         // 
         // LblHall
         // 
         this.LblHall.AutoSize = true;
         this.LblHall.Dock = System.Windows.Forms.DockStyle.Left;
         this.LblHall.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F);
         this.LblHall.ForeColor = System.Drawing.Color.White;
         this.LblHall.Location = new System.Drawing.Point(0, 0);
         this.LblHall.Name = "LblHall";
         this.LblHall.Size = new System.Drawing.Size(155, 25);
         this.LblHall.TabIndex = 43;
         this.LblHall.Text = "Informations hall";
         // 
         // PanelJobRecap
         // 
         this.PanelJobRecap.Controls.Add(this.PanelEngineContent);
         this.PanelJobRecap.Controls.Add(this.ToolStipEngineEditFooter);
         this.PanelJobRecap.Controls.Add(this.PanelEngineHeader);
         this.PanelJobRecap.Dock = System.Windows.Forms.DockStyle.Fill;
         this.PanelJobRecap.Location = new System.Drawing.Point(0, 0);
         this.PanelJobRecap.Name = "PanelJobRecap";
         this.PanelJobRecap.Padding = new System.Windows.Forms.Padding(3);
         this.PanelJobRecap.Size = new System.Drawing.Size(908, 407);
         this.PanelJobRecap.TabIndex = 62;
         // 
         // PanelEngineContent
         // 
         this.PanelEngineContent.AutoScroll = true;
         this.PanelEngineContent.Controls.Add(this.groupBox1);
         this.PanelEngineContent.Dock = System.Windows.Forms.DockStyle.Fill;
         this.PanelEngineContent.Location = new System.Drawing.Point(3, 33);
         this.PanelEngineContent.Name = "PanelEngineContent";
         this.PanelEngineContent.Padding = new System.Windows.Forms.Padding(3);
         this.PanelEngineContent.Size = new System.Drawing.Size(902, 346);
         this.PanelEngineContent.TabIndex = 60;
         // 
         // ToolStipEngineEditFooter
         // 
         this.ToolStipEngineEditFooter.BackColor = System.Drawing.SystemColors.ButtonShadow;
         this.ToolStipEngineEditFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.ToolStipEngineEditFooter.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this.ToolStipEngineEditFooter.ImageScalingSize = new System.Drawing.Size(32, 32);
         this.ToolStipEngineEditFooter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripBtnEngineSaveChanges,
            this.ToolStripBtnEngineCancelChanges});
         this.ToolStipEngineEditFooter.Location = new System.Drawing.Point(3, 379);
         this.ToolStipEngineEditFooter.Name = "ToolStipEngineEditFooter";
         this.ToolStipEngineEditFooter.Padding = new System.Windows.Forms.Padding(3);
         this.ToolStipEngineEditFooter.Size = new System.Drawing.Size(902, 25);
         this.ToolStipEngineEditFooter.TabIndex = 61;
         this.ToolStipEngineEditFooter.Text = "toolStrip1";
         // 
         // ToolStripBtnEngineSaveChanges
         // 
         this.ToolStripBtnEngineSaveChanges.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnEngineSaveChanges.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnEngineSaveChanges.Image")));
         this.ToolStripBtnEngineSaveChanges.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnEngineSaveChanges.Name = "ToolStripBtnEngineSaveChanges";
         this.ToolStripBtnEngineSaveChanges.Size = new System.Drawing.Size(36, 36);
         this.ToolStripBtnEngineSaveChanges.Text = "Save changes";
         this.ToolStripBtnEngineSaveChanges.Visible = false;
         this.ToolStripBtnEngineSaveChanges.Click += new System.EventHandler(this.ToolStripBtnEngineSaveChanges_Click);
         // 
         // ToolStripBtnEngineCancelChanges
         // 
         this.ToolStripBtnEngineCancelChanges.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnEngineCancelChanges.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnEngineCancelChanges.Image")));
         this.ToolStripBtnEngineCancelChanges.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnEngineCancelChanges.Name = "ToolStripBtnEngineCancelChanges";
         this.ToolStripBtnEngineCancelChanges.Size = new System.Drawing.Size(36, 36);
         this.ToolStripBtnEngineCancelChanges.Text = "Cancel changes";
         this.ToolStripBtnEngineCancelChanges.Visible = false;
         this.ToolStripBtnEngineCancelChanges.Click += new System.EventHandler(this.ToolStripBtnEngineCancelChanges_Click);
         // 
         // PanelEngineHeader
         // 
         this.PanelEngineHeader.BackColor = System.Drawing.SystemColors.ActiveBorder;
         this.PanelEngineHeader.Controls.Add(this.LblEngine);
         this.PanelEngineHeader.Dock = System.Windows.Forms.DockStyle.Top;
         this.PanelEngineHeader.Location = new System.Drawing.Point(3, 3);
         this.PanelEngineHeader.Name = "PanelEngineHeader";
         this.PanelEngineHeader.Size = new System.Drawing.Size(902, 30);
         this.PanelEngineHeader.TabIndex = 59;
         // 
         // LblEngine
         // 
         this.LblEngine.AutoSize = true;
         this.LblEngine.Dock = System.Windows.Forms.DockStyle.Left;
         this.LblEngine.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F);
         this.LblEngine.ForeColor = System.Drawing.Color.White;
         this.LblEngine.Location = new System.Drawing.Point(0, 0);
         this.LblEngine.Name = "LblEngine";
         this.LblEngine.Size = new System.Drawing.Size(196, 25);
         this.LblEngine.TabIndex = 43;
         this.LblEngine.Text = "Informations machine";
         // 
         // ToolStripUCHallTools
         // 
         this.ToolStripUCHallTools.BackColor = System.Drawing.SystemColors.ControlDarkDark;
         this.ToolStripUCHallTools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this.ToolStripUCHallTools.ImageScalingSize = new System.Drawing.Size(32, 32);
         this.ToolStripUCHallTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripBtnAddEngine,
            this.ToolStripBtnAddHall});
         this.ToolStripUCHallTools.Location = new System.Drawing.Point(0, 0);
         this.ToolStripUCHallTools.Name = "ToolStripUCHallTools";
         this.ToolStripUCHallTools.Padding = new System.Windows.Forms.Padding(0);
         this.ToolStripUCHallTools.Size = new System.Drawing.Size(1152, 39);
         this.ToolStripUCHallTools.TabIndex = 64;
         this.ToolStripUCHallTools.Text = "toolStrip1";
         // 
         // ToolStripBtnAddEngine
         // 
         this.ToolStripBtnAddEngine.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.ToolStripBtnAddEngine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnAddEngine.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnAddEngine.Image")));
         this.ToolStripBtnAddEngine.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnAddEngine.Name = "ToolStripBtnAddEngine";
         this.ToolStripBtnAddEngine.Size = new System.Drawing.Size(36, 36);
         this.ToolStripBtnAddEngine.Text = "Ajouter une machine";
         this.ToolStripBtnAddEngine.Click += new System.EventHandler(this.ToolStripBtnAddEngine_Click);
         // 
         // ToolStripBtnAddHall
         // 
         this.ToolStripBtnAddHall.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.ToolStripBtnAddHall.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ToolStripBtnAddHall.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripBtnAddHall.Image")));
         this.ToolStripBtnAddHall.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ToolStripBtnAddHall.Name = "ToolStripBtnAddHall";
         this.ToolStripBtnAddHall.Size = new System.Drawing.Size(36, 36);
         this.ToolStripBtnAddHall.Text = "Ajouter un hall";
         this.ToolStripBtnAddHall.Click += new System.EventHandler(this.ToolStripBtnAddHall_Click);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.CheckBoxEngineProducing);
         this.groupBox1.Controls.Add(this.TxtEngineLib);
         this.groupBox1.Controls.Add(this.DBComboxEngineResp);
         this.groupBox1.Controls.Add(this.label22);
         this.groupBox1.Controls.Add(this.TxtEngineNb);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this.label20);
         this.groupBox1.Controls.Add(this.label21);
         this.groupBox1.Controls.Add(this.label19);
         this.groupBox1.Controls.Add(this.TxtEnginePriceH);
         this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.groupBox1.Location = new System.Drawing.Point(6, 6);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(355, 192);
         this.groupBox1.TabIndex = 102;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Informations générales";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label2.Location = new System.Drawing.Point(6, 62);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(52, 17);
         this.label2.TabIndex = 2;
         this.label2.Text = "Libellé :";
         // 
         // label20
         // 
         this.label20.AutoSize = true;
         this.label20.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this.label20.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label20.Location = new System.Drawing.Point(6, 155);
         this.label20.Name = "label20";
         this.label20.Size = new System.Drawing.Size(78, 17);
         this.label20.TabIndex = 11;
         this.label20.Text = "Production :";
         // 
         // TxtEngineNb
         // 
         this.TxtEngineNb.BackColor = System.Drawing.Color.White;
         this.TxtEngineNb.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
         this.TxtEngineNb.Location = new System.Drawing.Point(131, 28);
         this.TxtEngineNb.Name = "TxtEngineNb";
         this.TxtEngineNb.Size = new System.Drawing.Size(209, 25);
         this.TxtEngineNb.TabIndex = 26;
         this.TxtEngineNb.TextChanged += new System.EventHandler(this.EngineValueChanged);
         // 
         // label21
         // 
         this.label21.AutoSize = true;
         this.label21.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label21.Location = new System.Drawing.Point(6, 124);
         this.label21.Name = "label21";
         this.label21.Size = new System.Drawing.Size(90, 17);
         this.label21.TabIndex = 9;
         this.label21.Text = "Responsable :";
         // 
         // label22
         // 
         this.label22.AutoSize = true;
         this.label22.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label22.Location = new System.Drawing.Point(6, 31);
         this.label22.Name = "label22";
         this.label22.Size = new System.Drawing.Size(63, 17);
         this.label22.TabIndex = 10;
         this.label22.Text = "Numéro :";
         // 
         // label19
         // 
         this.label19.AutoSize = true;
         this.label19.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label19.Location = new System.Drawing.Point(6, 93);
         this.label19.Name = "label19";
         this.label19.Size = new System.Drawing.Size(73, 17);
         this.label19.TabIndex = 3;
         this.label19.Text = "Prix heure :";
         // 
         // TxtEnginePriceH
         // 
         this.TxtEnginePriceH.BackColor = System.Drawing.Color.White;
         this.TxtEnginePriceH.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
         this.TxtEnginePriceH.Location = new System.Drawing.Point(131, 90);
         this.TxtEnginePriceH.Name = "TxtEnginePriceH";
         this.TxtEnginePriceH.Size = new System.Drawing.Size(209, 25);
         this.TxtEnginePriceH.TabIndex = 24;
         this.TxtEnginePriceH.TextChanged += new System.EventHandler(this.EngineValueChanged);
         // 
         // TxtEngineLib
         // 
         this.TxtEngineLib.BackColor = System.Drawing.Color.White;
         this.TxtEngineLib.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
         this.TxtEngineLib.Location = new System.Drawing.Point(131, 59);
         this.TxtEngineLib.Name = "TxtEngineLib";
         this.TxtEngineLib.Size = new System.Drawing.Size(209, 25);
         this.TxtEngineLib.TabIndex = 48;
         this.TxtEngineLib.TextChanged += new System.EventHandler(this.EngineValueChanged);
         // 
         // CheckBoxEngineProducing
         // 
         this.CheckBoxEngineProducing.AutoSize = true;
         this.CheckBoxEngineProducing.Location = new System.Drawing.Point(131, 158);
         this.CheckBoxEngineProducing.Name = "CheckBoxEngineProducing";
         this.CheckBoxEngineProducing.Size = new System.Drawing.Size(15, 14);
         this.CheckBoxEngineProducing.TabIndex = 104;
         this.CheckBoxEngineProducing.UseVisualStyleBackColor = true;
         this.CheckBoxEngineProducing.CheckedChanged += new System.EventHandler(this.EngineValueChanged);
         // 
         // DBListViewHall
         // 
         this.DBListViewHall.AllowMultipleSelecion = true;
         this.DBListViewHall.BackColor = System.Drawing.SystemColors.ButtonShadow;
         this.DBListViewHall.Dock = System.Windows.Forms.DockStyle.Fill;
         this.DBListViewHall.ListTitle = "List";
         this.DBListViewHall.Location = new System.Drawing.Point(3, 3);
         this.DBListViewHall.Margin = new System.Windows.Forms.Padding(0);
         this.DBListViewHall.Name = "DBListViewHall";
         this.DBListViewHall.Size = new System.Drawing.Size(234, 277);
         this.DBListViewHall.TabIndex = 0;
         // 
         // DBListViewEngines
         // 
         this.DBListViewEngines.AllowMultipleSelecion = true;
         this.DBListViewEngines.BackColor = System.Drawing.SystemColors.ButtonShadow;
         this.DBListViewEngines.Dock = System.Windows.Forms.DockStyle.Fill;
         this.DBListViewEngines.ListTitle = "List";
         this.DBListViewEngines.Location = new System.Drawing.Point(3, 3);
         this.DBListViewEngines.Margin = new System.Windows.Forms.Padding(0);
         this.DBListViewEngines.Name = "DBListViewEngines";
         this.DBListViewEngines.Size = new System.Drawing.Size(234, 273);
         this.DBListViewEngines.TabIndex = 0;
         // 
         // DBComboxEngineResp
         // 
         this.DBComboxEngineResp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
         this.DBComboxEngineResp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
         this.DBComboxEngineResp.BackColor = System.Drawing.Color.White;
         this.DBComboxEngineResp.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
         this.DBComboxEngineResp.FormattingEnabled = true;
         this.DBComboxEngineResp.Location = new System.Drawing.Point(131, 121);
         this.DBComboxEngineResp.Name = "DBComboxEngineResp";
         this.DBComboxEngineResp.Size = new System.Drawing.Size(209, 25);
         this.DBComboxEngineResp.TabIndex = 103;
         this.DBComboxEngineResp.SelectedIndexChanged += new System.EventHandler(this.EngineValueChanged);
         // 
         // HallsUC
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.splitContainer1);
         this.Controls.Add(this.ToolStripUCHallTools);
         this.Name = "HallsUC";
         this.Size = new System.Drawing.Size(1152, 605);
         this.splitContainer1.Panel1.ResumeLayout(false);
         this.splitContainer1.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
         this.splitContainer1.ResumeLayout(false);
         this.splitContainer3.Panel1.ResumeLayout(false);
         this.splitContainer3.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
         this.splitContainer3.ResumeLayout(false);
         this.PanelHallList.ResumeLayout(false);
         this.PanelEnginesList.ResumeLayout(false);
         this.splitContainer2.Panel1.ResumeLayout(false);
         this.splitContainer2.Panel1.PerformLayout();
         this.splitContainer2.Panel2.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
         this.splitContainer2.ResumeLayout(false);
         this.PanelCheckContent.ResumeLayout(false);
         this.groupBox4.ResumeLayout(false);
         this.groupBox4.PerformLayout();
         this.ToolStripHallEditFooter.ResumeLayout(false);
         this.ToolStripHallEditFooter.PerformLayout();
         this.PanelCheckHeader.ResumeLayout(false);
         this.PanelCheckHeader.PerformLayout();
         this.PanelJobRecap.ResumeLayout(false);
         this.PanelJobRecap.PerformLayout();
         this.PanelEngineContent.ResumeLayout(false);
         this.ToolStipEngineEditFooter.ResumeLayout(false);
         this.ToolStipEngineEditFooter.PerformLayout();
         this.PanelEngineHeader.ResumeLayout(false);
         this.PanelEngineHeader.PerformLayout();
         this.ToolStripUCHallTools.ResumeLayout(false);
         this.ToolStripUCHallTools.PerformLayout();
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DBListView DBListViewHall;
      private System.Windows.Forms.SplitContainer splitContainer1;
      private System.Windows.Forms.Panel PanelHallList;
      private System.Windows.Forms.SplitContainer splitContainer2;
      private System.Windows.Forms.Panel PanelCheckContent;
      private System.Windows.Forms.ToolStrip ToolStripHallEditFooter;
      private System.Windows.Forms.ToolStripButton ToolStripBtnHallSaveChanges;
      private System.Windows.Forms.ToolStripButton ToolStripBtnHallCancelChanges;
      private System.Windows.Forms.Panel PanelCheckHeader;
      private System.Windows.Forms.Label LblHall;
      private System.Windows.Forms.Panel PanelJobRecap;
      private System.Windows.Forms.ToolStrip ToolStripUCHallTools;
      private System.Windows.Forms.ToolStripButton ToolStripBtnAddHall;
      private System.Windows.Forms.Panel PanelEnginesList;
      private DBListView DBListViewEngines;
      private System.Windows.Forms.ToolStripButton ToolStripBtnAddEngine;
      private System.Windows.Forms.Panel PanelEngineContent;
      private System.Windows.Forms.ToolStrip ToolStipEngineEditFooter;
      private System.Windows.Forms.ToolStripButton ToolStripBtnEngineSaveChanges;
      private System.Windows.Forms.ToolStripButton ToolStripBtnEngineCancelChanges;
      private System.Windows.Forms.Panel PanelEngineHeader;
      private System.Windows.Forms.Label LblEngine;
      private System.Windows.Forms.SplitContainer splitContainer3;
      private System.Windows.Forms.GroupBox groupBox4;
      private System.Windows.Forms.Label label18;
      private System.Windows.Forms.TextBox TxtHallName;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.TextBox TxtEngineLib;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label20;
      private System.Windows.Forms.TextBox TxtEngineNb;
      private System.Windows.Forms.Label label21;
      private System.Windows.Forms.Label label22;
      private System.Windows.Forms.Label label19;
      private System.Windows.Forms.TextBox TxtEnginePriceH;
      private DBComboBox DBComboxEngineResp;
      private System.Windows.Forms.CheckBox CheckBoxEngineProducing;
   }
}
