using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace MMSoft
{
   public partial class DBListView : UserControl
   {
      private DatabaseManager mDBManager_O;
      internal CustomListView mListView_O;
      private String mTableName_ST;
      private List<String> mTableFields_ST;
      private List<String> mColumnHeaderName_ST;
      private List<TextBox> mFilterTextBox_O;
      private int mLastClickedFilterIndex_i;
      private String mLastSQLRequest_st;
      private bool Asc_b;
      private UInt32 mDBIDIndex_UL;
      private bool mLocked_b;
      private ListViewItem mListViewItem_O;
      private UInt32 mSelectedItemID_UL = 0;
      private String mInitialWhere_ST;
      private String mInitialOrderBy_ST;
      private int mFilterPadding_i = 1;
      private readonly int MinColumnWidth_i = 20;

      public bool mInitialized_b = false;

      public delegate void SelectionChangedHandler(UInt32 ItemID_UL);
      public event SelectionChangedHandler SelectionChanged;

      public delegate void ItemDoubleClickedHandler(UInt32 ItemID_UL);
      public event ItemDoubleClickedHandler ItemDoubleClicked;

      public delegate void ItemClickedHandler(UInt32 ItemID_UL, MouseEventArgs e);
      public event ItemClickedHandler ItemClicked;

      public delegate void ListRefreshedHandler();
      public event ListRefreshedHandler ListRefreshed;

      public bool AllowMultipleSelecion
      {
         get { return mListView_O.MultiSelect; }
         set { mListView_O.MultiSelect = value;}
      }

      public String ListTitle
      {
         get { return ToolStripLblListViewName.Text; }
         set { ToolStripLblListViewName.Text = value; }
      }

      public DBListView()
      {
         InitializeComponent();
         mLocked_b = false;
         mListViewItem_O = null;
         mListView_O = new CustomListView();
         AllowMultipleSelecion = false;
      }

      public bool IsLocked()
      {
         return mLocked_b;
      }

      public void SelectFirst()
      {
         if (mListView_O.Items.Count > 0)
         {
            mListView_O.Items[0].Selected = true;
         }
      }

      public void Initialize(DatabaseManager DBManager_O, String TableName_ST, List<String> TableFields_ST, UInt32 DBIDIndex_UL, List<String> ColumnHeaderName_ST,
                             List<int> ColumnHeaderDefaultSize_O, List<HorizontalAlignment> TextAlig_O, String InitialWhere_ST = null, String OrderBy_ST = null, bool InitList_b = true)
      {
         mDBManager_O = DBManager_O;
         mDBIDIndex_UL = DBIDIndex_UL;
         mTableFields_ST = TableFields_ST;
         mTableName_ST = TableName_ST;
         mColumnHeaderName_ST = ColumnHeaderName_ST;
         mLastClickedFilterIndex_i = -1;
         Asc_b = true;
         mLastSQLRequest_st = "";
         mInitialWhere_ST = InitialWhere_ST;
         mInitialOrderBy_ST = OrderBy_ST;

         mListView_O.View = View.Details;
         mListView_O.FullRowSelect = true;
         PanelListView.Controls.Add(mListView_O);
         mListView_O.BringToFront();
         mListView_O.Dock = DockStyle.Fill;
         mListView_O.ColumnClick += new ColumnClickEventHandler(this.ColumnClick);
         mListView_O.ColumnWidthChanging += new ColumnWidthChangingEventHandler(this.ColumnWidthChanging);
         mListView_O.ColumnWidthChanged += new ColumnWidthChangedEventHandler(this.ColumnWidthChanged);
         mListView_O.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(this.ListViewItemSelectionChanged);
         mListView_O.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MouseDoubleClick);
         mListView_O.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick);

         // Define column headers objects
         List<ColumnHeader> ColumnHeaders_O = new List<ColumnHeader>();
         mFilterTextBox_O = new List<TextBox>();

         for (int i = 0; i < mColumnHeaderName_ST.Count; i++)
         {
            // Define column header
            ColumnHeaders_O.Add(new ColumnHeader());
            ColumnHeaders_O[i].Name = mTableFields_ST[i];
            ColumnHeaders_O[i].Text = mColumnHeaderName_ST[i];
            ColumnHeaders_O[i].TextAlign = TextAlig_O[i];
            ColumnHeaders_O[i].Width = ColumnHeaderDefaultSize_O[i];

            // Add it to list view
            mListView_O.Columns.Add(ColumnHeaders_O[i]);

            // Define filter text box
            mFilterTextBox_O.Add(new TextBox());
            PanelFilter.Controls.Add(mFilterTextBox_O[i]);
            mFilterTextBox_O[i].TabIndex = i;
            mFilterTextBox_O[i].Tag = i;
            mFilterTextBox_O[i].TextChanged += new System.EventHandler(this.FilterTextChanged);
            mFilterTextBox_O[i].Width = ColumnHeaders_O[i].Width - 2 * mFilterPadding_i; // cannot control height of textbox ! so it is set to 20 and filter panel is 22 to get a padding of 1 pixel
            mFilterTextBox_O[i].Location = new Point((i == 0) ? mFilterPadding_i : mFilterTextBox_O[i - 1].Location.X + mFilterTextBox_O[i - 1].Width + 2 * mFilterPadding_i, mFilterPadding_i);
            mFilterTextBox_O[i].BorderStyle = BorderStyle.FixedSingle;
            mFilterTextBox_O[i].BackColor = Color.Gainsboro;
         }

         ControlStyle.SetFrameHeaderStyle(MainToolStrip);
         MainToolStrip.Renderer = new BorderlessToolStripRenderer();
         ControlStyle.SetFrameStyle(this);
         ControlStyle.SetFrameStyle(PanelListView);
         ControlStyle.SetFrameStyle(PanelFilter);

         if (InitList_b)
            this.Refresh();

         mInitialized_b = true;

         SelectFirst();
      }

      private void FilterTextChanged(object sender, EventArgs e)
      {
         mLastClickedFilterIndex_i = -1;
         this.Refresh();
      }

      public void Refresh()
      {
         // TODO : this method may take a little time and optimization by refreshing only selected job could be considered
         SqlDataReader SqlDataReader_O;
         ListViewItem ListViewItem_O;
         String SQLRequest_O;

         // Clear list before continuing, otherwise list will only grow with new items
         mListView_O.Items.Clear();

         if (mDBManager_O != null && mDBManager_O.mConnected_b)
         {
            SQLRequest_O = "SELECT ";

            for (int i = 0; i < mTableFields_ST.Count; i++)
            {
               SQLRequest_O += mTableFields_ST[i];

               if (i != mTableFields_ST.Count - 1)
                  SQLRequest_O += ",";
            }

            SQLRequest_O += " FROM " + mTableName_ST;

            if (!String.IsNullOrEmpty(mInitialWhere_ST))
               SQLRequest_O += " WHERE " + mInitialWhere_ST;

            SQLRequest_O += " " + BuildWhereFromFilter();
            SQLRequest_O += " " + BuildOrderByFromFilter();

            SqlDataReader_O = mDBManager_O.Select(SQLRequest_O);
            mLastSQLRequest_st = SQLRequest_O;

            if (SqlDataReader_O != null)
            {
               while (SqlDataReader_O.Read())
               {
                  ListViewItem_O = new ListViewItem();
                  ListViewItem_O.SubItems[0].Text = SqlDataReader_O[mTableFields_ST[0]].ToString();
                  ListViewItem_O.SubItems[0].Name = mTableFields_ST[0];

                  for (int i = 1; i < mTableFields_ST.Count; i++)
                  {
                     // If type of data is date, take only 10 first char to avoid time
                      if ((SqlDataReader_O.GetFieldType(SqlDataReader_O.GetOrdinal(mTableFields_ST[i])) == typeof(DateTime)) &&
                          !String.IsNullOrEmpty(SqlDataReader_O[mTableFields_ST[i]].ToString()))
                      {
                        DateTime Date_O = Convert.ToDateTime(SqlDataReader_O[mTableFields_ST[i]].ToString());
                        ListViewItem_O.SubItems.Add(Date_O.ToShortDateString());
                      }
                      else
                          ListViewItem_O.SubItems.Add(SqlDataReader_O[mTableFields_ST[i]].ToString());

                     ListViewItem_O.SubItems[i].Name = mTableFields_ST[i];
                  }

                  mListView_O.Items.Add(ListViewItem_O);
               }

               SqlDataReader_O.Close();

               if (ListRefreshed != null)
                  ListRefreshed();
            }
         }

         if (mListView_O.Items.Count > 0)
         {
            SelectFirst();
         }
         else
         {
            // Throw event as if non existing item with ID 0 was selected, such that UC can understand that no item is selected
            // because .net do not fires selected index changed when nothing is selected
            if (SelectionChanged != null)
            {
               SelectionChanged(0);
            }
         }
      }

      private String BuildWhereFromFilter()
      {
         String Where_st = "";
         int ConditionsFound_i = 0;

         for (int i = 0; i < mFilterTextBox_O.Count; i++)
         {
            if (!String.IsNullOrEmpty(mFilterTextBox_O[i].Text))
            {
               Where_st += "AND " + mTableFields_ST[i] + " LIKE '%" + mFilterTextBox_O[i].Text + "%'";
               ConditionsFound_i++;
            }
         }

         // if at least 1 coindition is set in filter, deleta first "AND " in constructed string
         if (ConditionsFound_i > 0)
         {
            if (String.IsNullOrEmpty(mInitialWhere_ST))
               Where_st = "WHERE " + Where_st.Substring(4);
         }

         return Where_st;
      }

      private String BuildOrderByFromFilter()
      {
         String OrderBy_st = "";

         if (mLastClickedFilterIndex_i > -1)
         {
            OrderBy_st = "ORDER BY " + mTableFields_ST[mLastClickedFilterIndex_i] + (Asc_b ? " ASC" : " DESC");
         }
         else if (!String.IsNullOrEmpty(mInitialOrderBy_ST))
         {
            OrderBy_st = "ORDER BY " + mInitialOrderBy_ST;
         }

         return OrderBy_st;
      }

      private void ColumnClick(object sender, ColumnClickEventArgs e)
      {
         if (!mLocked_b)
         {
            if (e.Column == mLastClickedFilterIndex_i)
               Asc_b = !Asc_b;
            else
            {
               mLastClickedFilterIndex_i = e.Column;
               Asc_b = true;
            }

            this.Refresh();
         }
      }

      private void ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
      {
         RefreshFilterTxt(false);
      }

      private void ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
      {
         if (mListView_O.Columns[e.ColumnIndex].Width < MinColumnWidth_i)
         {
            mListView_O.Columns[e.ColumnIndex].Width = MinColumnWidth_i;
         }

         RefreshFilterTxt(false);
      }

      public void RefreshFilterTxt(bool ClearTextBox_b)
      {
         mFilterTextBox_O[0].Width = this.mListView_O.Columns[0].Width - 2 * mFilterPadding_i;
         mFilterTextBox_O[0].Location = new Point(mFilterPadding_i, mFilterPadding_i);

         if (ClearTextBox_b)
            mFilterTextBox_O[0].Text = "";

         for (int i = 1; i < mFilterTextBox_O.Count; i++)
         {
            mFilterTextBox_O[i].Width = this.mListView_O.Columns[i].Width - 2 * mFilterPadding_i;
            mFilterTextBox_O[i].Location = new Point(mFilterTextBox_O[i - 1].Location.X + mFilterTextBox_O[i - 1].Width + 2 * mFilterPadding_i, mFilterPadding_i);

            if (ClearTextBox_b)
               mFilterTextBox_O[i].Text = "";
         }
      }

      private void ListViewItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
      {
         if (e.IsSelected)
         {
            UInt32 ID_UL = GetSelectedItemID();

            // throw event with last selected item
            if (!mLocked_b && ID_UL != 0 && SelectionChanged != null)
            {
               mSelectedItemID_UL = ID_UL;
               SelectionChanged(ID_UL);
            }
            else if (mLocked_b && mListView_O.SelectedItems != null && mListView_O.SelectedItems.Count > 0)
            {
               mListView_O.SelectedItems[0].Selected = false;
            }
         }
      }

      private void MouseDoubleClick(object sender, MouseEventArgs e)
      {
         UInt32 ID_UL = GetSelectedItemID();

         if (!mLocked_b &&  ID_UL != 0 && ItemDoubleClicked != null)
         {
            mSelectedItemID_UL = ID_UL;
            ItemDoubleClicked(ID_UL);
         }
         else if (mLocked_b && mListView_O.SelectedItems != null && mListView_O.SelectedItems.Count > 0)
         {
            mListView_O.SelectedItems[0].Selected = false;
         }
      }

      private void MouseClick(object sender, MouseEventArgs e)
      {
         if (ItemClicked != null)
         {
            ItemClicked(GetSelectedItemID(), e);
         }
      }

      /// <summary>
      /// Returns the current selected ID. If nothing is selected, 0 is returned.
      /// </summary>
      /// <returns></returns>
      public UInt32 GetSelectedItemID()
      {
         int Index_i = -1;

         if (!mLocked_b && mListView_O.SelectedIndices.Count > 0 && mDBIDIndex_UL >= 0)
         {
            Index_i = this.mListView_O.SelectedIndices[0];

            if (!String.IsNullOrEmpty(mListView_O.Items[Index_i].SubItems[(int)mDBIDIndex_UL].Text))
            {
               mSelectedItemID_UL = Convert.ToUInt32(mListView_O.Items[Index_i].SubItems[(int)mDBIDIndex_UL].Text); // Assuming that an ID return by DB cannot be non parsable
            }
            else
            {
               // This case can arise because a listview always have an empty item in its list (don't know why...)
               // In this case we set the selected item id to 0 such that the caller can know that there is an error whenthis function returns
               mSelectedItemID_UL = 0;
            }
         }

         return mSelectedItemID_UL;
      }

      public List<UInt32> GetSelectedItemsID()
      {
         int Index_i = -1;
         List<UInt32> ItemID_O = new List<UInt32>();

         if (!mLocked_b && mListView_O.SelectedIndices.Count > 0 && mDBIDIndex_UL >= 0)
         {
            for (int i = 0; i < mListView_O.SelectedIndices.Count; i++)
            {
               Index_i = this.mListView_O.SelectedIndices[i];
               ItemID_O.Add(Convert.ToUInt32(mListView_O.Items[Index_i].SubItems[(int)mDBIDIndex_UL].Text)); // Assuming that an ID return by DB cannot be non parsable
            }
         }
         else if (mLocked_b)
            ItemID_O.Add(mSelectedItemID_UL);

         return ItemID_O;
      }

      public void SetLockState(bool Lock_b)
      {
         if (Lock_b && mListView_O != null && mListView_O.SelectedItems != null && mListView_O.SelectedItems.Count > 0)
         {
            mLocked_b = true;
            //mSelectedItemID_UL = GetSelectedItemID();
            mListViewItem_O = mListView_O.SelectedItems[0];
            mListView_O.SelectedItems.Clear();
            mListViewItem_O.BackColor = Color.FromArgb(153, 0, 0);
            mListViewItem_O.ForeColor = Color.White;

            for (int i = 0; i < mFilterTextBox_O.Count; i++)
            {
               mFilterTextBox_O[i].Enabled = false;
            }
         }
         else if (mListViewItem_O != null && !Lock_b)
         {
            mLocked_b = false;
            mListViewItem_O.BackColor = Color.Transparent;
            mListViewItem_O.ForeColor = Color.Black;
            this.mListView_O.Items[mListViewItem_O.Index].Focused = true;
            this.mListView_O.Items[mListViewItem_O.Index].Selected = true;
            mListViewItem_O = null;

            for (int i = 0; i < mFilterTextBox_O.Count; i++)
            {
               mFilterTextBox_O[i].Enabled = true;
            }
         }
      }

      private void ToolStripBtnExportCSV_Click(object sender, EventArgs e)
      {
         SaveFileDialog Dlg_O = new SaveFileDialog();
         Dlg_O.FileName = "Export_MMSOFT"; // Default file name
         Dlg_O.DefaultExt = ".csv"; // Default file extension
         Dlg_O.Filter = "Csv files (.txt)|*.csv"; // Filter files by extension

         String[] CSVLines_ST = new String[mListView_O.Items.Count + 1];

         // Begin by writing column header name
         for (int i = 0; i < mColumnHeaderName_ST.Count; i++)
         {
            CSVLines_ST[0] += mColumnHeaderName_ST[i] + ((i == mColumnHeaderName_ST.Count - 1) ? "\r\n" : ";");
         }

         // Then write list view content
         for (int i = 0; i < mListView_O.Items.Count; i++)
         {
            for (int j = 0; j < mListView_O.Items[i].SubItems.Count; j++)
            {
               if (j != mDBIDIndex_UL) // avoid considering db id
               {
                  CSVLines_ST[i + 1] += (mListView_O.Items[i].SubItems[j].Text + ((j != mListView_O.Items[i].SubItems.Count - 1) ? ";" : ""));
               }
            }
         }

         // Show save file dialog box
         DialogResult DlgRes_O = Dlg_O.ShowDialog();

         // Process save file dialog box results
         if (DlgRes_O == DialogResult.OK)
         {
            // Save document
            File.WriteAllLines(Dlg_O.FileName, CSVLines_ST, Encoding.UTF8);
         }
      }

      public void AddToolStripBtn(ToolStripButton ToolStripBtn_O)
      {
         this.MainToolStrip.Items.Add(ToolStripBtn_O);
      }

      public void AddToolStripSeparator(ToolStripSeparator ToolStripSeparator_O)
      {
         this.MainToolStrip.Items.Add(ToolStripSeparator_O);
      }

      public void AddToolStripControlHost(ToolStripControlHost ControlHost_O)
      {
         this.MainToolStrip.Items.Add(ControlHost_O);
      }


      public void SelectItemByID(UInt32 ID_UL)
      {
         int Item_ID;
         bool Found_b = false;

         for (int i = 0; i < mListView_O.Items.Count && !Found_b; i++)
         {
            if (int.TryParse(mListView_O.Items[i].SubItems[(int)mDBIDIndex_UL].Text, out Item_ID) && Item_ID == ID_UL)
            {
               Found_b = true;
               this.mListView_O.Focus();
               this.mListView_O.Items[i].Focused = true;
               this.mListView_O.Items[i].Selected = true;
               this.mListView_O.Items[i].EnsureVisible();
            }
         }
      }

      public void SetInitialFilter(String InitialWhere_ST, String InitialOrderBy_ST)
      {
         mInitialWhere_ST = InitialWhere_ST;
         mInitialOrderBy_ST = InitialOrderBy_ST;
      }

      public UInt32 GetMaxID()
      {
         UInt32 MaxID_UL = 0;

         if (mListView_O.Items.Count > 0)
         {
            System.Nullable<int> max = ( from m in mListView_O.Items.Cast<ListViewItem>() select int.Parse(m.SubItems[(int)mDBIDIndex_UL].Text)).Max();

            if (max != null)
               MaxID_UL = (UInt32)max;
         }

         return MaxID_UL;
      }

      public void FormatSubItem(String DBFieldName_st, Color ForeColor_O, Font Font_O = null)
      {
         if (mListView_O.SelectedItems != null && mListView_O.SelectedItems.Count > 0)
         {
            mListView_O.SelectedItems[0].UseItemStyleForSubItems = false;
            mListView_O.SelectedItems[0].SubItems[DBFieldName_st].ForeColor = ForeColor_O;

            if (Font_O != null)
               mListView_O.SelectedItems[0].SubItems[DBFieldName_st].Font = Font_O;
         }
      }

      public float Sum(String ColumnName_st)
      {
         float Sum_f = 0;
         float CurrentValue_f;

         for (int i = 0; i < mListView_O.Items.Count; i++)
         {
            if (float.TryParse(mListView_O.Items[i].SubItems[ColumnName_st].Text, out CurrentValue_f))
            {
               Sum_f += CurrentValue_f;
            }
         }

         return Sum_f;
      }

      public String GetSelectedItemField(String FieldName_st)
      {
         String ItemField_st = "";

         if (mListView_O.SelectedItems != null)
            ItemField_st = mListView_O.SelectedItems[0].SubItems[FieldName_st].Text;

         return ItemField_st;
      }

      public void SetTableName(String TableName_ST)
      {
         mTableName_ST = TableName_ST;
      }
   }
}
