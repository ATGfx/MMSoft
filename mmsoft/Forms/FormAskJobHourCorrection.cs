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
   public partial class FormAskJobHourCorrection : Form
   {
      private String mEnteredString_ST;
      public float mEnteredNumber_f;

      public FormAskJobHourCorrection()
      {
         InitializeComponent();

         mEnteredString_ST = "";

         this.CenterToParent();

         ToolStripControlHost ToolStripControlHost_O = new ToolStripControlHost(TxtEnteredString);
         this.ToolStripValidatePref.Items.Insert(1,ToolStripControlHost_O);

         ToolStripValidatePref.Renderer = new BorderlessToolStripRenderer();
         ControlStyle.SetBackgroundColorFocusStyle(this);
         ControlStyle.SetFrameStyle(this.PanelUserPref);
         ControlStyle.SetFrameHeaderStyle(this.ToolStripValidatePref);

         this.ActiveControl = TxtEnteredString;
      }

      private void ToolStripBtnValidate_Click(object sender, EventArgs e)
      {
         mEnteredString_ST = TxtEnteredString.Text;
         mEnteredString_ST = mEnteredString_ST.Replace(".", ",");

         if (float.TryParse(mEnteredString_ST, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out mEnteredNumber_f))
         {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
         }
         else
         {
            MessageBox.Show("Le texte entré n'est pas un nombre valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
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
         else if (e.KeyCode == Keys.Escape)
         {
            ToolStripButtonCancel_Click(this, new EventArgs());
         }
      }
   }
}
