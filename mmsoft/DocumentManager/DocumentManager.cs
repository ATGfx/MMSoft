using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Data.SqlClient;

using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Visitors;
using MigraDoc.Rendering;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering.Printing;

namespace MMSoft
{
   public enum MMSoftDocument
   {
      JobInfos,
      Purchase,
      Return,
      SendNote,
      Certificate,
      MemberCheckings,
      MonthSectorHours,
      JobsMonthRentability
   }
   /// <summary>
   /// Class managing the creation, modification and printing of documents
   /// </summary>
   public class DocumentManager
   {
      private DatabaseManager mDBManager_O;
      private readonly String mMMSoftInstalFolder_st = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "MMSoft");
      private readonly String MMSoftAppDataFolder_st = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MMSoft" + Path.DirectorySeparatorChar + "Temp");
      private readonly float PageWidth_f = 17.0f;

      public DocumentManager(DatabaseManager DBManager_O)
      {
         mDBManager_O = DBManager_O;

         // Check if AppData directory exists for MMSoft
         if (Directory.Exists(MMSoftAppDataFolder_st) == false)
         {
            Directory.CreateDirectory(MMSoftAppDataFolder_st);
            System.Diagnostics.Debug.WriteLine("Directory created : " + MMSoftAppDataFolder_st);
         }

         // temp file may remain if MMSoft was uncorrectly shut down (like killed)
         ClearTempFiles();
      }

      public void Shutdown()
      {
         ClearTempFiles();
      }

      private void ClearTempFiles()
      {
         string[] FilePaths_O = Directory.GetFiles(MMSoftAppDataFolder_st);
         foreach (string FilePath_st in FilePaths_O)
         {
            try
            {
               File.Delete(FilePath_st);
            }
            catch (IOException e)
            {
               System.Diagnostics.Debug.WriteLine("File " + FilePath_st + " still open by Adobe Reader.");
            }
         }
      }

      public void ShowMemberDayCheckingsDocument(UInt32 MemberID_UL)
      {
         Document WordDoc_O = new Document();
         WordDoc_O.Info.Title = "Feuille de pointage";

         DefineStyles(WordDoc_O);

         WordDoc_O.DefaultPageSetup.RightMargin = 20;
         WordDoc_O.DefaultPageSetup.LeftMargin = 20;

         // Fill document with infos
         Section Section_O = WordDoc_O.AddSection();

         HeaderFooter Header_O = Section_O.Headers.Primary;
         Paragraph Paragraph_O = Header_O.AddParagraph(DateTime.Today.ToLongDateString());
         Paragraph_O.Format.Alignment = ParagraphAlignment.Right;

         HeaderFooter Footer_O = Section_O.Footers.Primary;
         Paragraph_O = Footer_O.AddParagraph();
         Paragraph_O.AddText("Page ");
         Paragraph_O.AddPageField();
         Paragraph_O.AddText(" sur ");
         Paragraph_O.AddNumPagesField();
         Paragraph_O.Format.Alignment = ParagraphAlignment.Right;

         Paragraph_O = Section_O.AddParagraph();
         Paragraph_O.AddFormattedText("Feuille de pointage : " + mDBManager_O.GetTableField("Pers", "PersNom", "PersID="+MemberID_UL), "Heading1");

         Paragraph_O = Section_O.AddParagraph();
         Paragraph_O.Format.Font.Size = 8;
         Paragraph_O.AddText("Heure d'arrivée : ");
         Paragraph_O.AddText("                                                ");
         Paragraph_O.AddText("Coupure de : ");
         Paragraph_O.AddText("                                                ");
         Paragraph_O.AddText("à : ");
         Paragraph_O.AddText("                                                ");
         Paragraph_O.AddText("Heure de fin de journée : ");
         Paragraph_O.AddText("                                                ");
         Paragraph_O.Format.Borders.Bottom.Width = 1;

         // Add column header and jobs
         Paragraph_O = Section_O.AddParagraph();
         Paragraph_O.Format.Font.Size = 8;

         Table MemberJobsTable_O = new Table();
         MemberJobsTable_O.Format.Font.Size = 8;
         MemberJobsTable_O.Borders.Width = 0;
         MemberJobsTable_O.AddColumn(Unit.FromCentimeter(2));
         MemberJobsTable_O.AddColumn(Unit.FromCentimeter(1));
         MemberJobsTable_O.AddColumn(Unit.FromCentimeter(4));
         MemberJobsTable_O.AddColumn(Unit.FromCentimeter(3));
         MemberJobsTable_O.AddColumn(Unit.FromCentimeter(8));
         MemberJobsTable_O.AddColumn(Unit.FromCentimeter(1));
         MemberJobsTable_O.AddColumn(Unit.FromCentimeter(1));

         Row Row_O = MemberJobsTable_O.AddRow();

         Row_O.Cells[0].AddParagraph("N° cmd int.");
         Row_O.Cells[0].Format.Font.Bold = true;
         Row_O.Cells[0].Format.Font.Size = 8;
         Row_O.Cells[0].Format.Shading.Color = Colors.LightGray;
         Row_O.Cells[1].AddParagraph("Job #");
         Row_O.Cells[1].Format.Font.Bold = true;
         Row_O.Cells[1].Format.Font.Size = 8;
         Row_O.Cells[1].Format.Shading.Color = Colors.LightGray;
         Row_O.Cells[1].Format.Alignment = ParagraphAlignment.Center;
         Row_O.Cells[2].AddParagraph("Client");
         Row_O.Cells[2].Format.Font.Bold = true;
         Row_O.Cells[2].Format.Font.Size = 8;
         Row_O.Cells[2].Format.Shading.Color = Colors.LightGray;
         Row_O.Cells[3].AddParagraph("Num cmd client");
         Row_O.Cells[3].Format.Font.Bold = true;
         Row_O.Cells[3].Format.Font.Size = 8;
         Row_O.Cells[3].Format.Shading.Color = Colors.LightGray;
         Row_O.Cells[4].AddParagraph("Libellé");
         Row_O.Cells[4].Format.Font.Bold = true;
         Row_O.Cells[4].Format.Font.Size = 8;
         Row_O.Cells[4].Format.Shading.Color = Colors.LightGray;
         Row_O.Cells[5].AddParagraph("Qte");
         Row_O.Cells[5].Format.Font.Bold = true;
         Row_O.Cells[5].Format.Font.Size = 8;
         Row_O.Cells[5].Format.Shading.Color = Colors.LightGray;
         Row_O.Cells[5].Format.Alignment = ParagraphAlignment.Center;
         Row_O.Cells[6].AddParagraph("Heures");
         Row_O.Cells[6].Format.Font.Bold = true;
         Row_O.Cells[6].Format.Font.Size = 8;
         Row_O.Cells[6].Format.Shading.Color = Colors.LightGray;

         if (mDBManager_O != null && mDBManager_O.mConnected_b)
         {
            String SqlSelect_O = "SELECT * FROM PersComJobSelectPop WHERE PersID=" + MemberID_UL + "ORDER BY NumRefInterne Desc";
            SqlDataReader SqlDataReader_O = mDBManager_O.Select(SqlSelect_O);

            int i = 1;

            while (SqlDataReader_O.Read())
            {
               Row_O = MemberJobsTable_O.AddRow();

               Row_O.Cells[0].AddParagraph(SqlDataReader_O["NumRefInterne"].ToString());
               Row_O.Cells[1].AddParagraph(SqlDataReader_O["NumOrdre"].ToString());
               Row_O.Cells[1].Format.Alignment = ParagraphAlignment.Center;
               Row_O.Cells[2].AddParagraph(SqlDataReader_O["ClientNom"].ToString());
               Row_O.Cells[3].AddParagraph(SqlDataReader_O["NumCmdClient"].ToString());
               Row_O.Cells[4].AddParagraph(SqlDataReader_O["JobLib"].ToString());
               Row_O.Cells[5].AddParagraph(SqlDataReader_O["Qte"].ToString());
               Row_O.Cells[5].Format.Alignment = ParagraphAlignment.Center;
               Row_O.Cells[6].AddParagraph("     ");

               MemberJobsTable_O.SetEdge(0, i, 7, 1, Edge.Bottom, MigraDoc.DocumentObjectModel.BorderStyle.Dot, 0.5, Colors.LightGray);

               i++;
            }

            SqlDataReader_O.Close();
         }

         WordDoc_O.LastSection.Add(MemberJobsTable_O);

         PdfDocumentRenderer PdfRenderer_O = new PdfDocumentRenderer(false, PdfFontEmbedding.Always);
         PdfRenderer_O.Document = WordDoc_O;
         PdfRenderer_O.RenderDocument();
         String TempFile = Path.Combine(MMSoftAppDataFolder_st, "Word_TEMP" + Directory.GetFiles(MMSoftAppDataFolder_st, "*.pdf").Length + ".pdf");
         PdfRenderer_O.PdfDocument.Save(TempFile);

         OpenPDFFile(TempFile);
      }

