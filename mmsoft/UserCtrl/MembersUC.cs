using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MMSoft
{
   public partial class MembersUC : UserControl, IMMSoftUC
   {
      private Control mParentContainer_O;
      private DatabaseManager mDBManager_O;
      private DocumentManager mDocManager_O;
      private bool mEditState_b;
      private bool mInitializingData_b;
      private List<Control> Fields_O;
      private bool mUpdateDepartmentAssociation_b = false;

      [DllImport("user32.dll", SetLastError = true)]
      private static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

      private const uint WM_SYSKEYDOWN = 0x104;

      public MembersUC(DatabaseManager DBManager_O, DocumentManager DocManager_O)
      {
         mDBManager_O = DBManager_O;
         mDocManager_O = DocManager_O;

         mInitializingData_b = false;

         InitializeComponent();

         // Add btn tool tool strip list view
         this.DBListViewMembers.ListTitle = "Equipe Malcourant Mécanique";
         this.DBListViewMembers.AddToolStripBtn(this.ToolStripBtnAddMember);
         ToolStripUCMembersTools.Visible = false;
         ToolStripUCMembersTools.Renderer = new BorderlessToolStripRenderer();

         List<String> TableField_ST = new List<String>();
         List<String> ColumnHeaderName_ST = new List<String>();
         List<int> ColumnHeaderDefaultSize_i = new List<int>();
         List<HorizontalAlignment> TextAlign_O = new List<HorizontalAlignment>();

         TableField_ST.Add("PersNom");
         TableField_ST.Add("NumTel");
         TableField_ST.Add("PersID");

         ColumnHeaderName_ST.Add("Nom");
         ColumnHeaderName_ST.Add("Téléphone");

         ColumnHeaderDefaultSize_i.Add(200);
         ColumnHeaderDefaultSize_i.Add(200);

         TextAlign_O.Add(HorizontalAlignment.Left);
         TextAlign_O.Add(HorizontalAlignment.Left);

         DBListViewMembers.Initialize(mDBManager_O, "Pers", TableField_ST, 2, ColumnHeaderName_ST, ColumnHeaderDefaultSize_i, TextAlign_O);
         DBListViewMembers.SelectionChanged += new DBListView.SelectionChangedHandler(this.MemberClick);

         DBComboxStatus.FillList(mDBManager_O, "PersStatus", "PersStatutID", "PersStatutLib");
         ComBoxFamilyState.Items.Add("Célibataire");
         ComBoxFamilyState.Items.Add("Cohabitant");
         ComBoxFamilyState.Items.Add("Marié");
         ComboxPostalCode.FillList(mDBManager_O, "CodePostal", "CodePostalID", "CodePostal");
         ComboxLocality.FillList(mDBManager_O, "CodePostal", "CodePostalID", "Localite");

         // Put fields of DB in a list to be able to set their edit state in one loop
         Fields_O = new List<Control>();
         Fields_O.Add(DBComboxStatus);
         Fields_O.Add(DTPBirthdate);
         Fields_O.Add(TxtCost);
         Fields_O.Add(DTPEntryDate);
         Fields_O.Add(TxtBankAccount);
         Fields_O.Add(TxtRegNumber);
         Fields_O.Add(ComBoxFamilyState);
         Fields_O.Add(TxtChilds);
         Fields_O.Add(CheckBoxActivePartner);
         Fields_O.Add(TxtTel);
         Fields_O.Add(TxtAdress);
         Fields_O.Add(ComboxPostalCode);
         Fields_O.Add(ComboxLocality);

         SetEditState(false);

         // Define checking recap list view
         List<String> TableFieldCheckingRecap_ST = new List<String>();
         List<String> ColumnHeaderNameCheckingRecap_ST = new List<String>();
         List<int> ColumnHeaderDefaultSizeCheckingRecap_i = new List<int>();
         List<HorizontalAlignment> TextAlignCheckingRecap_O = new List<HorizontalAlignment>();

         // Define column DB fields
         TableFieldCheckingRecap_ST.Add("NumRefInterne");
         TableFieldCheckingRecap_ST.Add("ClientNom");
         TableFieldCheckingRecap_ST.Add("TypeTacheCod");
         TableFieldCheckingRecap_ST.Add("JobLib");
         TableFieldCheckingRecap_ST.Add("QteProd");
         TableFieldCheckingRecap_ST.Add("DelaiPromis");
         TableFieldCheckingRecap_ST.Add("DatePrest");
         TableFieldCheckingRecap_ST.Add("NbrH");
         TableFieldCheckingRecap_ST.Add("Rem");
         // Unshown elements
         TableFieldCheckingRecap_ST.Add("PointageID");

         // Define column headers text
         ColumnHeaderNameCheckingRecap_ST.Add("Num ref int");
         ColumnHeaderNameCheckingRecap_ST.Add("Client");
         ColumnHeaderNameCheckingRecap_ST.Add("Tâche");
         ColumnHeaderNameCheckingRecap_ST.Add("Job libellé");
         ColumnHeaderNameCheckingRecap_ST.Add("Qte prod");
         ColumnHeaderNameCheckingRecap_ST.Add("Délais promis");
         ColumnHeaderNameCheckingRecap_ST.Add("Date prest");
         ColumnHeaderNameCheckingRecap_ST.Add("Nbr H");
         ColumnHeaderNameCheckingRecap_ST.Add("Remarques");

         // size
         ColumnHeaderDefaultSizeCheckingRecap_i.Add(100);
         ColumnHeaderDefaultSizeCheckingRecap_i.Add(100);
         ColumnHeaderDefaultSizeCheckingRecap_i.Add(50);
         ColumnHeaderDefaultSizeCheckingRecap_i.Add(600);
         ColumnHeaderDefaultSizeCheckingRecap_i.Add(50);
         ColumnHeaderDefaultSizeCheckingRecap_i.Add(100);
         ColumnHeaderDefaultSizeCheckingRecap_i.Add(100);
         ColumnHeaderDefaultSizeCheckingRecap_i.Add(50);
         ColumnHeaderDefaultSizeCheckingRecap_i.Add(300);

         // alignment
         for (int i = 0; i < ColumnHeaderNameCheckingRecap_ST.Count; i++)
         {
            if (i == 2 || i == 4 || i == 7)
               TextAlignCheckingRecap_O.Add(HorizontalAlignment.Center);
            else
               TextAlignCheckingRecap_O.Add(HorizontalAlignment.Left);
         }

         MemberDayChickingViewer.Initialize(mDBManager_O, DateTime.Today, 0, true);

         DBListViewMembers.AllowMultipleSelecion = false;

         DepartmentSelector.Initialize(mDBManager_O);
         DepartmentSelector.DepartmentsModified += new DepartmentSelector.DepartmentsModifiedHandler(this.ValueChanged);

         ToolStripMemberDocuments.Renderer = new BorderlessToolStripRenderer();

         ControlStyle.SetBackgroundStyle(this);
         ControlStyle.SetBackgroundStyle(ToolStripUCMembersTools);
         ControlStyle.SetFrameHeaderStyle(this.PanelMembersList);
         ControlStyle.SetFrameHeaderStyle(this.PanelCheckHeader);
         ControlStyle.SetFrameStyle(this.PanelCheckContent);
         ControlStyle.SetFrameHeaderStyle(this.splitContainer2.Panel2);
         ControlStyle.SetFrameHeaderStyle(this.splitContainer2.Panel1);
         ControlStyle.SetFrameStyle(this.PanelCheckContent);
         ControlStyle.SetFrameStyle(this.ToolStripMemberEditFooter);
         ControlStyle.SetFrameStyle(this.DepartmentSelector);
         ControlStyle.SetFrameStyle(this.ToolStripMemberDocuments);
      }

      public bool Activate(Control Container_O)
      {
         mParentContainer_O = Container_O;
         mParentContainer_O.Controls.Add(this);
         this.BringToFront();
         this.Dock = DockStyle.Fill;

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
            MessageBox.Show("Impossible d'ouvrir le module sélectionné car un membre de l'équipe est en cours d'édition. Veuillez enregistrer ou annuler vos modifications avant de continuer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Rts_b = false;
         }

         return Rts_b;
      }

      private void MemberClick(UInt32 MemberID_UL)
      {
         // Load client info in each control
         String SQLRequest_ST;
         SqlDataReader SqlDataReader_O;
         UInt32 CPID_UL = 0;
         UInt32 PersStatusID_UL = 0;

         mInitializingData_b = true;

         TxtTel.Clear();
         DTPBirthdate.Value = DTPBirthdate.MinDate;
         DTPEntryDate.Value = DTPEntryDate.MinDate;

         TxtCost.Clear();
         TxtBankAccount.Clear();
         TxtRegNumber.Clear();
         TxtChilds.Clear();
         TxtAdress.Clear();
         ComBoxFamilyState.SelectedItem = null;
         CheckBoxActivePartner.Checked = false;
         DBComboxStatus.ClearSelectedItem();
         ComboxPostalCode.ClearSelectedItem();
         ComboxLocality.ClearSelectedItem();
         LblMemberName.Text = "";
         CheckBoxActivePartner.Checked = false;
         DepartmentSelector.Clear();
         MemberDayChickingViewer.ChangePers(0, true);
         TxtLogin.Clear();

         bool ActivePartner_b = false;

         if (mDBManager_O != null && mDBManager_O.mConnected_b)
         {
            // Fill fields of member
            SQLRequest_ST = "SELECT * FROM Pers WHERE PersID=" + MemberID_UL;
            SqlDataReader_O = mDBManager_O.Select(SQLRequest_ST);

            while (SqlDataReader_O.Read())
            {
               bool.TryParse(SqlDataReader_O["ConjActif"].ToString(), out ActivePartner_b);

               // Fill info in panel edit controls
               TxtTel.Text = SqlDataReader_O["NumTel"].ToString();
               try 
               { 
                  DTPBirthdate.Value = Convert.ToDateTime(SqlDataReader_O["DateNaissance"].ToString());
               }
               catch(FormatException e)
               {
                  DTPBirthdate.Value = DTPBirthdate.MinDate;
               }

               try
               {
                  DTPEntryDate.Value = Convert.ToDateTime(SqlDataReader_O["DateEntreeService"].ToString());
               }
               catch (FormatException e)
               {
                  DTPEntryDate.Value = DTPEntryDate.MinDate;
               }
               
               TxtCost.Text = SqlDataReader_O["CoutHeure"].ToString() + "\u20AC";
               TxtBankAccount.Text = SqlDataReader_O["CompteBanq"].ToString();
               TxtRegNumber.Text = SqlDataReader_O["NumRegNat"].ToString();
               TxtChilds.Text = SqlDataReader_O["NbrEnfCharge"].ToString();
               TxtAdress.Text = SqlDataReader_O["Adresse"].ToString();
               ComBoxFamilyState.Text = SqlDataReader_O["SitFam"].ToString();
               TxtLogin.Text = SqlDataReader_O["UserLogin"].ToString();

               CheckBoxActivePartner.Checked = ActivePartner_b;

               if (UInt32.TryParse(SqlDataReader_O["PersStatutID"].ToString(), out PersStatusID_UL))
                  DBComboxStatus.SelectItemByID(PersStatusID_UL);
               if (UInt32.TryParse(SqlDataReader_O["CodePostalID"].ToString(), out CPID_UL))
               {
                  ComboxPostalCode.SelectItemByID(CPID_UL);
                  ComboxLocality.SelectItemByID(CPID_UL);
               }
               else
               {
                  ComboxPostalCode.ClearSelectedItem();
                  ComboxLocality.ClearSelectedItem();
               }

               // Fill info in panel check controls
               LblMemberName.Text = SqlDataReader_O["PersNom"].ToString();

               CheckBoxActivePartner.Checked = ActivePartner_b;

               // Refresh checking recap
               //int NbDays = DateTime.Today.DayOfWeek - DayOfWeek.Monday;
               if (!String.IsNullOrEmpty(SqlDataReader_O["PersNom"].ToString()))
               {
                  MemberDayChickingViewer.ChangePers(MemberID_UL, true);
               }
            }

            SqlDataReader_O.Close();

            // Fill associated departments
            SQLRequest_ST = "SELECT DepID FROM RelDepPers WHERE PersID=" + MemberID_UL;
            SqlDataReader_O = mDBManager_O.Select(SQLRequest_ST);
            List<UInt32> DepID_UL = new List<UInt32>();
            UInt32 ID_UL;

            while (SqlDataReader_O.Read())
            {
               if (UInt32.TryParse(SqlDataReader_O["DepID"].ToString(), out ID_UL))
                  DepID_UL.Add(ID_UL);
            }

            DepartmentSelector.CheckDepartments(DepID_UL);

            SqlDataReader_O.Close();
         }

         mInitializingData_b = false;
      }

      private void SetEditState(bool EditState_b)
      {
         mEditState_b = EditState_b;
         ToolStripBtnSaveChanges.Visible = EditState_b;
         ToolStripBtnCancelChanges.Visible = EditState_b; 
      }

      private void BtnCancelChanges_Click(object sender, EventArgs e)
      {
         if (mEditState_b)
         {
            DialogResult DlgRes_O = MessageBox.Show("Les modifications effectuées sur le membre du personnel seront perdues, continuer ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (DlgRes_O == DialogResult.Yes)
            {
               SetEditState(false);
               DBListViewMembers.SetLockState(false);
               mUpdateDepartmentAssociation_b = false;
            }            
         }
      }

      private void BtnSaveChanges_Click(object sender, EventArgs e)
      {
         String SqlCommand_st;
         List<String> Param_O = new List<String>();
         List<Object> Values_O = new List<Object>();

         if (mEditState_b)
         {
            UInt32 MemberID_UL = DBListViewMembers.GetSelectedItemID();

            //Build update request
            if (mDBManager_O != null && mDBManager_O.mConnected_b)
            {
               // Update member field
               SqlCommand_st = @"UPDATE Pers 
                                 SET  PersStatutID = @PersStatutID, DateNaissance = @DateNaissance, NumRegNat = @NumRegNat, 
                                                             NumTel = @NumTel, Adresse = @Adresse, SitFam = @SitFam, CodePostalID = @CodePostalID, 
                                                             NbrEnfCharge = @NbrEnfCharge, ConjActif = @ConjActif, DateEntreeService = @DateEntreeService, 
                                                             CompteBanq = @CompteBanq, CoutHeure = @CoutHeure, UserLogin = @UserLogin 
                                 WHERE PersID=@PersID";

               UInt32 PersStatusID_UL = 0, CPID_UL = 0;
               String CoutHeure_ST;
               float CoutHeure_f = 0.0f;
               DBComboxStatus.GetSelectedItemID(out PersStatusID_UL);
               ComboxPostalCode.GetSelectedItemID(out CPID_UL);
               CoutHeure_ST = TxtCost.Text.Trim('\u20AC');
               CoutHeure_ST = CoutHeure_ST.Trim();
               float.TryParse(CoutHeure_ST, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out CoutHeure_f);

               Param_O.Add("@PersID");                Values_O.Add((int)DBListViewMembers.GetSelectedItemID());
               Param_O.Add("@PersStatutID");          Values_O.Add((int)PersStatusID_UL);
               Param_O.Add("@DateNaissance");         Values_O.Add(DTPBirthdate.Value);
               Param_O.Add("@NumRegNat");             Values_O.Add(TxtRegNumber.Text);
               Param_O.Add("@NumTel");                Values_O.Add(TxtTel.Text);
               Param_O.Add("@Adresse");               Values_O.Add(TxtAdress.Text);
               Param_O.Add("@SitFam");                Values_O.Add(ComBoxFamilyState.Text);
               Param_O.Add("@CodePostalID");          Values_O.Add((int)CPID_UL);
               Param_O.Add("@NbrEnfCharge");          Values_O.Add(TxtChilds.Text);
               Param_O.Add("@ConjActif");             Values_O.Add(CheckBoxActivePartner.Checked);
               Param_O.Add("@DateEntreeService");     Values_O.Add(DTPEntryDate.Value);
               Param_O.Add("@CompteBanq");            Values_O.Add(TxtBankAccount.Text);
               Param_O.Add("@CoutHeure");             Values_O.Add(CoutHeure_f);
               Param_O.Add("@UserLogin");             Values_O.Add(TxtLogin.Text);

               mDBManager_O.ExecuteRequest(SqlCommand_st, Param_O, Values_O);
               Param_O.Clear();
               Values_O.Clear();

               // Update member's department associations               

               if (mUpdateDepartmentAssociation_b)
               {
                  // Remove all association
                  SqlCommand_st = @"DELETE FROM RelDepPers WHERE PersID=@PersID";
                  Param_O.Add("@PersID"); Values_O.Add((int)DBListViewMembers.GetSelectedItemID());
                  mDBManager_O.ExecuteRequest(SqlCommand_st, Param_O, Values_O);
                  Param_O.Clear();
                  Values_O.Clear();

                  // Add them back plus new ones
                  List<UInt32> IdList_UL = DepartmentSelector.GetSelectedDepartmentsID();

                  for (int i = 0; i < IdList_UL.Count; i++)
                  {
                     SqlCommand_st = @"INSERT INTO RelDepPers(DepID, PersID) VALUES (@DepID, @PersID)";
                     Param_O.Add("@DepID"); Values_O.Add((int)IdList_UL[i]);
                     Param_O.Add("@PersID"); Values_O.Add((int)DBListViewMembers.GetSelectedItemID());
                     mDBManager_O.ExecuteRequest(SqlCommand_st, Param_O, Values_O);
                     Param_O.Clear();
                     Values_O.Clear();
                  }

                  mUpdateDepartmentAssociation_b = false;
               }
            }

            SetEditState(false);
            DBListViewMembers.SetLockState(false);
            DBListViewMembers.Refresh();
            DBListViewMembers.SelectItemByID(MemberID_UL);
         }
      }

      private void ComboxPostalCode_SelectedIndexChanged(object sender, EventArgs e)
      {
         UInt32 PCID_UL = 0;
         ComboxPostalCode.GetSelectedItemID(out PCID_UL);

         if (PCID_UL > 0)
            ComboxLocality.SelectItemByID(PCID_UL);

         ValueChanged(this, EventArgs.Empty);
      }

      private void ComboxLocality_SelectedIndexChanged(object sender, EventArgs e)
      {
         UInt32 LocalityID_UL = 0;
         ComboxLocality.GetSelectedItemID(out LocalityID_UL);

         if (LocalityID_UL > 0)
            ComboxPostalCode.SelectItemByID(LocalityID_UL);

         ValueChanged(this, EventArgs.Empty);
      }

      private void ValueChanged(object sender, EventArgs e)
      {
         if (DBListViewMembers.GetSelectedItemID() > 0 && !mInitializingData_b)
         {
            DBListViewMembers.SetLockState(true);
            SetEditState(true);

            if (sender.GetType() == typeof(DepartmentSelector))
               mUpdateDepartmentAssociation_b = true;
         }
      }

      private void ToolStripBtnMemberDayCheckings_Click(object sender, EventArgs e)
      {
         if (DBListViewMembers.GetSelectedItemID() > 0)
         {
            mDocManager_O.ShowMemberDayCheckingsDocument(DBListViewMembers.GetSelectedItemID());
         }
      }

      private void ToolStripBtnAddMember_Click(object sender, EventArgs e)
      {
         FormAskString FormAskString_O = new FormAskString("Nom et prénom du nouveau membre :");
         DialogResult DlgRes_O = FormAskString_O.ShowDialog();

         if (DlgRes_O == DialogResult.OK)
         {
            if (!String.IsNullOrEmpty(FormAskString_O.mEnteredString_ST))
            {
               if (mDBManager_O != null && mDBManager_O.mConnected_b)
               {
                  mDBManager_O.mStoredProcedureManager_O.STPROC_CreatePers(FormAskString_O.mEnteredString_ST);
                  DBListViewMembers.Refresh();
               }
            }
            else
            {
               MessageBox.Show("Impossible d'ajouter un nouveau membre avec un nom vide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
      }

      private void BtnResetPwd_Click(object sender, EventArgs e)
      {
         String SqlCommand_st;
         List<String> Param_O = new List<String>();
         List<Object> Values_O = new List<Object>();

         //Build update request
         if (mDBManager_O != null && mDBManager_O.mConnected_b)
         {
            // Update member field
            SqlCommand_st = @"UPDATE Pers SET  Pwd = @Pwd WHERE PersID=@PersID";

            Param_O.Add("@PersID"); Values_O.Add((int)DBListViewMembers.GetSelectedItemID());
            Param_O.Add("@Pwd"); Values_O.Add("1111");

            if (mDBManager_O.ExecuteRequest(SqlCommand_st, Param_O, Values_O))
            {
               MessageBox.Show("Le mot de passe de l'utilisateur à été réinitialisé à la valeur '1111'", "Succès !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         }
      }
   }
}
