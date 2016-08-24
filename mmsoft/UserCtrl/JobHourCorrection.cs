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
   public partial class JobHourCorrection : UserControl
   {
      private DatabaseManager mDBManager_O;
      private UInt32 mComJobID_UL;

      public JobHourCorrection()
      {
         InitializeComponent();

         mDBManager_O = null;
         mComJobID_UL = 0;
      }

      public JobHourCorrection(DatabaseManager DBManager_O, UInt32 ComJobID_UL)
      {
         InitializeComponent();

         mDBManager_O = DBManager_O;
         mComJobID_UL = ComJobID_UL;

         ToolStripJob.Renderer = new BorderlessToolStripRenderer();

         ControlStyle.SetFrameStyle(this);
         ControlStyle.SetFrameStyle(this.ToolStripJob);
         ControlStyle.SetFrameStyle(this.JobHourCorrectionPanel);

         InitializeInfos();
      }

      private void InitializeInfos()
      {
         String SQLRequest_ST;
         SqlDataReader SqlDataReader_O;
         int HoursCorrectd_i; // should be bool but represented by int in DB where false == 0, otherwise true

         if (mDBManager_O != null && mDBManager_O.mConnected_b)
         {
            SQLRequest_ST = "SELECT ClientNom, NumRefInterne, NumOrdre, JobLib, HTravEstim, SommeHeureCorrect, ChkHoursCorrected, SommeHeuresTot FROM ComJobSelectPop WHERE ComJobID=" + mComJobID_UL;

            SqlDataReader_O = mDBManager_O.Select(SQLRequest_ST);

            while (SqlDataReader_O.Read())
            {
               ToolStripLblClient.Text = SqlDataReader_O["ClientNom"].ToString();
               ToolStripLblRefNumber.Text = SqlDataReader_O["NumRefInterne"].ToString();
               ToolStripLblJobNb.Text = SqlDataReader_O["NumOrdre"].ToString();
               ToolStripLblJobLib.Text = SqlDataReader_O["JobLib"].ToString();
               ToolStripLblHEstim.Text = SqlDataReader_O["HTravEstim"].ToString();
               ToolStripLblSumHours.Text = SqlDataReader_O["SommeHeuresTot"].ToString();
               ToolStripLblSumHoursCorrected.Text = SqlDataReader_O["SommeHeureCorrect"].ToString();

               if (int.TryParse(SqlDataReader_O["ChkHoursCorrected"].ToString(), out HoursCorrectd_i) && HoursCorrectd_i == 0)
                  ToolStripLblSumHoursCorrected.ForeColor = Color.Green;
               else
                  ToolStripLblSumHoursCorrected.ForeColor = Color.Gray;
               
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
   }
}
