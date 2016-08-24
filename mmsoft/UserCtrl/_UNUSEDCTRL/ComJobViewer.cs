using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MMSoft
{
    /// <summary>
    /// User control defining a selectable list of job with a filter to display a subset of job present in the database. The user can reorder
    /// the jobs acording to each column.
    /// </summary>
   public partial class ComJobViewer : UserControl
   {
      public List<String> mColumnHeaders_st;
      private List<ColumnHeader> mColumnHeaders_O;
      private List<TextBox> mFilterTextBox_O;
      private DatabaseManager mDBManager_O;
      private List<String> mColumnDBField_O;
      private String mLastSQLRequest_st;
      private int mLastClickedFilterIndex_i;
      private bool Asc_b;

      public delegate void JobSelectionChangedHandler(UInt32 ComJobID_UL);
      public event JobSelectionChangedHandler JobSelectionChanged;

      public delegate void JobDoubleClickedHandler(UInt32 ComJobID_UL);
      public event JobDoubleClickedHandler JobDoubleClicked;

      /// <summary>
      /// Default constructor
      /// </summary>
      public ComJobViewer()
      {
         InitializeComponent();
      }
      /// <summary>
      /// Initialization method
      /// </summary>
      public void Initialize(DatabaseManager DBManager_O)
      {
         mDBManager_O = DBManager_O;
         mLastSQLRequest_st = "";
         mLastClickedFilterIndex_i = -1;
         Asc_b = true;

         // Set list view style : done here because list view is private
         ControlStyle.SetFrameStyle(CustomComJobListView);

         // Define column DB fields
         mColumnDBField_O = new List<String>();
         mColumnDBField_O.Add("NumRefInterne");
         mColumnDBField_O.Add("LibelleCmd");
         mColumnDBField_O.Add("NumCmdClient");
         mColumnDBField_O.Add("ClientNom");
         mColumnDBField_O.Add("NumOrdre");
         mColumnDBField_O.Add("JobLib");
         mColumnDBField_O.Add("Qte");
         mColumnDBField_O.Add("NumPlan");
         mColumnDBField_O.Add("DelaiPromis");
         mColumnDBField_O.Add("ComStatusLib");
         mColumnDBField_O.Add("DateEncod");
         // Unshown elements
         mColumnDBField_O.Add("ComJobID");

         // Define column headers text
         mColumnHeaders_st = new List<string>();
         mColumnHeaders_st.Add("Num cmd int");
         mColumnHeaders_st.Add("Libellé cmd");
         mColumnHeaders_st.Add("Num cmd client");
         mColumnHeaders_st.Add("Nom client");
         mColumnHeaders_st.Add("# job");
         mColumnHeaders_st.Add("Job libellé");
         mColumnHeaders_st.Add("Qte");
         mColumnHeaders_st.Add("Num plan");
         mColumnHeaders_st.Add("Délai");
         mColumnHeaders_st.Add("Statut");
         mColumnHeaders_st.Add("Date encodage");

         // Define column headers objects
         mColumnHeaders_O = new List<ColumnHeader>();

         for (int i = 0; i < mColumnHeaders_st.Count; i++)
         {
            mColumnHeaders_O.Add(new ColumnHeader());
            mColumnHeaders_O[i].Name = mColumnDBField_O[i];
            mColumnHeaders_O[i].Text = mColumnHeaders_st[i];

            if (i == 4 || i == 6)
               mColumnHeaders_O[i].TextAlign = HorizontalAlignment.Center;
            else
               mColumnHeaders_O[i].TextAlign = HorizontalAlignment.Left;
         }

         mColumnHeaders_O[0].Width = 100;
         mColumnHeaders_O[1].Width = 100;
         mColumnHeaders_O[2].Width = 150;
         mColumnHeaders_O[3].Width = 150;
         mColumnHeaders_O[4].Width = 50;
         mColumnHeaders_O[5].Width = 600;
         mColumnHeaders_O[6].Width = 50;
         mColumnHeaders_O[7].Width = 100;
         mColumnHeaders_O[8].Width = 100;
         mColumnHeaders_O[9].Width = 100;
         mColumnHeaders_O[10].Width = 100;

         // Define list view column header
         for (int i = 0; i < mColumnHeaders_st.Count; i++)
         {
            CustomComJobListView.Columns.Add(mColumnHeaders_O[i]);
         }

         // Set text box as filter
         mFilterTextBox_O = new List<TextBox>();
         mFilterTextBox_O.Add(TxtNumPlan);
         mFilterTextBox_O.Add(TxtDelaiPromis);
         mFilterTextBox_O.Add(TxtDateEncod);
         mFilterTextBox_O.Add(TxtStatut);
         mFilterTextBox_O.Add(TxtJobNumOrdre);
         mFilterTextBox_O.Add(TxtJobLib);
         mFilterTextBox_O.Add(TxtQte);
         mFilterTextBox_O.Add(TxtLibCmd);
         mFilterTextBox_O.Add(TxtNumCmdClient);
         mFilterTextBox_O.Add(TxtNomClient);
         mFilterTextBox_O.Add(TxtNumCmdInt);

         //this.FilterPanel.Height = mFilterTextBox_O[0].Height + 3;

         for (int i = 0; i < mFilterTextBox_O.Count; i++)
         {
            mFilterTextBox_O[i].TabIndex = i;
            mFilterTextBox_O[i].Tag = i;
            mFilterTextBox_O[i].TextChanged += new System.EventHandler(this.FilterTextChanged);
         }

         // Set filter txt according to column header
         RefreshFilterTxt(true);

         // Set filter text box style
         ControlStyle.SetFrameStyle(this);
         ControlStyle.SetFrameStyle(this.ListViewPanel);
         ControlStyle.SetFrameStyle(this.CustomComJobListView);
         ControlStyle.SetFrameStyle(this.FilterPanel);
         ControlStyle.SetFrameHeaderStyle(this.FilterPanelPadding);
         ControlStyle.SetFrameStyle(this.TxtNumCmdInt);
         ControlStyle.SetFrameStyle(this.TxtNomClient);
         ControlStyle.SetFrameStyle(this.TxtNumCmdClient);
         ControlStyle.SetFrameStyle(this.TxtLibCmd);
         ControlStyle.SetFrameStyle(this.TxtQte);
         ControlStyle.SetFrameStyle(this.TxtJobLib);
         ControlStyle.SetFrameStyle(this.TxtJobNumOrdre);
         ControlStyle.SetFrameStyle(this.TxtStatut);
         ControlStyle.SetFrameStyle(this.TxtDateEncod);
         ControlStyle.SetFrameStyle(this.TxtDelaiPromis);
         ControlStyle.SetFrameStyle(this.TxtNumPlan);
         ControlStyle.SetFrameStyle(this.BtnClearFilter);

         // Display jobs
         RefreshJobs();
      }

      public void RefreshJobs()
      {
         // TODO : this method may take a little time and optimization by refreshing only selected job could be considered
         SqlDataReader SqlDataReader_O;
         ListViewItem ListViewItem_O;
         String SQLRequest_O;

         // Clear list before continuing, otherwise list will only grow with new items
         CustomComJobListView.Items.Clear();

         if (mDBManager_O != null && mDBManager_O.mConnected_b)
         {
            SQLRequest_O = "Select ";

            for (int i = 0; i < mColumnDBField_O.Count; i++)
            {
               SQLRequest_O += mColumnDBField_O[i];

               if (i != mColumnDBField_O.Count - 1)
                  SQLRequest_O += ",";
            }

            SQLRequest_O += " from ComJobSelectPop " + BuildWhereStatement() + " " + BuildOrderByStatement();

            SqlDataReader_O = mDBManager_O.Select(SQLRequest_O);
            mLastSQLRequest_st = SQLRequest_O;

            while (SqlDataReader_O.Read())
            {
               ListViewItem_O = new ListViewItem();
               ListViewItem_O.SubItems[0].Text = SqlDataReader_O[mColumnDBField_O[0]].ToString();

               for (int i = 1; i < mColumnDBField_O.Count; i++)
               {
                  if ((i == 8 || i == 10) && SqlDataReader_O[mColumnDBField_O[i]].ToString().Length > 10)
                  {
                     ListViewItem_O.SubItems.Add(SqlDataReader_O[mColumnDBField_O[i]].ToString().Substring(0, 10));
                  }
                  else
                     ListViewItem_O.SubItems.Add(SqlDataReader_O[mColumnDBField_O[i]].ToString());
               }

               CustomComJobListView.Items.Add(ListViewItem_O);
            }

            SqlDataReader_O.Close();
         }
      }

      public void RefreshFilterTxt(bool ClearTextBox_b)
      {
         mFilterTextBox_O[0].Width = this.CustomComJobListView.Columns[0].Width - 2;
         mFilterTextBox_O[0].Location = new Point(CustomComJobListView.Location.X + 1, this.FilterPanel.Height - mFilterTextBox_O[0].Height - 1);

         if (ClearTextBox_b)
            mFilterTextBox_O[0].Text = "";

         for (int i = 1; i < mFilterTextBox_O.Count; i++)
         {
            mFilterTextBox_O[i].Width = this.CustomComJobListView.Columns[i].Width - 2 ;
            mFilterTextBox_O[i].Location = new Point(mFilterTextBox_O[i - 1].Location.X + mFilterTextBox_O[i - 1].Width + 2, mFilterTextBox_O[0].Location.Y);

            if (ClearTextBox_b)
               mFilterTextBox_O[i].Text = "";
         }

         BtnClearFilter.Location = new Point(mFilterTextBox_O[mFilterTextBox_O.Count - 1].Location.X + mFilterTextBox_O[mFilterTextBox_O.Count - 1].Width, mFilterTextBox_O[0].Location.Y - 2);
      }

      private void FilterTextChanged(object sender, EventArgs e)
      {
         mLastClickedFilterIndex_i = -1;
         RefreshJobs();
      }

      private String BuildWhereStatement()
      {
         String Where_st = "";
         int ConditionsFound_i = 0;

         for (int i = 0; i < mFilterTextBox_O.Count; i++)
         {
            if (!String.IsNullOrEmpty(mFilterTextBox_O[i].Text))
            {
               Where_st += "AND " + mColumnDBField_O[i] + " LIKE '%" + mFilterTextBox_O[i].Text + "%'";
               ConditionsFound_i++;
            }
         }

         // if at least 1 coindition is set in filter, deleta first "AND " in constructed string
         if (ConditionsFound_i > 0)
         {
            Where_st = "WHERE " + Where_st.Substring(4);
         }

         return Where_st;
      }

      private String BuildOrderByStatement()
      {
         String OrderBy_st = "";

         if (mLastClickedFilterIndex_i > -1)
         {
            OrderBy_st = "ORDER BY " + mColumnDBField_O[mLastClickedFilterIndex_i] + (Asc_b ? " ASC" : " DESC");
         }

         return OrderBy_st;
      }

      private void BtnClearFilter_Click(object sender, EventArgs e)
      {
         for(int i = 0; i < mFilterTextBox_O.Count; i++)
         {
            mFilterTextBox_O[i].Text = "";
         }

         RefreshJobs();
      }

      /// <summary>
      /// Returns the current selected job ID. If no job is selected, 0 is returned.
      /// </summary>
      /// <returns></returns>
      public UInt32 GetSelectedJobID()
      {
         int Index_i = -1;
         UInt32 ComJobID_UL = 0;

         if (CustomComJobListView.SelectedIndices.Count > 0)
         {
            Index_i = this.CustomComJobListView.SelectedIndices[0];
            ComJobID_UL = Convert.ToUInt32(CustomComJobListView.Items[Index_i].SubItems[11].Text); // Assuming that an ID return by DB cannot be non parsable
         }

         return ComJobID_UL;
      }

      /// <summary>
      /// Allow to retrieve an information displayed by the listview under a header column. The info must be retrieved by the column header name (= name in DB).
      /// </summary>
      /// <returns></returns>
      public String GetSelectedJobInfo(String Info_ST)
      {
         int ListIndex_i = -1;
         int ColumnIndex_i = -1;
         String ComNumber_ST = "";

         if (CustomComJobListView.SelectedIndices.Count > 0)
         {
            ListIndex_i = this.CustomComJobListView.SelectedIndices[0];
            ColumnIndex_i = CustomComJobListView.Columns[Info_ST].Index;
            ComNumber_ST = CustomComJobListView.Items[ListIndex_i].SubItems[ColumnIndex_i].Text;
         }

         return ComNumber_ST;
      }

      private void CustomComJobListView_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
      {
         RefreshFilterTxt(false);
      }

      private void CustomComJobListView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
      {
         RefreshFilterTxt(false);
      }

      private void CustomComJobListView_SelectedIndexChanged(object sender, EventArgs e)
      {
         UInt32 ComJobID_UL = GetSelectedJobID();

         if (ComJobID_UL != 0 && JobSelectionChanged != null)
         {
            JobSelectionChanged(ComJobID_UL);
         }
      }

      private void CustomComJobListView_MouseDoubleClick(object sender, MouseEventArgs e)
      {
         UInt32 ComJobID_UL = GetSelectedJobID();

         if (ComJobID_UL != 0 && JobDoubleClicked != null)
         {
            JobDoubleClicked(ComJobID_UL);
         }
      }

      private void CustomComJobListView_ColumnClick(object sender, ColumnClickEventArgs e)
      {
         if (e.Column == mLastClickedFilterIndex_i)
            Asc_b = !Asc_b;
         else
         {
            mLastClickedFilterIndex_i = e.Column;
            Asc_b = true;
         }

         RefreshJobs();
      }
   }
}
