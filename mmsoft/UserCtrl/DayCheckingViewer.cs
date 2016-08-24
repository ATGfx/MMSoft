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
   public partial class DayCheckingViewer : UserControl
   {
      [DllImport("user32.dll", SetLastError = true)]
      private static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

      private const uint WM_SYSKEYDOWN = 0x104;

      private UInt32 mPersID_UL;
      private DatabaseManager mDataBaseManager_O;
      private List<CheckingViewer> mCheckingViewerList_O;
      private List<String> mColumnPersCheckDBField_O;
      private List<String> mColumnHeaderName_ST;
      private List<int> mColumnHeaderDefaultSize_i;
      private List<HorizontalAlignment> mTextAlign_O;
      private bool mEditSuperPower_b;

      public DayCheckingViewer()
      {
         InitializeComponent();

         this.DBListViewCheckings.ListTitle = "Pointages";
         this.DBListViewCheckings.AddToolStripBtn(this.ToolStripBtnFastDayBack);
         this.DBListViewCheckings.AddToolStripBtn(this.ToolStripBtnDayBack);
         this.DBListViewCheckings.AddToolStripBtn(this.ToolStripBtnDayFwd);
         this.DBListViewCheckings.AddToolStripBtn(this.ToolStripBtnDayFastFwd);
         this.DBListViewCheckings.AddToolStripBtn(this.ToolStripBtnDateTimePick);
         ToolStripControlHost ToolStripControlHost_O = new ToolStripControlHost(CustomDateTimePickerCtrl);
         this.DBListViewCheckings.AddToolStripControlHost(ToolStripControlHost_O);
         this.DBListViewCheckings.AddToolStripBtn(this.ToolStripBtnEdit);
         this.DBListViewCheckings.AddToolStripBtn(this.ToolStripBtnDelete);

         FormCheckingToolStrip.Visible = false;

         mColumnPersCheckDBField_O = new List<String>();
         mColumnPersCheckDBField_O.Add("NumRefInterne");
         mColumnPersCheckDBField_O.Add("ClientNom");
         mColumnPersCheckDBField_O.Add("JobLib");
         mColumnPersCheckDBField_O.Add("TypeTacheLib");
         mColumnPersCheckDBField_O.Add("QteProd");
         mColumnPersCheckDBField_O.Add("DelaiPromis");
         mColumnPersCheckDBField_O.Add("DatePrest");
         mColumnPersCheckDBField_O.Add("NbrH");
         mColumnPersCheckDBField_O.Add("Rem");
         mColumnPersCheckDBField_O.Add("ComJobEtapeID");

         mColumnHeaderName_ST = new List<String>();
         mColumnHeaderName_ST.Add("N° ref interne");
         mColumnHeaderName_ST.Add("Client");
         mColumnHeaderName_ST.Add("Libellé job");
         mColumnHeaderName_ST.Add("Type tâche");
         mColumnHeaderName_ST.Add("Qte prod");
         mColumnHeaderName_ST.Add("Delai Promis");
         mColumnHeaderName_ST.Add("Date Prestation");
         mColumnHeaderName_ST.Add("NbrH");
         mColumnHeaderName_ST.Add("Remarques");

         mColumnHeaderDefaultSize_i = new List<int>();
         mColumnHeaderDefaultSize_i.Add(100);
         mColumnHeaderDefaultSize_i.Add(150);
         mColumnHeaderDefaultSize_i.Add(600);
         mColumnHeaderDefaultSize_i.Add(150);
         mColumnHeaderDefaultSize_i.Add(75);
         mColumnHeaderDefaultSize_i.Add(100);
         mColumnHeaderDefaultSize_i.Add(100);
         mColumnHeaderDefaultSize_i.Add(50);
         mColumnHeaderDefaultSize_i.Add(300);

         mTextAlign_O = new List<HorizontalAlignment>();
         for (int i = 0; i < mColumnHeaderName_ST.Count; i++)
         {
            if (i == 4 || i == 7)
               mTextAlign_O.Add(HorizontalAlignment.Center);
            else
               mTextAlign_O.Add(HorizontalAlignment.Left);
         }

         DBListViewCheckings.ItemDoubleClicked += new DBListView.ItemDoubleClickedHandler(this.CheckingDoubleClic);

         ControlStyle.SetFrameStyle(this);
         ControlStyle.SetFrameStyle(this.PanelCheckings);
         ControlStyle.SetFrameStyle(this.PanelFooter);
         ControlStyle.SetFrameHeaderStyle(this.PanelFooterPadding);
         ControlStyle.SetFrameHeaderStyle(this.CustomDateTimePickerCtrl);
         this.CustomDateTimePickerCtrl.ForeColor = Color.White;
      }

      public void Initialize(DatabaseManager DataBaseManager_O, DateTime Date_O, UInt32 PersID_UL, bool EditSuperPower_b)
      {
         mDataBaseManager_O = DataBaseManager_O;
         CustomDateTimePickerCtrl.Value = Date_O;
         mPersID_UL = PersID_UL;
         mCheckingViewerList_O = new List<CheckingViewer>();
         mEditSuperPower_b = EditSuperPower_b;

         String Where_ST = "";

         if (mPersID_UL != 0)
            Where_ST = "PersID = " + mPersID_UL + " AND YEAR(DatePrest)=" + CustomDateTimePickerCtrl.Value.Year + " AND Month(DatePrest)=" + CustomDateTimePickerCtrl.Value.Month + " AND Day(DatePrest)=" + CustomDateTimePickerCtrl.Value.Day;

         DBListViewCheckings.Initialize(mDataBaseManager_O, "PointageSelectPop", mColumnPersCheckDBField_O, 9, mColumnHeaderName_ST, mColumnHeaderDefaultSize_i, mTextAlign_O, Where_ST, "", mPersID_UL != 0);
      }

      /// <summary>
      /// Method that reload the pers pointage according to the date. This method clears all the checking viewer on the GUI and simply rebuilds them.
      /// There is no check of new or deleted check, the whole list is rebuild.
      /// </summary>
      public void RefreshPersPointage()
      {
         if (DBListViewCheckings.mInitialized_b)
         {
            DBListViewCheckings.Refresh();
            RefreshSumHours();
         }
      }

      public void RefreshSumHours()
      {
         float SumHours_f;

         if (mDataBaseManager_O.mConnected_b)
         {
            SumHours_f = mDataBaseManager_O.mFunctionManager_O.SCFNC_CountPersHourInDay(CustomDateTimePickerCtrl.Value, mPersID_UL);
            LblSumHours.Text = SumHours_f.ToString();

            if (SumHours_f < 7.5f)
            {
               LblSumHours.ForeColor = Color.FromArgb(153, 0, 0);
               LblSumHours.Text += " (heures manquantes : " + (7.5f - SumHours_f) + ")";
            }
            else
            {
               LblSumHours.ForeColor = Color.FromArgb(51, 102, 102);
               LblSumHours.Text += " (heures supplémentaires : " + (SumHours_f - 7.5f) + ")";
            }
         }
      }

      public void ChangeDate(DateTime DateTime_O, bool Refresh_b)
      {
         CustomDateTimePickerCtrl.Value = DateTime_O;

         String Where_ST = "PersID = " + mPersID_UL + " AND YEAR(DatePrest)=" + CustomDateTimePickerCtrl.Value.Year + " AND Month(DatePrest)=" + CustomDateTimePickerCtrl.Value.Month + " AND Day(DatePrest)=" + CustomDateTimePickerCtrl.Value.Day;
         DBListViewCheckings.SetInitialFilter(Where_ST, "");

         if (Refresh_b)
         {
            RefreshPersPointage();
         }
      }

      public void ChangePers(UInt32 PersID_UL, bool Refresh_b)
      {
         mPersID_UL = PersID_UL;

         String Where_ST = "PersID = " + mPersID_UL + " AND YEAR(DatePrest)=" + CustomDateTimePickerCtrl.Value.Year + " AND Month(DatePrest)=" + CustomDateTimePickerCtrl.Value.Month + " AND Day(DatePrest)=" + CustomDateTimePickerCtrl.Value.Day;
         DBListViewCheckings.SetInitialFilter(Where_ST, "");

         if (Refresh_b)
            RefreshPersPointage();
      }

      private void PreviousWeekToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ChangeDate(CustomDateTimePickerCtrl.Value.AddDays(-7), true);
      }

      private void PreviousDayToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ChangeDate(CustomDateTimePickerCtrl.Value.AddDays(-1), true);
      }

      private void NextDayToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ChangeDate(CustomDateTimePickerCtrl.Value.AddDays(1), true);
      }

      private void NextWeekToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ChangeDate(CustomDateTimePickerCtrl.Value.AddDays(7), true);
      }

      private void CalendarToolStripMenuItem_Click(object sender, EventArgs e)
      {
         SendMessage(CustomDateTimePickerCtrl.Handle, WM_SYSKEYDOWN, (int)Keys.Down, 0);
         CustomDateTimePickerCtrl.Focus();
      }

      public DateTime GetViewerDate()
      {
         return CustomDateTimePickerCtrl.Value;
      }

      private void CustomDateTimePickerCtrl_ValueChanged(object sender, EventArgs e)
      {
         ChangeDate(CustomDateTimePickerCtrl.Value, true);

         if (!mEditSuperPower_b && CustomDateTimePickerCtrl.Value != DateTime.Today)
         {
            ToolStripBtnEdit.Enabled = false;
            ToolStripBtnDelete.Enabled = false;
         }
         else
         {
            ToolStripBtnEdit.Enabled = true;
            ToolStripBtnDelete.Enabled = true;
         }
      }

      private void ToolStripBtnEdit_Click(object sender, EventArgs e)
      {
         UInt32 EtapeID_UL = DBListViewCheckings.GetSelectedItemID();

         if (mDataBaseManager_O != null && mDataBaseManager_O.mConnected_b)
         {
            UInt32 mJobID_UL = 0;
            if (UInt32.TryParse(mDataBaseManager_O.GetTableField("PointageSelectPop", "ComJobID", "ComJobEtapeID=" + EtapeID_UL), out mJobID_UL))
            {
               String JobNumber_st = mDataBaseManager_O.GetTableField("PointageSelectPop", "NumOrdre", "ComJobEtapeID=" + EtapeID_UL);
               String JobRefNumber_st = mDataBaseManager_O.GetTableField("PointageSelectPop", "NumRefInterne", "ComJobEtapeID=" + EtapeID_UL);
               String JobLib_st = mDataBaseManager_O.GetTableField("PointageSelectPop", "JobLib", "ComJobEtapeID=" + EtapeID_UL);

               FormCheckingEdition FormCheckingEdition_O = new FormCheckingEdition();
               FormCheckingEdition_O.Initialize(mDataBaseManager_O, CustomDateTimePickerCtrl.Value, mPersID_UL, mJobID_UL, CheckingEditionMode.Edit, EtapeID_UL);
               FormCheckingEdition_O.SetFrameTitle("Edition pointage sur job n° " + JobNumber_st + " dans " + JobRefNumber_st + " : " + JobLib_st);
               FormCheckingEdition_O.ShowDialog();

               RefreshPersPointage();
            }
            else
               MessageBox.Show("Erreur lors de l'édition de job : le job ne peut pas être trouvé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void ToolStripBtnDelete_Click(object sender, EventArgs e)
      {
         if (mDataBaseManager_O != null && mDataBaseManager_O.mConnected_b)
         {
            mDataBaseManager_O.mStoredProcedureManager_O.STPROC_DeletePointageAndEtape(DBListViewCheckings.GetSelectedItemID());
            RefreshPersPointage();
         }
      }

      private void CheckingDoubleClic(UInt32 CheckingID_UL)
      {
         ToolStripBtnEdit_Click(this, new EventArgs());
      }
   }
}