      public void ShowJobInfoDocument(UInt32 ComJobID_UL)
      {
         Document WordDoc_O = new Document();
         WordDoc_O.Info.Title = "Fiche job";

         DefineStyles(WordDoc_O);

         if (mDBManager_O != null && mDBManager_O.mConnected_b)
         {
            String SqlSelect_O = "SELECT * FROM ComInfoSelectPop WHERE ComJobID=" + ComJobID_UL;
            SqlDataReader SqlDataReader_O = mDBManager_O.Select(SqlSelect_O);

            // Fill document with infos
            Section Section_O = WordDoc_O.AddSection();

            if (SqlDataReader_O.Read())
            {
               Paragraph Paragraph_O = Section_O.AddParagraph();
               Paragraph_O.AddFormattedText("Commande n° " + SqlDataReader_O["NumRefInterne"].ToString(), "Heading1");

               Paragraph_O = Section_O.AddParagraph();
               Paragraph_O.Format.SpaceBefore = "1cm";
               Paragraph_O.AddFormattedText("Job n° " + SqlDataReader_O["NumOrdre"].ToString() + " : " + SqlDataReader_O["JobLib"].ToString(), "Heading2");

               Paragraph_O = Section_O.AddParagraph();
               Paragraph_O.Format.SpaceBefore = "1cm";
               Paragraph_O.AddText("Note d'envoi : \n");
               Paragraph_O.AddText("Clotûré : ");

               // Client infos
               Paragraph_O = Section_O.AddParagraph();
               Paragraph_O.Format.SpaceBefore = "1cm";
               Paragraph_O.AddFormattedText("Informations client", "Heading3");

               Paragraph_O = Section_O.AddParagraph();

               Table ClientInfoTable_O = new Table();
               ClientInfoTable_O.Borders.Width = 0;
               ClientInfoTable_O.AddColumn(Unit.FromCentimeter(1.66));
               ClientInfoTable_O.AddColumn(Unit.FromCentimeter(4));
               ClientInfoTable_O.AddColumn(Unit.FromCentimeter(1.66));
               ClientInfoTable_O.AddColumn(Unit.FromCentimeter(4));
               ClientInfoTable_O.AddColumn(Unit.FromCentimeter(1.66));
               ClientInfoTable_O.AddColumn(Unit.FromCentimeter(4));

               Row Row_O = ClientInfoTable_O.AddRow();

               Row_O.Format.Font.Size = 14;
               Row_O.Cells[0].AddParagraph("Client n° " + SqlDataReader_O["NumClientInterne"].ToString()  + " : " + SqlDataReader_O["ClientNom"].ToString());
               Row_O.Cells[0].MergeRight = 5;

               Row_O = ClientInfoTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("Adresse : ");
               Row_O.Cells[0].Format.Font.Bold = true;
               Row_O.Cells[1].AddParagraph(SqlDataReader_O["AdresseFact"].ToString());
               Row_O.Cells[2].AddParagraph("Tél. : ");
               Row_O.Cells[2].Format.Font.Bold = true;
               Row_O.Cells[3].AddParagraph(SqlDataReader_O["ClientTel"].ToString());
               Row_O.Cells[4].AddParagraph("Contact : ");
               Row_O.Cells[4].Format.Font.Bold = true;
               Row_O.Cells[5].AddParagraph(SqlDataReader_O["Contact"].ToString());

               Row_O = ClientInfoTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("");
               if (!String.IsNullOrEmpty(SqlDataReader_O["CodePostalFactID"].ToString()))
               {
                  Row_O.Cells[1].AddParagraph(mDBManager_O.GetTableField("CodePostal", "CodePostal", "CodePostalID=" + SqlDataReader_O["CodePostalFactID"].ToString()) + " " +
                                              mDBManager_O.GetTableField("CodePostal", "Localite", "CodePostalID=" + SqlDataReader_O["CodePostalFactID"].ToString()));
               }
               Row_O.Cells[2].AddParagraph("Fax : ");
               Row_O.Cells[2].Format.Font.Bold = true;
               Row_O.Cells[3].AddParagraph(SqlDataReader_O["ClientFax"].ToString());
               Row_O.Cells[4].AddParagraph("Tel. : ");
               Row_O.Cells[4].Format.Font.Bold = true;
               Row_O.Cells[5].AddParagraph(SqlDataReader_O["ContactTel"].ToString());

               Row_O = ClientInfoTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("N° TVA : ");
               Row_O.Cells[0].Format.Font.Bold = true;
               Row_O.Cells[1].AddParagraph(SqlDataReader_O["NrTVA"].ToString());
               Row_O.Cells[2].AddParagraph("Mail : ");
               Row_O.Cells[2].Format.Font.Bold = true;
               Row_O.Cells[3].AddParagraph(SqlDataReader_O["ClientMail"].ToString());
               Row_O.Cells[4].AddParagraph("Mail : ");
               Row_O.Cells[4].Format.Font.Bold = true;
               Row_O.Cells[5].AddParagraph(SqlDataReader_O["ContactEmail"].ToString());

               ClientInfoTable_O.SetEdge(0, 0, 6, 4, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.5, Colors.LightGray);
               WordDoc_O.LastSection.Add(ClientInfoTable_O);

               // Com infos
               Paragraph_O = Section_O.AddParagraph();
               Paragraph_O.Format.SpaceBefore = "1cm";
               Paragraph_O.AddFormattedText("Informations commande", "Heading3");

               Paragraph_O = Section_O.AddParagraph();

               Table ComInfoTable_O = new Table();
               ComInfoTable_O.Borders.Width = 0;
               ComInfoTable_O.AddColumn(Unit.FromCentimeter(3));
               ComInfoTable_O.AddColumn(Unit.FromCentimeter(4));
               ComInfoTable_O.AddColumn(Unit.FromCentimeter(3));
               ComInfoTable_O.AddColumn(Unit.FromCentimeter(7));

               Row_O = ComInfoTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("Libellé commande : " + SqlDataReader_O["LibelleCmd"].ToString());
               Row_O.Cells[0].MergeRight = 2;

               Row_O = ComInfoTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("Date : ");
               Row_O.Cells[0].Format.Font.Bold = true;
               DateTime ComDate_O = Convert.ToDateTime(SqlDataReader_O["ComDate"].ToString());
               Row_O.Cells[1].AddParagraph(ComDate_O.ToShortDateString());
               Row_O.Cells[2].AddParagraph("N° cmd client : ");
               Row_O.Cells[2].Format.Font.Bold = true;
               Row_O.Cells[3].AddParagraph(SqlDataReader_O["NumCmdClient"].ToString());

               Row_O = ComInfoTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("Délai client : ");
               Row_O.Cells[0].Format.Font.Bold = true;
               DateTime ClinetDelayDate_O = Convert.ToDateTime(SqlDataReader_O["DelaiClient"].ToString());
               Row_O.Cells[1].AddParagraph(ClinetDelayDate_O.ToShortDateString());

               Row_O = ComInfoTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("Infos : ");
               Row_O.Cells[0].Format.Font.Bold = true;
               Row_O.Cells[1].AddParagraph(SqlDataReader_O["Info"].ToString());
               Row_O.Cells[1].MergeRight = 2;

               ComInfoTable_O.SetEdge(0, 0, 4, 4, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.5, Colors.LightGray);
               WordDoc_O.LastSection.Add(ComInfoTable_O);

               // Job infos
               Paragraph_O = Section_O.AddParagraph();
               Paragraph_O.Format.SpaceBefore = "1cm";
               Paragraph_O.AddFormattedText("Informations job", "Heading3");

               Paragraph_O = Section_O.AddParagraph();

               Table ComJobTable_O = new Table();
               ComJobTable_O.Borders.Width = 0;
               ComJobTable_O.AddColumn(Unit.FromCentimeter(3));
               ComJobTable_O.AddColumn(Unit.FromCentimeter(4));
               ComJobTable_O.AddColumn(Unit.FromCentimeter(3));
               ComJobTable_O.AddColumn(Unit.FromCentimeter(7));

               Row_O = ComJobTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("Secteur : ");
               Row_O.Cells[0].Format.Font.Bold = true;
               Row_O.Cells[1].AddParagraph(SqlDataReader_O["TypeDepCatLib"].ToString());
               Row_O.Cells[2].AddParagraph("Note d'envoi : ");
               Row_O.Cells[2].Format.Font.Bold = true;
               int NE_i = Convert.ToInt32(SqlDataReader_O["NoteEnvoi"].ToString());
               Row_O.Cells[3].AddParagraph(NE_i != 0 ? "Oui" : "Non");

               Row_O = ComJobTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("Qte : ");
               Row_O.Cells[0].Format.Font.Bold = true;
               Row_O.Cells[1].AddParagraph(SqlDataReader_O["Qte"].ToString());
               Row_O.Cells[2].AddParagraph("Certificat : ");
               Row_O.Cells[2].Format.Font.Bold = true;
               int Certif_i = Convert.ToInt32(SqlDataReader_O["Certif"].ToString());
               Row_O.Cells[3].AddParagraph(Certif_i != 0 ? "Oui" : "Non");

               Row_O = ComJobTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("Qte à prod. : ");
               Row_O.Cells[0].Format.Font.Bold = true;
               Row_O.Cells[1].AddParagraph(SqlDataReader_O["QteProd"].ToString());
               Row_O.Cells[2].AddParagraph("Rapp. conf. : ");
               Row_O.Cells[2].Format.Font.Bold = true;
               int RappConf_i = Convert.ToInt32(SqlDataReader_O["RappConf"].ToString());
               Row_O.Cells[3].AddParagraph(RappConf_i != 0 ? "Oui" : "Non");

               Row_O = ComJobTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("Délais promis : ");
               Row_O.Cells[0].Format.Font.Bold = true;
               DateTime PromiseDelayDate_O = Convert.ToDateTime(SqlDataReader_O["DelaiPromis"].ToString());
               Row_O.Cells[1].AddParagraph(PromiseDelayDate_O.ToShortDateString());

               Row_O = ComJobTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("Infos : ");
               Row_O.Cells[0].Format.Font.Bold = true;
               Row_O.Cells[1].AddParagraph(SqlDataReader_O["InfoJob"].ToString());
               Row_O.Cells[1].MergeRight = 2;

               ComJobTable_O.SetEdge(0, 0, 4, 4, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.5, Colors.LightGray);
               WordDoc_O.LastSection.Add(ComJobTable_O);

               // Remarks
               Paragraph_O = Section_O.AddParagraph();
               Paragraph_O.Format.SpaceBefore = "1cm";
               Paragraph_O.AddFormattedText("Remarques", "Heading3");

               Paragraph_O = Section_O.AddParagraph();

               Table RemarksTable_O = new Table();
               RemarksTable_O.Borders.Width = 0;
               RemarksTable_O.Borders.Color = Colors.White;
               RemarksTable_O.AddColumn(Unit.FromCentimeter(17));

               Row_O = RemarksTable_O.AddRow();
               Row_O.Cells[0].AddParagraph("");
               Row_O = RemarksTable_O.AddRow();
               Row_O.Cells[0].AddParagraph("");
               Row_O = RemarksTable_O.AddRow();
               Row_O.Cells[0].AddParagraph("");
               Row_O = RemarksTable_O.AddRow();
               Row_O.Cells[0].AddParagraph("");
               Row_O = RemarksTable_O.AddRow();
               Row_O.Cells[0].AddParagraph("");
               Row_O = RemarksTable_O.AddRow();
               Row_O.Cells[0].AddParagraph("");
               Row_O = RemarksTable_O.AddRow();
               Row_O.Cells[0].AddParagraph("");
               Row_O = RemarksTable_O.AddRow();
               Row_O.Cells[0].AddParagraph("");
               Row_O = RemarksTable_O.AddRow();
               Row_O.Cells[0].AddParagraph("");
               Row_O = RemarksTable_O.AddRow();
               Row_O.Cells[0].AddParagraph("");

               RemarksTable_O.SetEdge(0, 0, 1, 10, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.5, Colors.LightGray);
               WordDoc_O.LastSection.Add(RemarksTable_O);

            }

            SqlDataReader_O.Close();
         }

         PdfDocumentRenderer PdfRenderer_O = new PdfDocumentRenderer(false, PdfFontEmbedding.Always);
         PdfRenderer_O.Document = WordDoc_O;
         PdfRenderer_O.RenderDocument();
         String TempFile = Path.Combine(MMSoftAppDataFolder_st, "Word_TEMP" + Directory.GetFiles(MMSoftAppDataFolder_st, "*.pdf").Length + ".pdf");
         PdfRenderer_O.PdfDocument.Save(TempFile);

         OpenPDFFile(TempFile);
      }

