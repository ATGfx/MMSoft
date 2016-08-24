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
   public partial class JobsState : UserControl, IMMSoftUC
   {
      private DatabaseManager mDBManager_O;
      private Control mParentContainer_O;
      private String mWhereFilter_ST = "JobStatusID=3";

      public JobsState(DatabaseManager DBManager_O)
      {
         mDBManager_O = DBManager_O;

         InitializeComponent();

         ToolStripStatusFilter.Renderer = new BorderlessToolStripRenderer();
         ToolStripJobInfos1.Renderer = new BorderlessToolStripRenderer();

         ToolStripBtnDone.Checked = true;

         ControlStyle.SetBackgroundStyle(this);
         ControlStyle.SetFrameStyle(MainFlowLayoutPanel);
         ControlStyle.SetFrameHeaderStyle(PanelFilterHeader);
         ControlStyle.SetFrameHeaderStyle(PanelJobLifeCycleHeader);
         ControlStyle.SetFrameHeaderStyle(this.splitContainer1.Panel1);
         ControlStyle.SetFrameHeaderStyle(this.splitContainer1.Panel2);
         ControlStyle.SetFrameStyle(ToolStripStatusFilter);
      }

      public bool Activate(Control Container_O)
      {
         mParentContainer_O = Container_O;
         mParentContainer_O.Controls.Add(this);
         this.BringToFront();
         this.Dock = DockStyle.Fill;

         Refresh();

         return true;
      }

      public bool Deactivate()
      {
         bool Rts_b = true;

         if (mParentContainer_O != null)
            mParentContainer_O.Controls.Remove(this);

         return Rts_b;
      }

      private void Refresh()
      {
         String SQLRequest_ST;
         SqlDataReader SqlDataReader_O;

         if (mDBManager_O != null && mDBManager_O.mConnected_b)
         {
            MainFlowLayoutPanel.Controls.Clear();

            SQLRequest_ST = "SELECT ComJobID FROM ComJobSelectPop WHERE " + mWhereFilter_ST + " ORDER BY NumRefInterne";

            SqlDataReader_O = mDBManager_O.Select(SQLRequest_ST);

            while (SqlDataReader_O.Read())
            {
               UInt32 ComJobID_UL;

               if (UInt32.TryParse(SqlDataReader_O["ComJobID"].ToString(), out ComJobID_UL))
               {
                  JobLifeCycle JobLifeCycle_O = new JobLifeCycle(mDBManager_O, ComJobID_UL);
                  MainFlowLayoutPanel.Controls.Add(JobLifeCycle_O);
                  JobLifeCycle_O.Width = MainFlowLayoutPanel.Width - MainFlowLayoutPanel.Padding.Left - MainFlowLayoutPanel.Padding.Right - 25;
               }
            }
         }
      }

      private void FilterStatusChanged(object sender, EventArgs e)
      {
         ToolStripBtnRecorded.Checked = false;
         ToolStripBtnInProgress.Checked = false;
         ToolStripBtnDone.Checked = false;
         ToolStripBtnSent.Checked = false;
         ToolStripBtnBilled.Checked = false;

         if (sender.Equals(ToolStripBtnRecorded))
         {
            ToolStripBtnRecorded.Checked = true;
            mWhereFilter_ST = "JobStatusID=1";
         }
         else if (sender.Equals(ToolStripBtnInProgress))
         {
            ToolStripBtnInProgress.Checked = true;
            mWhereFilter_ST = "JobStatusID=2";
         }
         else if (sender.Equals(ToolStripBtnDone))
         {
            ToolStripBtnDone.Checked = true;
            mWhereFilter_ST = "JobStatusID=3";
         }
         else if (sender.Equals(ToolStripBtnSent))
         {
            ToolStripBtnSent.Checked = true;
            mWhereFilter_ST = "JobStatusID=4";
         }
         else if (sender.Equals(ToolStripBtnBilled))
         {
            ToolStripBtnBilled.Checked = true;
            mWhereFilter_ST = "JobStatusID=5";
         }

         Refresh();
      }

      private void MainFlowLayoutPanel_Resize(object sender, EventArgs e)
      {
         for (int i = 0; i < MainFlowLayoutPanel.Controls.Count; i++)
         {
            if (MainFlowLayoutPanel.Controls[i].GetType() == typeof(JobLifeCycle))
            {
               MainFlowLayoutPanel.Controls[i].Width = MainFlowLayoutPanel.Width - MainFlowLayoutPanel.Padding.Left - MainFlowLayoutPanel.Padding.Right - 25;
            }
         }
      }

      private void Filter(object sender, EventArgs e)
      {
         for (int i = 0; i < MainFlowLayoutPanel.Controls.Count; i++)
         {
            if (MainFlowLayoutPanel.Controls[i].GetType() == typeof(JobLifeCycle))
            {
               ((JobLifeCycle)MainFlowLayoutPanel.Controls[i]).Filter(ToolStripTxtRefNumber.Text, ToolStripTxtClient.Text, ToolStripTxtJobNb.Text, ToolStripTxtJobLib.Text);
            }
         }
      }
   }
}
