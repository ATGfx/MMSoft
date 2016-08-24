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
   /// <summary>
   /// Class defining the user control that presents a checking and allow to edit it
   /// </summary>
   public partial class CheckingViewer : UserControl
   {
      public string mNumRefInterne_st;
      public string mClient_st;
      public string mLibelle_st;
      public string mTache_st;
      public string mQte_st;
      public string mDelai_st;
      public string mDate_st;
      public string mNbrH_st;
      public string mRem_st;
      public UInt32 mEtapeID_UL;

      List<TextBox> mCheckFields_O;

      private DatabaseManager mDBManager_O;

      public delegate void DayCheckingsModifiedHandler();
      public event DayCheckingsModifiedHandler DayCheckingsModified;

      public CheckingViewer()
      {
         InitializeComponent();

         this.DoubleBuffered = true;
         SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

         // Init string variables
         mNumRefInterne_st = "";
         mClient_st = "";
         mLibelle_st = "";
         mTache_st = "";
         mQte_st = "";
         mDelai_st = "";
         mDate_st = "";
         mNbrH_st = "";
         mRem_st = "";
         mEtapeID_UL = 0;

         // Fill list of textbox structure
         mCheckFields_O = new List<TextBox>();
         mCheckFields_O.Add(TxtNumRefInt);
         mCheckFields_O.Add(TxtClient);
         mCheckFields_O.Add(TxtLibelle);
         mCheckFields_O.Add(TxtTache);
         mCheckFields_O.Add(TxtQte);
         mCheckFields_O.Add(TxtDelai);
         mCheckFields_O.Add(TxtDate);
         mCheckFields_O.Add(TxtNbrH);
         mCheckFields_O.Add(TxtRem);

         for (int i = 0; i < mCheckFields_O.Count; i++)
         {
            // Set all textbox as non eidtable
            mCheckFields_O[i].ReadOnly = true;

            // Set textbox style
            ControlStyle.SetFrameStyle(mCheckFields_O[i]);

            // Forward mouse enter and leave args to parent : allow the background to be set as selected when mouse enter in a textbox
            mCheckFields_O[i].MouseEnter += new EventHandler(this.PanelChecking_MouseEnter);
            mCheckFields_O[i].MouseLeave += new EventHandler(this.PanelChecking_MouseLeave);
         }

         ToolStripBtnEdit.MouseEnter += new EventHandler(this.PanelChecking_MouseEnter);
         ToolStripBtnCopy.MouseEnter += new EventHandler(this.PanelChecking_MouseEnter);
         ToolStripBtnDelete.MouseEnter += new EventHandler(this.PanelChecking_MouseEnter);

         ToolStripBtnEdit.MouseLeave += new EventHandler(this.PanelChecking_MouseLeave);
         ToolStripBtnCopy.MouseLeave += new EventHandler(this.PanelChecking_MouseLeave);
         ToolStripBtnDelete.MouseLeave += new EventHandler(this.PanelChecking_MouseLeave);

         ControlStyle.SetFrameStyle(this);
         this.PanelBorder.BackColor = Color.White;
         ControlStyle.SetFrameStyle(PanelChecking);
         ToolStripCheckActions.Renderer = new BorderlessToolStripRenderer();
         ControlStyle.SetFrameStyle(ToolStripCheckActions);
      }

      public void Initialize(DatabaseManager DBManager_O)
      {
         mDBManager_O = DBManager_O;
      }

      private void PanelChecking_MouseEnter(object sender, EventArgs e)
      {
         //ControlStyle.SetBackgroundColorFocusStyle(PanelBorder);
         ControlStyle.SetBackgroundColorFocusStyle(PanelChecking);

         for (int i = 0; i < mCheckFields_O.Count; i++)
         {
            // Set textbox style
            ControlStyle.SetBackgroundColorFocusStyle(mCheckFields_O[i]);
         }

         ControlStyle.SetBackgroundColorFocusStyle(ToolStripCheckActions);
      }

      private void PanelChecking_MouseLeave(object sender, EventArgs e)
      {
         //this.PanelBorder.BackColor = Color.White;
         ControlStyle.SetFrameStyle(PanelChecking);

         for (int i = 0; i < mCheckFields_O.Count; i++)
         {
            // Set textbox style
            ControlStyle.SetFrameStyle(mCheckFields_O[i]);
         }

         ControlStyle.SetFrameStyle(ToolStripCheckActions);
      }

      private void ToolStripBtnEdit_Click(object sender, EventArgs e)
      {
         if (mDBManager_O != null && mDBManager_O.mConnected_b)
         {
            UInt32 mPersID_UL = 0;
            UInt32.TryParse(mDBManager_O.GetTableField("PointageSelectPop", "PersID", "ComJobEtapeID=" + mEtapeID_UL), out mPersID_UL);

            UInt32 mJobID_UL = 0;
            UInt32.TryParse(mDBManager_O.GetTableField("PointageSelectPop", "ComJobID", "ComJobEtapeID=" + mEtapeID_UL), out mJobID_UL);

            FormCheckingEdition FormCheckingEdition_O = new FormCheckingEdition();
            FormCheckingEdition_O.Initialize(mDBManager_O, Convert.ToDateTime(mDate_st), mPersID_UL, mJobID_UL, CheckingEditionMode.Edit, mEtapeID_UL);
            FormCheckingEdition_O.SetFrameTitle("Edition pointage sur job n° " + mDBManager_O.GetTableField("ComJob", "NumOrdre", "ComJobID=" + mJobID_UL) + " dans " + mNumRefInterne_st + " : " + mLibelle_st);
            FormCheckingEdition_O.ShowDialog();

            DayCheckingsModified();
         }
      }

      public void RefreshCheckingViewer()
      {
         TxtNumRefInt.Text = mNumRefInterne_st;
         TxtClient.Text = mClient_st;
         TxtLibelle.Text = mLibelle_st;
         TxtTache.Text = mTache_st;
         TxtQte.Text = mQte_st;
         if (mDelai_st.Length >= 10) TxtDelai.Text = mDelai_st.Substring(0, 10);
         if (mDate_st.Length >= 10) TxtDate.Text = mDate_st.Substring(0, 10);
         TxtNbrH.Text = mNbrH_st;
         TxtRem.Text = mRem_st;
      }

      private void ToolStripBtnDelete_Click(object sender, EventArgs e)
      {
         if (mDBManager_O != null && mDBManager_O.mConnected_b)
         {
            mDBManager_O.mStoredProcedureManager_O.STPROC_DeletePointageAndEtape(mEtapeID_UL);
            DayCheckingsModified();
            this.Dispose();
         }
      }
   }
}