      public void ShowJobSendNoteDocument(UInt32 SendNoteID_UL)
      {
         Document WordDoc_O = new Document();
         WordDoc_O.Info.Title = "Note d'envoi";

         DefineStyles(WordDoc_O);

         if (mDBManager_O != null && mDBManager_O.mConnected_b)
         {
            String SqlSelect_O = "SELECT * FROM NECertifDocInfos WHERE NoteEnvoiID=" + SendNoteID_UL;
            SqlDataReader SqlDataReader_O = mDBManager_O.Select(SqlSelect_O);

            if (SqlDataReader_O.Read())
            {
               // Fill document with infos
               Section Section_O = WordDoc_O.AddSection();

               Paragraph Paragraph_O = Section_O.AddParagraph();
               Paragraph_O.Format.Alignment= ParagraphAlignment.Right;
               Paragraph_O.AddImage(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFilesX86) + "\\MMSoft\\Img\\MalcourantLogo.jpg"); 

               Paragraph_O = Section_O.AddParagraph();
               Paragraph_O.AddFormattedText("Note d'envoi", "Heading1");

               Paragraph_O = Section_O.AddParagraph();

               // Expedition and destination
               Table ExpedDestTable_O = new Table();
               ExpedDestTable_O.Borders.Width = 0;
               ExpedDestTable_O.AddColumn(Unit.FromCentimeter(0.13 * PageWidth_f));
               ExpedDestTable_O.AddColumn(Unit.FromCentimeter(0.37 * PageWidth_f));
               ExpedDestTable_O.AddColumn(Unit.FromCentimeter(0.13 * PageWidth_f));
               ExpedDestTable_O.AddColumn(Unit.FromCentimeter(0.37 * PageWidth_f));

               Row Row_O = ExpedDestTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("Expéditeur :");
               Row_O.Cells[0].Format.Font.Bold = true;
               Row_O.Cells[1].AddParagraph("Malcourant Mécanique S.A.");
               Row_O.Cells[2].AddParagraph("Destination :");
               Row_O.Cells[2].Format.Font.Bold = true;
               Row_O.Cells[3].AddParagraph(SqlDataReader_O["ClientNom"].ToString());

               Row_O = ExpedDestTable_O.AddRow();

               Row_O.Cells[1].AddParagraph("1-3 rue de la Marcelle");
               Row_O.Cells[3].AddParagraph(SqlDataReader_O["AdresseLivraison"].ToString());

               Row_O = ExpedDestTable_O.AddRow();

               Row_O.Cells[1].AddParagraph("5030 Gembloux");

               if (!String.IsNullOrEmpty(SqlDataReader_O["CodePostalLivraisonID"].ToString()))
               {
                  Row_O.Cells[3].AddParagraph(mDBManager_O.GetTableField("CodePostal", "CodePostal", "CodePostalID=" + SqlDataReader_O["CodePostalLivraisonID"].ToString()) + " " +
                                              mDBManager_O.GetTableField("CodePostal", "Localite", "CodePostalID=" + SqlDataReader_O["CodePostalLivraisonID"].ToString()));
               }

               Row_O = ExpedDestTable_O.AddRow();

               Row_O = ExpedDestTable_O.AddRow();

               Row_O.Cells[1].AddParagraph("Tél. : 081 62 65 00");

               Row_O = ExpedDestTable_O.AddRow();

               Row_O.Cells[1].AddParagraph("TVA : BE 0453.558.340");

               Row_O = ExpedDestTable_O.AddRow();

               Row_O.Cells[1].AddParagraph("www.malcourant-mecanique.be");

               WordDoc_O.LastSection.Add(ExpedDestTable_O);

               // Command infos
               Paragraph_O = Section_O.AddParagraph();
               Paragraph_O.Format.SpaceBefore = "1cm";
               Paragraph_O.AddFormattedText("Informations livraison", "Heading2");

               Paragraph_O = Section_O.AddParagraph();

               Table InfoTable_O = new Table();
               InfoTable_O.Borders.Width = 0;
               InfoTable_O.AddColumn(Unit.FromCentimeter(0.3 * PageWidth_f));
               InfoTable_O.AddColumn(Unit.FromCentimeter(0.7 * PageWidth_f));

               Row_O = InfoTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("Date d'éxpédition : ");
               Row_O.Cells[0].Format.Font.Bold = true;
               DateTime DateExpedition_O = Convert.ToDateTime(SqlDataReader_O["DateExpedition"].ToString());
               Row_O.Cells[1].AddParagraph(DateExpedition_O.ToShortDateString());

               Row_O = InfoTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("N° de référence Malcourant : ");
               Row_O.Cells[0].Format.Font.Bold = true;
               Row_O.Cells[1].AddParagraph(SqlDataReader_O["NumRefInterne"].ToString());

               Row_O = InfoTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("N° de référence " + SqlDataReader_O["ClientNom"].ToString() + " :");
               Row_O.Cells[0].Format.Font.Bold = true;
               Row_O.Cells[1].AddParagraph(SqlDataReader_O["NumCmdClient"].ToString());

               Row_O = InfoTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("Désignation : ");
               Row_O.Cells[0].Format.Font.Bold = true;
               Row_O.Cells[1].AddParagraph("Job n° " + SqlDataReader_O["NumOrdre"].ToString()+ " : " + SqlDataReader_O["JobLib"].ToString());

               Row_O = InfoTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("Quantité livrée : ");
               Row_O.Cells[0].Format.Font.Bold = true;
               Row_O.Cells[1].AddParagraph(SqlDataReader_O["QteNe"].ToString());

               Row_O = InfoTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("Quantité commandée : ");
               Row_O.Cells[0].Format.Font.Bold = true;
               Row_O.Cells[1].AddParagraph(SqlDataReader_O["Qte"].ToString());

               Row_O = InfoTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("Libellé de commande : ");
               Row_O.Cells[0].Format.Font.Bold = true;
               Row_O.Cells[1].AddParagraph(SqlDataReader_O["LibelleCmd"].ToString());

               Row_O = InfoTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("Observations : ");
               Row_O.Cells[0].Format.Font.Bold = true;
               Row_O.Cells[1].AddParagraph(SqlDataReader_O["Obs"].ToString());

               WordDoc_O.LastSection.Add(InfoTable_O);

               // Exped
               Paragraph_O = Section_O.AddParagraph();
               Paragraph_O.Format.SpaceBefore = "1cm";
               Paragraph_O.AddFormattedText("Conditionnement", "Heading2");

               Paragraph_O = Section_O.AddParagraph();

               Table CondTable_O = new Table();
               CondTable_O.Borders.Width = 0;
               CondTable_O.AddColumn(Unit.FromCentimeter(0.33 * PageWidth_f));
               CondTable_O.AddColumn(Unit.FromCentimeter(0.33 * PageWidth_f));
               CondTable_O.AddColumn(Unit.FromCentimeter(0.33 * PageWidth_f));

               Row_O = CondTable_O.AddRow();

               int Partial_i = 0;
               Int32.TryParse(SqlDataReader_O["ChkPartiel"].ToString(), out Partial_i);

               Row_O.Cells[0].AddParagraph(Partial_i == 0 ? "SOLDE COMMANDE" : "PARTIEL");
               Row_O.Cells[0].Format.Alignment = ParagraphAlignment.Center;
               Row_O.Cells[0].MergeRight = 2;

               Row_O = CondTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("Emballage");
               Row_O.Cells[0].Format.Alignment = ParagraphAlignment.Center;

               Row_O.Cells[1].AddParagraph("Dimensions");
               Row_O.Cells[1].Format.Alignment = ParagraphAlignment.Center;

               Row_O.Cells[2].AddParagraph("Poids");
               Row_O.Cells[2].Format.Alignment = ParagraphAlignment.Center;

               Row_O = CondTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("1.");
               Row_O.Cells[0].MergeRight = 2;

               Row_O = CondTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("2.");
               Row_O.Cells[0].MergeRight = 2;

               Row_O = CondTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("3.");
               Row_O.Cells[0].MergeRight = 2;

               Row_O = CondTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("Transporteur :");
               Row_O.Cells[0].Format.Alignment = ParagraphAlignment.Center;
               Row_O.Cells[0].Format.Font.Size = 8;

               Row_O.Cells[1].AddParagraph("N° plaque :");
               Row_O.Cells[1].Format.Alignment = ParagraphAlignment.Center;
               Row_O.Cells[1].Format.Font.Size = 8;

               Row_O.Cells[2].AddParagraph("Signature :");
               Row_O.Cells[2].Format.Alignment = ParagraphAlignment.Center;
               Row_O.Cells[2].Format.Font.Size = 8;

               WordDoc_O.LastSection.Add(CondTable_O);
            }

            SqlDataReader_O.Close();
         }

