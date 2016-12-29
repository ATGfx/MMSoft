using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MMSoft
{
   public partial class HallsUC : UserControl, IMMSoftUC
   {
      private Control mParentContainer_O;
      private bool mHallEditState_b, mEngineEditState_b;
      private DatabaseManager mDBManager_O;
      private bool mInitializingData_b;

      public HallsUC(DatabaseManager DBManager_O)
      {
         InitializeComponent();

         mInitializingData_b = false;

         // Add btn tool tool strip list view
         this.DBListViewHall.ListTitle = "Sélection du hall";
         this.DBListViewHall.AddToolStripBtn(this.ToolStripBtnAddHall);

         this.DBListViewEngines.ListTitle = "Sélection des machines";
         this.DBListViewEngines.AddToolStripBtn(this.ToolStripBtnAddEngine);

         ToolStripUCHallTools.Visible = false;

         this.DBListViewHall.ListTitle = "Informations hall";

         ToolStripUCHallTools.Renderer = new BorderlessToolStripRenderer();

         mDBManager_O = DBManager_O;

         // Hall db list view

         List<String> TableField_ST = new List<String>();
         List<String> ColumnHeaderName_ST = new List<String>();
         List<int> ColumnHeaderDefaultSize_i = new List<int>();
         List<HorizontalAlignment> TextAlign_O = new List<HorizontalAlignment>();

         TableField_ST.Add("HallName");
         TableField_ST.Add("HallID");

         ColumnHeaderName_ST.Add("Nom");

         ColumnHeaderDefaultSize_i.Add(300);

         TextAlign_O.Add(HorizontalAlignment.Left);

         DBListViewHall.Initialize(mDBManager_O, "Hall", TableField_ST, 1, ColumnHeaderName_ST, ColumnHeaderDefaultSize_i, TextAlign_O);
         DBListViewHall.SelectionChanged += new DBListView.SelectionChangedHandler(this.HallClick);

         // Engines db list view

         TableField_ST = new List<String>();
         ColumnHeaderName_ST = new List<String>();
         ColumnHeaderDefaultSize_i = new List<int>();
         TextAlign_O = new List<HorizontalAlignment>();

         TableField_ST.Add("MachineNr");
         TableField_ST.Add("MachineLib");
         TableField_ST.Add("MachineID");

         ColumnHeaderName_ST.Add("Nr.");
         ColumnHeaderName_ST.Add("Nom");

         ColumnHeaderDefaultSize_i.Add(50);
         ColumnHeaderDefaultSize_i.Add(300);

         TextAlign_O.Add(HorizontalAlignment.Left);
         TextAlign_O.Add(HorizontalAlignment.Left);

         DBListViewEngines.Initialize(mDBManager_O, "Machine", TableField_ST, 2, ColumnHeaderName_ST, ColumnHeaderDefaultSize_i, TextAlign_O, null, null, false);
         DBListViewEngines.SelectionChanged += new DBListView.SelectionChangedHandler(this.EngineClick);

         DBComboxEngineResp.FillList(mDBManager_O, "Pers", "PersID", "PersNom");

         ControlStyle.SetBackgroundStyle(this);
         ControlStyle.SetBackgroundStyle(this.ToolStripUCHallTools);
         ControlStyle.SetFrameHeaderStyle(this.PanelHallList);
         ControlStyle.SetFrameHeaderStyle(this.PanelCheckHeader);
         ControlStyle.SetFrameHeaderStyle(this.PanelEngineHeader);
         ControlStyle.SetFrameHeaderStyle(this.PanelJobRecap);
         ControlStyle.SetFrameHeaderStyle(this.splitContainer2.Panel1);
         ControlStyle.SetFrameStyle(this.PanelCheckContent);
         ControlStyle.SetFrameStyle(this.PanelEngineContent);
         ControlStyle.SetFrameStyle(this.ToolStripHallEditFooter);
         ControlStyle.SetFrameStyle(this.ToolStipEngineEditFooter);

         DBListViewHall.ForeColor = Color.Black;
         DBListViewHall.AllowMultipleSelecion = false;

      }

      public bool Activate(Control Container_O)
      {
         mParentContainer_O = Container_O;
         mParentContainer_O.Controls.Add(this);
         this.BringToFront();
         this.Dock = DockStyle.Fill;

         return true;
      }

      public bool Deactivate()
      {
         bool Rts_b = true;

         if (!mHallEditState_b)
         {
            if (mParentContainer_O != null)
               mParentContainer_O.Controls.Remove(this);
         }
         else
         {
            MessageBox.Show("Impossible d'ouvrir le module sélectionné car un hall est en cours d'édition. Veuillez enregistrer ou annuler vos modifications avant de continuer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Rts_b = false;
         }

         return Rts_b;
      }

      private void HallClick(UInt32 HallId)
      {
         // Load client info in each control
         String SQLRequest_ST;
         SqlDataReader SqlDataReader_O;

         // Fill info in panel edit controls
         mInitializingData_b = true;

         TxtHallName.Clear();

         mInitializingData_b = false;

         if (mDBManager_O != null && mDBManager_O.mConnected_b)
         {
            SQLRequest_ST = "SELECT * FROM Hall WHERE HallID=" + HallId;
            SqlDataReader_O = mDBManager_O.Select(SQLRequest_ST);
            mInitializingData_b = true;

            while (SqlDataReader_O.Read())
            {
               // Fill info in panel edit controls
               TxtHallName.Text = SqlDataReader_O["HallName"].ToString();
            }

            SqlDataReader_O.Close();
            mInitializingData_b = false;

            DBListViewEngines.SetInitialFilter("HallID='" + HallId + "'", null);
            DBListViewEngines.Refresh();
         }
      }

      private void EngineClick(UInt32 EngineId)
      {
         // Load client info in each control
         String SQLRequest_ST;
         SqlDataReader SqlDataReader_O;

         UInt32 PersID_UL;
         int Producing = 0;

         // Fill info in panel edit controls
         mInitializingData_b = true;

         TxtEngineLib.Clear();
         TxtEngineNb.Clear();
         TxtEnginePriceH.Clear();
         DBComboxEngineResp.ClearSelectedItem();

         mInitializingData_b = false;

         if (mDBManager_O != null && mDBManager_O.mConnected_b)
         {
            SQLRequest_ST = "SELECT * FROM Machine WHERE MachineID=" + EngineId;
            SqlDataReader_O = mDBManager_O.Select(SQLRequest_ST);
            mInitializingData_b = true;

            while (SqlDataReader_O.Read())
            {
               // Fill info in panel edit controls
               TxtEngineLib.Text = SqlDataReader_O["MachineLib"].ToString();
               TxtEngineNb.Text = SqlDataReader_O["MachineNr"].ToString();
               TxtEnginePriceH.Text = SqlDataReader_O["PrixH"].ToString();

               if (UInt32.TryParse(SqlDataReader_O["PersID"].ToString(), out PersID_UL))
                  DBComboxEngineResp.SelectItemByID(PersID_UL);

               int.TryParse(SqlDataReader_O["ChkProducing"].ToString(), out Producing);

               CheckBoxEngineProducing.Checked = Producing != 0 ? true : false;
            }

            SqlDataReader_O.Close();
            mInitializingData_b = false;
         }
      }

      private void HallValueChanged(object sender, EventArgs e)
      {
         if (DBListViewHall.GetSelectedItemID() > 0 && !mInitializingData_b)
         {
            DBListViewHall.SetLockState(true);
            SetHallEditState(true);
         }
      }

      private void EngineValueChanged(object sender, EventArgs e)
      {
         if (DBListViewEngines.GetSelectedItemID() > 0 && !mInitializingData_b)
         {
            DBListViewEngines.SetLockState(true);
            SetEngineEditState(true);
         }
      }

      private void SetHallEditState(bool EditState_b)
      {
         mHallEditState_b = EditState_b;
         ToolStripBtnHallSaveChanges.Visible = EditState_b;
         ToolStripBtnHallCancelChanges.Visible = EditState_b;

         if (mHallEditState_b)
         {
            ControlStyle.SetBackgroundColorFocusStyle(this.splitContainer2.Panel1);
            ControlStyle.SetBackgroundColorFocusStyle(PanelCheckHeader);

            if (!LblHall.Text.Contains(" *"))
            {
               LblHall.Text += " *";
            }
         }
         else
         {
            ControlStyle.SetFrameHeaderStyle(this.splitContainer2.Panel1);
            ControlStyle.SetFrameHeaderStyle(PanelCheckHeader);

            if (LblHall.Text.Contains(" *"))
            {
               LblHall.Text = LblHall.Text.Remove(LblHall.Text.IndexOf(" *"), 2);
            }
         }
      }

      private void SetEngineEditState(bool EditState_b)
      {
         mEngineEditState_b = EditState_b;
         ToolStripBtnEngineSaveChanges.Visible = EditState_b;
         ToolStripBtnEngineCancelChanges.Visible = EditState_b;

         if (mEngineEditState_b)
         {
            if (!mHallEditState_b)
            {
               DBListViewHall.SetLockState(true);
            }

            ControlStyle.SetBackgroundColorFocusStyle(this.splitContainer2.Panel2);
            ControlStyle.SetBackgroundColorFocusStyle(PanelEngineHeader);

            if (!LblEngine.Text.Contains(" *"))
            {
               LblEngine.Text += " *";
            }
         }
         else
         {
            if (!mHallEditState_b)
            {
               DBListViewHall.SetLockState(false);
            }

            ControlStyle.SetFrameHeaderStyle(this.splitContainer2.Panel2);
            ControlStyle.SetFrameHeaderStyle(PanelEngineHeader);

            if (LblEngine.Text.Contains(" *"))
            {
               LblEngine.Text = LblEngine.Text.Remove(LblEngine.Text.IndexOf(" *"), 2);
            }
         }
      }

      private void ToolStripBtnHallSaveChanges_Click(object sender, EventArgs e)
      {
         if (mHallEditState_b)
         {
            UInt32 HallID_UL = DBListViewHall.GetSelectedItemID();

            //Build update request
            if (mDBManager_O != null && mDBManager_O.mConnected_b)
            {
               List<String> Param_O = new List<String>();
               List<Object> Values_O = new List<Object>();

               String SqlCommand_O = @"UPDATE Hall SET HallName=@HallName WHERE HallID=@HallID";

               Param_O.Add("@HallName"); Values_O.Add(TxtHallName.Text);
               Param_O.Add("@HallID"); Values_O.Add((int)HallID_UL);

               mDBManager_O.ExecuteRequest(SqlCommand_O, Param_O, Values_O);

               SetHallEditState(false);
               DBListViewHall.SetLockState(false);
               DBListViewHall.Refresh();
               DBListViewHall.SelectItemByID(HallID_UL);
            }
         }
      }

      private void ToolStripBtnHallCancelChanges_Click(object sender, EventArgs e)
      {
         if (mHallEditState_b)
         {
            DialogResult DlgRes_O = MessageBox.Show("Les modifications effectuées sur le hall seront perdues, continuer ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (DlgRes_O == DialogResult.Yes)
            {
               SetHallEditState(false);
               DBListViewHall.SetLockState(false);
               Refresh();

               DBListViewHall.SelectItemByID(DBListViewHall.GetSelectedItemID());
            }
         }
      }

      private void ToolStripBtnAddHall_Click(object sender, EventArgs e)
      {
         if (!mHallEditState_b)
         {
            FormAskString Form_O = new FormAskString("Nom du nouveau hall");
            DialogResult DlgRes_O = Form_O.ShowDialog();

            if (DlgRes_O == DialogResult.OK && mDBManager_O.mConnected_b)
            {
               UInt32 NewHallID_O = mDBManager_O.mStoredProcedureManager_O.STPROC_CreateHall(Form_O.mEnteredString_ST);
               DBListViewHall.Refresh();
               DBListViewHall.SelectItemByID(NewHallID_O);
            }
         }
         else
            MessageBox.Show("Impossible d'ajouter un nouveau hall lorsqu'un autre est en cours d'édition. Veuillez d'abord enregistrer ou annuler vos modifications.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      private void ToolStripBtnAddEngine_Click(object sender, EventArgs e)
      {
         if (!mHallEditState_b)
         {
            FormAskString Form_O = new FormAskString("Nom de la nouvelle machine");
            DialogResult DlgRes_O = Form_O.ShowDialog();

            if (DlgRes_O == DialogResult.OK && mDBManager_O.mConnected_b)
            {
               UInt32 NewEngineID_O = mDBManager_O.mStoredProcedureManager_O.STPROC_CreateEngine(Form_O.mEnteredString_ST, DBListViewHall.GetSelectedItemID());
               DBListViewEngines.Refresh();
               DBListViewEngines.SelectItemByID(NewEngineID_O);
            }
         }
         else
            MessageBox.Show("Impossible d'ajouter une nouvelle machine lorsqu'un autre est en cours d'édition. Veuillez d'abord enregistrer ou annuler vos modifications.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      private void ToolStripBtnEngineSaveChanges_Click(object sender, EventArgs e)
      {
         if (mEngineEditState_b)
         {
            UInt32 EngineID_UL = DBListViewEngines.GetSelectedItemID();
            UInt32 PersID_UL;
            double PriceH;

            //Build update request
            if (mDBManager_O != null && mDBManager_O.mConnected_b)
            {
               DBComboxEngineResp.GetSelectedItemID(out PersID_UL);
               Double.TryParse(TxtEnginePriceH.Text.Replace(',', '.'), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out PriceH);

               List<String> Param_O = new List<String>();
               List<Object> Values_O = new List<Object>();

               String SqlCommand_O = @"UPDATE Machine SET MachineLib=@MachineLib, PrixH=@PrixH, PersID=@PersID, MachineNr=@MachineNr, ChkProducing=@ChkProducing
                                       WHERE MachineID=@MachineID";

               Param_O.Add("@MachineLib"); Values_O.Add(TxtEngineLib.Text);
               Param_O.Add("@PrixH"); Values_O.Add(PriceH);
               Param_O.Add("@PersID"); Values_O.Add((int)PersID_UL);
               Param_O.Add("@MachineNr"); Values_O.Add(TxtEngineNb.Text);
               Param_O.Add("@ChkProducing"); Values_O.Add(CheckBoxEngineProducing.Checked);
               Param_O.Add("@MachineID"); Values_O.Add((int)EngineID_UL);

               mDBManager_O.ExecuteRequest(SqlCommand_O, Param_O, Values_O);

               SetEngineEditState(false);
               DBListViewEngines.SetLockState(false);
               //DBListViewEngines.Refresh(); do not work if this line is not commented, but only needed if delete is allowed...
               DBListViewEngines.SelectItemByID(EngineID_UL);
            }
         }
      }

      private void ToolStripBtnEngineCancelChanges_Click(object sender, EventArgs e)
      {
         if (mEngineEditState_b)
         {
            DialogResult DlgRes_O = MessageBox.Show("Les modifications effectuées sur la machine seront perdues, continuer ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (DlgRes_O == DialogResult.Yes)
            {
               SetEngineEditState(false);
               DBListViewEngines.SetLockState(false);
               Refresh();

               DBListViewEngines.SelectItemByID(DBListViewEngines.GetSelectedItemID());
            }
         }
      }
   }
}
