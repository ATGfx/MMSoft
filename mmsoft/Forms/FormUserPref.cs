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
   public partial class FormUserPref : Form
   {
      DatabaseManager mDBManager_O;
      UInt32 mPersID_UL;

      public FormUserPref()
      {
         InitializeComponent();

         this.CenterToScreen();

         this.ToolStripValidatePref.Renderer = new BorderlessToolStripRenderer();

         ControlStyle.SetBackgroundColorFocusStyle(this);
         ControlStyle.SetFrameStyle(this.PanelUserPref);
         ControlStyle.SetFrameHeaderStyle(this.PanelFormHeader);
         ControlStyle.SetFrameHeaderStyle(this.ToolStripValidatePref);
      }

      public void Initialize(DatabaseManager DBManager_O, UInt32 PersID_UL)
      {
         mDBManager_O = DBManager_O;
         mPersID_UL = PersID_UL;
         String Where_ST = "PersID=" + mPersID_UL;

         if (mDBManager_O.mConnected_b)
         {
            TxtLogin.Text = mDBManager_O.GetTableField("Pers", "UserLogin", Where_ST);
            TxtPwd.Text = mDBManager_O.GetTableField("Pers", "Pwd", Where_ST);
            TxtConfirmPwd.Text = mDBManager_O.GetTableField("Pers", "Pwd", Where_ST);
            DBComboxPrefDep.FillList(DBManager_O, "TypeDep", "TypeDepID", "TypeDepLib");
            DBComboxPrefHall.FillList(DBManager_O, "Hall", "HallID", "HallName");

            // Get user prefered dep and hall
            UInt32 PrefDep_UL = 0;
            UInt32 PrefHall_UL = 0;
            UInt32.TryParse(DBManager_O.GetTableField("Pers", "PrefDepID", Where_ST), out PrefDep_UL);
            UInt32.TryParse(DBManager_O.GetTableField("Pers", "PrefHallID", Where_ST), out PrefHall_UL);

            // If prefered dep and hall found, select it in dep combo box
            if (PrefDep_UL > 0)
               DBComboxPrefDep.SelectItemByID(PrefDep_UL);
            if (PrefHall_UL > 0)
            {
               DBComboxPrefHall.SelectItemByID(PrefHall_UL);
            }
         }
      }

      private void ToolStripButtonCancel_Click(object sender, EventArgs e)
      {
         this.Dispose();
      }

      private void ToolStripBtnValidate_Click(object sender, EventArgs e)
      {
         bool LoginOK_b = false;
         bool PwdOK_b = false;
         bool PrefHallOK_b = false;
         bool PrefDepOK_b = false;
         UInt32 PrefHallID_UL, PrefDepID_UL;
         
         if (mDBManager_O.mConnected_b)
         {
            // Check user login
            LoginOK_b = !String.IsNullOrEmpty(TxtLogin.Text);
            if (!LoginOK_b)
            {
               MessageBox.Show("Votre login ne peut être vide.", "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Check password
            PwdOK_b = !String.IsNullOrEmpty(TxtPwd.Text) && !String.IsNullOrEmpty(TxtConfirmPwd.Text);
            if (!PwdOK_b)
            {
               MessageBox.Show("Votre mot de passe ne peut être vide.", "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
               PwdOK_b = TxtConfirmPwd.Text.Equals(TxtPwd.Text);
               if (!PwdOK_b)
               {
                  MessageBox.Show("Votre mot de passe et sa confirmation ne sont pas identiques.", "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
            }

            // Check pref hall
            DBComboxPrefHall.GetSelectedItemID(out PrefHallID_UL);
            PrefHallOK_b = (PrefHallID_UL > 0);
            if (!PrefHallOK_b)
            {
               MessageBox.Show("Le hall préféré sélectionné n'est pas valide.", "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Check pref dep
            DBComboxPrefDep.GetSelectedItemID(out PrefDepID_UL);
            PrefDepOK_b = (PrefDepID_UL > 0);
            if (!PrefDepOK_b)
            {
               MessageBox.Show("Le département préféré sélectionné n'est pas valide.", "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (LoginOK_b && PwdOK_b && PrefHallOK_b && PrefDepOK_b)
            {
               List<String> Param_O = new List<String>();
               List<Object> Values_O = new List<Object>();

               String SQLCommand_st = @"UPDATE Pers SET UserLogin=@UserLogin, Pwd=@Pwd, PrefHallID=@PrefHallID, PrefDepID=@PrefDepID
                                       WHERE PersID=@PersID";

               Param_O.Add("@UserLogin");    
               Param_O.Add("@Pwd");          
               Param_O.Add("@PrefHallID");   
               Param_O.Add("@PrefDepID");    
               Param_O.Add("@PersID");

               Values_O.Add(TxtLogin.Text);
               Values_O.Add(TxtPwd.Text);
               Values_O.Add((int)PrefHallID_UL);
               Values_O.Add((int)PrefDepID_UL);
               Values_O.Add((int)mPersID_UL);

               mDBManager_O.ExecuteRequest(SQLCommand_st, Param_O, Values_O);  

               this.Dispose();
            }

         }
      }
   }
}
