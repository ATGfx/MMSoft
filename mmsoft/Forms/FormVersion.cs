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
   public partial class FormVersion : Form
   {
      private String mVersion_st = "1.0.0";

      public FormVersion()
      {
         InitializeComponent();

         this.CenterToParent();

         ToolStripLblVersion.Text = "MMSoft version " + mVersion_st;

         ToolStripValidatePref.Renderer = new BorderlessToolStripRenderer();
         ControlStyle.SetBackgroundColorFocusStyle(this);
         ControlStyle.SetFrameStyle(this.PanelUserPref);
         ControlStyle.SetFrameHeaderStyle(this.ToolStripValidatePref);
      }

      private void ToolStripBtnValidate_Click(object sender, EventArgs e)
      {
         this.Dispose();
      }

      private void ToolStripValidatePref_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Enter)
         {
            ToolStripBtnValidate_Click(sender, new EventArgs());
         }
      }
   }
}
