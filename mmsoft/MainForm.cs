using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestCustomFormStyleCSharp
{
   public partial class MainForm : Form
   {
      private DockableForm mCheckingForm_O;
      private DockableForm mJobForm_O;

      public MainForm()
      {
         InitializeComponent();

         // Set main form as MDI container to hold several forms
         this.IsMdiContainer = true;

         this.splitContainer1.SplitterDistance = this.Width / 2;

         // Create checking form
         mCheckingForm_O = new DockableForm(this);
         mCheckingForm_O.DockWindow();
         mCheckingForm_O.SetFrameTitle("Checking");
         this.splitContainer1.Panel1.Controls.Add(mCheckingForm_O);
         mCheckingForm_O.Show();

         // Create job form
         mJobForm_O = new DockableForm(this);
         mJobForm_O.DockWindow();
         mJobForm_O.SetFrameTitle("Jobs");
         this.splitContainer1.Panel2.Controls.Add(mJobForm_O);
         mJobForm_O.Show();

         // Set toolstrip renderer
         toolStrip1.Renderer = new BorderlessToolStripRenderer();
      }

      public void DockForm(DockableForm ChildForm_O)
      {
         if (ChildForm_O.Equals(mCheckingForm_O))
         {
            this.splitContainer1.Panel1Collapsed = false;
            this.splitContainer1.Panel1.Controls.Add(mCheckingForm_O);
         }
         else if (ChildForm_O.Equals(mJobForm_O))
         {
            this.splitContainer1.Panel2Collapsed = false;
            this.splitContainer1.Panel2.Controls.Add(mJobForm_O);
         }   
      }

      public bool UndockForm(DockableForm ChildForm_O)
      {
         bool Undocked_b = false;

         if (mCheckingForm_O.IsDocked() && mJobForm_O.IsDocked())
         {
            if (ChildForm_O.Equals(mCheckingForm_O))
            {
               this.splitContainer1.Panel1.Controls.Remove(mCheckingForm_O);
               this.splitContainer1.Panel1Collapsed = true;
               Undocked_b = true;
            }
            else if (ChildForm_O.Equals(mJobForm_O))
            {
               this.splitContainer1.Panel2.Controls.Remove(mJobForm_O);
               this.splitContainer1.Panel2Collapsed = true;
               Undocked_b = true;
            }
         }

         return Undocked_b;
      }
   }
}
