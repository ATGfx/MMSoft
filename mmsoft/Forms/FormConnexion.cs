using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

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
        private readonly string USER_CONNECTION_CONFIG_FILE = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MMSoft\\UserConnexionConfig.txt");

        /// <summary>
        /// Number of properties in connection configuration file.
        /// </summary>
        private readonly int NB_CONNECTION_CONFIG_PROPERTIES = 6;

        /// <summary>
        /// Default constructor
        /// </summary>
        public FormConnexion()
        {            
            InitializeComponent();

            // Init Database Manager
            mDBManager_O = new DatabaseManager();

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

            // Check connection file validity
            if (!CheckConnectionFileValidity())
            {
                // If not valid rebuil a default one
                BuildDefaultConnectionFile();
            }                       
            
            // Fill form with connection informations (username and pwd)
            FillFormWithConnectionInfo();          
        }

        /// <summary>
        /// Button login click event. This method assumes that connexion file is valid. If the user can be identified, this method set the user id of FormChecking class. 
        /// </summary>
        private void BtnLogIn_Click(object sender, EventArgs e)
        {
            UInt32 UserID_UL = 0;
            bool IsManager_b = false;

            if (!mDBManager_O.mConnected_b)
                InitializeConnection();

            // Record username in configuration file if check box remember me is checked, else reset property
            RecordUsername();

            // Verify matching username - pwd
            if (mDBManager_O.mConnected_b)
            {
               mDBManager_O.mStoredProcedureManager_O.STPROC_VerifyUser(TxtUserName.Text, TxtPwd.Text, out UserID_UL, out IsManager_b);
            }

            if (UserID_UL > 0)
            {
                RecordUsername();
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
        /// Check if the connection file provided is valid, meaning that it has enough parameters and if each parameter is the correct one expected. The values of these parameters is not tested here.
        /// </summary>
        /// <returns></returns>
        private bool CheckConnectionFileValidity()
        {
            bool Rts_b = true;

            string[] Lines_ST;
            string[] CurrentLine_ST;

            try
            {
                Lines_ST = System.IO.File.ReadAllLines(USER_CONNECTION_CONFIG_FILE);

                // Check that we have enough args
                Rts_b = (Lines_ST.Length >= NB_CONNECTION_CONFIG_PROPERTIES);

                if (Rts_b)
                {
                    // Then check that each args is the correct one expected
                    for (int i = 0; i < NB_CONNECTION_CONFIG_PROPERTIES; i++)
                    {
                        CurrentLine_ST = Lines_ST[i].Split('=');

                        if (i == 0)
                            Rts_b &= ((CurrentLine_ST.Length > 0) && CurrentLine_ST[0].Equals("Username"));
                        else if (i == 1)
                            Rts_b &= ((CurrentLine_ST.Length > 0) && CurrentLine_ST[0].Equals("Persist Security Info"));
                        else if (i == 2)
                            Rts_b &= ((CurrentLine_ST.Length > 0) && CurrentLine_ST[0].Equals("Data Source"));
                        else if (i == 3)
                            Rts_b &= ((CurrentLine_ST.Length > 0) && CurrentLine_ST[0].Equals("Integrated Security"));
                        else if (i == 4)
                            Rts_b &= ((CurrentLine_ST.Length > 0) && CurrentLine_ST[0].Equals("Initial Catalog"));
                       else if (i==5)
                            Rts_b &= ((CurrentLine_ST.Length > 0) && CurrentLine_ST[0].Equals("MultipleActiveResultSets"));
                    }
                }
            }
            catch (Exception Error_O)
            {
                Rts_b = false;
                System.Diagnostics.Debug.WriteLine("Cannot open connection configuration file.\r\n" + Error_O.ToString());
            }

            return Rts_b;
        }

        /// <summary>
        /// Build a default connection file with default parameters
        /// </summary>
        /// <returns></returns>
        private bool BuildDefaultConnectionFile()
        {
            bool Rts_b = true;
            string[] Lines_ST = { "Username=", "Persist Security Info=False", "Data Source=SVR2012\\SQLEXPRESS", "Integrated Security=SSPI", "Initial Catalog=MMSoft", "MultipleActiveResultSets=True" }; 

            try
            {
                System.IO.File.WriteAllLines(USER_CONNECTION_CONFIG_FILE, Lines_ST);
            }
            catch (Exception Error_O)
            {
                Rts_b = false;
                System.Diagnostics.Debug.WriteLine("Cannot write default connection configuration file.\r\n" + Error_O.ToString());
            }

            return Rts_b;            
        }

        /// <summary>
        /// Method initializing the connection to the database's server. This method assume that the configuration file is correct. If the method cannot connect to the server,
        /// a message box pop to prevent the user that there is a problem with its connection.
        /// </summary>
        private bool InitializeConnection()
        {
            string ConnectionString_ST = "";
            bool Connected_b;
            string[] Lines_ST;
            string[] CurrentLine_ST;

            try
            {
                Lines_ST = System.IO.File.ReadAllLines(USER_CONNECTION_CONFIG_FILE);

                // Then check that each args is the correct one expected (skip first line)
                for (int i = 1; i < NB_CONNECTION_CONFIG_PROPERTIES; i++)
                {
                    CurrentLine_ST = Lines_ST[i].Split('=');

                    if ((CurrentLine_ST.Length > 1))
                        ConnectionString_ST += CurrentLine_ST[0] + "=" + CurrentLine_ST[1] + ";";
                }

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
            System.IO.StreamReader File_O = new System.IO.StreamReader(USER_CONNECTION_CONFIG_FILE);
            string Line_ST;

            try
            {
                // Read first line of file
                Line_ST = File_O.ReadLine();

                // Read username if provided
                if (Line_ST.Split('=').Length > 1 && !string.IsNullOrEmpty(Line_ST.Split('=')[1]))
                {
                    CheckRememberMe.Checked = true;
                    TxtUserName.Text = Line_ST.Split('=')[1];
                    TxtPwd.Select();
                }
                else
                {
                    CheckRememberMe.Checked = false;
                    TxtUserName.Text = "";
                    TxtUserName.Select();
                }
            }
            catch (Exception Error_O)
            {
                System.Diagnostics.Debug.WriteLine("Cannot open connection configuration file.\r\n" + Error_O.ToString());
            }

            File_O.Close();
        }

        /// <summary>
        /// Record typed username in connection configuration file. If checked box is not checked, value is reset.
        /// </summary>
        private void RecordUsername()
        {
            string[] Lines_ST;
            string[] NewLines_ST;

            try
            {
                Lines_ST = System.IO.File.ReadAllLines(USER_CONNECTION_CONFIG_FILE);

                NewLines_ST = new string[Lines_ST.Length];

                for (int i = 0; i < Lines_ST.Length; i++)
                {
                    if (i == 0) // if line is user name property
                    {
                        NewLines_ST[i] = "Username=" + (CheckRememberMe.Checked ? TxtUserName.Text : "");
                    }
                    else
                        NewLines_ST[i] = Lines_ST[i];
                }

                System.IO.File.WriteAllLines(USER_CONNECTION_CONFIG_FILE, NewLines_ST);

            }
            catch (Exception Error_O)
            {
                System.Diagnostics.Debug.WriteLine("Cannot open connection configuration file.\r\n" + Error_O.ToString());
            }
        }

        private void LblExit_Click(object sender, EventArgs e)
        {
           RecordUsername();
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
