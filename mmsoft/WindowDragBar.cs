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

namespace TestCustomFormStyleCSharp
{

   public partial class WindowDragBar : UserControl
   {
      private FormWindowState mLastWindowState_O;
      private bool mMouseDown_b;
      private bool mDocked_b;
      private DockableForm mParentWindow_O;
      private Point mDockedMouseDownPosition_O;

      public const int WM_NCLBUTTONDOWN = 0xA1;
      public const int HT_CAPTION = 0x2;

      public WindowDragBar()
      {
         InitializeComponent();

         mLastWindowState_O = FormWindowState.Normal;
         mMouseDown_b = false;
         mDocked_b = true;

         toolStrip1.Renderer = new BorderlessToolStripRenderer();
      }
      
      [DllImportAttribute("user32.dll")]
      public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

      [DllImportAttribute("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
      public static extern bool ReleaseCapture();

      [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
      public static extern IntPtr GetParent(IntPtr hWnd);

      private void toolStrip1_MouseDown(object sender, MouseEventArgs e)
      {
         if (e.Clicks == 1)
            mMouseDown_b = true;

         if (mDocked_b)
            mDockedMouseDownPosition_O = e.Location;
      }

      private void toolStrip1_MouseUp(object sender, MouseEventArgs e)
      {
         mMouseDown_b = false;
      }

      private void toolStrip1_MouseLeave(object sender, EventArgs e)
      {
         if (mMouseDown_b && mParentWindow_O != null && mDocked_b)
         {
            mDocked_b = !mParentWindow_O.UndockWindow();
         }
      }

      private void toolStrip1_MouseDoubleClick(object sender, MouseEventArgs e)
      {
         this.toolStripBtnMaximize_Click(sender, e);
      }

      private void toolStripBtnDock_Click(object sender, EventArgs e)
      {
         if (mParentWindow_O != null && !mDocked_b)
         {
            mDocked_b = mParentWindow_O.DockWindow();
            mMouseDown_b = false;
         }
      }

      private void toolStrip1_MouseMove(object sender, MouseEventArgs e)
      {
         if (mMouseDown_b)
         {
            if (e.Button == MouseButtons.Left && !mDocked_b)
            {
               ReleaseCapture();
               SendMessage(GetParent(this.Handle), WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }   
         }
      }

      private void toolStripBtnMaximize_Click(object sender, EventArgs e)
      {
         if (mParentWindow_O != null && !mDocked_b)
         {
            if (mLastWindowState_O == FormWindowState.Normal)
            {
               mParentWindow_O.WindowState = FormWindowState.Maximized;
               mLastWindowState_O = FormWindowState.Maximized;
            }
            else
            {
               mParentWindow_O.WindowState = FormWindowState.Normal;
               mLastWindowState_O = FormWindowState.Normal;
            }
         }
      }

      public void SetParentWindow(DockableForm ParentWindow_O)
      {
         mParentWindow_O = ParentWindow_O;
      }

      public bool IsDocked()
      {
         return mDocked_b;
      }

      public void SetFrameTitle(string FrameName_st)
      {
         this.LblTitle.Text = FrameName_st;
      }

      public Point GetDragPosition()
      {
         return mDockedMouseDownPosition_O;
      }
   }
}
