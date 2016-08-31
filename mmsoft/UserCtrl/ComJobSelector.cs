using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MMSoft
{
   public partial class ComJobSelector : UserControl
   {
      private DatabaseManager mDBManager_O;

      public ComJobSelector()
      {
         InitializeComponent();
      }

      public void Initialize(DatabaseManager DBManager_O)
      {
         mDBManager_O = DBManager_O;

         this.DBListViewCom.ListTitle = "Commandes";
         this.DBListViewJob.ListTitle = "Jobs";

         List<String> TableFieldCom_ST = new List<String>();
         List<String> ColumnHeaderNameCom_ST = new List<String>();
         List<int> ColumnHeaderDefaultSizeCom_i = new List<int>();
         List<HorizontalAlignment> TextAlignCom_O = new List<HorizontalAlignment>();

         // Fill com info
         TableFieldCom_ST.Add("NumRefInterne");
         TableFieldCom_ST.Add("ComDate");
         TableFieldCom_ST.Add("LibelleCmd");
         TableFieldCom_ST.Add("NumCmdClient");
         TableFieldCom_ST.Add("ClientNom");

         TableFieldCom_ST.Add("ComID");

         ColumnHeaderNameCom_ST.Add("Num cmd interne");
         ColumnHeaderNameCom_ST.Add("Date");
         ColumnHeaderNameCom_ST.Add("Libellé commande");
         ColumnHeaderNameCom_ST.Add("Num cmd client");
         ColumnHeaderNameCom_ST.Add("Client");

         ColumnHeaderDefaultSizeCom_i.Add(90);
         ColumnHeaderDefaultSizeCom_i.Add(80);
         ColumnHeaderDefaultSizeCom_i.Add(150);
         ColumnHeaderDefaultSizeCom_i.Add(100);
         ColumnHeaderDefaultSizeCom_i.Add(200);

         TextAlignCom_O.Add(HorizontalAlignment.Left);
         TextAlignCom_O.Add(HorizontalAlignment.Left);
         TextAlignCom_O.Add(HorizontalAlignment.Left);
         TextAlignCom_O.Add(HorizontalAlignment.Left);
         TextAlignCom_O.Add(HorizontalAlignment.Left);

         DBListViewCom.Initialize(mDBManager_O, "ComSelectPop", TableFieldCom_ST, 5, ColumnHeaderNameCom_ST, ColumnHeaderDefaultSizeCom_i, TextAlignCom_O, null, "NumRefInterne DESC");

         List<String> TableFieldJob_ST = new List<String>();
         List<String> ColumnHeaderNameJob_ST = new List<String>();
         List<int> ColumnHeaderDefaultSizeJob_i = new List<int>();
         List<HorizontalAlignment> TextAlignJob_O = new List<HorizontalAlignment>();

         // Fill job info
         TableFieldJob_ST.Add("NumOrdre");
         TableFieldJob_ST.Add("JobLib");
         TableFieldJob_ST.Add("Qte");
         TableFieldJob_ST.Add("JobStatusLib");
         TableFieldJob_ST.Add("DelaiPromis");
         TableFieldJob_ST.Add("NumPlan");
         TableFieldJob_ST.Add("DateEncod");
                   
         TableFieldJob_ST.Add("ComJobID");

         ColumnHeaderNameJob_ST.Add("Job #");
         ColumnHeaderNameJob_ST.Add("Libellé");
         ColumnHeaderNameJob_ST.Add("Qte");
         ColumnHeaderNameJob_ST.Add("Statut");
         ColumnHeaderNameJob_ST.Add("Délai promis");
         ColumnHeaderNameJob_ST.Add("N° plan");
         ColumnHeaderNameJob_ST.Add("Date d'encodage");

         ColumnHeaderDefaultSizeJob_i.Add(40);
         ColumnHeaderDefaultSizeJob_i.Add(300);
         ColumnHeaderDefaultSizeJob_i.Add(40);
         ColumnHeaderDefaultSizeJob_i.Add(80);
         ColumnHeaderDefaultSizeJob_i.Add(80);
         ColumnHeaderDefaultSizeJob_i.Add(100);
         ColumnHeaderDefaultSizeJob_i.Add(90);

         TextAlignJob_O.Add(HorizontalAlignment.Left);
         TextAlignJob_O.Add(HorizontalAlignment.Left);
         TextAlignJob_O.Add(HorizontalAlignment.Left);
         TextAlignJob_O.Add(HorizontalAlignment.Left);
         TextAlignJob_O.Add(HorizontalAlignment.Left);
         TextAlignJob_O.Add(HorizontalAlignment.Left);
         TextAlignJob_O.Add(HorizontalAlignment.Left);

         DBListViewJob.Initialize(mDBManager_O, "ComJobSelectPop", TableFieldJob_ST, 7, ColumnHeaderNameJob_ST, ColumnHeaderDefaultSizeJob_i, TextAlignJob_O, null, null, false);

         // Record on selection changed event for DBListViewCom
         DBListViewCom.SelectionChanged += new DBListView.SelectionChangedHandler(ComSelectionChanged);

         ControlStyle.SetFrameHeaderStyle(this);
      }

      private void ComSelectionChanged(UInt32 ComID)
      {
         DBListViewJob.SetInitialFilter("ComID='" + ComID + "'", "DateEncod desc");
         DBListViewJob.Refresh();
      }

      public void AddComToolStripBtn(ToolStripButton ToolStripBtn_O)
      {
         DBListViewCom.AddToolStripBtn(ToolStripBtn_O);
      }

      public void AddJobToolStripBtn(ToolStripButton ToolStripBtn_O)
      {
         DBListViewJob.AddToolStripBtn(ToolStripBtn_O);
      }

      public DBListView GetComListView()
      {
         return DBListViewCom;
      }

      public DBListView GetJobListView()
      {
         return DBListViewJob;
      }
   }
}
