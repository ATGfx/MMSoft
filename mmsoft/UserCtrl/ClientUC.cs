using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MMSoft
{
   public partial class ClientUC : UserControl, IMMSoftUC
   {
      private Control mParentContainer_O;
      private DatabaseManager mDBManager_O;
      private bool mEditState_b;
      private bool mInitializingData_b;

      public ClientUC(DatabaseManager DBManager_O)
      {
         InitializeComponent();

         mInitializingData_b = false;

         // Add btn tool tool strip list view
         this.DBListViewClient.ListTitle = "Sélection client";
         this.DBListViewClient.AddToolStripBtn(this.ToolStripBtnAddClient);
         ToolStripUCClientTools.Visible = false;

         this.DBListViewComjobRecap.ListTitle = "Jobs du client";

         ToolStripUCClientTools.Renderer = new BorderlessToolStripRenderer();

         mDBManager_O = DBManager_O;

         List<String> TableField_ST = new List<String>();
         List<String> ColumnHeaderName_ST = new List<String>();
         List<int> ColumnHeaderDefaultSize_i = new List<int>();
         List<HorizontalAlignment> TextAlign_O = new List<HorizontalAlignment>();
         
         TableField_ST.Add("NumClientInterne");
         TableField_ST.Add("ClientNom");
         TableField_ST.Add("NrTVA");
         TableField_ST.Add("ClientID");

         ColumnHeaderName_ST.Add("N° de client");
         ColumnHeaderName_ST.Add("Nom");
         ColumnHeaderName_ST.Add("N° TVA");

         ColumnHeaderDefaultSize_i.Add(100);
         ColumnHeaderDefaultSize_i.Add(300);
         ColumnHeaderDefaultSize_i.Add(150);

         TextAlign_O.Add(HorizontalAlignment.Left);
         TextAlign_O.Add(HorizontalAlignment.Left);
         TextAlign_O.Add(HorizontalAlignment.Left);

         DBListViewClient.Initialize(mDBManager_O, "Client", TableField_ST, 3, ColumnHeaderName_ST, ColumnHeaderDefaultSize_i, TextAlign_O);
         DBListViewClient.SelectionChanged += new DBListView.SelectionChangedHandler(this.ClientClick);

         DBComboxTypeSoc.FillList(mDBManager_O, "TypeSoc", "TypeSocID", "TypeSocLib");
         DBComboxCPFact.FillList(mDBManager_O, "CodePostal", "CodePostalID", "CodePostal");
         DBComboxCPLivr.FillList(mDBManager_O, "CodePostal", "CodePostalID", "CodePostal");
         DBComboxCPLibFact.FillList(mDBManager_O, "CodePostal", "CodePostalID", "Localite");
         DBComboxCPLibLivr.FillList(mDBManager_O, "CodePostal", "CodePostalID", "Localite");

         // Define comjob recap list view
         List<String> TableFieldJobRecap_ST = new List<String>();
         List<String> ColumnHeaderNameJobRecap_ST = new List<String>();
         List<int> ColumnHeaderDefaultSizeJobRecap_i = new List<int>();
         List<HorizontalAlignment> TextAlignJobRecap_O = new List<HorizontalAlignment>();

         // Define column DB fields
         TableFieldJobRecap_ST.Add("NumRefInterne");
         TableFieldJobRecap_ST.Add("LibelleCmd");
         TableFieldJobRecap_ST.Add("NumCmdClient");
         TableFieldJobRecap_ST.Add("NumOrdre");
         TableFieldJobRecap_ST.Add("JobLib");
         TableFieldJobRecap_ST.Add("Qte");
         TableFieldJobRecap_ST.Add("NumPlan");
         TableFieldJobRecap_ST.Add("DelaiPromis");
         TableFieldJobRecap_ST.Add("JobStatusLib");
         TableFieldJobRecap_ST.Add("DateEncod");
         // Unshown elements
         TableFieldJobRecap_ST.Add("ComJobID");

         // Define column headers text
         ColumnHeaderNameJobRecap_ST.Add("Num cmd int");
         ColumnHeaderNameJobRecap_ST.Add("Libellé cmd");
         ColumnHeaderNameJobRecap_ST.Add("Num cmd client");
         ColumnHeaderNameJobRecap_ST.Add("# job");
         ColumnHeaderNameJobRecap_ST.Add("Job libellé");
         ColumnHeaderNameJobRecap_ST.Add("Qte");
         ColumnHeaderNameJobRecap_ST.Add("Num plan");
         ColumnHeaderNameJobRecap_ST.Add("Délai");
         ColumnHeaderNameJobRecap_ST.Add("Statut");
         ColumnHeaderNameJobRecap_ST.Add("Date encodage");

         // size
         ColumnHeaderDefaultSizeJobRecap_i.Add(100);
         ColumnHeaderDefaultSizeJobRecap_i.Add(100);
         ColumnHeaderDefaultSizeJobRecap_i.Add(150);
         ColumnHeaderDefaultSizeJobRecap_i.Add(50);
         ColumnHeaderDefaultSizeJobRecap_i.Add(600);
         ColumnHeaderDefaultSizeJobRecap_i.Add(50);
         ColumnHeaderDefaultSizeJobRecap_i.Add(100);
         ColumnHeaderDefaultSizeJobRecap_i.Add(100);
         ColumnHeaderDefaultSizeJobRecap_i.Add(100);
         ColumnHeaderDefaultSizeJobRecap_i.Add(100);

         // alignment
         for (int i = 0; i < ColumnHeaderNameJobRecap_ST.Count; i++)
         {
            if (i == 3 || i == 5)
               TextAlignJobRecap_O.Add(HorizontalAlignment.Center);
            else
               TextAlignJobRecap_O.Add(HorizontalAlignment.Left);
         }

         DBListViewComjobRecap.Initialize(mDBManager_O, "ComJobSelectPop", TableFieldJobRecap_ST, 10, ColumnHeaderNameJobRecap_ST, ColumnHeaderDefaultSizeJobRecap_i, TextAlignJobRecap_O, null, null, false);

         SetEditState(false);

         TxtClientNumber.Width = Math.Max(50, TxtClientNumber.Width);
         TxtClientName.Width = ToolStripClientHeader.Width - toolStripLabel1.Width - TxtClientNumber.Width - toolStripLabel3.Width - 5;
         
         ToolStripClientEditFooter.Renderer = new BorderlessToolStripRenderer();
         ToolStripClientHeader.Renderer = new BorderlessToolStripRenderer();
         ControlStyle.SetBackgroundStyle(this);
         ControlStyle.SetBackgroundStyle(this.ToolStripUCClientTools);
         ControlStyle.SetFrameHeaderStyle(this.PanelClientList);
         ControlStyle.SetFrameHeaderStyle(this.PanelCheckHeader);
         ControlStyle.SetFrameHeaderStyle(this.PanelJobRecap);
         ControlStyle.SetFrameHeaderStyle(this.splitContainer2.Panel1);
         ControlStyle.SetFrameStyle(this.PanelCheckContent);
         ControlStyle.SetFrameStyle(this.ToolStripClientEditFooter);

         DBListViewClient.ForeColor = Color.Black;
         DBListViewClient.AllowMultipleSelecion = false;
         DBListViewComjobRecap.AllowMultipleSelecion = false;
      }

      public bool Activate(Control Container_O)
      {
         mParentContainer_O = Container_O;
         mParentContainer_O.Controls.Add(this);
         this.BringToFront();
         this.Dock = DockStyle.Fill;

         // Update tooltip of client number text box
         TxtClientNumber.ToolTipText = mDBManager_O.mConnected_b ? "Plus haut numéro de client entré : " + mDBManager_O.mFunctionManager_O.SCFNC_GetMaxClientNumber() : null;
         
         return true;
      }

      public bool Deactivate()
      {
         bool Rts_b = true;

         if (!mEditState_b)
         {
            if (mParentContainer_O != null)
               mParentContainer_O.Controls.Remove(this);
         }
         else
         {
            MessageBox.Show("Impossible d'ouvrir le module sélectionné car un client est en cours d'édition. Veuillez enregistrer ou annuler vos modifications avant de continuer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Rts_b = false;
         }

         return Rts_b;
      }

      private void ClientClick(UInt32 ClientID_UL)
      {
         // Load client info in each control
         String SQLRequest_ST;
         SqlDataReader SqlDataReader_O;
         UInt32 TypeSocID_UL = 0;
         UInt32 CPID_UL = 0;

         int RappConf_i = 0, NoteEnvoi_i = 0, Certif_i = 0;

         // Fill info in panel edit controls
         mInitializingData_b = true;

         TxtClientNumber.Clear();
         TxtClientName.Clear();
         TxtTel.Clear();
         TxtFax.Clear();
         TxtAdressFact.Clear();
         TxtAdressLivr.Clear();
         TxtContactMail.Clear();
         TxtContactTel.Clear();
         TxtContactName.Clear();
         TxtTVA.Clear();
         TxtMail.Clear();
         TxtRem.Clear();

         CheckBoxRappConf.Checked = false;
         CheckBoxNE.Checked = false;
         CheckBoxCertif.Checked = false;

         DBComboxTypeSoc.ClearSelectedItem();
         DBComboxCPFact.ClearSelectedItem();
         DBComboxCPLivr.ClearSelectedItem();
         DBComboxCPLibFact.ClearSelectedItem();
         DBComboxCPLibLivr.ClearSelectedItem();

         mInitializingData_b = false;


         if (mDBManager_O != null && mDBManager_O.mConnected_b)
         {
            SQLRequest_ST = "SELECT * FROM Client WHERE ClientID=" + ClientID_UL;
            SqlDataReader_O = mDBManager_O.Select(SQLRequest_ST);
            mInitializingData_b = true;

            while (SqlDataReader_O.Read())
            {
               int.TryParse(SqlDataReader_O["RappConf"].ToString(), out RappConf_i);
               int.TryParse(SqlDataReader_O["NoteEnvoi"].ToString(), out NoteEnvoi_i);
               int.TryParse(SqlDataReader_O["Certif"].ToString(), out Certif_i);

               // Fill info in panel edit controls
               TxtClientNumber.Text = SqlDataReader_O["NumClientInterne"].ToString();
               TxtClientName.Text = SqlDataReader_O["ClientNom"].ToString();
               TxtTel.Text = SqlDataReader_O["ClientTel"].ToString();
               TxtFax.Text = SqlDataReader_O["ClientFax"].ToString();
               TxtAdressFact.Text = SqlDataReader_O["AdresseFact"].ToString();
               TxtAdressLivr.Text = SqlDataReader_O["AdresseLivraison"].ToString();
               TxtContactMail.Text = SqlDataReader_O["ContactEmail"].ToString();
               TxtContactTel.Text = SqlDataReader_O["ContactTel"].ToString();
               TxtContactName.Text = SqlDataReader_O["Contact"].ToString();
               TxtTVA.Text = SqlDataReader_O["NrTVA"].ToString();
               TxtMail.Text = SqlDataReader_O["ClientMail"].ToString();
               TxtRem.Text = SqlDataReader_O["ClientRem"].ToString();

               CheckBoxRappConf.Checked = RappConf_i != 0 ? true : false;
               CheckBoxNE.Checked = NoteEnvoi_i != 0 ? true : false;
               CheckBoxCertif.Checked = Certif_i != 0 ? true : false;

               if (UInt32.TryParse(SqlDataReader_O["TypeSocID"].ToString(), out TypeSocID_UL))
                  DBComboxTypeSoc.SelectItemByID(TypeSocID_UL);

               if (UInt32.TryParse(SqlDataReader_O["CodePostalFactID"].ToString(), out CPID_UL))
               {
                  DBComboxCPFact.SelectItemByID(CPID_UL);
                  DBComboxCPLibFact.SelectItemByID(CPID_UL);
               }
               else
               {
                  DBComboxCPFact.ClearSelectedItem();
                  DBComboxCPLibFact.ClearSelectedItem();
               }

               if (UInt32.TryParse(SqlDataReader_O["CodePostalLivraisonID"].ToString(), out CPID_UL))
               {
                  DBComboxCPLivr.SelectItemByID(CPID_UL);
                  DBComboxCPLibLivr.SelectItemByID(CPID_UL);
               }
               else
               {
                  DBComboxCPLivr.ClearSelectedItem();
                  DBComboxCPLibLivr.ClearSelectedItem();
               }

               // Refresh job recap
               if (!String.IsNullOrEmpty(SqlDataReader_O["ClientNom"].ToString()))
               {
                  DBListViewComjobRecap.SetInitialFilter("ClientNom='" + SqlDataReader_O["ClientNom"].ToString() + "'", "DelaiPromis desc");
                  DBListViewComjobRecap.Refresh();
               }
            }

            SqlDataReader_O.Close();
            mInitializingData_b = false;
         }
      }

      private void DBComboxCPFact_SelectedIndexChanged(object sender, EventArgs e)
      {
         UInt32 ID_UL;
         DBComboxCPFact.GetSelectedItemID(out ID_UL);
         DBComboxCPLibFact.SelectItemByID(ID_UL);
         ValueChanged(this, EventArgs.Empty);
      }

      private void DBComboxCPLibFact_SelectedIndexChanged(object sender, EventArgs e)
      {
         UInt32 ID_UL;
         DBComboxCPLibFact.GetSelectedItemID(out ID_UL);
         DBComboxCPFact.SelectItemByID(ID_UL);
         ValueChanged(this, EventArgs.Empty);
      }

      private void ToolStripBtnAddClient_Click(object sender, EventArgs e)
      {
         if (!mEditState_b)
         {
            FormAskString Form_O = new FormAskString("Nom du nouveau client");
            DialogResult DlgRes_O = Form_O.ShowDialog();

            if(DlgRes_O == DialogResult.OK && mDBManager_O.mConnected_b)
            {
               UInt32 NewClientID_O = mDBManager_O.mStoredProcedureManager_O.STPROC_CreateClient(Form_O.mEnteredString_ST);
               DBListViewClient.Refresh();
               DBListViewClient.SelectItemByID(NewClientID_O);
               TxtClientNumber.ToolTipText = mDBManager_O.mConnected_b ? "Plus haut numéro de client entré : " + mDBManager_O.mFunctionManager_O.SCFNC_GetMaxClientNumber() : null;
            }
         }
         else
            MessageBox.Show("Impossible d'ajouter un nouveau client lorsqu'un autre est en cours d'édition. Veuillez d'abord enregistrer ou annuler vos modifications.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      private void ToolStripBtnEditClient_Click(object sender, EventArgs e)
      {
         if (!mEditState_b && DBListViewClient.GetSelectedItemID() != 0)
         {
            DBListViewClient.SetLockState(true);
            SetEditState(true);
            
         }
      }

      private void BtnSaveChanges_Click(object sender, EventArgs e)
      {
         if (mEditState_b)
         {
            UInt32 ClientID_UL = DBListViewClient.GetSelectedItemID();

            //Build update request
            if (mDBManager_O != null && mDBManager_O.mConnected_b)
            {
               UInt32 TypeSocID_UL;
               UInt32 CPFactID_UL, CPLivrID_UL;
               UInt32 ClientNumber_UL;

               if (UInt32.TryParse(TxtClientNumber.Text, out ClientNumber_UL))
               {
                  // Check if client number already exists
                  String ClientWithSameNumber_ST = mDBManager_O.GetTableField("Client", "ClientNom", "NumClientInterne='" + ClientNumber_UL + "'");
                  String ClientIDWithSameNumber_ST = mDBManager_O.GetTableField("Client", "ClientID", "NumClientInterne='" + ClientNumber_UL + "'");
                  UInt32 ClientIDWithSameNumber_UL = 0;
                  UInt32.TryParse(ClientIDWithSameNumber_ST, out ClientIDWithSameNumber_UL);
                  DialogResult DlgRes_O = DialogResult.Yes;

                  if (!String.IsNullOrEmpty(TxtClientNumber.Text) && !String.IsNullOrEmpty(ClientWithSameNumber_ST) && ClientID_UL != ClientIDWithSameNumber_UL)
                  {
                     DlgRes_O = MessageBox.Show("Le client " + ClientWithSameNumber_ST + " existe déjà sous le numéro " + ClientNumber_UL + ". Poursuivre quand même l'enregistrement ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                  }

                  if (DlgRes_O == DialogResult.Yes)
                  {
                     DBComboxTypeSoc.GetSelectedItemID(out TypeSocID_UL);
                     DBComboxCPFact.GetSelectedItemID(out CPFactID_UL);
                     DBComboxCPLivr.GetSelectedItemID(out CPLivrID_UL);

                     List<String> Param_O = new List<String>();
                     List<Object> Values_O = new List<Object>();

                     String SqlCommand_O = @"UPDATE Client SET ClientNom=@ClientNom, NumClientInterne=@NumClientInterne, TypeSocID=@TypeSocID, NrTVA=@NrTVA, Contact=@Contact, ContactTel=@ContactTel,
                                                           ContactEmail=@ContactEmail, AdresseFact=@AdresseFact, CodePostalFactID=@CodePostalFactID, AdresseLivraison=@AdresseLivraison, CodePostalLivraisonID=@CodePostalLivraisonID,
                                                            ClientTel=@ClientTel, ClientFax=@ClientFax, ClientMail=@ClientMail, ClientRem=@ClientRem, NoteEnvoi=@NoteEnvoi, Certif=@Certif, RappConf=@RappConf
                                                       WHERE ClientID=@ClientID";

                     Param_O.Add("@ClientNom"); Values_O.Add(TxtClientName.Text);
                     Param_O.Add("@NumClientInterne"); Values_O.Add((int)ClientNumber_UL);
                     Param_O.Add("@TypeSocID"); Values_O.Add((int)TypeSocID_UL);
                     Param_O.Add("@NrTVA"); Values_O.Add(TxtTVA.Text);
                     Param_O.Add("@Contact"); Values_O.Add(TxtContactName.Text);
                     Param_O.Add("@ContactTel"); Values_O.Add(TxtContactTel.Text);
                     Param_O.Add("@ContactEmail"); Values_O.Add(TxtContactMail.Text);
                     Param_O.Add("@AdresseFact"); Values_O.Add(TxtAdressFact.Text);
                     Param_O.Add("@CodePostalFactID"); Values_O.Add((int)CPFactID_UL);
                     Param_O.Add("@AdresseLivraison"); Values_O.Add(TxtAdressLivr.Text);
                     Param_O.Add("@CodePostalLivraisonID"); Values_O.Add((int)CPLivrID_UL);
                     Param_O.Add("@ClientTel"); Values_O.Add(TxtTel.Text);
                     Param_O.Add("@ClientFax"); Values_O.Add(TxtFax.Text);
                     Param_O.Add("@ClientMail"); Values_O.Add(TxtMail.Text);
                     Param_O.Add("@ClientRem"); Values_O.Add(TxtRem.Text);
                     Param_O.Add("@ClientID"); Values_O.Add((int)ClientID_UL);
                     Param_O.Add("@NoteEnvoi"); Values_O.Add(CheckBoxNE.Checked);
                     Param_O.Add("@Certif"); Values_O.Add(CheckBoxCertif.Checked);
                     Param_O.Add("@RappConf"); Values_O.Add(CheckBoxRappConf.Checked);

                     mDBManager_O.ExecuteRequest(SqlCommand_O, Param_O, Values_O);

                     SetEditState(false);
                     DBListViewClient.SetLockState(false);
                     DBListViewClient.Refresh();
                     DBListViewClient.SelectItemByID(ClientID_UL);
                  }
               }
               else
               {
                  MessageBox.Show("Impossible d'enregistrer les modifications : le numéro de client entré n'est pas un nombre valide.", "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
            }
         }
      }

      private void BtnCancelChanges_Click(object sender, EventArgs e)
      {       
         if (mEditState_b)
         {
            DialogResult DlgRes_O = MessageBox.Show("Les modifications effectuées sur le client seront perdues, continuer ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (DlgRes_O == DialogResult.Yes)
            {
               SetEditState(false);
               DBListViewClient.SetLockState(false);
               Refresh();

               DBListViewClient.SelectItemByID(DBListViewClient.GetSelectedItemID());
            }
         }
      }

      private void SetEditState(bool EditState_b)
      {
         mEditState_b = EditState_b;
         ToolStripBtnSaveChanges.Visible = EditState_b;
         ToolStripBtnCancelChanges.Visible = EditState_b;

         if (mEditState_b)
         {
             ControlStyle.SetBackgroundColorFocusStyle(this.splitContainer2.Panel1);
             ControlStyle.SetBackgroundColorFocusStyle(PanelCheckHeader);

             if (!LblClientNumAndName.Text.Contains(" *"))
             {
                 LblClientNumAndName.Text += " *";
             }
         }
         else
         {
             ControlStyle.SetFrameHeaderStyle(this.splitContainer2.Panel1);
             ControlStyle.SetFrameHeaderStyle(PanelCheckHeader);

             if (LblClientNumAndName.Text.Contains(" *"))
             {
                 LblClientNumAndName.Text = LblClientNumAndName.Text.Remove(LblClientNumAndName.Text.IndexOf(" *"), 2);
             }
         }
      }

      private void ValueChanged(object sender, EventArgs e)
      {
         if (DBListViewClient.GetSelectedItemID() > 0 && !mInitializingData_b)
         {
            DBListViewClient.SetLockState(true);
            SetEditState(true);
         }
      }

      private void DBComboxCPLivr_SelectedIndexChanged(object sender, EventArgs e)
      {
         UInt32 ID_UL;
         DBComboxCPLivr.GetSelectedItemID(out ID_UL);
         DBComboxCPLibLivr.SelectItemByID(ID_UL);
         ValueChanged(this, EventArgs.Empty);
      }

      private void DBComboxCPLibLivr_SelectedIndexChanged(object sender, EventArgs e)
      {
         UInt32 ID_UL;
         DBComboxCPLibLivr.GetSelectedItemID(out ID_UL);
         DBComboxCPLivr.SelectItemByID(ID_UL);
         ValueChanged(this, EventArgs.Empty);
      }
   }
}
