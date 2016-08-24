using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MMSoft
{
   public partial class JobsCorrectionUC : UserControl, IMMSoftUC
   {
      private DatabaseManager mDBManager_O;
      private Control mParentContainer_O;

      [DllImport("user32.dll", SetLastError = true)]
      private static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

      private const uint WM_SYSKEYDOWN = 0x104;

      public JobsCorrectionUC(DatabaseManager DBManager_O)
      {
         mDBManager_O = DBManager_O;

         InitializeComponent();

         DBListViewJobs.ListRefreshed += ApplyCorrectedHoursFormating;

         this.DBListViewJobs.ItemClicked += new DBListView.ItemClickedHandler(JobClicked);

         // Set default date from first day of month to today
         CustomDTPFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
         CustomDTPTo.Value = DateTime.Now;

         this.DBListViewJobs.ListTitle = "Cycle de vie des jobs";
         this.DBListViewJobs.AddToolStripBtn(this.ToolStripBtnPreviousMonth);
         this.DBListViewJobs.AddToolStripBtn(this.ToolStripBtnDTPFrom);
         ToolStripControlHost ToolStripControlHostFrom_O = new ToolStripControlHost(CustomDTPFrom);
         this.DBListViewJobs.AddToolStripControlHost(ToolStripControlHostFrom_O);
         this.DBListViewJobs.AddToolStripBtn(this.ToolStripBtnDTPTo);
         ToolStripControlHost ToolStripControlHostTo_O = new ToolStripControlHost(CustomDTPTo);
         this.DBListViewJobs.AddToolStripControlHost(ToolStripControlHostTo_O);
         this.DBListViewJobs.AddToolStripBtn(this.ToolStripBtnNextMonth);

         this.JobCorrectionToolStrip.Visible = false;

         List<String> TableFieldJobRecap_ST = new List<String>();
         List<String> ColumnHeaderNameJobRecap_ST = new List<String>();
         List<int> ColumnHeaderDefaultSizeJobRecap_i = new List<int>();
         List<HorizontalAlignment> TextAlignJobRecap_O = new List<HorizontalAlignment>();

         // Define column DB fields
         TableFieldJobRecap_ST.Add("NumRefInterne");
         TableFieldJobRecap_ST.Add("ClientNom");
         TableFieldJobRecap_ST.Add("NumOrdre");
         TableFieldJobRecap_ST.Add("JobLib");
         TableFieldJobRecap_ST.Add("DateEncod");
         TableFieldJobRecap_ST.Add("HTravEstim");
         TableFieldJobRecap_ST.Add("SommeHeuresTot");
         TableFieldJobRecap_ST.Add("SommeHeureCorrect");

         // Unshown elements
         TableFieldJobRecap_ST.Add("ComJobID");
         TableFieldJobRecap_ST.Add("ChkHoursCorrected");

         // Define column headers text
         ColumnHeaderNameJobRecap_ST.Add("Num cmd int");
         ColumnHeaderNameJobRecap_ST.Add("Client");
         ColumnHeaderNameJobRecap_ST.Add("# job");
         ColumnHeaderNameJobRecap_ST.Add("Job libellé");
         ColumnHeaderNameJobRecap_ST.Add("Date encodage");
         ColumnHeaderNameJobRecap_ST.Add("H estim.");
         ColumnHeaderNameJobRecap_ST.Add("H. tot.");
         ColumnHeaderNameJobRecap_ST.Add("H. tot. corr.");

         // size
         ColumnHeaderDefaultSizeJobRecap_i.Add(100);
         ColumnHeaderDefaultSizeJobRecap_i.Add(250);
         ColumnHeaderDefaultSizeJobRecap_i.Add(50);
         ColumnHeaderDefaultSizeJobRecap_i.Add(600);
         ColumnHeaderDefaultSizeJobRecap_i.Add(100);
         ColumnHeaderDefaultSizeJobRecap_i.Add(75);
         ColumnHeaderDefaultSizeJobRecap_i.Add(75);
         ColumnHeaderDefaultSizeJobRecap_i.Add(75);

         // alignment
         for (int i = 0; i < ColumnHeaderNameJobRecap_ST.Count; i++)
         {
            if (i == 2 || i == 5 || i == 6 || i == 7)
               TextAlignJobRecap_O.Add(HorizontalAlignment.Center);
            else
               TextAlignJobRecap_O.Add(HorizontalAlignment.Left);
         }

         DBListViewJobs.Initialize(mDBManager_O, "ComJobSelectPop", TableFieldJobRecap_ST, 8, ColumnHeaderNameJobRecap_ST, ColumnHeaderDefaultSizeJobRecap_i, TextAlignJobRecap_O,
                                   "JobStatusID <= 4 AND DateEncod >= '" + CustomDTPFrom.Value.ToShortDateString() + "' AND DateEncod <= dateadd(day, 1, '" + CustomDTPTo.Value.ToShortDateString() + "')");

         RefreshSum();

         ToolStripJobCorrectionFooter.Renderer = new BorderlessToolStripRenderer();

         ControlStyle.SetFrameHeaderStyle(this);
         ControlStyle.SetFrameHeaderStyle(this.CustomDTPFrom);
         ControlStyle.SetFrameHeaderStyle(this.CustomDTPTo);
         ControlStyle.SetFrameStyle(this.ToolStripJobCorrectionFooter);
      }

      private void JobClicked(UInt32 JobID_UL, MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Right)
         {
            FormAskJobHourCorrection Form_O = new FormAskJobHourCorrection();
            Form_O.StartPosition = FormStartPosition.Manual;

            Point EndPoint_O = DBListViewJobs.mListView_O.PointToScreen(new Point(e.X, e.Y));

            if (EndPoint_O.X + Form_O.Width > Screen.PrimaryScreen.Bounds.Width)
               EndPoint_O.X -= Form_O.Width;

            if (EndPoint_O.Y + Form_O.Height > Screen.PrimaryScreen.Bounds.Height)
               EndPoint_O.Y -= Form_O.Height;

            Form_O.Location = new Point(EndPoint_O.X, EndPoint_O.Y);
            DialogResult DlgRes_O = Form_O.ShowDialog();

            if (DlgRes_O == DialogResult.OK)
            {
               String SqlRequest_st = "UPDATE ComJob SET SommeHeureCorrect='" + Form_O.mEnteredNumber_f.ToString().Replace(",",".") + "', ChkHoursCorrected=1 WHERE ComJobID=" + DBListViewJobs.GetSelectedItemID();

               if (mDBManager_O != null && mDBManager_O.mConnected_b)
               {
                  mDBManager_O.ExecuteRequest(SqlRequest_st);
                  RefreshJobsList();
                  RefreshSum();
               }
            }
         }
      }

      public bool Activate(Control Container_O)
      {
         mParentContainer_O = Container_O;
         mParentContainer_O.Controls.Add(this);
         this.BringToFront();
         this.Dock = DockStyle.Fill;

         RefreshJobsList();
         RefreshSum();

         return true;
      }

      public bool Deactivate()
      {
         bool Rts_b = true;

         if (mParentContainer_O != null)
            mParentContainer_O.Controls.Remove(this);

         return Rts_b;
      }

      private void button1_Click(object sender, EventArgs e)
      {
         // If there is an item selected
         if (DBListViewJobs.GetSelectedItemID() > 0)
         {
            DBListViewJobs.FormatSubItem("SommeHeureCorrect", Color.Red, new Font("Segoe UI", 9, FontStyle.Bold));
         }
      }

      private void ToolStripBtnDTPFrom_Click(object sender, EventArgs e)
      {
         SendMessage(CustomDTPFrom.Handle, WM_SYSKEYDOWN, (int)Keys.Down, 0);
         CustomDTPFrom.Focus();
      }

      private void ToolStripBtnDTPTo_Click(object sender, EventArgs e)
      {
         SendMessage(CustomDTPTo.Handle, WM_SYSKEYDOWN, (int)Keys.Down, 0);
         CustomDTPTo.Focus();
      }

      private void DateChanged(object sender, EventArgs e)
      {
         RefreshJobsList();
         RefreshSum();
      }

      private void ToolStripBtnPreviousMonth_Click(object sender, EventArgs e)
      {
         DateTime NewFromValue = CustomDTPFrom.Value.AddMonths(-1);
         CustomDTPFrom.Value = new DateTime(NewFromValue.Year, NewFromValue.Month, 1);
         CustomDTPTo.Value = CustomDTPFrom.Value.AddMonths(1).AddDays(-1);
      }

      private void ToolStripBtnNextMonth_Click(object sender, EventArgs e)
      {
         DateTime NewFromValue = CustomDTPTo.Value.AddMonths(1);
         CustomDTPFrom.Value = new DateTime(NewFromValue.Year, NewFromValue.Month, 1);
         CustomDTPTo.Value = CustomDTPFrom.Value.AddMonths(1).AddDays(-1);
      }

      private void RefreshSum()
      {
         ToolStripLblSumHours.Text = DBListViewJobs.Sum("SommeHeuresTot").ToString();
         ToolStripLblSumHoursCorrected.Text = DBListViewJobs.Sum("SommeHeureCorrect").ToString();
      }

      private void RefreshJobsList()
      {
         DBListViewJobs.SetInitialFilter("JobStatusID > 1 AND JobStatusID <= 4 AND DateEncod >= '" + CustomDTPFrom.Value.ToShortDateString() + "' AND DateEncod <= dateadd(day, 1, '" + CustomDTPTo.Value.ToShortDateString() + "')", "");
         DBListViewJobs.Refresh(); 
      }

      private void ApplyCorrectedHoursFormating()
      {
         int HoursCorrected_i;

         for (int i = 0; i < DBListViewJobs.mListView_O.Items.Count; i++)
         {
            DBListViewJobs.mListView_O.Items[i].UseItemStyleForSubItems = false;

            if (int.TryParse(DBListViewJobs.mListView_O.Items[i].SubItems["ChkHoursCorrected"].Text, out HoursCorrected_i))
            {
               DBListViewJobs.mListView_O.Items[i].SubItems["SommeHeureCorrect"].ForeColor = (HoursCorrected_i == 0) ? Color.Orange : Color.Green;
            }
         }
      }
   }
}
