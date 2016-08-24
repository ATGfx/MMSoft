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
   public partial class DepartmentSelector : UserControl
   {
      private DatabaseManager mDBManager_O;
      private List<CheckBox> mDepartmentCheckbox_O = new List<CheckBox>();

      public delegate void DepartmentsModifiedHandler(object sender, EventArgs e);
      public event DepartmentsModifiedHandler DepartmentsModified; 

      public DepartmentSelector()
      {
         InitializeComponent();

         mDBManager_O = null;
      }

      /// <summary>
      /// Method that initialize the user control (it display some lines with a slected department)
      /// </summary>
      public void Initialize(DatabaseManager DBManager_O, List<UInt32> SelectedItem_UL = null)
      {
         mDBManager_O = DBManager_O;

         SqlDataReader SqlDataReader_O;
         String SQLRequest_O;

         if (mDBManager_O != null && mDBManager_O.mConnected_b)
         {
            SQLRequest_O = "SELECT * FROM TypeDep";
            SqlDataReader_O = mDBManager_O.Select(SQLRequest_O);

            while (SqlDataReader_O.Read())
            {
               UInt32 DepID_UL;

               if (UInt32.TryParse(SqlDataReader_O["TypeDepID"].ToString(), out DepID_UL))
               {
                  CheckBox Checkbox_O = new CheckBox();
                  Checkbox_O.AutoSize = true;
                  Checkbox_O.Text = SqlDataReader_O["TypeDepLib"].ToString();
                  Checkbox_O.Tag = DepID_UL;
                  Checkbox_O.Checked = (SelectedItem_UL != null && SelectedItem_UL.Contains(DepID_UL));
                  Checkbox_O.CheckedChanged += new EventHandler(this.DepartmentCheckedChanged);
                  FlowLayoutPanel.Controls.Add(Checkbox_O);
                  mDepartmentCheckbox_O.Add(Checkbox_O);
               }
            }

            SqlDataReader_O.Close();
         }
      }

      public void CheckDepartments(List<UInt32> CheckID_UL)
      {
         for (int i = 0; i < mDepartmentCheckbox_O.Count; i++)
         {
            mDepartmentCheckbox_O[i].Checked = CheckID_UL.Contains((UInt32)mDepartmentCheckbox_O[i].Tag);
         }
      }

      public void Clear()
      {
         for (int i = 0; i < mDepartmentCheckbox_O.Count; i++)
         {
            mDepartmentCheckbox_O[i].Checked = false;
         }
      }

      private void DepartmentCheckedChanged(object sender, EventArgs e)
      {
         DepartmentsModified(this, e);
      }

      public List<UInt32> GetSelectedDepartmentsID()
      {
         List<UInt32> SelectedDepartmentID_O = new List<UInt32>();

         for (int i = 0; i < mDepartmentCheckbox_O.Count; i++)
         {
            if (mDepartmentCheckbox_O[i].Checked)
            {
               SelectedDepartmentID_O.Add((UInt32)mDepartmentCheckbox_O[i].Tag);
            }
         }

         return SelectedDepartmentID_O;
      }
      

   }
}
