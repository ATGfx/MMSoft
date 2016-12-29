using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MMSoft
{
   public partial class FormNeCertif : Form
   {
      private DatabaseManager mDBManager_O;
      private UInt32 mComJobID_UL;

      public FormNeCertif(DatabaseManager DBManager_O, UInt32 ComJobID_UL)
      {
         InitializeComponent();

         this.CenterToParent();

         mDBManager_O = DBManager_O;
         mComJobID_UL = ComJobID_UL;

         ToolStripValidate.Renderer = new BorderlessToolStripRenderer();

         ControlStyle.SetBackgroundColorFocusStyle(this);
         ControlStyle.SetFrameHeaderStyle(PanelFormHeader);
         ControlStyle.SetFrameHeaderStyle(ToolStripValidate);
         ControlStyle.SetFrameStyle(this.PanelNECertfif);

         Initialize();
      }

      private void Initialize()
      {
         if (mDBManager_O != null && mDBManager_O.mConnected_b)
         {
            String SqlRequest_st = "SELECT * FROM ComJobSelectPop WHERE ComJobID=" + mComJobID_UL;
            SqlDataReader SqlDataReader_O = mDBManager_O.Select(SqlRequest_st);

            if(SqlDataReader_O.Read())
            {
               int CheckNE_i, CheckCertif_i, CheckRappConf_i;
               bool CanParseNE_b, CanParseCertif_b, CanParseRappConf_b;
               bool CheckNE_b, CheckCertif_b, CheckRappConf_b;

               CanParseNE_b = int.TryParse(SqlDataReader_O["NoteEnvoi"].ToString(), out CheckNE_i);
               CanParseCertif_b = int.TryParse(SqlDataReader_O["Certif"].ToString(), out CheckCertif_i);
               CanParseRappConf_b = int.TryParse(SqlDataReader_O["RappConf"].ToString(), out CheckRappConf_i);

               if (CanParseNE_b && CanParseCertif_b && CanParseRappConf_b)
               {
                  CheckNE_b = Convert.ToBoolean(CheckNE_i);
                  CheckCertif_b = Convert.ToBoolean(CheckCertif_i);
                  CheckRappConf_b = Convert.ToBoolean(CheckRappConf_i);

                  if (CheckNE_b != CheckBoxNE.Checked)
                     CheckBoxNE.Checked = CheckNE_b;
                  if (CheckCertif_b != CheckBoxCertif.Checked)
                     CheckBoxCertif.Checked = CheckCertif_b;
                  if (CheckRappConf_b != CheckBoxRappConf.Checked)
                     CheckBoxRappConf.Checked = CheckRappConf_b;
               }

               TxtQteProd.Text = SqlDataReader_O["QteProd"].ToString();
               TxtJobLib.Text = SqlDataReader_O["JobLib"].ToString();
               TxtRefCLient.Text = SqlDataReader_O["NumCmdClient"].ToString();
            }
         }
      }

      private void CheckBoxGenerateCertif_CheckedChanged(object sender, EventArgs e)
      {
         TxtMat.Enabled = CheckBoxGenerateCertif.Checked;
         TxtLot.Enabled = CheckBoxGenerateCertif.Checked;
         TxtTherm.Enabled = CheckBoxGenerateCertif.Checked;
         TxtSurf.Enabled = CheckBoxGenerateCertif.Checked;
         TxtConformity.Enabled = CheckBoxGenerateCertif.Checked;
         TxtCertifRem.Enabled = CheckBoxGenerateCertif.Checked;
      }

      private void ToolStripBtnValidate_Click(object sender, EventArgs e)
      {
         bool Rts_b = false;
         double QteNE_f = 0.0;
         bool Continue_b = true;
         UInt32 SendNoteID_UL = 0;
         UInt32 CertifID_UL = 0;

         if (mDBManager_O != null && mDBManager_O.mConnected_b)
         {
            // Create note envoi
            if (!Double.TryParse(TxtQte.Text.Replace(',', '.'), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out QteNE_f))
            {
               DialogResult DlgRes_O = MessageBox.Show("La quantité " + TxtQte.Text + " n'est pas un nombre valide. Continuer avec la valeur 0.0f ?", "Erreur !", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

               if (DlgRes_O != DialogResult.Yes)
               {
                  Continue_b = false;
               }
            }

            if (Continue_b)
            {
               SendNoteID_UL = mDBManager_O.mStoredProcedureManager_O.STPROC_CreateFullNE(mComJobID_UL, QteNE_f, DTPExpedition.Value, CheckBoxPartial.Checked, "", TxtJobLib.Text, TxtRefCLient.Text, TxtObs.Text);

               Rts_b = SendNoteID_UL > 0;

               if (!Rts_b)
               {
                  MessageBox.Show("La note d'envoi n'a pas pu être créée.", "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
               else if (CheckBoxGenerateCertif.Checked)
               {
                  // Create certif if needed
                  CertifID_UL = mDBManager_O.mStoredProcedureManager_O.STPROC_CreateFullCertif(SendNoteID_UL , TxtMat.Text , TxtLot.Text , TxtTherm.Text, TxtSurf.Text, TxtConformity.Text, "", TxtCertifRem.Text);

                  Rts_b = CertifID_UL > 0;

                  if (!Rts_b)
                  {
                     MessageBox.Show("Le rapport de confirmité n'a pas pu être créée.", "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  }
               }
            }
         }

         if (Rts_b)
         {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
         }
      }

      private void ToolStripButtonCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Dispose();
      }

      private void FormNeCertif_Load(object sender, EventArgs e)
      {
         DTPExpedition.Value = DateTime.Today;
      }
   }
}
