using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MMSoft
{
   public partial class FormManager : Form
   {
      /// <summary>
      /// Form's inner Database manager used to check correctness of user/pwd combination. This database manager will be passed to other forms at log in.
      /// </summary>
      private DatabaseManager mDBManager_O;

      private DocumentManager mDocManager_O;

      /// <summary>
      /// User id identified by child form FormConnexion
      /// </summary>
      public static UInt32 mUserID_UL;

      private ClientUC mClientUC_O;
      private ProviderUC mProviderUC_O;
      private MembersUC mEmployeesUC_O;
      private ComJobUC mComJobUC_O;
      private HomeUC mHomeUC_O;
      private JobsState mJobStatesUC_O;
      private JobsCorrectionUC mJobCorrectionUC_O;
      private StatsUC mStatsUC_O;
      private HallsUC mHallsUC_O;

      private IMMSoftUC mCurrentUC_O;

      public FormManager(DatabaseManager DBManager_O, UInt32 UserID_UL)
      {
         InitializeComponent();

         HomeImgList.Images.Add(Properties.Resources.Home);
         HomeImgList.Images.Add(Properties.Resources.HomeNewMsg);

         mDBManager_O = DBManager_O;
         mDocManager_O = new DocumentManager(mDBManager_O);
         mUserID_UL = UserID_UL;

         // Set drag bar parent window an title
         this.FormDragBar.SetParentWindow(this);
         this.FormDragBar.SetTitle("MMSoft - Gestion Manager");

         this.ModulesToolStrip.Renderer = new BorderlessToolStripRenderer();

         // Set menu items renderer
         MainMenuStrip.RenderMode = ToolStripRenderMode.Professional;
         MainMenuStrip.Renderer = new CustomMenuItemRenderer();

         //Display user name
         if (mDBManager_O.mConnected_b)
         {
            LblUsername.Text = mDBManager_O.GetTableField("Pers", "PersNom", "PersID=" + mUserID_UL);
         }

         LblConnectionStatus.Text = mDBManager_O.mDBInstanceName_ST;

         mCurrentUC_O = null;
         mClientUC_O = new ClientUC(mDBManager_O);
         mProviderUC_O = new ProviderUC(mDBManager_O);
         mEmployeesUC_O = new MembersUC(mDBManager_O, mDocManager_O);
         mComJobUC_O = new ComJobUC(mDBManager_O, mDocManager_O);
         mHomeUC_O = new HomeUC(mDBManager_O);
         mHomeUC_O.NewMessage += new HomeUC.NewMessageHandler(this.NewMessage);
         mJobStatesUC_O = new JobsState(mDBManager_O);
         mJobCorrectionUC_O = new JobsCorrectionUC(mDBManager_O);
         mStatsUC_O = new StatsUC(mDBManager_O, mDocManager_O);
         mHallsUC_O = new HallsUC(mDBManager_O);

         //ControlStyle.SetBackgroundStyle(this);
         ControlStyle.SetBackgroundStyle(MainMenuStrip);
         ControlStyle.SetBackgroundStyle(ModulesToolStrip);
         ControlStyle.SetBackgroundStyle(ModuleContainerPanel);
         ControlStyle.SetBackgroundStyle(this.StatusStripFormChecking);

         ModuleChanged(ToolStripBtnHome, new EventArgs());
      }

      public void ModuleChanged(object sender, EventArgs e)
      {
         bool Rts_b = true;

         // Disable current active UC
         if (mCurrentUC_O != null)
            Rts_b = mCurrentUC_O.Deactivate();

         if (Rts_b)
         {
            // Disable all btns
            ToolStripBtnClient.Checked = false;
            ToolStripBtnProvider.Checked = false;
            ToolStripBtnMembers.Checked = false;
            ToolStripBtnJobs.Checked = false;
            ToolStripBtnHome.Checked = false;
            ToolStripBtnJobStates.Checked = false;
            ToolStripBtnJobsCorrection.Checked = false;
            ToolStripBtnStats.Checked = false;
            ToolStripBtnHalls.Checked = false;

            ToolStripBtnHome.Image = HomeImgList.Images[0];

            // Enable correct one
            if (sender.Equals(ToolStripBtnClient))
            {
               ToolStripBtnClient.Checked = true;
               mCurrentUC_O = mClientUC_O;
            }
            else if (sender.Equals(ToolStripBtnProvider))
            {
               ToolStripBtnProvider.Checked = true;
               mCurrentUC_O = mProviderUC_O;
            }
            else if (sender.Equals(ToolStripBtnMembers))
            {
               ToolStripBtnMembers.Checked = true;
               mCurrentUC_O = mEmployeesUC_O;
            }
            else if (sender.Equals(ToolStripBtnJobs))
            {
               ToolStripBtnJobs.Checked = true;
               mCurrentUC_O = mComJobUC_O;
            }
            else if (sender.Equals(ToolStripBtnHome))
            {
               ToolStripBtnHome.Checked = true;
               mCurrentUC_O = mHomeUC_O;
            }
            else if (sender.Equals(ToolStripBtnJobStates))
            {
               ToolStripBtnJobStates.Checked = true;
               mCurrentUC_O = mJobStatesUC_O;
            }
            else if (sender.Equals(ToolStripBtnJobsCorrection))
            {
               ToolStripBtnJobsCorrection.Checked = true;
               mCurrentUC_O = mJobCorrectionUC_O;
            }
            else if (sender.Equals(ToolStripBtnStats))
            {
               ToolStripBtnStats.Checked = true;
               mCurrentUC_O = mStatsUC_O;
            }
            else if (sender.Equals(ToolStripBtnHalls))
            {
               ToolStripBtnHalls.Checked = true;
               mCurrentUC_O = mHallsUC_O;
            }

            // Active UC
            if (mCurrentUC_O != null)
               mCurrentUC_O.Activate(ModuleContainerPanel);
         }
         else
         {
            ToolStripBtnClient.Checked = mCurrentUC_O.Equals(mClientUC_O);
            ToolStripBtnProvider.Checked = mCurrentUC_O.Equals(mProviderUC_O);
            ToolStripBtnMembers.Checked = mCurrentUC_O.Equals(mEmployeesUC_O);
            ToolStripBtnJobs.Checked = mCurrentUC_O.Equals(mComJobUC_O);
            ToolStripBtnHome.Checked = mCurrentUC_O.Equals(mHomeUC_O);
            ToolStripBtnJobStates.Checked = mCurrentUC_O.Equals(mJobStatesUC_O);
            ToolStripBtnJobsCorrection.Checked = mCurrentUC_O.Equals(mJobCorrectionUC_O);
            ToolStripBtnStats.Checked = mCurrentUC_O.Equals(mStatsUC_O);
         }
      }

      private void PrefToolStripMenuItem_Click(object sender, EventArgs e)
      {
         FormUserPref FormUserPref_O = new FormUserPref();
         FormUserPref_O.Initialize(mDBManager_O, mUserID_UL);

         FormUserPref_O.ShowDialog();
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

      private void ToolStripBtnChecking_Click(object sender, EventArgs e)
      {
          FormChecking FormChecking_O = new FormChecking(mDBManager_O, mUserID_UL);
          FormChecking_O.Show();
      }

      private void WhatAboutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         FormVersion FormVersion_O = new FormVersion();
         FormVersion_O.ShowDialog();
      }

      private void NewMessage()
      {
         ToolStripBtnHome.Image = HomeImgList.Images[1];
      }

      private void FormManager_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (mDocManager_O != null)
            mDocManager_O.Shutdown();
      }
   }
}
