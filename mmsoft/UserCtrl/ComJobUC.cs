using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Word;


namespace MMSoft
{
   public partial class ComJobUC : UserControl, IMMSoftUC
   {
      private Control mParentContainer_O;
      private bool mComEditState_b;
      private bool mJobEditState_b;
      private bool mInitializingComData_b = false;
      private bool mInitializingJobData_b = false;
      private bool mIgnoreComValueChangedEvent_b = false;
      private bool mIgnoreJobValueChangedEvent_b = false;
      private bool mUpdateDepartmentAssociation_b = false;
      private DatabaseManager mDBManager_O;
      private DocumentManager mDocManager_O;

      public ComJobUC(DatabaseManager DBManager_O, DocumentManager DocManager_O)
      {
         InitializeComponent();

         this.ComJobSelector.AddComToolStripBtn(this.ToolStripBtnCancelCmd);
         this.ComJobSelector.AddComToolStripBtn(this.ToolStripBtnAddCom);         
         this.ToolStripCom.Visible = false;
         this.ComJobSelector.AddJobToolStripBtn(this.ToolStripBtnCancelJob);
         this.ComJobSelector.AddJobToolStripBtn(this.ToolStripBtnAddJob);         
         this.ToolStripJob.Visible = false;

         mDBManager_O = DBManager_O;
         mDocManager_O = DocManager_O;

         ComJobSelector.Initialize(mDBManager_O);

         SetComEditState(false);
         SetJobEditState(false);

         ComJobSelector.GetComListView().SelectionChanged += new DBListView.SelectionChangedHandler(this.ComClick);
         ComJobSelector.GetJobListView().SelectionChanged += new DBListView.SelectionChangedHandler(this.JobClick);

         JobAssociatedDep.Initialize(mDBManager_O);
         JobAssociatedDep.DepartmentsModified += new DepartmentSelector.DepartmentsModifiedHandler(this.JobValueChanged);

         ToolStripComTools.Renderer = new BorderlessToolStripRenderer();
         ToolStripJobTools.Renderer = new BorderlessToolStripRenderer();
         ToolStripComHeader.Renderer = new BorderlessToolStripRenderer();
         ToolStripJobHeader.Renderer = new BorderlessToolStripRenderer();
         ToolStripJobDocuments.Renderer = new BorderlessToolStripRenderer();
         ToolStripNEAndCertif.Renderer = new BorderlessToolStripRenderer();
         ControlStyle.SetBackgroundStyle(this);
         ControlStyle.SetFrameHeaderStyle(this.ToolStripComTools);
         ControlStyle.SetFrameHeaderStyle(this.ToolStripJobTools);
         ControlStyle.SetBackgroundStyle(this.splitContainer1.Panel2);
         ControlStyle.SetFrameHeaderStyle(this.splitContainer2.Panel1);
         ControlStyle.SetFrameHeaderStyle(this.splitContainer2.Panel2);
         ControlStyle.SetFrameStyle(this.ToolStripComEditFooter);
         ControlStyle.SetFrameStyle(this.PanelCmdInfo);
         ControlStyle.SetFrameStyle(this.PanelJobInfo);
         ControlStyle.SetFrameStyle(this.ToolStripJobEditFooter);
         ControlStyle.SetFrameStyle(this.JobAssociatedDep);
         ControlStyle.SetFrameStyle(this.ToolStripJobDocuments);
         ControlStyle.SetFrameStyle(this.ToolStripNEAndCertif);
      }

      public bool Activate(Control Container_O)
      {
         mParentContainer_O = Container_O;
         mParentContainer_O.Controls.Add(this);
         this.BringToFront();
         this.Dock = DockStyle.Fill;

         ComClick(ComJobSelector.GetComListView().GetSelectedItemID());
         JobClick(ComJobSelector.GetJobListView().GetSelectedItemID());

         return true;
      }

