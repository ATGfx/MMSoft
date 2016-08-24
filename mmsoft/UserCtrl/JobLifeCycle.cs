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
   public partial class JobLifeCycle : UserControl
   {
      private DatabaseManager mDBManager_O;
      private UInt32 mComJobID_UL;

      public JobLifeCycle()
      {
         InitializeComponent();

         mDBManager_O = null;
         mComJobID_UL = 0;
      }

      public JobLifeCycle(DatabaseManager DBManager_O, UInt32 ComJobID_UL)
      {
         InitializeComponent();

         mDBManager_O = DBManager_O;
         mComJobID_UL = ComJobID_UL;

         ToolStripJobStates.Renderer = new BorderlessToolStripRenderer();
         ToolStripJobInfos1.Renderer = new BorderlessToolStripRenderer();

         ControlStyle.SetFrameStyle(this);
         ControlStyle.SetFrameStyle(this.ToolStripJobStates);
         ControlStyle.SetFrameStyle(this.JobLifeCyclePanel);

         InitializeInfos();
         UpdateJobStatus();
      }

      public void Filter(String RefNumber_st, String ClientName_st, String JobNumber_st, String JobLib_st)
      {
         bool IsVisible_b = true;

         if (!String.IsNullOrEmpty(RefNumber_st))
         {
            IsVisible_b &= ToolStripLblRefNumber.Text.ToLower().Contains(RefNumber_st.ToLower());
         }

         if (!String.IsNullOrEmpty(ClientName_st))
         {
            IsVisible_b &= ToolStripLblClient.Text.ToLower().Contains(ClientName_st.ToLower());
         }

         if (!String.IsNullOrEmpty(JobNumber_st))
         {
            IsVisible_b &= ToolStripLblJobNb.Text.ToLower().Contains(JobNumber_st.ToLower());
         }

         if (!String.IsNullOrEmpty(JobLib_st))
         {
            IsVisible_b &= ToolStripLblJobLib.Text.ToLower().Contains(JobLib_st.ToLower());
         }

         this.Visible = IsVisible_b;
      }

      private void InitializeInfos()
      {
         String SQLRequest_ST;
         SqlDataReader SqlDataReader_O;

         if (mDBManager_O != null && mDBManager_O.mConnected_b)
         {
            SQLRequest_ST = "SELECT ClientNom, NumRefInterne, NumOrdre, JobLib, Qte, CoutEstim, QteProd, QteFact, PVFact FROM ComJobSelectPop WHERE ComJobID=" + mComJobID_UL;

            SqlDataReader_O = mDBManager_O.Select(SQLRequest_ST);

            while (SqlDataReader_O.Read())
            {
               ToolStripLblClient.Text = SqlDataReader_O["ClientNom"].ToString();
               ToolStripLblRefNumber.Text = SqlDataReader_O["NumRefInterne"].ToString();
               ToolStripLblJobNb.Text = SqlDataReader_O["NumOrdre"].ToString();
               ToolStripLblJobLib.Text = SqlDataReader_O["JobLib"].ToString();
               ToolStripLblQte.Text = SqlDataReader_O["Qte"].ToString();
               ToolStripLblPUEst.Text = SqlDataReader_O["CoutEstim"].ToString();
               ToolStripLblQteProd.Text = SqlDataReader_O["QteProd"].ToString();
               ToolStripTxtboxQteFact.Text = SqlDataReader_O["QteFact"].ToString();
               ToolStripTxtboxPUFact.Text = SqlDataReader_O["PVFact"].ToString();
            }
         }
      }

      private void UpdateJobStatus()
      {
         if (mDBManager_O != null && mDBManager_O.mConnected_b)
         {
            UInt32 StatusID_UL;

            if (UInt32.TryParse(mDBManager_O.GetTableField("ComJob", "ComStatusID", "ComJobID=" + mComJobID_UL), out StatusID_UL))
            {
               for (int i = 0; i < ToolStripJobStates.Items.Count; i++)
               {
                  if (ToolStripJobStates.Items[i].GetType() == typeof(ToolStripButton) || 
                      ToolStripJobStates.Items[i].GetType() == typeof(ToolStripLabel) ||
                      ToolStripJobStates.Items[i].GetType() == typeof(ToolStripControlHost)||
                     ToolStripJobStates.Items[i].GetType() == typeof(ToolStripTextBox))
                  {
                     if (StatusID_UL > Convert.ToUInt32(ToolStripJobStates.Items[i].Tag))
                     {
                        ToolStripJobStates.Items[i].Enabled = false;
                     }
                     else
                     {
                        ToolStripJobStates.Items[i].Enabled = true;
                     }
                  }
               }
            }
         }
      }

      private void JobLifeCycle_MouseEnter(object sender, EventArgs e)
      {
         ControlStyle.SetBackgroundColorFocusStyle(this);
      }

      private void JobLifeCycle_MouseLeave(object sender, EventArgs e)
      {
         ControlStyle.SetFrameStyle(this);
      }

      private void ToolStripBtnGoto_Click(object sender, EventArgs e)
      {
         bool EncodingError_b = false;

         if (mDBManager_O != null && mDBManager_O.mConnected_b && sender.GetType() == typeof(ToolStripButton))
         {
            UInt32 StatusID_UL = 0, DestinationStatusID_UL = Convert.ToUInt32(((ToolStripButton)sender).Tag) + 1;

            if (UInt32.TryParse(mDBManager_O.GetTableField("ComJob", "ComStatusID", "ComJobID=" + mComJobID_UL), out StatusID_UL))
            {
               for (UInt32 i = StatusID_UL; i < DestinationStatusID_UL && !EncodingError_b; i++)
               {
                  // Do not do anything before this because status change are done at other place in software
                  if (i == 3)
                     mDBManager_O.mStoredProcedureManager_O.STPROC_ExpedierJob(mComJobID_UL);
                  else if (i == 4)
                  {
                     float QteFact_f, PUFact_f;

                     if (Single.TryParse(ToolStripTxtboxQteFact.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out QteFact_f) &&
                         Single.TryParse(ToolStripTxtboxPUFact.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out PUFact_f))
                     {
                        mDBManager_O.mStoredProcedureManager_O.STPROC_FacturerJob(mComJobID_UL);

                        String UpdateString_st = "Update ComJob SET QteFact='" + QteFact_f.ToString(System.Globalization.CultureInfo.InvariantCulture) + "', PVFact='" + 
                                                   PUFact_f.ToString(System.Globalization.CultureInfo.InvariantCulture) + "' WHERE ComJobID=" + mComJobID_UL;
                        mDBManager_O.ExecuteRequest(UpdateString_st);
                     }
                     else
                     {
                        MessageBox.Show("Impossible d'archiver le job car les valeurs de quantité et prix unitaire facturés ne sont pas correctes.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        EncodingError_b = true;
                     }
                  }
                  else if (i == 5)
                     mDBManager_O.mStoredProcedureManager_O.STPROC_ArchiverJob(mComJobID_UL);
               }

               UpdateJobStatus();
            }
         }
      }

      private void ToolStripBtnUnlock_Click(object sender, EventArgs e)
      {
         DialogResult DlgRes_O = MessageBox.Show("Cette action est fortement déconseillée!\r\nSi vous continuer le status du job sera remis comme étant \"en cours\".\r\n\r\n Etes-vous sûr de vouloir continuer ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
      
         if (DlgRes_O == DialogResult.Yes)
         {
            if (mDBManager_O != null)
            {
               String UpdateString_st = "Update ComJob SET ComStatusID=2 WHERE ComJobID=" + mComJobID_UL;
               mDBManager_O.ExecuteRequest(UpdateString_st);
            }

            UpdateJobStatus();
         }
      }
   }
}
