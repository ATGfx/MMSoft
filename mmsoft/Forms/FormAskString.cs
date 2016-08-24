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
   public partial class FormAskString : Form
   {
      public String mEnteredString_ST;

      public FormAskString(String FormTitle_ST)
      {
         InitializeComponent();

         mEnteredString_ST = "";

         this.CenterToParent();
         this.LblFormTitle.Text = FormTitle_ST;

         ToolStripValidatePref.Renderer = new BorderlessToolStripRenderer();
         ControlStyle.SetBackgroundColorFocusStyle(this);
         ControlStyle.SetFrameStyle(this.PanelUserPref);
         ControlStyle.SetFrameHeaderStyle(this.PanelFormHeader);
         ControlStyle.SetFrameHeaderStyle(this.ToolStripValidatePref);
      }

      private void ToolStripBtnValidate_Click(object sender, EventArgs e)
      {
         mEnteredString_ST = TxtEnteredString.Text;
         this.DialogResult = DialogResult.OK;
         this.Dispose();
      }

      private void ToolStripButtonCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Dispose();
      }

      private void TxtEnteredString_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Enter)
         {
            ToolStripBtnValidate_Click(this, new EventArgs());
         }
      }
   }
}