      public bool Deactivate()
      {
         bool Rts_b = true;

         if (!mComEditState_b && ! mJobEditState_b)
         {
            if (mParentContainer_O != null)
               mParentContainer_O.Controls.Remove(this);
         }
         else
         {
            MessageBox.Show("Impossible d'ouvrir le module sélectionné car une commande ou un job est en cours d'édition. Veuillez enregistrer ou annuler vos modifications avant de continuer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Rts_b = false;
         }

         return Rts_b;
      }

      private void SetComEditState(bool EditState_b)
      {
         mComEditState_b = EditState_b;
         BtnSaveComChanges.Visible = EditState_b;
         BtnCancelComChanges.Visible = EditState_b; 
      }

      private void SetJobEditState(bool EditState_b)
      {
         mJobEditState_b = EditState_b;
         BtnSaveJobChanges.Visible = EditState_b;
         BtnCancelJobChanges.Visible = EditState_b;
      }

      private void ComClick(UInt32 ComID_UL)
      {
         // Load client info in each control
         String SQLRequest_ST;
         SqlDataReader SqlDataReader_O;

         int RappConf_i = 0, NoteEnvoi_i = 0, Certif_i = 0;

         mInitializingComData_b = true;

         ClearComInfo();
         if (ComJobSelector.GetJobListView().GetSelectedItemID() == 0)
         {
            ClearJobInfo();
         }

         if (mDBManager_O != null && mDBManager_O.mConnected_b)
         {
            SQLRequest_ST = "SELECT * FROM ComSelectPop WHERE ComID=" + ComID_UL;
            SqlDataReader_O = mDBManager_O.Select(SQLRequest_ST);

            while (SqlDataReader_O.Read())
            {
               int.TryParse(SqlDataReader_O["RappConf"].ToString(), out RappConf_i);
               int.TryParse(SqlDataReader_O["NoteEnvoi"].ToString(), out NoteEnvoi_i);
               int.TryParse(SqlDataReader_O["Certif"].ToString(), out Certif_i);

               // Fill info in panel edit controls
               TxtComNumber.Text = SqlDataReader_O["NumRefInterne"].ToString();
               TxtClient.Text = SqlDataReader_O["ClientNom"].ToString();
               try
               {
                  DTPComDate.Value = Convert.ToDateTime(SqlDataReader_O["ComDate"].ToString());
               }
               catch (FormatException e)
               {
                  DTPComDate.Value = DTPComDate.MinDate;
               }
               TxtNumComClient.Text = SqlDataReader_O["NumCmdClient"].ToString();
               TxtComLib.Text = SqlDataReader_O["LibelleCmd"].ToString();
               TxtComInfos.Text = SqlDataReader_O["Info"].ToString();

               CheckBoxRappConf.Checked = RappConf_i != 0 ? true : false;
               CheckBoxNE.Checked = NoteEnvoi_i != 0 ? true : false;
               CheckBoxCertif.Checked = Certif_i != 0 ? true : false;
            }

            SqlDataReader_O.Close();
         }

         mInitializingComData_b = false;
      }

      private void BtnSaveComChanges_Click(object sender, EventArgs e)
      {
         if (mJobEditState_b)
         {
            MessageBox.Show("Des modifications sont en cours sur un job associé à la commande. Enregistez d'abord les modifications sur le job, ensuite celles sur la commande.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         else if (mComEditState_b)
         {
            UInt32 ComID_UL = ComJobSelector.GetComListView().GetSelectedItemID();

            //Build update request
            if (mDBManager_O != null && mDBManager_O.mConnected_b)
            {
               List<String> Param_O = new List<String>();
               List<Object> Values_O = new List<Object>();

               String SqlCommand_st = @"UPDATE Com SET NumRefInterne=@NumRefInterne, NumCmdClient=@NumCmdClient, LibelleCmd=@LibelleCmd, Info=@Info, NoteEnvoi=@NoteEnvoi, Certif=@Certif, RappConf=@RappConf
                                                 WHERE ComID=@ComID";

               Param_O.Add("@NumRefInterne");
               Param_O.Add("@NumCmdClient");
               Param_O.Add("@LibelleCmd");
               Param_O.Add("@Info");
               Param_O.Add("@NoteEnvoi");
               Param_O.Add("@Certif");
               Param_O.Add("@RappConf");
               Param_O.Add("@ComID");

               Values_O.Add(TxtComNumber.Text);
               Values_O.Add(TxtNumComClient.Text);
               Values_O.Add(TxtComLib.Text);
               Values_O.Add(TxtComInfos.Text);
               Values_O.Add(CheckBoxNE.Checked);
               Values_O.Add(CheckBoxCertif.Checked);
               Values_O.Add(CheckBoxRappConf.Checked);
               Values_O.Add((int)ComID_UL);

               mDBManager_O.ExecuteRequest(SqlCommand_st, Param_O, Values_O);
            }

            SetComEditState(false);
            ComJobSelector.GetComListView().SetLockState(false);
            ComJobSelector.GetComListView().Refresh();
            ComJobSelector.GetComListView().SelectItemByID(ComID_UL);
         }
      }

      private void BtnCancelComChanges_Click(object sender, EventArgs e)
      {
         if (mComEditState_b)
         {
            DialogResult DlgRes_O = MessageBox.Show("Les modifications effectuées sur la commande seront perdues, continuer ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (DlgRes_O == DialogResult.Yes)
            {
               SetComEditState(false);
            }
         }
      }

      private void ComValueChanged(object sender, EventArgs e)
      {
         if (ComJobSelector.GetComListView().GetSelectedItemID() > 0 && !mInitializingComData_b && !mIgnoreComValueChangedEvent_b)
         {
            ComJobSelector.GetComListView().SetLockState(true);
            SetComEditState(true);
         }
      }

      private void JobClick(UInt32 ComJobID_UL)
      {
         // Load client info in each control
         String SQLRequest_ST;
         SqlDataReader SqlDataReader_O;

         int RegieWork_i = 0;

         mInitializingJobData_b = true;

         // Fill info in panel edit controls
         ClearJobInfo();

         if (mDBManager_O != null && mDBManager_O.mConnected_b)
         {
            SQLRequest_ST = "SELECT * FROM ComJobSelectPop WHERE ComJobID=" + ComJobID_UL;
            SqlDataReader_O = mDBManager_O.Select(SQLRequest_ST);

            while (SqlDataReader_O.Read())
            {
               int.TryParse(SqlDataReader_O["ChkRegie"].ToString(), out RegieWork_i);

               // Fill info in panel edit controls
               ToolStripBtnJobLib.Text = SqlDataReader_O["JobLib"].ToString();
               TxtQte.Text = SqlDataReader_O["Qte"].ToString();
               TxtQteProd.Text = SqlDataReader_O["QteProd"].ToString();
               TxtQteFact.Text = SqlDataReader_O["QteFact"].ToString();
               TxtHEstim.Text = SqlDataReader_O["HTravEstim"].ToString();
               TxtPVUnitEst.Text = SqlDataReader_O["CoutEstim"].ToString();
               TxtPVUnitFact.Text = SqlDataReader_O["PVFact"].ToString();
               TxtJobStatus.Text = SqlDataReader_O["JobStatusLib"].ToString();
               try { DTPClientDelay.Value = Convert.ToDateTime(SqlDataReader_O["DelaiClient"].ToString()); }
               catch (FormatException e) { DTPClientDelay.Value = DTPClientDelay.MinDate; }
               try { DTPPromiseDelay.Value = Convert.ToDateTime(SqlDataReader_O["DelaiPromis"].ToString()); }
               catch (FormatException e) { DTPPromiseDelay.Value = DTPPromiseDelay.MinDate; }
               try { DTPRealisedDelay.Value = Convert.ToDateTime(SqlDataReader_O["DelaRealise"].ToString()); }
               catch (FormatException e) { DTPRealisedDelay.Value = DTPRealisedDelay.MinDate; }
               TxtJobInfo.Text = SqlDataReader_O["InfoJob"].ToString();
               CheckBoxRegieWork.Checked = RegieWork_i > 0;

               // Fill sum hours prested on job
               float NbrH_f = mDBManager_O.mFunctionManager_O.SCFNC_CountPointageHoursOnJob(ComJobID_UL);

               TxtHPrest.Text = NbrH_f.ToString();
               JobProgress.Maximum = (int)Convert.ToDecimal(TxtHEstim.Text);
               JobProgress.Value = Math.Min((int)NbrH_f, JobProgress.Maximum);
            }

            SqlDataReader_O.Close();

            // Fill associated departments
            SQLRequest_ST = "SELECT TypeDepID FROM RelJobTypeDep WHERE ComJobID=" + ComJobID_UL;
            SqlDataReader_O = mDBManager_O.Select(SQLRequest_ST);
            List<UInt32> DepID_UL = new List<UInt32>();
            UInt32 ID_UL;

            while (SqlDataReader_O.Read())
            {
               if (UInt32.TryParse(SqlDataReader_O["TypeDepID"].ToString(), out ID_UL))
                  DepID_UL.Add(ID_UL);
            }

            JobAssociatedDep.CheckDepartments(DepID_UL);

            // Fill associated Send note
            FlowLayoutPaneSendNote.Controls.Clear();

            SQLRequest_ST = "SELECT NoteEnvoiID FROM NoteEnvoiAndCertif WHERE ComJobID=" + ComJobID_UL;
            SqlDataReader_O = mDBManager_O.Select(SQLRequest_ST);

            while (SqlDataReader_O.Read())
            {
               if (UInt32.TryParse(SqlDataReader_O["NoteEnvoiID"].ToString(), out ID_UL))
               {
                  NECertifUC NewNECertifUC_O = new NECertifUC(mDBManager_O, mDocManager_O, ID_UL);
                  NewNECertifUC_O.Width = FlowLayoutPaneSendNote.Width;
                  FlowLayoutPaneSendNote.Controls.Add(NewNECertifUC_O);
               }
            }
         }

         mInitializingJobData_b = false;
      }

      private void BtnSaveJobChanges_Click(object sender, EventArgs e)
      {
         if (mJobEditState_b)
         {
            UInt32 JobID_UL = ComJobSelector.GetJobListView().GetSelectedItemID();
            //Build update request
            if (mDBManager_O != null && mDBManager_O.mConnected_b)
            {
               List<String> Param_O = new List<String>();
               List<Object> Values_O = new List<Object>();

               String SQLCommand_st = @"UPDATE ComJob SET JobLib=@JobLib, Qte=@Qte, QteProd=@QteProd, HTravEstim=@HTravEstim, CoutEstim=@CoutEstim, DelaiClient=@DelaiClient," +
                                                          "DelaiPromis=@DelaiPromis, ChkRegie=@ChkRegie, InfoJob=@InfoJob " +
                                                      "WHERE ComJobID=@ComJobID";

               Param_O.Add("@JobLib");
               Param_O.Add("@Qte");
               Param_O.Add("@QteProd");
               Param_O.Add("@HTravEstim");
               Param_O.Add("@CoutEstim");
               Param_O.Add("@DelaiClient");
               Param_O.Add("@DelaiPromis");
               Param_O.Add("@ChkRegie");
               Param_O.Add("@InfoJob");
               Param_O.Add("@ComJobID");

               Values_O.Add(ToolStripBtnJobLib.Text);
               Values_O.Add(TxtQte.Text);
               Values_O.Add(TxtQteProd.Text);
               Values_O.Add(TxtHEstim.Text);
               Values_O.Add(TxtPVUnitEst.Text);
               Values_O.Add(DTPClientDelay.Value);
               Values_O.Add(DTPPromiseDelay.Value);
               Values_O.Add(CheckBoxRegieWork.Checked);
               Values_O.Add(TxtJobInfo.Text);
               Values_O.Add((int)JobID_UL);

               mDBManager_O.ExecuteRequest(SQLCommand_st, Param_O, Values_O);
               Param_O.Clear();
               Values_O.Clear();

               if (mUpdateDepartmentAssociation_b)
               {
                  // Remove all association
                  SQLCommand_st = @"DELETE FROM RelJobTypeDep WHERE ComJobID=@ComJobID";
                  Param_O.Add("@ComJobID"); Values_O.Add((int)ComJobSelector.GetJobListView().GetSelectedItemID());
                  mDBManager_O.ExecuteRequest(SQLCommand_st, Param_O, Values_O);
                  Param_O.Clear();
                  Values_O.Clear();

                  // Add them back plus new ones
                  List<UInt32> IdList_UL = JobAssociatedDep.GetSelectedDepartmentsID();

                  for (int i = 0; i < IdList_UL.Count; i++)
                  {
                     SQLCommand_st = @"INSERT INTO RelJobTypeDep(TypeDepID, ComJobID) VALUES (@TypeDepID, @ComJobID)";
                     Param_O.Add("@TypeDepID"); Values_O.Add((int)IdList_UL[i]);
                     Param_O.Add("@ComJobID"); Values_O.Add((int)ComJobSelector.GetJobListView().GetSelectedItemID());
                     mDBManager_O.ExecuteRequest(SQLCommand_st, Param_O, Values_O);
                     Param_O.Clear();
                     Values_O.Clear();
                  }

                  mUpdateDepartmentAssociation_b = false;
               }
            }

            SetJobEditState(false);
            ComJobSelector.GetJobListView().SetLockState(false);

            if (!mComEditState_b)
               ComJobSelector.GetComListView().SetLockState(false);

            ComJobSelector.GetJobListView().Refresh();
            ComJobSelector.GetJobListView().SelectItemByID(JobID_UL);
         }
      }

      private void BtnCancelJobChanges_Click(object sender, EventArgs e)
      {
         if (mJobEditState_b)
         {
            DialogResult DlgRes_O = MessageBox.Show("Les modifications effectuées sur le job seront perdues, continuer ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (DlgRes_O == DialogResult.Yes)
            {
               SetJobEditState(false);
               ComJobSelector.GetJobListView().SetLockState(false);

               if (!mComEditState_b)
                  ComJobSelector.GetComListView().SetLockState(false);

               mUpdateDepartmentAssociation_b = false;
            }
         }
      }

      private void JobValueChanged(object sender, EventArgs e)
      {
         if (ComJobSelector.GetJobListView().GetSelectedItemID() > 0 && !mInitializingJobData_b && !mIgnoreJobValueChangedEvent_b)
         {
            // Handle special case : if delai client is changed, change delais promis with it
            if (sender.GetType() == typeof(DateTimePicker) && ((DateTimePicker)sender).Equals(DTPClientDelay))
            {
               DTPPromiseDelay.Value = DTPClientDelay.Value;
            }

            // When edit a job, lock com selection
            ComJobSelector.GetComListView().SetLockState(true);
            ComJobSelector.GetJobListView().SetLockState(true);
            SetJobEditState(true);

            if (sender.GetType() == typeof(DepartmentSelector))
               mUpdateDepartmentAssociation_b = true;
         }
      }

      private void ToolStripBtnAddCom_Click(object sender, EventArgs e)
      {
         if (mDBManager_O != null && mDBManager_O.mConnected_b)
         {
            FormAskClient FormAskClient_O = new FormAskClient(mDBManager_O);

            if (FormAskClient_O.ShowDialog() == DialogResult.OK)
            {
               UInt32 ClientID_UL = FormAskClient_O.SelectedClient_UL;

               if (ClientID_UL > 0)
               {
                  // Generate com internal reference number as DATE/# of job in current day/client number
                  String RefNumber_st = DateTime.Today.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).Substring(2) + "/";
                  RefNumber_st += (char)(mDBManager_O.mStoredProcedureManager_O.STPROC_CountJobByClientID(ClientID_UL) + 65) + "/";
                  RefNumber_st += mDBManager_O.GetTableField("Client", "NumClientInterne", "ClientID=" + ClientID_UL);

                  UInt32 NewComID_UL = mDBManager_O.mStoredProcedureManager_O.STPROC_CreateClientCom(ClientID_UL, RefNumber_st);
                  ComJobSelector.GetComListView().Refresh();

                  if (NewComID_UL > 0)
                  {
                     ComJobSelector.GetComListView().SelectItemByID(NewComID_UL);
                  }
               }
            }
         }
      }

      private void ToolStripBtnCancelCmd_Click(object sender, EventArgs e)
      {
         if (mDBManager_O != null && mDBManager_O.mConnected_b && ComJobSelector.GetComListView().GetSelectedItemID() > 0)
         {
            UInt32 NbJobsInCom_UL = mDBManager_O.mFunctionManager_O.SCFNC_CountJobInCom(ComJobSelector.GetComListView().GetSelectedItemID());

            // If no job is recorded on command, it can be deleted
            if (NbJobsInCom_UL == 0)
            {
               DialogResult DlgRes_O = MessageBox.Show("La suppression d'une commande est une action irréversible (les données seront perdues), êtes-vous certain de vouloir continuer ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

               if (DlgRes_O == DialogResult.Yes)
               {
                  mDBManager_O.mStoredProcedureManager_O.STPROC_DeleteCom(ComJobSelector.GetComListView().GetSelectedItemID());
                  ComJobSelector.GetComListView().Refresh();
                  ClearComInfo();
               }
            }
            else
               MessageBox.Show("Impossible de supprimer la commande car des jobs sont enregistrés sur celle-ci.", "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void ToolStripBtnAddJob_Click(object sender, EventArgs e)
      {
         if (mDBManager_O != null && mDBManager_O.mConnected_b && ComJobSelector.GetComListView().GetSelectedItemID() > 0)
         {
            UInt32 NewJobID_UL = mDBManager_O.mStoredProcedureManager_O.STPROC_CreateEmptyJob(ComJobSelector.GetComListView().GetSelectedItemID());
            ComJobSelector.GetJobListView().Refresh();
            ComJobSelector.GetJobListView().SelectItemByID(NewJobID_UL);
         }
      }

      private void ToolStripBtnCancelJob_Click(object sender, EventArgs e)
      {
         if (mDBManager_O != null && mDBManager_O.mConnected_b && ComJobSelector.GetJobListView().GetSelectedItemID() > 0)
         {
            UInt32 ComJobStatusID_UL;
            UInt32.TryParse(mDBManager_O.GetTableField("ComJob", "ComStatusID", "ComJobID=" + (ComJobSelector.GetJobListView().GetSelectedItemID())), out ComJobStatusID_UL);

            // If job status id is 1 (recorded) it means to nothing has been done on this job, and it can be deleted
            if (ComJobStatusID_UL == 1)
            {
               DialogResult DlgRes_O = MessageBox.Show("La suppression d'un job est une action irréversible (les données seront perdues), êtes-vous certain de vouloir continuer ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

               if (DlgRes_O == DialogResult.Yes)
               {
                  mDBManager_O.ExecuteRequest("DELETE FROM ComJob WHERE ComJobID=" + ComJobSelector.GetJobListView().GetSelectedItemID());
                  ClearJobInfo();
                  ComJobSelector.GetJobListView().Refresh();
               }
            }
            else
            {
               DialogResult DlgRes_O = MessageBox.Show("La suppression d'un job dont le statut n'est pas 'en cours' entraine la perte de tous les pointages associés, êtes-vous certain de vouloir continuer ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

               if (DlgRes_O == DialogResult.Yes)
               {
                  if (mDBManager_O.mStoredProcedureManager_O.STPROC_DeletePointageAndEtape(ComJobSelector.GetJobListView().GetSelectedItemID()))
                  {
                     mDBManager_O.ExecuteRequest("DELETE FROM ComJob WHERE ComJobID=" + ComJobSelector.GetJobListView().GetSelectedItemID());
                     ClearJobInfo();
                     ComJobSelector.GetJobListView().Refresh();
                  }
               }
            }
               
         }
      }

      private void ClearComInfo()
      {
         mIgnoreComValueChangedEvent_b = true;

         TxtClient.Text = "";
         TxtComNumber.Text = "";
         DTPComDate.Value = DTPComDate.MinDate;
         TxtNumComClient.Text = "";
         TxtComLib.Text = "";
         TxtComInfos.Text = "";
         CheckBoxNE.Checked = false;
         CheckBoxCertif.Checked = false;
         CheckBoxRappConf.Checked = false;

         mIgnoreComValueChangedEvent_b = false;
      }

      private void ClearJobInfo()
      {
         mIgnoreJobValueChangedEvent_b = true;

         ToolStripBtnJobLib.Text = "";
         TxtQte.Text = "";
         TxtQteProd.Text = "";
         TxtQteFact.Text = "";
         TxtHEstim.Text = "";
         TxtPVUnitEst.Text = "";
         TxtPVUnitFact.Text = "";
         TxtJobStatus.Text = "";
         TxtJobInfo.Text = "";
         CheckBoxRegieWork.Checked = false;
         DTPClientDelay.Value = DTPClientDelay.MinDate;
         DTPPromiseDelay.Value = DTPPromiseDelay.MinDate;
         JobAssociatedDep.Clear();
         TxtHPrest.Text = "";
         JobProgress.Value = 0;

         mIgnoreJobValueChangedEvent_b = false;
      }

      private void ToolStripBtnLoadClientPref_Click(object sender, EventArgs e)
      {
         LoadClientPref();
      }

      private void LoadClientPref()
      {
         UInt32 ComID_UL = ComJobSelector.GetComListView().GetSelectedItemID();

         if (mDBManager_O != null && mDBManager_O.mConnected_b && ComID_UL > 0)
         {
            UInt32 ClientID_UL;

            if (UInt32.TryParse(mDBManager_O.GetTableField("Com", "ClientID", "ComID=" + ComID_UL), out ClientID_UL))
            {
               bool CanParseNE_b, CanParseCertif_b, CanParseRappConf_b;
               int CheckNE_i, CheckCertif_i, CheckRappConf_i;
               bool CheckNE_b, CheckCertif_b, CheckRappConf_b;

               CanParseNE_b = int.TryParse(mDBManager_O.GetTableField("Client", "NoteEnvoi", "ClientID=" + ClientID_UL), out CheckNE_i);
               CanParseCertif_b = int.TryParse(mDBManager_O.GetTableField("Client", "Certif", "ClientID=" + ClientID_UL), out CheckCertif_i);
               CanParseRappConf_b = int.TryParse(mDBManager_O.GetTableField("Client", "RappConf", "ClientID=" + ClientID_UL), out CheckRappConf_i);

               if (CanParseNE_b && CanParseCertif_b && CanParseRappConf_b)
               {
                  CheckNE_b = Convert.ToBoolean(CheckNE_i);
                  CheckCertif_b = Convert.ToBoolean(CheckCertif_i);
                  CheckRappConf_b = Convert.ToBoolean(CheckRappConf_i);

                  if (CheckNE_b != CheckBoxNE.Checked)
                     CheckBoxNE.Checked = CheckNE_b;
                  if (CheckCertif_b != CheckBoxCertif.Checked)
                     CheckBoxCertif.Checked = CheckCertif_b;
                  if (CheckRappConf_b != CheckBoxRappConf.Checked)
                     CheckBoxRappConf.Checked = CheckRappConf_b;
               }
            }
         } 
      }

      private void ToolStripBtnReports_Click(object sender, EventArgs e)
      {
         if (ComJobSelector.GetJobListView().GetSelectedItemID() > 0)
         {
            mDocManager_O.ShowJobInfoDocument(ComJobSelector.GetJobListView().GetSelectedItemID());
         }
      }

      private void ToolStripBtnAddNeCertif_Click(object sender, EventArgs e)
      {
         if (ComJobSelector.GetJobListView().GetSelectedItemID() > 0)
         {
            FormNeCertif FormNeCertif_O = new FormNeCertif(mDBManager_O, ComJobSelector.GetJobListView().GetSelectedItemID());

            if (FormNeCertif_O.ShowDialog() == DialogResult.OK)
            {
               JobClick(ComJobSelector.GetJobListView().GetSelectedItemID());
            }
         }         
      }

      private void ToolStripBtnReturn_Click(object sender, EventArgs e)
      {
         if (mDocManager_O != null && ComJobSelector.GetJobListView().GetSelectedItemID() > 0)
         {
            mDocManager_O.ShowReturnDocument(ComJobSelector.GetJobListView().GetSelectedItemID());
         }
      }

      private void DTPClientDelay_ValueChanged(object sender, EventArgs e)
      {
         //DTPPromiseDelay.Value = DTPClientDelay.Value;
      }

      private void ToolStripBtnReturnDBListView_Click(object sender, EventArgs e)
      {
          FormReturnListView FormReturnListView_O = new FormReturnListView(mDBManager_O, ComJobSelector.GetJobListView().GetSelectedItemID());
          FormReturnListView_O.ShowDialog();
      }
   }
}
