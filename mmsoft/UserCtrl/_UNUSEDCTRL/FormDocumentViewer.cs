using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing.Printing;

using Microsoft.Office.Interop.Word;

namespace MMSoft
{
   public partial class FormDocumentViewer : Form
   {
      private Microsoft.Office.Interop.Word.Document mWordDoc_O;
      private String mTempFileName_st = null;
      private String MMSoftAppDataFolder_st = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MMSoft");

      delegate void ConvertDocumentDelegate();


      public FormDocumentViewer(Microsoft.Office.Interop.Word.Document WordDoc_O)
      {
         InitializeComponent();

         ToolStripTools.Renderer = new BorderlessToolStripRenderer();

         ControlStyle.SetFrameStyle(this);
         ControlStyle.SetFrameStyle(this.ToolStripTools);
         ControlStyle.SetFrameStyle(this.WebBrowser);

         mWordDoc_O = WordDoc_O;

         mTempFileName_st = Path.Combine(MMSoftAppDataFolder_st, "Word_TEMP" + Directory.GetFiles(MMSoftAppDataFolder_st, "*.html").Length + ".pdf");

         // Call ConvertDocument asynchronously. 
         ConvertDocumentDelegate Delegate_O = new ConvertDocumentDelegate(ConvertDocument);

         // Call DocumentConversionComplete when the method has completed. 
         Delegate_O.BeginInvoke(DocumentConversionComplete, null);
      }

      private void FormDocumentViewer_FormClosing(object sender, FormClosingEventArgs e)
      {
         object m = System.Reflection.Missing.Value;

         // Close document
         mWordDoc_O.Close(ref m, ref m, ref m);
         mWordDoc_O = null; 

         if (!String.IsNullOrEmpty(mTempFileName_st))
         {
            // delete the temp file we created. 
            File.Delete(mTempFileName_st);

            string[] DirectoryPaths_O = Directory.GetDirectories(MMSoftAppDataFolder_st);
            foreach (string DirectoryPath_st in DirectoryPaths_O)
            {
               if (DirectoryPath_st.Contains(Path.GetFileNameWithoutExtension(mTempFileName_st)))
                  Directory.Delete(DirectoryPath_st, true);
            }

            File.Delete(Path.ChangeExtension(mTempFileName_st, "docx"));
         }
      }

      private void ToolStripBtnSaveAs_Click(object sender, EventArgs e)
      {
         bool Continue_b = false;
         object FileType_O = (object)WdSaveFormat.wdFormatDocumentDefault;
         object m = System.Reflection.Missing.Value;

         DialogResult DlgRes_O = SaveDlg.ShowDialog();

         if (DlgRes_O == DialogResult.OK)
         {
            try
            {
               object FileName_O = (object)SaveDlg.FileName;
               mWordDoc_O.SaveAs(ref FileName_O, ref FileType_O,
                                 ref m, ref m, ref m, ref m, ref m, ref m, ref m,
                                 ref m, ref m, ref m, ref m, ref m, ref m, ref m);
            }
            catch (IOException ex)
            {
               MessageBox.Show("Le fichier " + SaveDlg.FileName + " ne peut être sauvegardé.\r\n " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
      }

      private void ToolStripBtnPrint_Click(object sender, EventArgs e)
      {

      }

      void ConvertDocument()
      {
         object m = System.Reflection.Missing.Value;
         object ReadOnly_O = (object)false;
         object HtmlFileName_O = (object)mTempFileName_st;
         object FileType_O = (object)WdSaveFormat.wdFormatPDF; // We will be saving this file as HTML format.

         try
         {           
            // Save the file. 
            mWordDoc_O.SaveAs(ref HtmlFileName_O, ref FileType_O,
                              ref m, ref m, ref m, ref m, ref m, ref m, ref m,
                              ref m, ref m, ref m, ref m, ref m, ref m, ref m);
         }
         catch (Exception e)
         {
            System.Diagnostics.Debug.WriteLine("Exception occurs when converting word doc to html. Error descirption : " + e.Message);
         }
      }

      void DocumentConversionComplete(IAsyncResult result)
      {
         // navigate to our temp file. 
         WebBrowser.Navigate(mTempFileName_st);
      }
   }
}
