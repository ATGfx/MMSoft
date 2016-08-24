using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MMSoft 
{
    /// <summary>
    /// Class managing interaction between client and Database
    /// </summary>
    public class DatabaseManager
    {
        /// <summary>
        /// Variable representing the connection to a Database
        /// </summary>
        protected SqlConnection mSqlConnection_O;

        /// <summary>
        /// Database Manager internal's Stored Procedure Manager. All the stored procedure of the Database must be accessed by
        /// this Stored Procedure Manager
        /// </summary>
        public StoredProcedureManager mStoredProcedureManager_O;

        /// <summary>
        /// Database Manager internal's function manager. All the user defined function (scalar and table-valued) must be accessed
        /// by this Function Manager
        /// </summary>
        public FunctionManager mFunctionManager_O;

        /// <summary>
        /// State variable of connexion status to a Database
        /// </summary>
        public bool mConnected_b;

        /// <summary>
        /// Name of the database instance on which DBManager is connected
        /// </summary>
        public String mDBInstanceName_ST;

        /// <summary>
        /// Default constructor, set member variables to null and connexion state to not connected
        /// </summary>
        public DatabaseManager()
        {
            mSqlConnection_O = null;
            mConnected_b = false;
            mDBInstanceName_ST = null;
        }

        
        /// <summary>
        ///  Connect to database with provided connection string that contains information about the Database and credentials
        /// </summary>
        /// <param name="ConnectionString_S"> Default string for connection in format (Persist Info Security; Data Source; Integrated Security; Inital Catalog)\n
        /// - Persist Security Info : security-sensitive information, such as the password, is not returned as part of the connection
        /// - Data Source :	identifies the server, it could be local machine, machine domain name, or IP Address.\n
        /// - Initial Catalog : is Database name on provided Database server.\n
        /// - Integrated Security : set to SSPI to make connection with user's Windows login\n
        /// - User ID : name of user configured in SQL Server.\n
        /// - Password : password matching SQL Server User ID.
        ///</param>
        ///<example>Persist Security Info=False; Data Source=(local)\\SQLEXPRESS; Integrated Security=SSPI; Initial Catalog=MMSoft;UserID = toto; Password = 1234;</example>
        /// <returns>true if connexion between server and client is established, and update internal state such that this object knows its connexion state</returns>
        public bool ConnectDatabase(String ConnectionString_S)
        {
            if (!mConnected_b)
            {
                try
                {
                    // Connect to database
                    mSqlConnection_O = new SqlConnection(ConnectionString_S);
                    mSqlConnection_O.Open();
                    mConnected_b = true;

                    // Get instance name
                    String[] ConnectionInfos_ST = ConnectionString_S.Split(';');

                    for (int i = 0; i < ConnectionInfos_ST.Length; i++)
                    {
                        if (ConnectionInfos_ST[i].Contains("Initial Catalog") && ConnectionInfos_ST[i].Split('=').Length >= 2)
                        {
                            mDBInstanceName_ST = ConnectionInfos_ST[i].Split('=')[1];
                        }
                    }

                    bool DateFormatChanged_b = ExecuteRequest("SET DATEFORMAT dmy;");

                   if (!DateFormatChanged_b)
                   {
                      MessageBox.Show("Le format de date n'a pas été enregistré par le serveur, le programme se comportera de façon instable au niveau des dates " +
                                       "et il n'est pas conseillé d'aller plus loin", "Attention !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   }

                    // Create internal stored procedure manager
                    mStoredProcedureManager_O = new StoredProcedureManager(mConnected_b, mSqlConnection_O);

                    // Create internal function manager
                    mFunctionManager_O = new FunctionManager(mConnected_b, mSqlConnection_O);
                }
                catch (InvalidOperationException Error_O)
                {
                    mSqlConnection_O = null;
                    System.Diagnostics.Debug.WriteLine("Cannot open database due to invalid operation exception.\r\n" + Error_O.ToString());
                }
                catch (SqlException Error_O)
                {
                    mSqlConnection_O = null;
                    System.Diagnostics.Debug.WriteLine("Cannot open database due to SQL exception.\r\n" + Error_O.ToString());
                }
                catch (ArgumentException Error_O)
                {
                    mSqlConnection_O = null;
                    System.Diagnostics.Debug.WriteLine("Cannot open database due to argument exception.\r\n" + Error_O.ToString());
                }
            }

            return mConnected_b;
        }

        /// <summary>
        /// Close the previously opened connection to a database
        /// </summary>
        /// <returns>true if the disconnection was executed successfuly</returns>
        public bool DisconnectDatabase()
        {
            if (mConnected_b)
            {
                try
                {
                    mSqlConnection_O.Close();
                    mConnected_b = false;
                    mDBInstanceName_ST = null;
                }
                catch (SqlException Error_O)
                {
                    System.Diagnostics.Debug.WriteLine("Cannot close database due to SQL excpetion.\r\n" + Error_O.ToString());
                }
            }

            // returns inverse of mConnected_b to know if method succeeded, if not connected at method calling, the method considered disconnection as successful
            return !mConnected_b;
        }

        /// <summary>
        /// Execute a select command on the database
        /// </summary>
        /// <param name="SqlSelect_S">String of Sql SELECT command</param>
        /// <returns>Returns the associated SqlDataReader of request. Reader is null if command fails</returns>
        public SqlDataReader Select(String SqlSelect_S)
        {
            SqlCommand SqlCommand_O = new SqlCommand();
            SqlDataReader SqlReader_O = null;

            if (mConnected_b)
            {
                SqlCommand_O.Connection = mSqlConnection_O;
                SqlCommand_O.CommandText = SqlSelect_S;

                try
                {
                    SqlReader_O = SqlCommand_O.ExecuteReader();
                }
                catch (SqlException Error_O)
                {
                    System.Diagnostics.Debug.WriteLine("Cannot execute select request on database due to SQL exception.\r\n" + Error_O.ToString());
                }
                catch (InvalidOperationException Error_O)
                {
                    System.Diagnostics.Debug.WriteLine("Cannot execute select request on database due to invalid operation exception.\r\n" + Error_O.ToString());
                }
            }

            return SqlReader_O;
        }

        /// <summary>
        /// Execute a request command on the database
        /// </summary>
        /// <param name="SqlCmd_st">String of Sql command</param>
        /// /// <param name="ParamList_O">List of parameters name of Sql command</param>
        /// /// <param name="ValueList_O">Value oif parameters as object type. Implicit conversion is done between .net type and sql type.</param>
        /// <returns>Returns the associated SqlDataReader of request. Reader is null if command fails</returns>
         public bool ExecuteRequest(String SqlCmd_st, List<String> ParamList_O = null, List<Object> ValueList_O = null)
         {
            SqlCommand SqlCommand_O;

            bool Succeed_b = false;           

            if (mConnected_b)
            {
               using (SqlCommand_O = new SqlCommand())
               {
                  SqlCommand_O.Connection = mSqlConnection_O;
                  SqlCommand_O.CommandText = SqlCmd_st;

                  if (ParamList_O != null && ValueList_O != null)
                  {
                     for (int i = 0; i < ParamList_O.Count; i++)
                        SqlCommand_O.Parameters.AddWithValue(ParamList_O[i], ValueList_O[i]);
                  }

                  try
                  {
                     SqlCommand_O.ExecuteNonQuery();
                     Succeed_b = true;
                  }
                  catch (SqlException Error_O)
                  {
                     System.Diagnostics.Debug.WriteLine("Cannot execute select request on database due to SQL exception.\r\n" + Error_O.ToString() + "\r\nQuerry : " + SqlCommand_O.CommandText);
                  }
                  catch (InvalidOperationException Error_O)
                  {
                     System.Diagnostics.Debug.WriteLine("Cannot execute update request on database due to invalid operation exception.\r\n" + Error_O.ToString() + "\r\nQuerry : " + SqlCommand_O.CommandText);
                  }
               }
            }

            return Succeed_b;
         }

       /// <summary>
       /// This method select a single field from a table. If the method cannot find the specified field, "" is returned.
       /// </summary>
       /// <param name="TableName_ST"></param>
       /// <param name="TableField_ST"></param>
       /// <returns></returns>
       public String GetTableField(String TableName_ST, String TableField_ST, String Where_ST = "")
       {
          String Field_ST = "";
          String SQLRequest_ST = "SELECT " + TableField_ST + " FROM " + TableName_ST;

          if (!String.IsNullOrEmpty(Where_ST))
             SQLRequest_ST += " WHERE " + Where_ST;
             
          SqlDataReader SqlDataReader_O = Select(SQLRequest_ST);

          while (SqlDataReader_O.Read())
          {
             Field_ST = SqlDataReader_O[0].ToString();
          }

          SqlDataReader_O.Close();

          return Field_ST;
       }
    }
}
