 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace MMSoft
{
   public partial class FormVersion : Form
   {
      private Version mVersion_O = Assembly.GetEntryAssembly().GetName().Version;

      public FormVersion()
      {
         InitializeComponent();

         this.CenterToParent();

         ToolStripLblVersion.Text = "MMSoft version " + mVersion_O.Major + "." + mVersion_O.Minor + "." + mVersion_O.Build;

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
