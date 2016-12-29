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
   public enum CheckingEditionMode
   {
      Add = 0,
      Edit
   }

   public partial class CheckingEdition : UserControl
   {
      private DateTime mDate_O;
      private UInt32 mPersID_UL;
      private UInt32 mComJobID_UL;
      private UInt32 mComJobEtapeID_UL;
      private CheckingEditionMode mMode_e;
      private DatabaseManager mDataBaseManager_O;
      private List<String> mJobCheckDBField_O;
      private List<String> mJobCheckHeaders_O;
      List<int> mJobHeaderDefaultSize_i = new List<int>();
      List<HorizontalAlignment> mJobTextAlign_O = new List<HorizontalAlignment>();

      private UInt32[] mPointageMachineID_O;

      public delegate void CheckingValidatedHandler();
      public event CheckingValidatedHandler CheckingValidated;

      public CheckingEdition()
      {
         InitializeComponent();
      }

      public void Initialize(DatabaseManager DBManager_O, DateTime Date_O, UInt32 PersID_UL, UInt32 ComJobID_UL, CheckingEditionMode Mode_e = CheckingEditionMode.Add, UInt32 ComJobEtapeID_UL = 0)
      {
         mDataBaseManager_O = DBManager_O;
         mDate_O = Date_O;
         mPersID_UL = PersID_UL;
         mComJobID_UL = ComJobID_UL;
         mComJobEtapeID_UL = ComJobEtapeID_UL;
         mMode_e = Mode_e;
         mPointageMachineID_O = new UInt32[4];

         // Define column DB fields
         mJobCheckDBField_O = new List<String>();
         mJobCheckDBField_O.Add("DatePrest");
         mJobCheckDBField_O.Add("TypeTacheCod");
         mJobCheckDBField_O.Add("TypeTacheLib");
         mJobCheckDBField_O.Add("PersNom");
         mJobCheckDBField_O.Add("Rem");
         mJobCheckDBField_O.Add("PointageID");

         // Define column headers text
         mJobCheckHeaders_O = new List<string>();
         mJobCheckHeaders_O.Add("Date");
         mJobCheckHeaders_O.Add("Type tâche");
         mJobCheckHeaders_O.Add("Tache libellé");
         mJobCheckHeaders_O.Add("Opérateur");
         mJobCheckHeaders_O.Add("Remarques");

         mJobTextAlign_O = new List<HorizontalAlignment>();

         for (int i = 0; i < mJobCheckHeaders_O.Count; i++)
               mJobTextAlign_O.Add(HorizontalAlignment.Left);


         mJobHeaderDefaultSize_i = new List<int>();
         mJobHeaderDefaultSize_i.Add(70);
         mJobHeaderDefaultSize_i.Add(70);
         mJobHeaderDefaultSize_i.Add(150);
         mJobHeaderDefaultSize_i.Add(100);
         mJobHeaderDefaultSize_i.Add(600);

         DBLstViewJobChecking.Initialize(mDataBaseManager_O, "PointageSelectPop", mJobCheckDBField_O, 5, mJobCheckHeaders_O, mJobHeaderDefaultSize_i, mJobTextAlign_O, "ComJobID=" + mComJobID_UL, "", true);

         ControlStyle.SetFrameStyle(this);
         ControlStyle.SetFrameStyle(this.DBLstViewJobChecking);
         ControlStyle.SetFrameStyle(this.DBComboxDep);
         ControlStyle.SetFrameStyle(this.DBComboxTask);
         ControlStyle.SetFrameHeaderStyle(this.splitContainer);
         ControlStyle.SetFrameStyle(this.splitContainer.Panel1);
         ControlStyle.SetFrameStyle(this.splitContainer.Panel2);

         // Not so good when dealing with different screen resolutions
         //this.splitContainer.SplitterDistance = (int)(this.Height * 0.75);
      }

      public void LoadChecking()
      {
         String SQLRequest_ST;
         SqlDataReader SqlDataReader_O;
         UInt32 PointageMachine_UL = 1;
         UInt32 TaskID_UL = 0;
         UInt32 MachineID_UL = 0;
         UInt32 HallID_UL = 0;
         UInt32 DepID_UL = 0;
   
         if (mDataBaseManager_O != null && mDataBaseManager_O.mConnected_b)
         {
            // Fill pointage info
            SQLRequest_ST = "SELECT * FROM Pointage WHERE ComJobEtapeID=" + mComJobEtapeID_UL;
            SqlDataReader_O = mDataBaseManager_O.Select(SQLRequest_ST);

            while (SqlDataReader_O.Read())
            {
               // Select Task
               if (UInt32.TryParse(mDataBaseManager_O.GetTableField("ComJobEtape", "TypeTacheID", "ComJobEtapeID=" + mComJobEtapeID_UL), out TaskID_UL))
               {
                  if (UInt32.TryParse(mDataBaseManager_O.GetTableField("TypeTache", "TypeDepID", "TypeTacheID=" + TaskID_UL), out DepID_UL))
                  {
                     DBComboxDep.SelectItemByID(DepID_UL);
                     DBComboxTask.SelectItemByID(TaskID_UL);
                  }
               }
               // Fill NbrH field
               TxtNbrH.Text = SqlDataReader_O["NbrH"].ToString();
               // Fill Rem field
               TxtRem.Text = SqlDataReader_O["Rem"].ToString();
            }

            SqlDataReader_O.Close();

            // Fill pointage machine info
            SQLRequest_ST = "SELECT * FROM PointageMachine WHERE ComJobEtapeID=" + mComJobEtapeID_UL;
            SqlDataReader_O = mDataBaseManager_O.Select(SQLRequest_ST);

            while (SqlDataReader_O.Read())
            {
               if (PointageMachine_UL >= 1 && PointageMachine_UL <= 4)
                  UInt32.TryParse(SqlDataReader_O["PointageMachinelID"].ToString(), out mPointageMachineID_O[PointageMachine_UL - 1]);

               if (PointageMachine_UL == 1)
               {
                  if (UInt32.TryParse(SqlDataReader_O["MachineID"].ToString(), out MachineID_UL))
                  {
                     if (UInt32.TryParse(mDataBaseManager_O.GetTableField("Machine", "HallID", "MachineID=" + MachineID_UL), out HallID_UL))
                     {
                        DBComboxHall1.SelectItemByID(HallID_UL);
                        DBComboxMachine1.SelectItemByID(MachineID_UL);
                     }
                  }
                  TxtNbrhMach1.Text = SqlDataReader_O["NbrHMachine"].ToString();
               }
               else if (PointageMachine_UL == 2)
               {
                  if (UInt32.TryParse(SqlDataReader_O["MachineID"].ToString(), out MachineID_UL))
                  {
                     if (UInt32.TryParse(mDataBaseManager_O.GetTableField("Machine", "HallID", "MachineID=" + MachineID_UL), out HallID_UL))
                     {
                        DBComboxHall2.SelectItemByID(HallID_UL);
                        DBComboxMachine2.SelectItemByID(MachineID_UL);
                     }
                  }  
                  TxtNbrhMach2.Text = SqlDataReader_O["NbrHMachine"].ToString();

               }
               else if (PointageMachine_UL == 3)
               {
                  if (UInt32.TryParse(SqlDataReader_O["MachineID"].ToString(), out MachineID_UL))
                  {
                     if (UInt32.TryParse(mDataBaseManager_O.GetTableField("Machine", "HallID", "MachineID=" + MachineID_UL), out HallID_UL))
                     {
                        DBComboxHall3.SelectItemByID(HallID_UL);
                        DBComboxMachine3.SelectItemByID(MachineID_UL);
                     }
                  }
                  TxtNbrhMach3.Text = SqlDataReader_O["NbrHMachine"].ToString();
               }
               else if (PointageMachine_UL == 4)
               {
                  if (UInt32.TryParse(SqlDataReader_O["MachineID"].ToString(), out MachineID_UL))
                  {
                     if (UInt32.TryParse(mDataBaseManager_O.GetTableField("Machine", "HallID", "MachineID=" + MachineID_UL), out HallID_UL))
                     {
                        DBComboxHall4.SelectItemByID(HallID_UL);
                        DBComboxMachine4.SelectItemByID(MachineID_UL);
                     }
                  }
                  TxtNbrhMach4.Text = SqlDataReader_O["NbrHMachine"].ToString();
               }

               PointageMachine_UL++;
            }

            SqlDataReader_O.Close();
         }    
      }

      private void ToolStripBtnValidate_Click(object sender, EventArgs e)
      {
         CheckingValidated();
      }

      private void CheckingEdition_Load(object sender, EventArgs e)
      {
         // Fill dep and machine check DB combo box with prefered user dep
         DBComboxDep.FillList(mDataBaseManager_O, "TypeDep", "TypeDepID", "TypeDepLib");
         DBComboxHall1.FillList(mDataBaseManager_O, "Hall", "HallID", "HallName");
         DBComboxHall2.FillList(mDataBaseManager_O, "Hall", "HallID", "HallName");
         DBComboxHall3.FillList(mDataBaseManager_O, "Hall", "HallID", "HallName");
         DBComboxHall4.FillList(mDataBaseManager_O, "Hall", "HallID", "HallName");

         // Get user prefered dep and hall
         UInt32 PrefDep_UL = 0;
         UInt32 PrefHall_UL = 0;
         UInt32.TryParse(mDataBaseManager_O.GetTableField("Pers", "PrefDepID", "PersID=" + mPersID_UL), out PrefDep_UL);
         UInt32.TryParse(mDataBaseManager_O.GetTableField("Pers", "PrefHallID", "PersID=" + mPersID_UL), out PrefHall_UL);

         // If prefered dep and hall found, select it in dep combo box
         if (PrefDep_UL > 0)
            DBComboxDep.SelectItemByID(PrefDep_UL);
         if (PrefHall_UL > 0)
         {
            DBComboxHall1.SelectItemByID(PrefHall_UL);
            DBComboxHall2.SelectItemByID(PrefHall_UL);
            DBComboxHall3.SelectItemByID(PrefHall_UL);
            DBComboxHall4.SelectItemByID(PrefHall_UL);
         }

         // Update Task combo box
         UpdateTaskDBComboBox(PrefDep_UL);
         UpdateMachineDBCombox(DBComboxMachine1, PrefHall_UL);
         UpdateMachineDBCombox(DBComboxMachine2, PrefHall_UL);
         UpdateMachineDBCombox(DBComboxMachine3, PrefHall_UL);
         UpdateMachineDBCombox(DBComboxMachine4, PrefHall_UL);

         if (mMode_e == CheckingEditionMode.Edit)
            LoadChecking();

         if (mDataBaseManager_O.mConnected_b)
            LblSumHours.Text = mDataBaseManager_O.mFunctionManager_O.SCFNC_CountPersHourInJob(mComJobID_UL, mPersID_UL).ToString();
      }

      private void DBComboxDep_SelectedValueChanged(object sender, EventArgs e)
      {
         UInt32 SelectedItemID_UL;

         if (DBComboxDep.GetSelectedItemID(out SelectedItemID_UL))
            UpdateTaskDBComboBox(SelectedItemID_UL);
      }

      /// <summary>
      /// Builds task combo box according to selcted item in dep combo box
      /// </summary>
      /// <param name="DepID_i"></param>
      private void UpdateTaskDBComboBox(UInt32 DepID_UL)
      {
         String TaskWhere_ST = "";

         if (DepID_UL > 0)
         {
            TaskWhere_ST = "TypeDepID=" + DepID_UL;
         }

         DBComboxTask.FillList(mDataBaseManager_O, "TypeTache", "TypeTacheID", "TypeTacheLib", TaskWhere_ST);
      }

      /// <summary>
      /// Builds machine combo box according to selcted item in hall combo box
      /// </summary>
      /// <param name="DBComboxHall_O"></param>
      /// <param name="PrefHall_UL"></param>
      private void UpdateMachineDBCombox(DBComboBox DBComboxMachine_O, UInt32 Hall_UL)
      {
         String MachineWhere_ST = "";

         if (Hall_UL > 0)
         {
            MachineWhere_ST = "HallID=" + Hall_UL;
         }

         DBComboxMachine_O.FillList(mDataBaseManager_O, "Machine", "MachineID", "MachineLib", MachineWhere_ST);
      }

      /// <summary>
      /// This method record checking edition.
      /// </summary>
      public bool RecordModifications()
      {
         double NbrH_f, NbrhMach1_f, NbrhMach2_f, NbrhMach3_f, NbrhMach4_f;
         bool Rts_b = false;
         UInt32 TaskCount_UL, ComJobEtapeID_UL, SelectedItemID_UL, NewCheckingID_UL;

         if (mMode_e == CheckingEditionMode.Add)
         {
            if (CheckData(out NbrH_f, out NbrhMach1_f, out NbrhMach2_f, out NbrhMach3_f, out NbrhMach4_f) && mDataBaseManager_O.mConnected_b)
            {
               // Create job step
               TaskCount_UL = mDataBaseManager_O.mStoredProcedureManager_O.STPROC_CountTask(mComJobID_UL);

               if (DBComboxTask.GetSelectedItemID(out SelectedItemID_UL))
               {
                  ComJobEtapeID_UL = mDataBaseManager_O.mStoredProcedureManager_O.STPROC_CreateComJobEtape(mComJobID_UL, SelectedItemID_UL, TaskCount_UL);

                  if (ComJobEtapeID_UL > 0)
                  {
                     // Create pointage on this step
                     NewCheckingID_UL = mDataBaseManager_O.mStoredProcedureManager_O.STPROC_CreatePointage(mComJobID_UL, ComJobEtapeID_UL, mPersID_UL, NbrH_f, TxtRem.Text, mDate_O);

                     // Create pointage machine
                     if (DBComboxMachine1.GetSelectedItemID(out SelectedItemID_UL))
                        mDataBaseManager_O.mStoredProcedureManager_O.STPROC_CreatePointageMachine(ComJobEtapeID_UL, SelectedItemID_UL, NbrhMach1_f);

                     if (DBComboxMachine2.GetSelectedItemID(out SelectedItemID_UL))
                        mDataBaseManager_O.mStoredProcedureManager_O.STPROC_CreatePointageMachine(ComJobEtapeID_UL, SelectedItemID_UL, NbrhMach2_f);

                     if (DBComboxMachine3.GetSelectedItemID(out SelectedItemID_UL))
                        mDataBaseManager_O.mStoredProcedureManager_O.STPROC_CreatePointageMachine(ComJobEtapeID_UL, SelectedItemID_UL, NbrhMach3_f);

                     if (DBComboxMachine4.GetSelectedItemID(out SelectedItemID_UL))
                        mDataBaseManager_O.mStoredProcedureManager_O.STPROC_CreatePointageMachine(ComJobEtapeID_UL, SelectedItemID_UL, NbrhMach4_f);

                     // If first checking on job, set status to "in progress"
                     if (TaskCount_UL == 0)
                     {
                        mDataBaseManager_O.mStoredProcedureManager_O.STPROC_StartJob(mComJobID_UL);
                     }

                  }
                  else
                     MessageBox.Show("Erreur lors de l'enregistrement du pointage : l'étape associée n'a pu être créée.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }

               Rts_b = true;
            }
         }
         else if (mMode_e == CheckingEditionMode.Edit)
         {
            UInt32 SelectedTaskID_UL;
            UInt32 MachineID_UL;
            List<String> Param_O = new List<String>();
            List<Object> Values_O = new List<Object>();

            if (mDataBaseManager_O.mConnected_b)
            {
               DBComboxTask.GetSelectedItemID(out SelectedTaskID_UL);
               // Update task
               Param_O.Add("@TypeTacheID");   Values_O.Add((int)SelectedTaskID_UL); 
               Param_O.Add("@ComJobEtapeID"); Values_O.Add((int)mComJobEtapeID_UL);

               mDataBaseManager_O.ExecuteRequest("UPDATE ComJobEtape SET TypeTacheID=@TypeTacheID WHERE ComJobEtapeID=@ComJobEtapeID", Param_O, Values_O);

               // Update pointage
               Param_O.Clear();
               Values_O.Clear();

               double Nbrh_f;
               Double.TryParse(TxtNbrH.Text.Replace(',', '.'), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out Nbrh_f);

               Param_O.Add("@NbrH"); Values_O.Add(Nbrh_f);
               Param_O.Add("@Rem"); Values_O.Add(TxtRem.Text);
               Param_O.Add("@ComJobEtapeID"); Values_O.Add((int)mComJobEtapeID_UL);

               mDataBaseManager_O.ExecuteRequest("UPDATE Pointage SET NbrH=@NbrH, Rem=@Rem WHERE ComJobEtapeID=@ComJobEtapeID", Param_O, Values_O);

               // Update pointage machine (create it if not yet created)
               if (CheckData(out NbrH_f, out NbrhMach1_f, out NbrhMach2_f, out NbrhMach3_f, out NbrhMach4_f))
               {
                  DBComboxMachine1.GetSelectedItemID(out MachineID_UL);
                  if (MachineID_UL > 0)
                  {
                     if (mPointageMachineID_O[0] == 0 && DBComboxTask.GetSelectedItemID(out SelectedItemID_UL))
                        mPointageMachineID_O[0] = mDataBaseManager_O.mStoredProcedureManager_O.STPROC_CreatePointageMachine(mComJobEtapeID_UL, SelectedItemID_UL, NbrhMach1_f);

                     Param_O.Clear();
                     Values_O.Clear();

                     Param_O.Add("@MachineID"); Values_O.Add((int)MachineID_UL);

                     double.TryParse(TxtNbrhMach1.Text.Replace(',', '.'), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out Nbrh_f);
                     Param_O.Add("@NbrHMachine"); Values_O.Add(Nbrh_f);

                     Param_O.Add("@PointageMachinelID"); Values_O.Add((int)mPointageMachineID_O[0]);

                     mDataBaseManager_O.ExecuteRequest("UPDATE PointageMachine SET MachineID=@MachineID, NbrHMachine=@NbrHMachine WHERE PointageMachinelID=@PointageMachinelID", Param_O, Values_O);
                  }

                  DBComboxMachine2.GetSelectedItemID(out MachineID_UL);
                  if (MachineID_UL > 0)
                  {
                     if (mPointageMachineID_O[1] == 0 && DBComboxTask.GetSelectedItemID(out SelectedItemID_UL))
                        mPointageMachineID_O[1] = mDataBaseManager_O.mStoredProcedureManager_O.STPROC_CreatePointageMachine(mComJobEtapeID_UL, SelectedItemID_UL, NbrhMach2_f);

                     Param_O.Clear();
                     Values_O.Clear();

                     Param_O.Add("@MachineID"); Values_O.Add((int)MachineID_UL);
                     Param_O.Add("@NbrHMachine"); Values_O.Add(TxtNbrhMach2.Text);
                     Param_O.Add("@PointageMachinelID"); Values_O.Add((int)mPointageMachineID_O[1]);

                     mDataBaseManager_O.ExecuteRequest("UPDATE PointageMachine SET MachineID=@MachineID, NbrHMachine=@NbrHMachine WHERE PointageMachinelID=@PointageMachinelID", Param_O, Values_O);
                  }

                  DBComboxMachine3.GetSelectedItemID(out MachineID_UL);
                  if (MachineID_UL > 0)
                  {
                     if (mPointageMachineID_O[2] == 0 && DBComboxTask.GetSelectedItemID(out SelectedItemID_UL))
                        mPointageMachineID_O[2] = mDataBaseManager_O.mStoredProcedureManager_O.STPROC_CreatePointageMachine(mComJobEtapeID_UL, SelectedItemID_UL, NbrhMach3_f);

                     Param_O.Clear();
                     Values_O.Clear();

                     Param_O.Add("@MachineID"); Values_O.Add((int)MachineID_UL);
                     Param_O.Add("@NbrHMachine"); Values_O.Add(TxtNbrhMach3.Text);
                     Param_O.Add("@PointageMachinelID"); Values_O.Add((int)mPointageMachineID_O[2]);

                     mDataBaseManager_O.ExecuteRequest("UPDATE PointageMachine SET MachineID=@MachineID, NbrHMachine=@NbrHMachine WHERE PointageMachinelID=@PointageMachinelID", Param_O, Values_O);
                  }

                  DBComboxMachine4.GetSelectedItemID(out MachineID_UL);
                  if (MachineID_UL > 0)
                  {
                     if (mPointageMachineID_O[3] == 0 && DBComboxTask.GetSelectedItemID(out SelectedItemID_UL))
                        mPointageMachineID_O[3] = mDataBaseManager_O.mStoredProcedureManager_O.STPROC_CreatePointageMachine(mComJobEtapeID_UL, SelectedItemID_UL, NbrhMach4_f);

                     Param_O.Clear();
                     Values_O.Clear();

                     Param_O.Add("@MachineID"); Values_O.Add((int)MachineID_UL);
                     Param_O.Add("@NbrHMachine"); Values_O.Add(TxtNbrhMach4.Text);
                     Param_O.Add("@PointageMachinelID"); Values_O.Add((int)mPointageMachineID_O[3]);

                     mDataBaseManager_O.ExecuteRequest("UPDATE PointageMachine SET MachineID=@MachineID, NbrHMachine=@NbrHMachine WHERE PointageMachinelID=@PointageMachinelID", Param_O, Values_O);
                  }
               }
               
               Rts_b = true;
            } 
           
            // Don't forget to update hours tot and corrected on job
            if (Rts_b)
            {
               mDataBaseManager_O.mStoredProcedureManager_O.STPROC_UpdateJobSumHours(mComJobID_UL);
            }
         }

         return Rts_b;
      }

      /// <summary>
      /// This method checks if all data entered by user is correct before recording modifications. If this is not the case, wrong elements in GUI are highlighted.
      /// </summary>
      /// <returns></returns>
      private bool CheckData(out double Nbrh_f, out double NbrhMach1_f, out double NbrhMach2_f, out double NbrhMach3_f, out double NbrhMach4_f)
      {
         bool Rts_b = true;
         UInt32 Mach1SelectedItemID_UL, Mach2SelectedItemID_UL, Mach3SelectedItemID_UL, Mach4SelectedItemID_UL, TaskID_UL;
         NbrhMach1_f = 0.0f;
         NbrhMach2_f = 0.0f;
         NbrhMach3_f = 0.0f;
         NbrhMach4_f = 0.0f;

         Rts_b &= DBComboxTask.GetSelectedItemID(out TaskID_UL);
         Rts_b &= Double.TryParse(TxtNbrH.Text.Replace(',', '.'), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out Nbrh_f);

         if (DBComboxMachine1.GetSelectedItemID(out Mach1SelectedItemID_UL))
            Rts_b &= Double.TryParse(TxtNbrhMach1.Text.Replace(',', '.'), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out NbrhMach1_f);

         if (DBComboxMachine2.GetSelectedItemID(out Mach2SelectedItemID_UL))
            Rts_b &= Double.TryParse(TxtNbrhMach2.Text.Replace(',', '.'), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out NbrhMach2_f);

         if (DBComboxMachine3.GetSelectedItemID(out Mach3SelectedItemID_UL))
            Rts_b &= Double.TryParse(TxtNbrhMach3.Text.Replace(',', '.'), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out NbrhMach3_f);

         if (DBComboxMachine4.GetSelectedItemID(out Mach4SelectedItemID_UL))
            Rts_b &= Double.TryParse(TxtNbrhMach4.Text.Replace(',', '.'), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out NbrhMach4_f);

         return Rts_b;
      }

      private void DBComboxHall1_SelectedValueChanged(object sender, EventArgs e)
      {
         UInt32 SelectedItemID_UL;

         if (DBComboxHall1.GetSelectedItemID(out SelectedItemID_UL))
            UpdateMachineDBCombox(DBComboxMachine1, SelectedItemID_UL);
      }

      private void DBComboxHall2_SelectedValueChanged(object sender, EventArgs e)
      {
         UInt32 SelectedItemID_UL;

         if (DBComboxHall2.GetSelectedItemID(out SelectedItemID_UL))
            UpdateMachineDBCombox(DBComboxMachine2, SelectedItemID_UL);
      }

      private void DBComboxHall3_SelectedValueChanged(object sender, EventArgs e)
      {
         UInt32 SelectedItemID_UL;

         if (DBComboxHall3.GetSelectedItemID(out SelectedItemID_UL))
            UpdateMachineDBCombox(DBComboxMachine3, SelectedItemID_UL);
      }

      private void DBComboxHall4_SelectedValueChanged(object sender, EventArgs e)
      {
         UInt32 SelectedItemID_UL;

         if (DBComboxHall4.GetSelectedItemID(out SelectedItemID_UL))
            UpdateMachineDBCombox(DBComboxMachine4, SelectedItemID_UL);
      }

      public void SetFrameTitle(String FrameTitle_ST)
      {
         this.DBLstViewJobChecking.ListTitle = FrameTitle_ST;
      }
   }
}