using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Reflection;

namespace MMSoft
{
    /// <summary>
    /// Class defining the interaction with the connexion panel
    /// </summary>
    public partial class FormConnexion : Form
    {
        /// <summary>
        /// Form's inner Database manager used to check correctness of user/pwd combination. This database manager will be passed to other forms at log in.
        /// </summary>
        private DatabaseManager mDBManager_O;

        /// <summary>
        /// Filename of the user connection configuration. This file contains a slot to remember last username and a connection string to acces MMSoft's database.
        /// This file should be located in the same directory as the executable.
        /// </summary>
        private readonly string USER_CONNECTION_CONFIG_FILE = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MMSoft\\UserConnexionConfig.xml");

        /// <summary>
        /// Data structure that contains all the information to open a connection to the database.
        /// </summary>
        private UserConnexionInfo mUserConnexionInfo_O;

        /// <summary>
        /// Default constructor
        /// </summary>
        public FormConnexion()
        {
            InitializeComponent();

           // Check if roaming dir exists for MMSoft
           if (!Directory.Exists(Path.GetDirectoryName(USER_CONNECTION_CONFIG_FILE)))
           {
              Directory.CreateDirectory(Path.GetDirectoryName(USER_CONNECTION_CONFIG_FILE));
           }
        }

        /// <summary>
        /// Form connexion load event
        /// </summary>
        private void FormConnexion_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            mUserConnexionInfo_O = UserConnexionInfo.DeserializeFromFile(USER_CONNECTION_CONFIG_FILE);

            // check if object can be deserialized (if no it means that it do not exist and we will recreate one)
            if (mUserConnexionInfo_O == null)
            {
                mUserConnexionInfo_O = new UserConnexionInfo();
                mUserConnexionInfo_O.SerializeToFile(USER_CONNECTION_CONFIG_FILE);
            }      
            
            // Fill form with connection informations (username and pwd)
            FillFormWithConnectionInfo();

            // Init Database Manager
            mDBManager_O = new DatabaseManager();
            InitializeConnection();

            CheckProgramVersion();
        }