         PdfDocumentRenderer PdfRenderer_O = new PdfDocumentRenderer(false, PdfFontEmbedding.Always);
         PdfRenderer_O.Document = WordDoc_O;
         PdfRenderer_O.RenderDocument();
         String TempFile = Path.Combine(MMSoftAppDataFolder_st, "Word_TEMP" + Directory.GetFiles(MMSoftAppDataFolder_st, "*.pdf").Length + ".pdf");
         PdfRenderer_O.PdfDocument.Save(TempFile);

         OpenPDFFile(TempFile);
      }

      public void ShowCertifDocument(UInt32 SendNoteID_UL)
      {
         Document WordDoc_O = new Document();
         WordDoc_O.Info.Title = "Note d'envoi";

         DefineStyles(WordDoc_O);

         if (mDBManager_O != null && mDBManager_O.mConnected_b)
         {
            String SqlSelect_O = "SELECT * FROM NECertifDocInfos WHERE NoteEnvoiID=" + SendNoteID_UL;
            SqlDataReader SqlDataReader_O = mDBManager_O.Select(SqlSelect_O);

            if (SqlDataReader_O.Read())
            {
               // Fill document with infos
               Section Section_O = WordDoc_O.AddSection();

               Paragraph Paragraph_O = Section_O.AddParagraph();
               Paragraph_O.AddFormattedText("Certificat de conformité", "Heading1");

               Paragraph_O = Section_O.AddParagraph();

               // Expedition and destination
               Table ExpedDestTable_O = new Table();
               ExpedDestTable_O.Borders.Width = 0;
               ExpedDestTable_O.AddColumn(Unit.FromCentimeter(0.25 * PageWidth_f));
               ExpedDestTable_O.AddColumn(Unit.FromCentimeter(0.75 * PageWidth_f));

               Row Row_O = ExpedDestTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("Expéditeur :");
               Row_O.Cells[0].Format.Font.Bold = true;
               Row_O.Cells[1].AddParagraph("Malcourant Mécanique S.A.");

               Row_O = ExpedDestTable_O.AddRow();

               Row_O.Cells[1].AddParagraph("1-3 rue de la Marcelle");

               Row_O = ExpedDestTable_O.AddRow();

               Row_O.Cells[1].AddParagraph("5030 Gembloux");

               Row_O = ExpedDestTable_O.AddRow();

               Row_O = ExpedDestTable_O.AddRow();

               Row_O.Cells[1].AddParagraph("Tél. : 081 62 65 00");

               Row_O = ExpedDestTable_O.AddRow();

               Row_O.Cells[1].AddParagraph("Fax : 081 61 09 41");

               Row_O = ExpedDestTable_O.AddRow();

               Row_O.Cells[1].AddParagraph("Centea : 853-8430559-30");

               Row_O = ExpedDestTable_O.AddRow();

               Row_O.Cells[1].AddParagraph("IBAN BE15 8538 4305 5930");

               Row_O = ExpedDestTable_O.AddRow();

               Row_O.Cells[1].AddParagraph("BIC SPAABE22");

               Row_O = ExpedDestTable_O.AddRow();

               Row_O.Cells[1].AddParagraph("TVA : BE 0453.558.340");

               Row_O = ExpedDestTable_O.AddRow();

               Row_O.Cells[1].AddParagraph("RPM Namur");

               WordDoc_O.LastSection.Add(ExpedDestTable_O);

               // Certif infos
               Paragraph_O = Section_O.AddParagraph();
               Paragraph_O.Format.SpaceBefore = "1cm";
               Paragraph_O.AddFormattedText("Informations certificat", "Heading2");

               Paragraph_O = Section_O.AddParagraph();

               Table InfoTable_O = new Table();
               InfoTable_O.Borders.Width = 0;
               InfoTable_O.AddColumn(Unit.FromCentimeter(0.3 * PageWidth_f));
               InfoTable_O.AddColumn(Unit.FromCentimeter(0.7 * PageWidth_f));

               Row_O = InfoTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("Client : ");
               Row_O.Cells[0].Format.Font.Bold = true;
               Row_O.Cells[1].AddParagraph(SqlDataReader_O["ClientNom"].ToString());

               Row_O = InfoTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("Date d'éxpédition : ");
               Row_O.Cells[0].Format.Font.Bold = true;
               Row_O.Cells[1].AddParagraph(SqlDataReader_O["DateExpedition"].ToString());

               Row_O = InfoTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("N° de référence Malcourant : ");
               Row_O.Cells[0].Format.Font.Bold = true;
               Row_O.Cells[1].AddParagraph(SqlDataReader_O["NumRefInterne"].ToString());

               Row_O = InfoTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("N° de référence " + SqlDataReader_O["ClientNom"].ToString() + " :");
               Row_O.Cells[0].Format.Font.Bold = true;
               Row_O.Cells[1].AddParagraph(SqlDataReader_O["NumCmdClient"].ToString());

               Row_O = InfoTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("Désignation : ");
               Row_O.Cells[0].Format.Font.Bold = true;
               Row_O.Cells[1].AddParagraph(SqlDataReader_O["JobLib"].ToString());

               Row_O = InfoTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("Quantité : ");
               Row_O.Cells[0].Format.Font.Bold = true;
               Row_O.Cells[1].AddParagraph(SqlDataReader_O["QteNe"].ToString());

               Row_O = InfoTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("Plan : ");
               Row_O.Cells[0].Format.Font.Bold = true;
               Row_O.Cells[1].AddParagraph(SqlDataReader_O["NumPlan"].ToString());

               Row_O = InfoTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("Matière : ");
               Row_O.Cells[0].Format.Font.Bold = true;
               Row_O.Cells[1].AddParagraph(SqlDataReader_O["Matiere"].ToString());

               Row_O = InfoTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("Lot : ");
               Row_O.Cells[0].Format.Font.Bold = true;
               Row_O.Cells[1].AddParagraph(SqlDataReader_O["Lot"].ToString());

               Row_O = InfoTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("Traitement thermique : ");
               Row_O.Cells[0].Format.Font.Bold = true;
               Row_O.Cells[1].AddParagraph(SqlDataReader_O["Ttherm"].ToString());

               Row_O = InfoTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("Traitement de surface : ");
               Row_O.Cells[0].Format.Font.Bold = true;
               Row_O.Cells[1].AddParagraph(SqlDataReader_O["TSurf"].ToString());

               Row_O = InfoTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("Conforme : ");
               Row_O.Cells[0].Format.Font.Bold = true;
               Row_O.Cells[1].AddParagraph(SqlDataReader_O["Conforme"].ToString());

               Row_O = InfoTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("Remarques : ");
               Row_O.Cells[0].Format.Font.Bold = true;
               Row_O.Cells[1].AddParagraph(SqlDataReader_O["Rem"].ToString());

               Row_O = InfoTable_O.AddRow();

               Row_O.Cells[1].AddParagraph("Fait par :");
               Row_O.Cells[1].Format.Font.Bold = true;
               Row_O.Cells[1].Format.Alignment = ParagraphAlignment.Center;

               WordDoc_O.LastSection.Add(InfoTable_O);
            }

            SqlDataReader_O.Close();
         }

         PdfDocumentRenderer PdfRenderer_O = new PdfDocumentRenderer(false, PdfFontEmbedding.Always);
         PdfRenderer_O.Document = WordDoc_O;
         PdfRenderer_O.RenderDocument();
         String TempFile = Path.Combine(MMSoftAppDataFolder_st, "Word_TEMP" + Directory.GetFiles(MMSoftAppDataFolder_st, "*.pdf").Length + ".pdf");
         PdfRenderer_O.PdfDocument.Save(TempFile);

         OpenPDFFile(TempFile);
      }

      public void ShowMonthHoursDocument(DateTime Date_O)
      {
         Document WordDoc_O = new Document();
         WordDoc_O.Info.Title = "Note d'envoi";

         DefineStyles(WordDoc_O);

         // Fill document with infos
         Section Section_O = WordDoc_O.AddSection();

         Paragraph Paragraph_O = Section_O.AddParagraph();
         Paragraph_O.AddFormattedText("Cumul des heures pointées en " + Date_O.ToString("MMMM") + " " + Date_O.Year.ToString(), "Heading1");

         Paragraph_O = Section_O.AddParagraph();

         // Expedition and destination
         Table RepportTable_O = new Table();
         RepportTable_O.Borders.Width = 0;
         RepportTable_O.AddColumn(Unit.FromCentimeter((3.0f / 7) * PageWidth_f));
         RepportTable_O.AddColumn(Unit.FromCentimeter((1.0f / 7) * PageWidth_f));
         RepportTable_O.AddColumn(Unit.FromCentimeter((1.0f / 7) * PageWidth_f));
         RepportTable_O.AddColumn(Unit.FromCentimeter((1.0f / 7) * PageWidth_f));
         RepportTable_O.AddColumn(Unit.FromCentimeter((1.0f / 7) * PageWidth_f));

         Row Row_O = RepportTable_O.AddRow();

         Row_O.Cells[0].AddParagraph("Département");
         Row_O.Cells[0].Format.Font.Bold = true;
         Row_O.Cells[0].Format.Alignment = ParagraphAlignment.Left;
         Row_O.Cells[1].AddParagraph("Facturable");
         Row_O.Cells[1].Format.Font.Bold = true;
         Row_O.Cells[1].Format.Alignment = ParagraphAlignment.Center;
         Row_O.Cells[2].AddParagraph("Non facturable");
         Row_O.Cells[2].Format.Font.Bold = true;
         Row_O.Cells[2].Format.Alignment = ParagraphAlignment.Center;
         Row_O.Cells[3].AddParagraph("Entretient");
         Row_O.Cells[3].Format.Font.Bold = true;
         Row_O.Cells[3].Format.Alignment = ParagraphAlignment.Center;
         Row_O.Cells[4].AddParagraph("Total");
         Row_O.Cells[4].Format.Font.Bold = true;
         Row_O.Cells[4].Format.Alignment = ParagraphAlignment.Center;

         if (mDBManager_O != null && mDBManager_O.mConnected_b)
         {
            String SqlSelect_O = "SELECT * FROM GetCumulTableView(" + Date_O.Month + ", " + Date_O.Year + ")";
            SqlDataReader SqlDataReader_O = mDBManager_O.Select(SqlSelect_O);
            UInt32 Line_UL = 0;

            while (SqlDataReader_O.Read())
            {
               Row_O = RepportTable_O.AddRow();

               Row_O.Cells[0].AddParagraph(SqlDataReader_O[0].ToString());
               Row_O.Cells[0].Format.Alignment = ParagraphAlignment.Left;
               Row_O.Cells[1].AddParagraph(SqlDataReader_O[1].ToString());
               Row_O.Cells[1].Format.Alignment = ParagraphAlignment.Center;
               Row_O.Cells[2].AddParagraph(SqlDataReader_O[2].ToString());
               Row_O.Cells[2].Format.Alignment = ParagraphAlignment.Center;
               Row_O.Cells[3].AddParagraph(SqlDataReader_O[3].ToString());
               Row_O.Cells[3].Format.Alignment = ParagraphAlignment.Center;
               Row_O.Cells[4].AddParagraph(SqlDataReader_O[4].ToString());
               Row_O.Cells[4].Format.Font.Bold = true;
               Row_O.Cells[4].Format.Alignment = ParagraphAlignment.Center;

               if (Line_UL % 2 == 0)
               {
                  Row_O.Cells[0].Shading.Color = Colors.LightGray;
                  Row_O.Cells[1].Shading.Color = Colors.LightGray;
                  Row_O.Cells[2].Shading.Color = Colors.LightGray;
                  Row_O.Cells[3].Shading.Color = Colors.LightGray;
                  Row_O.Cells[4].Shading.Color = Colors.LightGray;
               }

               Line_UL++;
            }

            WordDoc_O.LastSection.Add(RepportTable_O);
         }

         PdfDocumentRenderer PdfRenderer_O = new PdfDocumentRenderer(false, PdfFontEmbedding.Always);
         PdfRenderer_O.Document = WordDoc_O;
         PdfRenderer_O.RenderDocument();
         String TempFile = Path.Combine(MMSoftAppDataFolder_st, "Word_TEMP" + Directory.GetFiles(MMSoftAppDataFolder_st, "*.pdf").Length + ".pdf");
         PdfRenderer_O.PdfDocument.Save(TempFile);

         OpenPDFFile(TempFile);
      }

      public void ShowReturnDocument(UInt32 ComJobID_UL)
      {
         Document WordDoc_O = new Document();
         WordDoc_O.Info.Title = "Note d'envoi";

         DefineStyles(WordDoc_O);

         // Fill document with infos
         Section Section_O = WordDoc_O.AddSection();

         Paragraph Paragraph_O = Section_O.AddParagraph();
         Paragraph_O.AddFormattedText("Feuille return", "Heading1");

         Paragraph_O = Section_O.AddParagraph();

         if (mDBManager_O != null && mDBManager_O.mConnected_b)
         {
            String SqlSelect_O = "SELECT * FROM ComJobSelectPop WHERE ComJobID='" + ComJobID_UL + "'";
            SqlDataReader SqlDataReader_O = mDBManager_O.Select(SqlSelect_O);
            SqlDataReader MachineSqlDataReader_O;
            SqlDataReader PointageSqlDataReader_O;            

            if (SqlDataReader_O.Read())
            {
               Paragraph_O.AddFormattedText("Job : " + SqlDataReader_O["JobLib"].ToString(), "Heading2");
               WordDoc_O.LastSection.AddParagraph();

               Table JobInfosTable_O = new Table();
               JobInfosTable_O.Borders.Width = 0;
               JobInfosTable_O.AddColumn(Unit.FromCentimeter((1.0f / 6) * PageWidth_f));
               JobInfosTable_O.AddColumn(Unit.FromCentimeter((1.0f / 6) * PageWidth_f));
               JobInfosTable_O.AddColumn(Unit.FromCentimeter((1.0f / 6) * PageWidth_f));
               JobInfosTable_O.AddColumn(Unit.FromCentimeter((1.0f / 6) * PageWidth_f));
               JobInfosTable_O.AddColumn(Unit.FromCentimeter((1.0f / 6) * PageWidth_f));
               JobInfosTable_O.AddColumn(Unit.FromCentimeter((1.0f / 6) * PageWidth_f));

               Row Row_O = JobInfosTable_O.AddRow();
               Row_O = JobInfosTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("Client :");
               Row_O.Cells[0].Format.Font.Bold = true;
               Row_O.Cells[1].AddParagraph(SqlDataReader_O["ClientNom"].ToString());
               Row_O.Cells[2].AddParagraph("N° de cmd :");
               Row_O.Cells[2].Format.Font.Bold = true;
               Row_O.Cells[3].AddParagraph(SqlDataReader_O["NumRefInterne"].ToString());
               Row_O.Cells[4].AddParagraph("Délai");
               Row_O.Cells[4].Format.Font.Bold = true;
               Row_O.Cells[5].AddParagraph(Convert.ToDateTime(SqlDataReader_O["DelaiPromis"].ToString()).ToShortDateString());

               Row_O = JobInfosTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("N° cmd client :");
               Row_O.Cells[0].Format.Font.Bold = true;
               Row_O.Cells[1].AddParagraph(SqlDataReader_O["NumCmdClient"].ToString());
               Row_O.Cells[2].AddParagraph("N° de job :");
               Row_O.Cells[2].Format.Font.Bold = true;
               Row_O.Cells[3].AddParagraph(SqlDataReader_O["NumOrdre"].ToString());
               Row_O.Cells[4].AddParagraph("Qte :");
               Row_O.Cells[4].Format.Font.Bold = true;
               Row_O.Cells[5].AddParagraph(SqlDataReader_O["Qte"].ToString());

               Row_O = JobInfosTable_O.AddRow();

               JobInfosTable_O.SetEdge(0, 0, 6, 4, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.5, Colors.LightGray);
               WordDoc_O.LastSection.Add(JobInfosTable_O);
               WordDoc_O.LastSection.AddParagraph();

               Table HeaderTable_O = new Table();
               HeaderTable_O.Borders.Width = 0;
               HeaderTable_O.AddColumn(Unit.FromCentimeter((1.0f / 9) * PageWidth_f));
               HeaderTable_O.AddColumn(Unit.FromCentimeter((2.0f / 9) * PageWidth_f));
               HeaderTable_O.AddColumn(Unit.FromCentimeter((2.0f / 9) * PageWidth_f));
               HeaderTable_O.AddColumn(Unit.FromCentimeter((1.0f / 9) * PageWidth_f));
               HeaderTable_O.AddColumn(Unit.FromCentimeter((2.0f / 9) * PageWidth_f));
               HeaderTable_O.AddColumn(Unit.FromCentimeter((1.0f / 9) * PageWidth_f));

               Row_O = HeaderTable_O.AddRow();

               Row_O.Cells[0].AddParagraph("Date :");
               Row_O.Cells[0].Format.Font.Bold = true;

               Row_O.Cells[1].AddParagraph("Opérateur :");
               Row_O.Cells[1].Format.Font.Bold = true;

               Row_O.Cells[2].AddParagraph("Tâche :");
               Row_O.Cells[2].Format.Font.Bold = true;

               Row_O.Cells[3].AddParagraph("Heures :");
               Row_O.Cells[3].Format.Font.Bold = true;

               Row_O.Cells[4].AddParagraph("Machine :");
               Row_O.Cells[4].Format.Font.Bold = true;

               Row_O.Cells[5].AddParagraph("Heures :");
               Row_O.Cells[5].Format.Font.Bold = true;

               HeaderTable_O.SetEdge(0, 0, 6, 1, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.5, Colors.LightGray);
               WordDoc_O.LastSection.Add(HeaderTable_O);
               WordDoc_O.LastSection.AddParagraph();

               PointageSqlDataReader_O = mDBManager_O.Select("SELECT * FROM PointageSelectPop WHERE ComJobID=" + ComJobID_UL);

               while (PointageSqlDataReader_O.Read())
               {
                   if (!String.IsNullOrEmpty(PointageSqlDataReader_O["ComJobEtapeID"].ToString()))
                   {
                       Table PointageTable_O = new Table();
                       PointageTable_O.Borders.Width = 0;
                       PointageTable_O.AddColumn(Unit.FromCentimeter((1.0f / 9) * PageWidth_f));
                       PointageTable_O.AddColumn(Unit.FromCentimeter((2.0f / 9) * PageWidth_f));
                       PointageTable_O.AddColumn(Unit.FromCentimeter((2.0f / 9) * PageWidth_f));
                       PointageTable_O.AddColumn(Unit.FromCentimeter((1.0f / 9) * PageWidth_f));
                       PointageTable_O.AddColumn(Unit.FromCentimeter((2.0f / 9) * PageWidth_f));
                       PointageTable_O.AddColumn(Unit.FromCentimeter((1.0f / 9) * PageWidth_f));

                       Row_O = PointageTable_O.AddRow();

                       DateTime DatePrest_O = Convert.ToDateTime(PointageSqlDataReader_O["DatePrest"].ToString());
                       Row_O.Cells[0].AddParagraph(DatePrest_O.ToShortDateString());

                       Row_O.Cells[1].AddParagraph(PointageSqlDataReader_O["PersNom"].ToString());

                       Row_O.Cells[2].AddParagraph(PointageSqlDataReader_O["TypeTacheLib"].ToString());

                       Row_O.Cells[3].Format.Alignment = ParagraphAlignment.Center;
                       Row_O.Cells[3].AddParagraph(PointageSqlDataReader_O["NbrH"].ToString());


                        MachineSqlDataReader_O = mDBManager_O.Select("SELECT * FROM PointageMachineSelectPop WHERE ComJobEtapeID=" + PointageSqlDataReader_O["ComJobEtapeID"].ToString());

                        while (MachineSqlDataReader_O.Read())
                        {
                            // WARINING : Pointage Machine display Pointage AND PointageMachine, so Pointage Machine ID can be null !
                            if (!String.IsNullOrEmpty(MachineSqlDataReader_O["PointageMachinelID"].ToString()))
                            {
                                Row_O.Cells[4].AddParagraph(MachineSqlDataReader_O["MachineLib"].ToString());

                                Row_O.Cells[5].Format.Alignment = ParagraphAlignment.Center;
                                Row_O.Cells[5].AddParagraph(MachineSqlDataReader_O["NbrHMachine"].ToString());
                            }
                        }

                       if (!String.IsNullOrEmpty(PointageSqlDataReader_O["Rem"].ToString()))
                       {
                           Table RemTable_O = new Table();
                           RemTable_O.Borders.Width = 0;
                           RemTable_O.AddColumn(Unit.FromCentimeter((1.0f / 10) * PageWidth_f));
                           RemTable_O.AddColumn(Unit.FromCentimeter((9.0f / 10) * PageWidth_f));

                           Row_O = RemTable_O.AddRow();
                           Row_O = RemTable_O.AddRow();

                           Row_O.Cells[0].AddParagraph("Rem. :");
                           Row_O.Cells[0].Format.Font.Bold = true;
                           Row_O.Cells[1].AddParagraph(PointageSqlDataReader_O["Rem"].ToString());

                           Row_O = RemTable_O.AddRow();

                           //RemTable_O.SetEdge(0, 0, 2, 1, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.5, Colors.LightGray);
                           WordDoc_O.LastSection.Add(RemTable_O);
                       }

                       WordDoc_O.LastSection.Add(PointageTable_O);
                   }
               }

               WordDoc_O.LastSection.AddParagraph();

               Table SummaryTable_O = new Table();
               SummaryTable_O.Borders.Width = 0;
               SummaryTable_O.AddColumn(Unit.FromCentimeter((1.0f / 9) * PageWidth_f));
               SummaryTable_O.AddColumn(Unit.FromCentimeter((2.0f / 9) * PageWidth_f));
               SummaryTable_O.AddColumn(Unit.FromCentimeter((2.0f / 9) * PageWidth_f));
               SummaryTable_O.AddColumn(Unit.FromCentimeter((1.0f / 9) * PageWidth_f));
               SummaryTable_O.AddColumn(Unit.FromCentimeter((2.0f / 9) * PageWidth_f));
               SummaryTable_O.AddColumn(Unit.FromCentimeter((1.0f / 9) * PageWidth_f));

               Row_O = SummaryTable_O.AddRow();

               Row_O.Cells[2].AddParagraph("Total des heures :");
               Row_O.Cells[2].Format.Font.Bold = true;
               Row_O.Cells[3].AddParagraph(mDBManager_O.mFunctionManager_O.SCFNC_CountPointageHoursOnJob(ComJobID_UL).ToString());
               Row_O.Cells[3].Format.Alignment = ParagraphAlignment.Center;

               Row_O.Cells[4].AddParagraph("Total des h. machine :");
               Row_O.Cells[4].Format.Font.Bold = true;
               Row_O.Cells[5].AddParagraph(mDBManager_O.mFunctionManager_O.SCFNC_CountMachineHoursOnJob(ComJobID_UL).ToString());
               Row_O.Cells[5].Format.Alignment = ParagraphAlignment.Center;

               SummaryTable_O.SetEdge(0, 0, 6, 1, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 0.5, Colors.LightGray);
               WordDoc_O.LastSection.Add(SummaryTable_O);
            }
         }

         PdfDocumentRenderer PdfRenderer_O = new PdfDocumentRenderer(false, PdfFontEmbedding.Always);
         PdfRenderer_O.Document = WordDoc_O;
         PdfRenderer_O.RenderDocument();
         String TempFile = Path.Combine(MMSoftAppDataFolder_st, "Word_TEMP" + Directory.GetFiles(MMSoftAppDataFolder_st, "*.pdf").Length + ".pdf");
         PdfRenderer_O.PdfDocument.Save(TempFile);

         OpenPDFFile(TempFile);
      }
      /// <summary>
      /// Define style for pdf writing
      /// </summary>
      /// <param name="document"></param>
      public static void DefineStyles(Document document)   
      {
         // Get the predefined style Normal.
         Style style = document.Styles["Normal"];
         style.Font.Size = 10;
         // Because all styles are derived from Normal, the next line changes the
         // font of the whole document. Or, more exactly, it changes the font of
         // all styles and paragraphs that do not redefine the font.
         style.Font.Name = "Calibri";
         // Heading1 to Heading9 are predefined styles with an outline level. An outline level
         // other than OutlineLevel.BodyText automatically creates the outline (or bookmarks)
         // in PDF.
         style = document.Styles["Heading1"];
         style.Font.Name = "Calibri Light";
         style.Font.Size = 28;
         style.Font.Bold = true;
         style.Font.Color = Colors.Black;
         style.ParagraphFormat.Borders = new Borders();
         style.ParagraphFormat.PageBreakBefore = true;
         //style.ParagraphFormat.SpaceAfter = 6;
         style = document.Styles["Heading2"];
         style.Font.Name = "Calibri Light";
         style.Font.Size = 20;
         style.Font.Bold = false;
         style.Font.Color = Colors.Black; 
         style.ParagraphFormat.PageBreakBefore = false;
         //style.ParagraphFormat.SpaceBefore = 6;
         //style.ParagraphFormat.SpaceAfter = 6;
         style = document.Styles["Heading3"];
         style.Font.Name = "Calibri Light";
         style.Font.Size = 12;
         style.Font.Bold = false;
         style.Font.Italic = false;
         style.Font.Color = Colors.Black;
         //style.ParagraphFormat.SpaceBefore = 6;
         //style.ParagraphFormat.SpaceAfter = 3;

         style = document.Styles[StyleNames.Header];

         style = document.Styles[StyleNames.Footer];

         style = document.Styles.AddStyle("TextBox", "Normal");
         style.ParagraphFormat.Alignment = ParagraphAlignment.Justify;
         style.ParagraphFormat.Borders.Width = 2.5;
         style.ParagraphFormat.Borders.Distance = "3pt";
         style.ParagraphFormat.Shading.Color = Colors.SkyBlue;
         // Create a new style called TOC based on style Normal
         style = document.Styles.AddStyle("TOC", "Normal");
         style.ParagraphFormat.Font.Color = Colors.Blue;
      }

      void OpenPDFFile(String PDFFile_ST)
      {
         try
         {
            Process.Start(PDFFile_ST);
         }
         catch (System.ComponentModel.Win32Exception e)
         {
            MessageBox.Show("Une erreur s'est produite lors de l'ouverture du fichier " + PDFFile_ST + ".\nInfo supplémentaire :\n" + e.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         catch (ObjectDisposedException e)
         {
            MessageBox.Show("Le fichier " + PDFFile_ST + " a été supprimé depuis la demande d'ouverture.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         catch (FileNotFoundException e)
         {
            MessageBox.Show("Le fichier " + PDFFile_ST + " n'a pas été trouvé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }
   }
}
