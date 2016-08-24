using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MMSoft
{
   public partial class HomeUC : UserControl, IMMSoftUC
   {
      private Control mParentContainer_O;
      private bool mEditState_b = false; // may be needed if edition of message ?
      private DatabaseManager mDBManager_O;

      public delegate void NewMessageHandler();
      public event NewMessageHandler NewMessage;

      public HomeUC(DatabaseManager DBManager_O)
      {
         InitializeComponent();

         mDBManager_O = DBManager_O;

         List<String> TableField_ST = new List<String>();
         List<String> ColumnHeaderName_ST = new List<String>();
         List<int> ColumnHeaderDefaultSize_i = new List<int>();
         List<HorizontalAlignment> TextAlign_O = new List<HorizontalAlignment>();

         TableField_ST.Add("PersNom");
         TableField_ST.Add("Msg");
         TableField_ST.Add("MsgID");

         ColumnHeaderName_ST.Add("Expéditeur");
         ColumnHeaderName_ST.Add("Message");

         ColumnHeaderDefaultSize_i.Add(100);
         ColumnHeaderDefaultSize_i.Add(DBListViewMsg.Width - 100);

         TextAlign_O.Add(HorizontalAlignment.Left);
         TextAlign_O.Add(HorizontalAlignment.Left);

         DBListViewMsg.Initialize(mDBManager_O, "MsgSelectPop", TableField_ST, 2, ColumnHeaderName_ST, ColumnHeaderDefaultSize_i, TextAlign_O);
         DBListViewMsg.ListTitle = "Messages";
         DBListViewMsg.AllowMultipleSelecion = true;

         DBListViewMsg.AddToolStripBtn(ToolStripBtnDelete);
         FormMsgToolStrip.Visible = false;

         // Initialize db list view com job
         DbListViewComJobs.ListTitle = "Sélection des jobs";

         List<String> mComJobTableField_ST = new List<String>();
         List<String> mComJobColumnHeaderName_ST = new List<String>();
         List<int> mComJobColumnHeaderDefaultSize_i = new List<int>();
         List<HorizontalAlignment> mComJobTextAlign_O = new List<HorizontalAlignment>();

         // Define column DB fields
         mComJobTableField_ST = new List<String>();
         mComJobTableField_ST.Add("NumRefInterne");
         mComJobTableField_ST.Add("LibelleCmd");
         mComJobTableField_ST.Add("NumCmdClient");
         mComJobTableField_ST.Add("ClientNom");
         mComJobTableField_ST.Add("NumOrdre");
         mComJobTableField_ST.Add("JobLib");
         mComJobTableField_ST.Add("Qte");
         mComJobTableField_ST.Add("NumPlan");
         mComJobTableField_ST.Add("DelaiPromis");
         mComJobTableField_ST.Add("JobStatusLib");
         mComJobTableField_ST.Add("DateEncod");
         // Unshown elements
         mComJobTableField_ST.Add("ComJobID");

         // Define column headers text
         mComJobColumnHeaderName_ST = new List<string>();
         mComJobColumnHeaderName_ST.Add("Num cmd int");
         mComJobColumnHeaderName_ST.Add("Libellé cmd");
         mComJobColumnHeaderName_ST.Add("Num cmd client");
         mComJobColumnHeaderName_ST.Add("Nom client");
         mComJobColumnHeaderName_ST.Add("# job");
         mComJobColumnHeaderName_ST.Add("Job libellé");
         mComJobColumnHeaderName_ST.Add("Qte");
         mComJobColumnHeaderName_ST.Add("Num plan");
         mComJobColumnHeaderName_ST.Add("Délai");
         mComJobColumnHeaderName_ST.Add("Statut");
         mComJobColumnHeaderName_ST.Add("Date encodage");

         // Define column headers objects
         mComJobTextAlign_O = new List<HorizontalAlignment>();

         for (int i = 0; i < mComJobColumnHeaderName_ST.Count; i++)
         {
            if (i == 4 || i == 6)
               mComJobTextAlign_O.Add(HorizontalAlignment.Center);
            else
               mComJobTextAlign_O.Add(HorizontalAlignment.Left);
         }

         mComJobColumnHeaderDefaultSize_i = new List<int>();
         mComJobColumnHeaderDefaultSize_i.Add(100);
         mComJobColumnHeaderDefaultSize_i.Add(100);
         mComJobColumnHeaderDefaultSize_i.Add(150);
         mComJobColumnHeaderDefaultSize_i.Add(150);
         mComJobColumnHeaderDefaultSize_i.Add(50);
         mComJobColumnHeaderDefaultSize_i.Add(600);
         mComJobColumnHeaderDefaultSize_i.Add(50);
         mComJobColumnHeaderDefaultSize_i.Add(100);
         mComJobColumnHeaderDefaultSize_i.Add(100);
         mComJobColumnHeaderDefaultSize_i.Add(100);
         mComJobColumnHeaderDefaultSize_i.Add(100);

         DbListViewComJobs.Initialize(mDBManager_O, "ComJobSelectPop", mComJobTableField_ST, 11, mComJobColumnHeaderName_ST, mComJobColumnHeaderDefaultSize_i, mComJobTextAlign_O);

         ControlStyle.SetFrameHeaderStyle(this);
         ControlStyle.SetFrameHeaderStyle(this.splitContainer1);
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

         if (!mEditState_b)
         {
            if (mParentContainer_O != null)
               mParentContainer_O.Controls.Remove(this);
         }
         else
         {
            MessageBox.Show("Impossible d'ouvrir le module sélectionné car un client est en cours d'édition. Veuillez enregistrer ou annuler vos modifications avant de continuer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Rts_b = false;
         }

         return Rts_b;
      }

      private void UpdateMsgTimer_Tick(object sender, EventArgs e)
      {
         SqlDataReader SqlDataReader_O;
         String SqlRequest_st = "SELECT MAX(MsgID) FROM Msg";
         UInt32 DBMaxID_UL, ListMaxID_UL;

         if (mDBManager_O != null && mDBManager_O.mConnected_b)
         {
            SqlDataReader_O = mDBManager_O.Select(SqlRequest_st);

            while (SqlDataReader_O.Read())
            {
               if (UInt32.TryParse(SqlDataReader_O[0].ToString(), out DBMaxID_UL))
               {
                  ListMaxID_UL = DBListViewMsg.GetMaxID();

                  if (ListMaxID_UL < DBMaxID_UL)
                  {
                     DBListViewMsg.Refresh();
                     NewMessage();
                  }
                  else if (ListMaxID_UL != DBMaxID_UL)
                  {
                     DBListViewMsg.Refresh();
                  }
               }
               else
                  DBListViewMsg.Refresh();
            }

            SqlDataReader_O.Close();
         }
      }

      private void ToolStripBtnDelete_Click(object sender, EventArgs e)
      {
         List<UInt32> ItemsID_UL = DBListViewMsg.GetSelectedItemsID();

         UpdateMsgTimer.Enabled = false;

         if (mDBManager_O != null && mDBManager_O.mConnected_b)
         {
            for (int i = 0; i < ItemsID_UL.Count; i++)
            {
                  mDBManager_O.mStoredProcedureManager_O.STPROC_DeleteMsg(ItemsID_UL[i]);
            }
         }

         UpdateMsgTimer.Enabled = true;
      }
   }
}
