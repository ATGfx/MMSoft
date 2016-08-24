using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MMSoft
{
   public partial class FormCheckingEdition : Form
   {
      public FormCheckingEdition()
      {
         InitializeComponent();

         ToolStripAddChecking.Renderer = new BorderlessToolStripRenderer();

         // Register on checking validated event
         CheckingEditionCtrl.CheckingValidated += new CheckingEdition.CheckingValidatedHandler(CheckingValidated);

         ControlStyle.SetBackgroundColorFocusStyle(CheckingEditionPanel);

         // Not so good for different screen resolutions
         //this.Width = (int)(Screen.PrimaryScreen.Bounds.Width * 0.75);
         //this.Height = (int)(Screen.PrimaryScreen.Bounds.Height * 0.75);

         this.CenterToScreen();

         ControlStyle.SetFrameHeaderStyle(this);
         ControlStyle.SetFrameHeaderStyle(this.ToolStripAddChecking);
      }

      public void Initialize(DatabaseManager DBManager_O, DateTime Date_O, UInt32 PersID_UL, UInt32 ComJobID_UL, CheckingEditionMode Mode_e = CheckingEditionMode.Add, UInt32 ComJobEtapeID_UL = 0)
      {
         this.CheckingEditionCtrl.Initialize(DBManager_O, Date_O, PersID_UL, ComJobID_UL, Mode_e, ComJobEtapeID_UL);
      }

      public void CheckingValidated()
      {
         this.Dispose();
      }

      public void SetFrameTitle(String FrameTitle_ST)
      {
         this.CheckingEditionCtrl.SetFrameTitle(FrameTitle_ST);
      }

      private void ToolStripBtnValidate_Click(object sender, EventArgs e)
      {
         if (CheckingEditionCtrl.RecordModifications())
            this.Dispose();
         else
            MessageBox.Show("Les donées entrées dans le formulaire ne sont pas correctes.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      private void ToolStripButtonCancel_Click(object sender, EventArgs e)
      {
         this.Dispose();
      }
   }
}
