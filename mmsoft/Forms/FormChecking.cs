using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MMSoft
{
    /// <summary>
    /// Class defining the form for operators and managers daily checkings.
    /// </summary>
    public partial class FormChecking : Form
    {
        /// <summary>
        /// Form's inner Database manager used to check correctness of user/pwd combination. This database manager will be passed to other forms at log in.
        /// </summary>
        private DatabaseManager mDBManager_O;

        private DocumentManager mDocManager_O;

        /// <summary>
        /// Internal connexion form of main form checking
        /// </summary>
        FormConnexion mFormConnexion_O;

        /// <summary>
        /// Defines if user has been identified through connexion form
        /// </summary>
        private bool UserIdentified_b;

        /// <summary>
        /// User id identified by child form FormConnexion
        /// </summary>
        public static UInt32 mUserID_UL;

        List<String> mComJobTableField_ST = new List<String>();
        List<String> mComJobColumnHeaderName_ST = new List<String>();
        List<int> mComJobColumnHeaderDefaultSize_i = new List<int>();
        List<HorizontalAlignment> mComJobTextAlign_O = new List<HorizontalAlignment>();

        /// <summary>
        /// Constructor
        /// </summary>
        public FormChecking(DatabaseManager DBManager_O, UInt32 UserID_UL)
        {
            InitializeComponent();

            // Init Database Manager
            mDBManager_O = DBManager_O;
            mDocManager_O = new DocumentManager(mDBManager_O);
            mUserID_UL = UserID_UL;

            DbListViewComJobs.AddToolStripBtn(ToolStripBtnAddChecking);
            DbListViewComJobs.AddToolStripBtn(ToolStripBtnCloseJob);
            DbListViewComJobs.AddToolStripBtn(ToolStripBtnAll);
            FormCheckingToolStrip.Visible = false;

            // Set drag bar parent window an title
            this.FormDragBar.SetParentWindow(this);
            this.FormDragBar.SetTitle("MMSoft - Pointages");

            // Initialize db list view com job
            DbListViewComJobs.ListTitle = "Sélection des jobs";

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
            //mComJobTableField_ST.Add("DateEncod");
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
            //mComJobColumnHeaderName_ST.Add("Date encodage");

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

            DbListViewComJobs.Initialize(mDBManager_O, "PersComJobSelectPop", mComJobTableField_ST, 10, mComJobColumnHeaderName_ST, mComJobColumnHeaderDefaultSize_i, mComJobTextAlign_O, 
               "JobStatusID < 3 AND PersID=" + mUserID_UL, null);
            DbListViewComJobs.ItemDoubleClicked += new DBListView.ItemDoubleClickedHandler(ComJobDoubleClick);

            // Initialize day checking viewer
            DayCheckingViewerCtrl.Initialize(mDBManager_O, DateTime.Today, mUserID_UL, false);
            DayCheckingViewerCtrl.RefreshPersPointage();

            this.splitContainer1.SplitterDistance = this.Height / 3;

            // Set menu items renderer
            MainMenuStrip.RenderMode = ToolStripRenderMode.Professional;
            MainMenuStrip.Renderer = new CustomMenuItemRenderer();

            //Display user name
            if (mDBManager_O.mConnected_b)
            {
               LblUsername.Text = mDBManager_O.GetTableField("Pers", "PersNom", "PersID=" + mUserID_UL);
            } 

            LblConnectionStatus.Text = mDBManager_O.mDBInstanceName_ST;

            // Set control style
            ControlStyle.SetBackgroundStyle(this.splitContainer1);
            ControlStyle.SetFrameHeaderStyle(this.splitContainer1.Panel1);
            ControlStyle.SetFrameHeaderStyle(this.splitContainer1.Panel2);
            ControlStyle.SetBackgroundStyle(MainMenuStrip);
            ControlStyle.SetBackgroundStyle(this.StatusStripFormChecking);
            RefreshPersPointage();
        }

        private void DisplayConnexionForm()
        {
            mFormConnexion_O = new FormConnexion();
            mFormConnexion_O.ShowDialog(); // When calling showdialog instead of show, parent is blocked
            if (mUserID_UL > 0)
            {
               UserIdentified_b = true;
            }

            LblUsername.Text = mUserID_UL + "";
        }
        /// <summary>
        /// Method that reload the pers pointage according to the date selected by user
        /// </summary>
        public void RefreshPersPointage()
        {
           DayCheckingViewerCtrl.RefreshPersPointage();
        }

        private void FormChecking_Load(object sender, EventArgs e)
        {
           this.MaximizeBox = false;
        }

        private void AddCheckingToolStripMenuItem_Click(object sender, EventArgs e)
        {
           if (mDBManager_O != null && mDBManager_O.mConnected_b)
           {
              String JobOrder_ST = mDBManager_O.GetTableField("ComJob", "NumOrdre", "ComJobID=" + DbListViewComJobs.GetSelectedItemID());
              String ComJobNumRef_ST = mDBManager_O.GetTableField("ComJobSelectPop", "NumRefInterne", "ComJobID=" + DbListViewComJobs.GetSelectedItemID());
              String JobLib_ST = mDBManager_O.GetTableField("ComJob", "JobLib", "ComJobID=" + DbListViewComJobs.GetSelectedItemID());

              if (DbListViewComJobs.GetSelectedItemID() > 0)
              {
                 FormCheckingEdition FormCheckingEdition_O = new FormCheckingEdition();
                 FormCheckingEdition_O.Initialize(mDBManager_O, DayCheckingViewerCtrl.GetViewerDate(), mUserID_UL, DbListViewComJobs.GetSelectedItemID());
                 FormCheckingEdition_O.SetFrameTitle("Ajout pointage sur job n° " + JobOrder_ST + " dans " + ComJobNumRef_ST + " : " + JobLib_ST);
                 FormCheckingEdition_O.ShowDialog();

                 DbListViewComJobs.Refresh();
                 DayCheckingViewerCtrl.RefreshPersPointage(); // Check if easy to only add one check viewer in list instead of refresh everything
              }
              else
                 MessageBox.Show("Veuillez sélectionner un job pour enregistrer un nouveau pointage.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           }
        }

        private void ComJobDoubleClick(UInt32 ComJobID_UL)
        {
           AddCheckingToolStripMenuItem_Click(this, new EventArgs());
        }

        private void DecoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           if (mDBManager_O != null)
              mDBManager_O.DisconnectDatabase();
           this.Dispose();
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
           if (mDBManager_O != null)
              mDBManager_O.DisconnectDatabase();
           Application.Exit();
        }

        private void ResetFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
           DbListViewComJobs.RefreshFilterTxt(true);
        }

        private void PrefToolStripMenuItem_Click(object sender, EventArgs e)
        {
           FormUserPref FormUserPref_O = new FormUserPref();
           FormUserPref_O.Initialize(mDBManager_O, mUserID_UL);

           FormUserPref_O.ShowDialog();
        }

        private void WhatAboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
           FormVersion FormVersion_O = new FormVersion();
           FormVersion_O.ShowDialog();
        }

        private void ToolStripBtnAddChecking_Click(object sender, EventArgs e)
        {
           AddCheckingToolStripMenuItem_Click(this, EventArgs.Empty);
        }

        private void ToolStripBtnCloseJob_Click(object sender, EventArgs e)
        {
           FormAskString FormAskString_O = new FormAskString("Quantité produite :");
           DialogResult DlgRes_O = FormAskString_O.ShowDialog();
           double Qte_f;

           if (DlgRes_O == DialogResult.OK && mDBManager_O != null && mDBManager_O.mConnected_b)
           {
               if (DbListViewComJobs.GetSelectedItemID() > 0)
               {
                  if (Double.TryParse(FormAskString_O.mEnteredString_ST, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out Qte_f))
                  {
                     DialogResult DlgConfirm_O = MessageBox.Show("Etes-vous sûr de vouloir clôturer le job " + DbListViewComJobs.GetSelectedItemField("JobLib") + " avec une quantité produite de " + Qte_f + " ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                     if (DlgConfirm_O == DialogResult.Yes)
                     {
                        if (mDBManager_O.ExecuteRequest("UPDATE ComJob SET QteProd='" + Qte_f.ToString().Replace(",", ".") + "' WHERE ComJobID=" + DbListViewComJobs.GetSelectedItemID()))
                        {
                           mDBManager_O.mStoredProcedureManager_O.STPROC_CloseJob(DbListViewComJobs.GetSelectedItemID());

                           // Send message to tell manager that job is finished
                           String Msg_ST = "[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "] ";
                           Msg_ST += "Job " + DbListViewComJobs.GetSelectedItemField("JobLib") + " clôturé";
                           mDBManager_O.mStoredProcedureManager_O.STPROC_SendMsg(Msg_ST, mUserID_UL);

                           // Open return document
                           if (mDocManager_O != null && DbListViewComJobs.GetSelectedItemID() > 0)
                           {
                              mDocManager_O.ShowReturnDocument(DbListViewComJobs.GetSelectedItemID());
                           }

                           DbListViewComJobs.Refresh();
                        }
                        else
                        {
                           MessageBox.Show("Impossible d'enregistrer la valeur " + FormAskString_O.mEnteredString_ST + " comme quantité produite.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                     }
                  }
                  else
                  {
                     MessageBox.Show("La quantité entrée n'est pas valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  }
               }
               else
               {
                  MessageBox.Show("Veuillez sélectionner un job à clôturer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
           }
        }

        private void ToolStripBtnAll_Click(object sender, EventArgs e)
        {
           if (ToolStripBtnAll.Checked)
           {
              DbListViewComJobs.SetTableName("ComJobSelectPop");
              DbListViewComJobs.SetInitialFilter("JobStatusID < 3", null);
           }
           else
           {
              DbListViewComJobs.SetTableName("PersComJobSelectPop");
              DbListViewComJobs.SetInitialFilter("JobStatusID < 3 AND PersID=" + mUserID_UL, null);
           }
           
           DbListViewComJobs.Refresh();
        }

        private void FormChecking_FormClosing(object sender, FormClosingEventArgs e)
        {
           if (mDocManager_O != null)
              mDocManager_O.Shutdown();
        }
    }
}
