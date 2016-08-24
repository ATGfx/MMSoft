using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MMSoft
{
    /// <summary>
    /// Class managing Functions (scalar and table-valued) ressources of a Database
    /// </summary>
    public class FunctionManager
    {
        /// <summary>
        /// Connexion state between client and Database
        /// </summary>
        protected bool mConnected_b;

        /// <summary>
        /// Variable representing the connection to a Database
        /// </summary>
        protected SqlConnection mSqlConnection_O;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="Connected_b">Connexion between client and Database server state</param>
        /// <param name="SqlConnection_O">Variable representing the connection to a Database</param>
        public FunctionManager(bool Connected_b, SqlConnection SqlConnection_O)
        {
            mConnected_b = Connected_b;
            mSqlConnection_O = SqlConnection_O;
        }

        /****************************/
        /** Table-valued functions **/
        /****************************/
        //GetCumulTable
        //GetCumulTableView
        //GetDetailedCumulTableView
        //GetPersTotHoursPerMonth

        /*****************************/
        /** Scalar-valued functions **/
        /*****************************/
        /// <summary>
        /// Count the estimated value of all the purchase made on a job
        /// </summary>
        /// <param name="JobID_i">The ID of the job</param>
        /// <returns>The sum of estimated value of purchases. If there is a connection problem (client not connected) the method returns -1</returns>
        public float SCFNC_CountJobAchatEstim(int JobID_i)
        {
            float JobAchatEstim_f = -1.0f;

            SqlCommand SqlCommand_O;
            SqlParameter JobIdParam_O;

            if (mConnected_b)
            {
                SqlCommand_O = new SqlCommand("SELECT dbo.CountJobAchatEstim(@jobID)", mSqlConnection_O);
                JobIdParam_O = new SqlParameter("@jobID", SqlDbType.Int);
                SqlCommand_O.Parameters.Add(JobIdParam_O);
                JobIdParam_O.Value = JobID_i;
                try
                {
                    JobAchatEstim_f = (float)Convert.ToDecimal(SqlCommand_O.ExecuteScalar()); // Brutal cast in float because Execute Scalar method returns object
                }
                catch (SqlException Error_O)
                {
                    System.Diagnostics.Debug.WriteLine("Cannot execute function CountJobAchatEstim SQL exception.\r\n" + Error_O.ToString());
                }
                catch (Exception Error_O)
                {
                    System.Diagnostics.Debug.WriteLine("Cannot cast in float returned value of function CountJobAchatEstim.\r\n" + Error_O.ToString());
                }
            }

            return JobAchatEstim_f;
        }
        //CountJobAchatReel
        //CountJobCost
        //CountJobFact

        //CountJobInCom
        public UInt32 SCFNC_CountJobInCom(UInt32 ComID_UL)
        {
           UInt32 NbJobs_UL = 0;

           SqlCommand SqlCommand_O;
           SqlParameter ComID_O;

           if (mConnected_b)
           {
              SqlCommand_O = new SqlCommand("SELECT dbo.CountJobInCom(@ComID)", mSqlConnection_O);
              ComID_O = new SqlParameter("@ComID", SqlDbType.Int);

              SqlCommand_O.Parameters.Add(ComID_O);

              ComID_O.Value = (int)ComID_UL;
              try
              {
                 object StoredProcValue_O = SqlCommand_O.ExecuteScalar();

                 if (StoredProcValue_O.GetType() != typeof(DBNull))
                    NbJobs_UL = (UInt32)Convert.ToInt32(StoredProcValue_O); // Brutal cast in int32 because Execute Scalar method returns object
              }
              catch (SqlException Error_O)
              {
                 System.Diagnostics.Debug.WriteLine("Cannot execute function CountJobInCom SQL exception.\r\n" + Error_O.ToString());
              }
              catch (Exception Error_O)
              {
                 System.Diagnostics.Debug.WriteLine("Cannot cast in int32 returned value of function CountJobInCom.\r\n" + Error_O.ToString());
              }
           }

           return NbJobs_UL;
        }

        //CountMachineHoursOnJob
        public float SCFNC_CountMachineHoursOnJob(UInt32 JobID_UL)
        {
           float SumHours_f = 0.0f;

           SqlCommand SqlCommand_O;
           SqlParameter JobID_O;

           if (mConnected_b)
           {
              SqlCommand_O = new SqlCommand("SELECT dbo.CountMachineHoursOnJob(@JobID)", mSqlConnection_O);
              JobID_O = new SqlParameter("@JobID", SqlDbType.Int);

              SqlCommand_O.Parameters.Add(JobID_O);

              JobID_O.Value = JobID_UL;

              try
              {
                 SumHours_f = (float)Convert.ToDecimal(SqlCommand_O.ExecuteScalar()); // Brutal cast in float because Execute Scalar method returns object
              }
              catch (SqlException Error_O)
              {
                 System.Diagnostics.Debug.WriteLine("Cannot execute function CountMachineHoursOnJob SQL exception.\r\n" + Error_O.ToString());
              }
              catch (Exception Error_O)
              {
                 System.Diagnostics.Debug.WriteLine("Cannot cast in float returned value of function CountMachineHoursOnJob.\r\n" + Error_O.ToString());
              }
           }

           return SumHours_f;
        }

        //CountNbrH
        //CountNbrHCorr
        //CountPersHourInDay
        public float SCFNC_CountPersHourInDay(DateTime Date_O, UInt32 PersID_UL)
        {
            float SumHours_f = 0.0f;

            SqlCommand SqlCommand_O;
            SqlParameter DayParam_O, MonthParam_O, YearParam_O, PersIDParam_O;

            if (mConnected_b)
            {
                  SqlCommand_O = new SqlCommand("SELECT dbo.CountPersHourInDay(@day, @month, @year, @PersID)", mSqlConnection_O);
                  DayParam_O = new SqlParameter("@day", SqlDbType.Int);
                  MonthParam_O = new SqlParameter("@month", SqlDbType.Int);
                  YearParam_O = new SqlParameter("@year", SqlDbType.Int);
                  PersIDParam_O = new SqlParameter("@PersID", SqlDbType.Int);

                  SqlCommand_O.Parameters.Add(DayParam_O);
                  SqlCommand_O.Parameters.Add(MonthParam_O);
                  SqlCommand_O.Parameters.Add(YearParam_O);
                  SqlCommand_O.Parameters.Add(PersIDParam_O);

                  DayParam_O.Value = Date_O.Day;
                  MonthParam_O.Value = Date_O.Month;
                  YearParam_O.Value = Date_O.Year;
                  PersIDParam_O.Value = PersID_UL;
                  try
                  {
                     object StoredProcValue_O = SqlCommand_O.ExecuteScalar();

                     if (StoredProcValue_O.GetType() != typeof(DBNull))
                        SumHours_f = (float)Convert.ToDecimal(StoredProcValue_O); // Brutal cast in float because Execute Scalar method returns object
                  }
                  catch (SqlException Error_O)
                  {
                     System.Diagnostics.Debug.WriteLine("Cannot execute function CountPersHourInDay SQL exception.\r\n" + Error_O.ToString());
                  }
                  catch (Exception Error_O)
                  {
                     System.Diagnostics.Debug.WriteLine("Cannot cast in float returned value of function CountPersHourInDay.\r\n" + Error_O.ToString());
                  }
            }

            return SumHours_f;
        }

        //CountPersHourInJob
        public float SCFNC_CountPersHourInJob(UInt32 JobID_UL, UInt32 PersID_UL)
        {
           float SumHours_f = 0.0f;

           SqlCommand SqlCommand_O;
           SqlParameter JobID_O, PersIDParam_O;

           if (mConnected_b)
           {
              SqlCommand_O = new SqlCommand("SELECT dbo.CountPersHourInJob(@JobID, @PersID)", mSqlConnection_O);
              JobID_O = new SqlParameter("@JobID", SqlDbType.Int);
              PersIDParam_O = new SqlParameter("@PersID", SqlDbType.Int);

              SqlCommand_O.Parameters.Add(JobID_O);
              SqlCommand_O.Parameters.Add(PersIDParam_O);

              JobID_O.Value = JobID_UL;
              PersIDParam_O.Value = PersID_UL;
              try
              {
                 SumHours_f = (float)Convert.ToDecimal(SqlCommand_O.ExecuteScalar()); // Brutal cast in float because Execute Scalar method returns object
              }
              catch (SqlException Error_O)
              {
                 System.Diagnostics.Debug.WriteLine("Cannot execute function CountPersHourInJob SQL exception.\r\n" + Error_O.ToString());
              }
              catch (Exception Error_O)
              {
                 System.Diagnostics.Debug.WriteLine("Cannot cast in float returned value of function CountPersHourInJob.\r\n" + Error_O.ToString());
              }
           }

           return SumHours_f;
        }

        //CountPointageHoursOnJob
        public float SCFNC_CountPointageHoursOnJob(UInt32 JobID_UL)
        {
           float SumHours_f = 0.0f;

           SqlCommand SqlCommand_O;
           SqlParameter JobID_O;

           if (mConnected_b)
           {
              SqlCommand_O = new SqlCommand("SELECT dbo.CountPointageHoursOnJob(@JobID)", mSqlConnection_O);
              JobID_O = new SqlParameter("@JobID", SqlDbType.Int);

              SqlCommand_O.Parameters.Add(JobID_O);

              JobID_O.Value = JobID_UL;

              try
              {
                 SumHours_f = (float)Convert.ToDecimal(SqlCommand_O.ExecuteScalar()); // Brutal cast in float because Execute Scalar method returns object
              }
              catch (SqlException Error_O)
              {
                 System.Diagnostics.Debug.WriteLine("Cannot execute function CountPointageHoursOnJob SQL exception.\r\n" + Error_O.ToString());
              }
              catch (Exception Error_O)
              {
                 System.Diagnostics.Debug.WriteLine("Cannot cast in float returned value of function CountPointageHoursOnJob.\r\n" + Error_O.ToString());
              }
           }

           return SumHours_f;
        }

        //CountQteExp
        //GetClientPrefCertif
        //GetClientPrefNE
        //GetClientPrefRappConf
        //GetCumul
        //GetCumulEstim
        //GetDepOfJob

        //GetMaxClientNumber
        public UInt32 SCFNC_GetMaxClientNumber()
        {
           UInt32 MaxID_UL = 0;

           SqlCommand SqlCommand_O;

           if (mConnected_b)
           {
              SqlCommand_O = new SqlCommand("SELECT dbo.GetMaxClientNumber()", mSqlConnection_O);

              try
              {
                 MaxID_UL = (UInt32)Convert.ToUInt32(SqlCommand_O.ExecuteScalar()); // Brutal cast in UInt32 because Execute Scalar method returns object
              }
              catch (SqlException Error_O)
              {
                 System.Diagnostics.Debug.WriteLine("Cannot execute function GetMaxClientNumber SQL exception.\r\n" + Error_O.ToString());
              }
              catch (Exception Error_O)
              {
                 System.Diagnostics.Debug.WriteLine("Cannot cast in float returned value of function GetMaxClientNumber.\r\n" + Error_O.ToString());
              }
           }

           return MaxID_UL;
        }

        //GetMaxFournNumber
        public UInt32 SCFNC_GetMaxProviderNumber()
        {
           UInt32 MaxID_UL = 0;

           SqlCommand SqlCommand_O;

           if (mConnected_b)
           {
              SqlCommand_O = new SqlCommand("SELECT dbo.GetMaxFournNumber()", mSqlConnection_O);

              try
              {
                 MaxID_UL = (UInt32)Convert.ToUInt32(SqlCommand_O.ExecuteScalar()); // Brutal cast in UInt32 because Execute Scalar method returns object
              }
              catch (SqlException Error_O)
              {
                 System.Diagnostics.Debug.WriteLine("Cannot execute function GetMaxFournNumber SQL exception.\r\n" + Error_O.ToString());
              }
              catch (Exception Error_O)
              {
                 System.Diagnostics.Debug.WriteLine("Cannot cast in float returned value of function GetMaxFournNumber.\r\n" + Error_O.ToString());
              }
           }

           return MaxID_UL;
        }

        //GetNumberOfDep
        //GetPersPrefDep
        //GetPersPrefHall
    }
}
