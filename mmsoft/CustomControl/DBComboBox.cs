using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MMSoft
{
   /// <summary>
   /// This class defines a combo box that will display the elements of a table in a database. The items of the list are defined by an id and a string value of a specified field in the table.
   /// </summary>
   class DBComboBox : ComboBox
   {
      public void FillList(DatabaseManager DBManager_O, String TableName_ST, String DBFieldID_ST, String DBField_ST, String Where_ST = "")
      {
         SqlDataReader SqlDataReader_O;
         DBComboBoxItem DBListBoxItem_O;
         String SQLRequest_ST;
         UInt32 ID_UL = 0;
         String Field_ST = "";

         if (DBManager_O != null && DBManager_O.mConnected_b && !String.IsNullOrEmpty(TableName_ST) && !String.IsNullOrEmpty(DBFieldID_ST) && !String.IsNullOrEmpty(DBField_ST))
         {
            this.Items.Clear();
            this.Text = null;

            SQLRequest_ST = "SELECT " + DBFieldID_ST + ", " + DBField_ST + " FROM " + TableName_ST;

            if (!String.IsNullOrEmpty(Where_ST))
               SQLRequest_ST += " WHERE " + Where_ST;

            SqlDataReader_O = DBManager_O.Select(SQLRequest_ST);

            while (SqlDataReader_O.Read())
            {
               UInt32.TryParse(SqlDataReader_O[DBFieldID_ST].ToString(), out ID_UL);
               Field_ST = SqlDataReader_O[DBField_ST].ToString();

               DBListBoxItem_O = new DBComboBoxItem(ID_UL, Field_ST);

               this.Items.Add(DBListBoxItem_O);
            }

            SqlDataReader_O.Close();
         }         
      }

      /// <summary>
      /// This methods selects an item in its combo box list given an ID present in a DBComboBoxItem.
      /// </summary>
      /// <param name="ID_i"></param>
      public void SelectItemByID(UInt32 ID_UL)
      {
         DBComboBoxItem CurrentItem_i;

         for(int i = 0; i < this.Items.Count; i++)
         {
            CurrentItem_i = (DBComboBoxItem)this.Items[i];

            if (CurrentItem_i.mID_UL == ID_UL)
            {
               this.SelectedItem = this.Items[i];
            }
         }
      }

      public void ClearSelectedItem()
      {
         this.SelectedItem = null;
      }

      public bool GetSelectedItemID(out UInt32 ID_UL)
      {
         bool Rts_b = false;
         DBComboBoxItem SelectedItem_O;
         ID_UL = 0;

         if (this.SelectedItem != null)
         {
            SelectedItem_O = (DBComboBoxItem)this.SelectedItem;
            ID_UL = SelectedItem_O.mID_UL;
            Rts_b = true;
         }

         return Rts_b;
      }

      class DBComboBoxItem
      {
         public UInt32 mID_UL;
         public String mValue_ST;

         public DBComboBoxItem(UInt32 ID_UL, String Value_ST)
         {
            mID_UL = ID_UL;
            mValue_ST = Value_ST;
         }

         public override string ToString()
         {
            return mValue_ST;
         }
      }
   }

   
}
