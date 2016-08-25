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
    public partial class FormReturnListView : Form
    {
        private DatabaseManager mDBManager_O;
        private UInt32 mComJobID_UL;

        public FormReturnListView(DatabaseManager DBManager_O, UInt32 ComJobID_UL)
        {
            InitializeComponent();

            mDBManager_O = DBManager_O;
            mComJobID_UL = ComJobID_UL;

            List<String> TableField_ST = new List<String>();
            List<String> ColumnHeaderName_ST = new List<String>();
            List<int> ColumnHeaderDefaultSize_i = new List<int>();
            List<HorizontalAlignment> TextAlign_O = new List<HorizontalAlignment>();

            TableField_ST.Add("DatePrest");
            TableField_ST.Add("PersNom");
            TableField_ST.Add("TypeTacheLib");
            TableField_ST.Add("NbrH");
            TableField_ST.Add("MachineLib");
            TableField_ST.Add("NbrHMachine");
            TableField_ST.Add("Rem");
            TableField_ST.Add("PointageID");

            ColumnHeaderName_ST.Add("Date");
            ColumnHeaderName_ST.Add("Opérateur");
            ColumnHeaderName_ST.Add("Tâche");
            ColumnHeaderName_ST.Add("Heures");
            ColumnHeaderName_ST.Add("Machine");
            ColumnHeaderName_ST.Add("Heures");
            ColumnHeaderName_ST.Add("Remarques");

            ColumnHeaderDefaultSize_i.Add(100);
            ColumnHeaderDefaultSize_i.Add(150);
            ColumnHeaderDefaultSize_i.Add(150);
            ColumnHeaderDefaultSize_i.Add(50);
            ColumnHeaderDefaultSize_i.Add(150);
            ColumnHeaderDefaultSize_i.Add(50);
            ColumnHeaderDefaultSize_i.Add(200);

            TextAlign_O.Add(HorizontalAlignment.Left);
            TextAlign_O.Add(HorizontalAlignment.Left);
            TextAlign_O.Add(HorizontalAlignment.Left);
            TextAlign_O.Add(HorizontalAlignment.Center);
            TextAlign_O.Add(HorizontalAlignment.Left);
            TextAlign_O.Add(HorizontalAlignment.Center);
            TextAlign_O.Add(HorizontalAlignment.Left);

            DBListViewJobReturn.Initialize(mDBManager_O, "PointageMachineSelectPop", TableField_ST, 7, ColumnHeaderName_ST, ColumnHeaderDefaultSize_i, TextAlign_O);
        }
    }
}
