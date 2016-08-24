using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace MMSoft
{
   public partial class NECertifUC : UserControl
   {
      private DatabaseManager mDBManager_O;
      private UInt32 mSendNoteID_UL;
      private DocumentManager mDocumentManager_O;

      public NECertifUC(DatabaseManager DBManager_O, DocumentManager DocumentManager_O, UInt32 SendNoteID_UL)
      {
         InitializeComponent();

         mDBManager_O = DBManager_O;
         mSendNoteID_UL = SendNoteID_UL;
         mDocumentManager_O = DocumentManager_O;

         // Set UC style
         ToolStripNeCertif.Renderer = new BorderlessToolStripRenderer();
         ControlStyle.SetFrameStyle(ToolStripNeCertif);

         // Initialize user control
         if (mDBManager_O != null && mDBManager_O.mConnected_b)
         {
            try 
            {
               DateTime Date_O = Convert.ToDateTime(mDBManager_O.GetTableField("NoteEnvoiAndCertif", "DateExpedition", "NoteEnvoiID=" + mSendNoteID_UL));
               ToolStripLblDate.Text = Date_O.ToShortDateString();

               // Hide certif button if do not exist
               UInt32 CertifID_UL;
               if (!UInt32.TryParse(mDBManager_O.GetTableField("NoteEnvoiAndCertif", "CertifID", "NoteEnvoiID=" + mSendNoteID_UL), out CertifID_UL))
               {
                  ToolStripBtnCertif.Visible = false;
               }
               else if (CertifID_UL == 0)
               {
                  ToolStripBtnCertif.Visible = false;
               }
            }
            catch (FormatException e) 
            {
               ToolStripLblDate.Text = mDBManager_O.GetTableField("NoteEnvoiAndCertif", "DateExpedition", "NoteEnvoiID=" + mSendNoteID_UL);
            }
         }
      }

      private void ToolStripButtonNE_Click(object sender, EventArgs e)
      {
         if (mDocumentManager_O != null)
         {
            mDocumentManager_O.ShowJobSendNoteDocument(mSendNoteID_UL);
         }
      }

      private void ToolStripBtnCertif_Click(object sender, EventArgs e)
      {
         if (mDBManager_O != null && mDBManager_O.mConnected_b)
         {
            mDocumentManager_O.ShowCertifDocument(mSendNoteID_UL);
         }
      }

      private void ToolStripBtnDelete_Click(object sender, EventArgs e)
      {
         if (mDBManager_O != null && mDBManager_O.mConnected_b)
         {
            if (mDBManager_O.ExecuteRequest("DELETE FROM NoteEnvoi WHERE NoteEnvoiID=" + mSendNoteID_UL))
            {
               // execute delete of rapp conf but can fail because rapp conf do not necessary exists
               mDBManager_O.ExecuteRequest("DELETE FROM RappConf WHERE NoteEnvoiID=" + mSendNoteID_UL);
               this.Parent.Controls.Remove(this);
            }
         }
      }
   }
}
