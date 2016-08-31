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
   public partial class ProviderUC : UserControl, IMMSoftUC
   {
      private Control mParentContainer_O;
      private DatabaseManager mDBManager_O;
      private bool mEditState_b;
      private bool mInitializingData_b;
      private List<Control> Fields_O;

      public ProviderUC(DatabaseManager DBManager_O)
      {
         InitializeComponent();

         mInitializingData_b = false;

         // Add btn tool tool strip list view
         this.DBListViewProvider.ListTitle = "Sélection fournisseur";
         this.DBListViewProvider.AddToolStripBtn(this.ToolStripBtnAddProvider);
         ToolStripUCProviderTools.Visible = false;

         this.DBListViewBuyRecap.ListTitle = "Achats chez le fournisseur";

         ToolStripUCProviderTools.Renderer = new BorderlessToolStripRenderer();

         mDBManager_O = DBManager_O;

         List<String> TableField_ST = new List<String>();
         List<String> ColumnHeaderName_ST = new List<String>();
         List<int> ColumnHeaderDefaultSize_i = new List<int>();
         List<HorizontalAlignment> TextAlign_O = new List<HorizontalAlignment>();
         
         TableField_ST.Add("NumFournInterne");
         TableField_ST.Add("FournNom");
         TableField_ST.Add("NrTVA");
         TableField_ST.Add("FournID");

         ColumnHeaderName_ST.Add("N° de fournisseur");
         ColumnHeaderName_ST.Add("Nom");
         ColumnHeaderName_ST.Add("N° TVA");

         ColumnHeaderDefaultSize_i.Add(100);
         ColumnHeaderDefaultSize_i.Add(300);
         ColumnHeaderDefaultSize_i.Add(150);

         TextAlign_O.Add(HorizontalAlignment.Left);
         TextAlign_O.Add(HorizontalAlignment.Left);
         TextAlign_O.Add(HorizontalAlignment.Left);

         DBListViewProvider.Initialize(mDBManager_O, "Fourn", TableField_ST, 3, ColumnHeaderName_ST, ColumnHeaderDefaultSize_i, TextAlign_O);

         DBListViewProvider.SelectionChanged += new DBListView.SelectionChangedHandler(this.ProviderClick);

         DBComboxTypeSoc.FillList(mDBManager_O, "TypeSoc", "TypeSocID", "TypeSocLib");
         DBComboxCPFact.FillList(mDBManager_O, "CodePostal", "CodePostalID", "CodePostal");
         DBComboxCPLibFact.FillList(mDBManager_O, "CodePostal", "CodePostalID", "Localite");

         // Define comjob recap list view
         List<String> TableFieldJobRecap_ST = new List<String>();
         List<String> ColumnHeaderNameJobRecap_ST = new List<String>();
         List<int> ColumnHeaderDefaultSizeJobRecap_i = new List<int>();
         List<HorizontalAlignment> TextAlignJobRecap_O = new List<HorizontalAlignment>();

         // alignment
         for (int i = 0; i < ColumnHeaderNameJobRecap_ST.Count; i++)
         {
            if (i == 3 || i == 5)
               TextAlignJobRecap_O.Add(HorizontalAlignment.Center);
            else
               TextAlignJobRecap_O.Add(HorizontalAlignment.Left);
         }

         DBListViewBuyRecap.Initialize(mDBManager_O, "ComJobAchatSelectPop", TableFieldJobRecap_ST, 10, ColumnHeaderNameJobRecap_ST, ColumnHeaderDefaultSizeJobRecap_i, TextAlignJobRecap_O, null, null, false);

         Fields_O = new List<Control>();
         Fields_O.Add(DBComboxTypeSoc);
         Fields_O.Add(DBComboxCPFact);
         Fields_O.Add(DBComboxCPLibFact);
         Fields_O.Add(TxtTel);
         Fields_O.Add(TxtFax);
         Fields_O.Add(TxtAdressFact);
         Fields_O.Add(TxtContactMail);
         Fields_O.Add(TxtContactTel);
         Fields_O.Add(TxtContactName);
         Fields_O.Add(TxtTVA);
         Fields_O.Add(TxtMail);
         Fields_O.Add(TxtRem);

         SetEditState(false);

         TxtProviderNumber.Width = Math.Max(50, TxtProviderNumber.Width);
         TxtProviderName.Width = ToolStripProviderHeader.Width - toolStripLabel1.Width - TxtProviderNumber.Width - toolStripLabel3.Width - 5;

         ToolStripProviderEditFooter.Renderer = new BorderlessToolStripRenderer();
         ToolStripProviderHeader.Renderer = new BorderlessToolStripRenderer();
         ControlStyle.SetBackgroundStyle(this);
         ControlStyle.SetBackgroundStyle(this.ToolStripUCProviderTools);
         ControlStyle.SetFrameHeaderStyle(this.PanelProviderList);
         ControlStyle.SetFrameHeaderStyle(this.PanelCheckHeader);
         ControlStyle.SetFrameHeaderStyle(this.PanelJobRecap);
         ControlStyle.SetFrameHeaderStyle(this.splitContainer2.Panel1);
         ControlStyle.SetFrameStyle(this.PanelCheckContent);
         ControlStyle.SetFrameStyle(this.ToolStripProviderEditFooter);

         DBListViewProvider.ForeColor = Color.Black;
      }

      public bool Activate(Control Container_O)
      {
         mParentContainer_O = Container_O;
         mParentContainer_O.Controls.Add(this);
         this.BringToFront();
         this.Dock = DockStyle.Fill;

         // Update tooltip of client number text box
         TxtProviderNumber.ToolTipText = mDBManager_O.mConnected_b ? "Plus haut numéro de fournisseur entré : " + mDBManager_O.mFunctionManager_O.SCFNC_GetMaxProviderNumber() : null;


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
            MessageBox.Show("Impossible d'ouvrir le module sélectionné car un fournisseur est en cours d'édition. Veuillez enregistrer ou annuler vos modifications avant de continuer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Rts_b = false;
         }

         return Rts_b;
      }

      private void ProviderClick(UInt32 ProviderID_UL)
      {
         // Load provider info in each control
         String SQLRequest_ST;
         SqlDataReader SqlDataReader_O;
         UInt32 TypeSocID_UL = 0;
         UInt32 CPID_UL = 0;

         mInitializingData_b = true;

         TxtProviderNumber.Clear();
         TxtProviderName.Clear();
         TxtTel.Clear();
         TxtFax.Clear();
         TxtAdressFact.Clear();
         TxtContactMail.Clear();
         TxtContactTel.Clear();
         TxtContactName.Clear();
         TxtTVA.Clear();
         TxtMail.Clear();
         TxtRem.Clear();

         DBComboxTypeSoc.ClearSelectedItem();
         DBComboxCPFact.ClearSelectedItem();
         DBComboxCPLibFact.ClearSelectedItem();

         mInitializingData_b = false;

         if (mDBManager_O != null && mDBManager_O.mConnected_b)
         {
            SQLRequest_ST = "SELECT * FROM Fourn WHERE FournID=" + ProviderID_UL;
            SqlDataReader_O = mDBManager_O.Select(SQLRequest_ST);
            mInitializingData_b = true;

            while (SqlDataReader_O.Read())
            {
               // Fill info in panel edit controls
               TxtProviderNumber.Text = SqlDataReader_O["NumFournInterne"].ToString();
               TxtProviderName.Text = SqlDataReader_O["FournNom"].ToString();
               TxtTel.Text = SqlDataReader_O["FournTel"].ToString();
               TxtFax.Text = SqlDataReader_O["FournFax"].ToString();
               TxtAdressFact.Text = SqlDataReader_O["Adresse"].ToString();
               TxtContactMail.Text = SqlDataReader_O["ContactEmail"].ToString();
               TxtContactTel.Text = SqlDataReader_O["ContactTel"].ToString();
               TxtContactName.Text = SqlDataReader_O["Contact"].ToString();
               TxtTVA.Text = SqlDataReader_O["NrTVA"].ToString();
               TxtMail.Text = SqlDataReader_O["FournMail"].ToString();
               TxtRem.Text = SqlDataReader_O["FournRem"].ToString();

               if (UInt32.TryParse(SqlDataReader_O["TypeSocID"].ToString(), out TypeSocID_UL))
                  DBComboxTypeSoc.SelectItemByID(TypeSocID_UL);
               if (UInt32.TryParse(SqlDataReader_O["CodePostalID"].ToString(), out CPID_UL))
               {
                  DBComboxCPFact.SelectItemByID(CPID_UL);
                  DBComboxCPLibFact.SelectItemByID(CPID_UL);
               }
               else
               {
                  DBComboxCPFact.ClearSelectedItem();
                  DBComboxCPLibFact.ClearSelectedItem();
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

      private void ToolStripBtnAddProvider_Click(object sender, EventArgs e)
      {
         if (!mEditState_b)
         {
            FormAskString Form_O = new FormAskString("Nom du nouveau fournisseur");
            DialogResult DlgRes_O = Form_O.ShowDialog();

            if(DlgRes_O == DialogResult.OK && mDBManager_O.mConnected_b)
            {
               UInt32 NewProviderID_O = mDBManager_O.mStoredProcedureManager_O.STPROC_CreateProvider(Form_O.mEnteredString_ST);
               DBListViewProvider.Refresh();
               DBListViewProvider.SelectItemByID(NewProviderID_O);
               TxtProviderNumber.ToolTipText = mDBManager_O.mConnected_b ? "Plus haut numéro de fournisseur entré : " + mDBManager_O.mFunctionManager_O.SCFNC_GetMaxProviderNumber() : null;
            }
         }
         else
            MessageBox.Show("Impossible d'ajouter un nouveau fournisseur lorsqu'un autre est en cours d'édition. Veuillez d'abord enregistrer ou annuler vos modifications.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      private void ToolStripBtnEditProvider_Click(object sender, EventArgs e)
      {
         if (!mEditState_b && DBListViewProvider.GetSelectedItemID() != 0)
         {
            DBListViewProvider.SetLockState(true);
            SetEditState(true);
         }
      }

      private void BtnSaveChanges_Click(object sender, EventArgs e)
      {
         if (mEditState_b)
         {
            UInt32 ProviderID_UL = DBListViewProvider.GetSelectedItemID();

            //Build update request
            if (mDBManager_O != null && mDBManager_O.mConnected_b)
            {
               UInt32 TypeSocID_UL;
               UInt32 CPFactID_UL;

               // Check if provider number already exists
               String ProviderWithSameNumber_ST = mDBManager_O.GetTableField("Fourn", "FournNom", "NumFournInterne='" + TxtProviderNumber.Text + "'");
               String ProviderIDWithSameNumber_ST = mDBManager_O.GetTableField("Fourn", "FournID", "NumFournInterne='" + TxtProviderNumber.Text + "'");
               UInt32 ProviderIDWithSameNumber_UL = 0;
               UInt32.TryParse(ProviderIDWithSameNumber_ST, out ProviderIDWithSameNumber_UL);
               DialogResult DlgRes_O = DialogResult.Yes;

               if (!String.IsNullOrEmpty(TxtProviderNumber.Text) && !String.IsNullOrEmpty(ProviderWithSameNumber_ST) && ProviderID_UL != ProviderIDWithSameNumber_UL)
               {
                  DlgRes_O = MessageBox.Show("Le fournisseur " + ProviderWithSameNumber_ST + " existe déjà sous le numéro " + TxtProviderNumber.Text + ". Poursuivre quand même l'enregistrement ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
               }

               if (DlgRes_O == DialogResult.Yes)
               {
                  DBComboxTypeSoc.GetSelectedItemID(out TypeSocID_UL);
                  DBComboxCPFact.GetSelectedItemID(out CPFactID_UL);

                  List<String> Param_O = new List<String>();
                  List<Object> Values_O = new List<Object>();

                  String SqlCommand_O = @"UPDATE Fourn SET FournNom=@FournNom, NumFournInterne=@NumFournInterne, TypeSocID=@TypeSocID, NrTVA=@NrTVA, Contact=@Contact, ContactTel=@ContactTel,
                                                           ContactEmail=@ContactEmail, Adresse=@Adresse, CodePostalID=@CodePostalID, FournTel=@FournTel, FournFax=@FournFax, FournMail=@FournMail,
                                                           FournRem=@FournRem
                                                       WHERE FournID=@FournID";

                  Param_O.Add("@FournNom");        Values_O.Add(TxtProviderName.Text);
                  Param_O.Add("@NumFournInterne"); Values_O.Add(TxtProviderNumber.Text);
                  Param_O.Add("@TypeSocID");       Values_O.Add((int)TypeSocID_UL);
                  Param_O.Add("@NrTVA");           Values_O.Add(TxtTVA.Text);
                  Param_O.Add("@Contact");         Values_O.Add(TxtContactName.Text);
                  Param_O.Add("@ContactTel");      Values_O.Add(TxtContactTel.Text);
                  Param_O.Add("@ContactEmail");    Values_O.Add(TxtContactMail.Text);
                  Param_O.Add("@Adresse");         Values_O.Add(TxtAdressFact.Text);
                  Param_O.Add("@CodePostalID");    Values_O.Add((int)CPFactID_UL);
                  Param_O.Add("@FournTel");        Values_O.Add(TxtTel.Text);
                  Param_O.Add("@FournFax");        Values_O.Add(TxtFax.Text);
                  Param_O.Add("@FournMail");       Values_O.Add(TxtMail.Text);
                  Param_O.Add("@FournRem");        Values_O.Add(TxtRem.Text);
                  Param_O.Add("@FournID");         Values_O.Add((int)ProviderID_UL);

                  mDBManager_O.ExecuteRequest(SqlCommand_O, Param_O, Values_O);

                  SetEditState(false);
                  DBListViewProvider.SetLockState(false);
                  DBListViewProvider.Refresh();
                  DBListViewProvider.SelectItemByID(ProviderID_UL);
               }
            }
         }
      }

      private void BtnCancelChanges_Click(object sender, EventArgs e)
      {
         if (mEditState_b)
         {
            DialogResult DlgRes_O = MessageBox.Show("Les modifications effectuées sur le fournisseur seront perdues, continuer ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (DlgRes_O == DialogResult.Yes)
            {
               SetEditState(false);
               DBListViewProvider.SetLockState(false);
               DBListViewProvider.SelectItemByID(DBListViewProvider.GetSelectedItemID());
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

             if (!LblProviderNumAndName.Text.Contains(" *"))
             {
                 LblProviderNumAndName.Text += " *";
             }
         }
         else
         {
             ControlStyle.SetFrameHeaderStyle(this.splitContainer2.Panel1);
             ControlStyle.SetFrameHeaderStyle(PanelCheckHeader);

             if (LblProviderNumAndName.Text.Contains(" *"))
             {
                 LblProviderNumAndName.Text = LblProviderNumAndName.Text.Remove(LblProviderNumAndName.Text.IndexOf(" *"), 2);
             }
         }
      }

      private void ValueChanged(object sender, EventArgs e)
      {
         if (DBListViewProvider.GetSelectedItemID() > 0 && !mInitializingData_b)
         {
            DBListViewProvider.SetLockState(true);
            SetEditState(true);
         }
      }
   }
}