        /// <summary>
        /// Method that check if the current build correspond to the version in the database. If they not match a pop-up inform the user that he is not up to date
        /// </summary>
        public void CheckProgramVersion()
        {
            String SqlRequest_st;
            SqlDataReader SqlDataReader_O;

            Version Version_O = Assembly.GetEntryAssembly().GetName().Version;

            int Major_i, Minor_i, Build_i;

            if (mDBManager_O != null && mDBManager_O.mConnected_b)
            {
                SqlRequest_st = "SELECT * FROM Version";

                SqlDataReader_O = mDBManager_O.Select(SqlRequest_st);

                while (SqlDataReader_O.Read())
                {
                    Major_i = Convert.ToInt32(SqlDataReader_O["Major"].ToString());
                    Minor_i = Convert.ToInt32(SqlDataReader_O["Minor"].ToString());
                    Build_i = Convert.ToInt32(SqlDataReader_O["Build"].ToString());

                    if (Major_i != Version_O.Major || Minor_i != Version_O.Minor || Build_i != Version_O.Build)
                    {
                        MessageBox.Show("Vous ne possédez pas la dernière version de MMSoft.\nVersion installée : " + Version_O.Major + "." + Version_O.Minor +
                                        "\nVersion serveur : " + Major_i + "." + Minor_i + "." + Build_i, "Attention !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        /// <summary>
        /// Button login click event. This method assumes that connexion file is valid. If the user can be identified, this method set the user id of FormChecking class. 
        /// </summary>
        private void BtnLogIn_Click(object sender, EventArgs e)
        {
            UInt32 UserID_UL = 0;
            bool IsManager_b = false;

            // Record username in configuration file if check box remember me is checked, else reset property
            RecordConnexionInfo();

            // Verify matching username - pwd
            if (mDBManager_O.mConnected_b)
            {
               mDBManager_O.mStoredProcedureManager_O.STPROC_VerifyUser(TxtUserName.Text, TxtPwd.Text, out UserID_UL, out IsManager_b);
            }

            if (UserID_UL > 0)
            {
                this.Hide();

                if (IsManager_b)
                {
                   FormManager FormManager_O = new FormManager(mDBManager_O, UserID_UL);
                   FormManager_O.ShowDialog();
                }
                else
                {
                   FormChecking FormCheking_O = new FormChecking(mDBManager_O, UserID_UL);
                   FormCheking_O.ShowDialog();
                }

                try
                {
                   this.Show();
                }
                catch(ObjectDisposedException Exception_O)
                {
                  // In this case an application exit was called and application should juste shut down
                   this.Dispose();
                }
            }
            else
            {
               MessageBox.Show("Mot de passe incorrect.", "Erreur !");
            }

            TxtPwd.Text = "";
        }

        /// <summary>
        /// Method initializing the connection to the database's server. This method assume that the configuration file is correct. If the method cannot connect to the server,
        /// a message box pop to prevent the user that there is a problem with its connection.
        /// </summary>
        private bool InitializeConnection()
        {
            string ConnectionString_ST = "";
            bool Connected_b;

            try
            {
                ConnectionString_ST += "User ID=" + mUserConnexionInfo_O.mUserName_st + "; ";
                ConnectionString_ST += "Persist Security Info=" + mUserConnexionInfo_O.mPersistSecurityInfo_b.ToString() + "; ";
                ConnectionString_ST += "Data Source=" + mUserConnexionInfo_O.mDataSource_st + "; ";
                ConnectionString_ST += "Integrated Security=" + mUserConnexionInfo_O.mIntegratedSecurity_st + "; ";
                ConnectionString_ST += "Initial Catalog=" + mUserConnexionInfo_O.mInitialCatalog_st + "; ";
                ConnectionString_ST += "MultipleActiveResultSets=" + mUserConnexionInfo_O.mMultipleActiveResultSets_b.ToString() + ";";

                mDBManager_O.ConnectDatabase(ConnectionString_ST);
                Connected_b = mDBManager_O.mConnected_b;
            }
            catch (IOException Error_O)
            {
                Connected_b = false;
                System.Diagnostics.Debug.WriteLine("Cannot open connection configuration file.\r\n" + Error_O.ToString());
                MessageBox.Show("Impossible de se connecter au serveur de base de données MMSoft. Veuillez vérifier votre fichier de configuration de connexion " + USER_CONNECTION_CONFIG_FILE + ". Si le fichier de configuration était inexistant il sera recréé.");
            }               

            return Connected_b;
        }

        /// <summary>
        /// Initialize form with information found on user connection configuration file
        /// </summary>
        private void FillFormWithConnectionInfo()
        {
            CheckRememberMe.Checked = mUserConnexionInfo_O.mSaveInfoOnLogin_b;
            TxtUserName.Text = mUserConnexionInfo_O.mUserName_st;

            if (String.IsNullOrEmpty(TxtUserName.Text))
            {
                TxtUserName.Select();
            }
            else
            {
                TxtPwd.Select();
            }
        }

        /// <summary>
        /// Record connexion infos in connection configuration file. If checked box is not checked, username is reset to empty field.
        /// </summary>
        private void RecordConnexionInfo()
        {
            mUserConnexionInfo_O.mUserName_st = (CheckRememberMe.Checked ? TxtUserName.Text : "");
            mUserConnexionInfo_O.mSaveInfoOnLogin_b = CheckRememberMe.Checked;
            mUserConnexionInfo_O.SerializeToFile(USER_CONNECTION_CONFIG_FILE);
        }

        private void LblExit_Click(object sender, EventArgs e)
        {
           RecordConnexionInfo();
           Application.Exit();
        }

        private void FormConnexion_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyCode == Keys.Enter)
              BtnLogIn_Click(sender, e);
        }

        private void TxtPwd_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyCode == Keys.Enter)
              BtnLogIn_Click(sender, e);
        }

        private void TxtUserName_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyCode == Keys.Enter)
              BtnLogIn_Click(sender, e);
        }
    }
}
