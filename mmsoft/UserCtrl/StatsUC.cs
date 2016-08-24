using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MMSoft
{
   public partial class StatsUC : UserControl, IMMSoftUC
   {
      [DllImport("user32.dll", SetLastError = true)]
      private static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

      private const uint WM_SYSKEYDOWN = 0x104;

      private DatabaseManager mDBManager_O;
      private DocumentManager mDocManager_O;
      private Control mParentContainer_O;

      public StatsUC(DatabaseManager DBManager_O, DocumentManager DocManager_O)
      {
         InitializeComponent();

         mDBManager_O = DBManager_O;
         mDocManager_O = DocManager_O;

         DateTimePicker MonHoursDataTimePicker_O = new DateTimePicker();
         MonHoursDataTimePicker_O.Format = DateTimePickerFormat.Custom;
         MonHoursDataTimePicker_O.CustomFormat = "MM yyyy";
         //MonHoursDataTimePicker_O.ShowUpDown = true; // to prevent the calendar from being displayed

         ToolStripControlHost ToolStripControlHost_O = new ToolStripControlHost(CustomDateTimePickerCtrl);
         this.ToolStripMonthSumHours.Items.Add(ToolStripControlHost_O);

         ToolStripMonthSumHours.Renderer = new BorderlessToolStripRenderer();

         CustomDateTimePickerCtrl.Format = DateTimePickerFormat.Custom;
         CustomDateTimePickerCtrl.CustomFormat = "MM/yyyy";
         CustomDateTimePickerCtrl.mDarkBackground_b = false;
         CustomDateTimePickerCtrl.mDisplayDay_b = false;

         ControlStyle.SetFrameHeaderStyle(this);
         ControlStyle.SetFrameHeaderStyle(PanelHeader);
         ControlStyle.SetFrameStyle(PanelStats);
         ControlStyle.SetFrameStyle(ToolStripMonthSumHours);
         ControlStyle.SetFrameStyle(CustomDateTimePickerCtrl);
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

         if (mParentContainer_O != null)
            mParentContainer_O.Controls.Remove(this);

         return Rts_b;
      }

      private void ToolStripBtnDateTimePick_Click(object sender, EventArgs e)
      {
         SendMessage(CustomDateTimePickerCtrl.Handle, WM_SYSKEYDOWN, (int)Keys.Down, 0);
         CustomDateTimePickerCtrl.Focus();
      }

      private void ToolStripBtnMonthHours_Click(object sender, EventArgs e)
      {
         if (mDocManager_O != null)
         {
            mDocManager_O.ShowMonthHoursDocument(CustomDateTimePickerCtrl.Value);
         }
      }
   }
}
