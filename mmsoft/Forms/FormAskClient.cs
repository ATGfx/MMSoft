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
   public partial class FormAskClient : Form
   {
      public UInt32 SelectedClient_UL = 0;

      private DatabaseManager mDBManager_O;

      public FormAskClient(DatabaseManager DBManager_O)
      {
         InitializeComponent();

         mDBManager_O = DBManager_O;

         this.CenterToParent();
         this.DBListViewClient.ListTitle = "Sélection client";

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
         DBListViewClient.ItemDoubleClicked += new DBListView.ItemDoubleClickedHandler(this.ClientDoubleClic);

         ToolStripValidate.Renderer = new BorderlessToolStripRenderer();
         ControlStyle.SetBackgroundColorFocusStyle(this);
         ControlStyle.SetFrameStyle(this.PanelUserPref);
         ControlStyle.SetFrameHeaderStyle(this.ToolStripValidate);
      }

      private void ToolStripBtnValidate_Click(object sender, EventArgs e)
      {
         SelectedClient_UL = DBListViewClient.GetSelectedItemID();
         this.DialogResult = DialogResult.OK;
         this.Dispose();
      }

      private void ToolStripButtonCancel_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Dispose();
      }

      private void ClientDoubleClic(UInt32 ClientID_UL)
      {
         ToolStripBtnValidate_Click(this, new EventArgs());
      }
   }
}
