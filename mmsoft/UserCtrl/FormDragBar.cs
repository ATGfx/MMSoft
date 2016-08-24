using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MMSoft.UsrCtrl
{
   public partial class FormDragBar : UserControl
   {
      public const int WM_NCLBUTTONDOWN = 0xA1;
      public const int HT_CAPTION = 0x2;

      [DllImportAttribute("user32.dll")]
      public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

      [DllImportAttribute("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
      public static extern bool ReleaseCapture();

      [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
      public static extern IntPtr GetParent(IntPtr hWnd);

      private bool mMouseDown_b;

      private Form mParentWindow_O;

      private FormWindowState mLastWindowState_O;

      public FormDragBar()
      {
         InitializeComponent();

         this.toolStrip1.Renderer = new BorderlessToolStripRenderer();

         mMouseDown_b = false;

         mLastWindowState_O = FormWindowState.Maximized;

         ControlStyle.SetBackgroundStyle(this);
         ControlStyle.SetBackgroundStyle(toolStrip1);
      }

      private void FormDragBar_MouseDown(object sender, MouseEventArgs e)
      {
         if (e.Clicks == 1)
            mMouseDown_b = true;
      }

      private void FormDragBar_MouseUp(object sender, MouseEventArgs e)
      {
         mMouseDown_b = false;
      }

      private void FormDragBar_MouseMove(object sender, MouseEventArgs e)
      {
         if (mMouseDown_b)
         {
            if (e.Button == MouseButtons.Left)
            {
               ReleaseCapture();
               SendMessage(GetParent(this.Handle), WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
         }
      }

      public void SetParentWindow(Form ParentWindow_O)
      {
         if (ParentWindow_O != null)
         {
            mParentWindow_O = ParentWindow_O;
            this.mParentWindow_O.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            mLastWindowState_O = FormWindowState.Maximized;
         }
      }

      private void FormDragBar_MouseDoubleClick(object sender, MouseEventArgs e)
      {
         toolStripButtonMaximize_Click(sender, e);
      }

      private void toolStripButtonExit_Click(object sender, EventArgs e)
      {
         if (this.mParentWindow_O != null)
         {
            this.mParentWindow_O.Dispose();
         }
      }

      private void label1_Paint(object sender, PaintEventArgs e)
      {
         //e.Graphics.DrawImage(Properties.Resources.appbar_os_windows_8, 0, 0, LblAppLogo.Width, LblAppLogo.Height);
      }

      public void SetTitle(string Title_ST)
      {
         this.LblAppTitle.Text = Title_ST;
      }

      private void toolStripButtonMaximize_Click(object sender, EventArgs e)
      {
         if (mParentWindow_O != null)
         {
            if (mLastWindowState_O == FormWindowState.Normal)
            {
               mParentWindow_O.WindowState = FormWindowState.Maximized;
               mLastWindowState_O = FormWindowState.Maximized;
               //this.toolStripButtonMaximize.Image = Properties.Resources.appbar_window_minimize;
            }
            else
            {
               mParentWindow_O.WindowState = FormWindowState.Normal;
               mLastWindowState_O = FormWindowState.Normal;
               //this.toolStripButtonMaximize.Image = Properties.Resources.appbar_window_maximize;
            }
         }
      }

      private void toolStripButtonMinimize_Click(object sender, EventArgs e)
      {
         if (mParentWindow_O != null)
         {
            mParentWindow_O.WindowState = FormWindowState.Minimized;
            mLastWindowState_O = FormWindowState.Minimized;
         }
      }
   }
}
