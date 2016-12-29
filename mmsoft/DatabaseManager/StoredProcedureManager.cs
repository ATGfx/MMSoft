using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MMSoft
{
      /// <summary>
      /// Class managing Stored Procedure ressources of a Database
      /// </summary>
      public class StoredProcedureManager
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
         public StoredProcedureManager(bool Connected_b, SqlConnection SqlConnection_O)
         {
            mConnected_b = Connected_b;
            mSqlConnection_O = SqlConnection_O;
         }

         //ArchiverJob
         public bool STPROC_ArchiverJob(UInt32 ComJobID_UL)
         {
            bool Rts_b = false;

            if (mConnected_b)
            {
               // 1. create a command object identifying the stored procedure
               SqlCommand SqlCommand_O = new SqlCommand("ArchiverJob", mSqlConnection_O);

               // 2. set the command object so it knows to execute a stored procedure
               SqlCommand_O.CommandType = CommandType.StoredProcedure;

               // 3. add parameter to command, which will be passed to the stored procedure
               SqlCommand_O.Parameters.Add(new SqlParameter("@ComJobID", (int)ComJobID_UL));

               // execute the command
               try
               {
                  Rts_b = (SqlCommand_O.ExecuteNonQuery() == 1);
               }
               catch (SqlException Error_O)
               {
                  System.Diagnostics.Debug.WriteLine("Cannot execute stored procedure ArchiverJob SQL exception.\r\n" + Error_O.ToString());
               }
            }

            return Rts_b;
         }

         //CloseEtape

         //CloseJob
         public bool STPROC_CloseJob(UInt32 ComJobID_UL)
         {
            bool Rts_b = false;

            if (mConnected_b)
            {
               // 1. create a command object identifying the stored procedure
               SqlCommand SqlCommand_O = new SqlCommand("CloseJob", mSqlConnection_O);

               // 2. set the command object so it knows to execute a stored procedure
               SqlCommand_O.CommandType = CommandType.StoredProcedure;

               // 3. add parameter to command, which will be passed to the stored procedure
               SqlCommand_O.Parameters.Add(new SqlParameter("@ComJobID", (int)ComJobID_UL));

               // execute the command
               try
               {
                  SqlCommand_O.ExecuteNonQuery();
                  Rts_b = true;
               }
               catch (SqlException Error_O)
               {
                  System.Diagnostics.Debug.WriteLine("Cannot execute stored procedure CloseJob SQL exception.\r\n" + Error_O.ToString());
               }
            }

            return Rts_b;
         }

         //ClosePointage
         //CountComAchatTot
         //CountComAchatTotEst
         //CountComJob
         //CountComJobAchatTot
         //CountComJobAchatTotEst
         //CountFactJob

         //CountJobByClientID
         public UInt32 STPROC_CountJobByClientID(UInt32 ClientID_UL)
         {
            SqlParameter Sum_O = null;
            UInt32 Sum_UL = 0;

            if (mConnected_b)
            {
               // 1. create a command object identifying the stored procedure
               SqlCommand SqlCommand_O = new SqlCommand("CountJobByClientID", mSqlConnection_O);

               // 2. set the command object so it knows to execute a stored procedure
               SqlCommand_O.CommandType = CommandType.StoredProcedure;

               // 3. add parameter to command, which will be passed to the stored procedure
               SqlCommand_O.Parameters.Add(new SqlParameter("@ClientID", (int)ClientID_UL));

               Sum_O = SqlCommand_O.Parameters.Add("@sum", SqlDbType.Int);
               Sum_O.Direction = ParameterDirection.Output;

               // execute the command
               try
               {
                  SqlCommand_O.ExecuteNonQuery();
                  if (!(UInt32.TryParse(Sum_O.Value.ToString(), out Sum_UL)))
                  {
                     System.Diagnostics.Debug.WriteLine("Error in stored procedure CountJobByClientID : ID returned is not integer type.\r\n");
                  }
               }
               catch (SqlException Error_O)
               {
                  System.Diagnostics.Debug.WriteLine("Cannot execute stored procedure CountJobByClientID SQL exception.\r\n" + Error_O.ToString());
               }
            }

            return Sum_UL;
         }

         //CountPlanByName

         //CountTask
         public UInt32 STPROC_CountTask(UInt32 ComJobID_UL)
         {
            SqlParameter Sum_O = null;
            UInt32 Sum_UL = 0;

            if (mConnected_b)
            {
               // 1. create a command object identifying the stored procedure
               SqlCommand SqlCommand_O = new SqlCommand("CountTask", mSqlConnection_O);

               // 2. set the command object so it knows to execute a stored procedure
               SqlCommand_O.CommandType = CommandType.StoredProcedure;

               // 3. add parameter to command, which will be passed to the stored procedure
               SqlCommand_O.Parameters.Add(new SqlParameter("@JobID", (int)ComJobID_UL));

               Sum_O = SqlCommand_O.Parameters.Add("@sum", SqlDbType.Int);
               Sum_O.Direction = ParameterDirection.Output;

               // execute the command
               try
               {
                  SqlCommand_O.ExecuteNonQuery();
                  if (!(UInt32.TryParse(Sum_O.Value.ToString(), out Sum_UL)))
                  {
                     System.Diagnostics.Debug.WriteLine("Error in stored procedure CountTask : ID returned is not integer type.\r\n");
                  }
               }
               catch (SqlException Error_O)
               {
                  System.Diagnostics.Debug.WriteLine("Cannot execute stored procedure CountTask SQL exception.\r\n" + Error_O.ToString());
               }
            }

            return Sum_UL;
         }

         //CreateCertif

         // CreateFullCertif
         public UInt32 STPROC_CreateFullCertif(UInt32 NoteEnvoiID_UL , String Matiere_st , String Lot_st , String TTherm_st , String TSurf_st , String Conforme_st , String PathCertif_st , String Rem_st)
         {
            SqlParameter NewID_O = null;
            UInt32 NewID_UL = 0;

            if (mConnected_b)
            {
               // 1. create a command object identifying the stored procedure
               SqlCommand SqlCommand_O = new SqlCommand("CreateFullCertif", mSqlConnection_O);

               // 2. set the command object so it knows to execute a stored procedure
               SqlCommand_O.CommandType = CommandType.StoredProcedure;

               // 3. add parameter to command, which will be passed to the stored procedure
               SqlCommand_O.Parameters.Add(new SqlParameter("@NoteEnvoiID", (int)NoteEnvoiID_UL));
               SqlCommand_O.Parameters.Add(new SqlParameter("@Matiere", Matiere_st));
               SqlCommand_O.Parameters.Add(new SqlParameter("@Lot", Lot_st));
               SqlCommand_O.Parameters.Add(new SqlParameter("@TTherm", TTherm_st));
               SqlCommand_O.Parameters.Add(new SqlParameter("@TSurf", TSurf_st));
               SqlCommand_O.Parameters.Add(new SqlParameter("@Conforme", Conforme_st));
               SqlCommand_O.Parameters.Add(new SqlParameter("@PathCertif", PathCertif_st));
               SqlCommand_O.Parameters.Add(new SqlParameter("@Rem", Rem_st));

               NewID_O = SqlCommand_O.Parameters.Add("@newid", SqlDbType.Int);
               NewID_O.Direction = ParameterDirection.Output;

               // execute the command
               try
               {
                  SqlCommand_O.ExecuteNonQuery();
                  if (!(UInt32.TryParse(NewID_O.Value.ToString(), out NewID_UL)))
                  {
                     System.Diagnostics.Debug.WriteLine("Error in stored procedure CreateFullCertif : ID returned is not integer type.\r\n");
                  }
               }
               catch (SqlException Error_O)
               {
                  System.Diagnostics.Debug.WriteLine("Cannot execute stored procedure CreateFullCertif SQL exception.\r\n" + Error_O.ToString());
               }
            }

            return NewID_UL;
         }

         //CreateClient
         public UInt32 STPROC_CreateClient(String ClientName_ST)
         {
            SqlParameter NewID_O = null;
            UInt32 NewID_UL = 0;

            if (mConnected_b)
            {
               // 1. create a command object identifying the stored procedure
               SqlCommand SqlCommand_O = new SqlCommand("CreateClient", mSqlConnection_O);

               // 2. set the command object so it knows to execute a stored procedure
               SqlCommand_O.CommandType = CommandType.StoredProcedure;

               // 3. add parameter to command, which will be passed to the stored procedure
               SqlCommand_O.Parameters.Add(new SqlParameter("@Nom", ClientName_ST));

               NewID_O = SqlCommand_O.Parameters.Add("@newid", SqlDbType.Int);
               NewID_O.Direction = ParameterDirection.Output;

               // execute the command
               try
               {
                  SqlCommand_O.ExecuteNonQuery();
                  if (!(UInt32.TryParse(NewID_O.Value.ToString(), out NewID_UL)))
                  {
                     System.Diagnostics.Debug.WriteLine("Error in stored procedure CreateClient : ID returned is not integer type.\r\n");
                  }
               }
               catch (SqlException Error_O)
               {
                  System.Diagnostics.Debug.WriteLine("Cannot execute stored procedure CreateClient SQL exception.\r\n" + Error_O.ToString());
               }
            }

            return NewID_UL;
         }

         //CreateHall
         public UInt32 STPROC_CreateHall(String HallName_ST)
         {
            SqlParameter NewID_O = null;
            UInt32 NewID_UL = 0;

            if (mConnected_b)
            {
               // 1. create a command object identifying the stored procedure
               SqlCommand SqlCommand_O = new SqlCommand("CreateHall", mSqlConnection_O);

               // 2. set the command object so it knows to execute a stored procedure
               SqlCommand_O.CommandType = CommandType.StoredProcedure;

               // 3. add parameter to command, which will be passed to the stored procedure
               SqlCommand_O.Parameters.Add(new SqlParameter("@Nom", HallName_ST));

               NewID_O = SqlCommand_O.Parameters.Add("@newid", SqlDbType.Int);
               NewID_O.Direction = ParameterDirection.Output;

               // execute the command
               try
               {
                  SqlCommand_O.ExecuteNonQuery();
                  if (!(UInt32.TryParse(NewID_O.Value.ToString(), out NewID_UL)))
                  {
                     System.Diagnostics.Debug.WriteLine("Error in stored procedure CreateHall : ID returned is not integer type.\r\n");
                  }
               }
               catch (SqlException Error_O)
               {
                  System.Diagnostics.Debug.WriteLine("Cannot execute stored procedure CreateHall SQL exception.\r\n" + Error_O.ToString());
               }
            }

            return NewID_UL;
         }

         //CreateEngine
         public UInt32 STPROC_CreateEngine(String EngineName_ST, UInt32 HallId)
         {
            SqlParameter NewID_O = null;
            UInt32 NewID_UL = 0;

            if (mConnected_b)
            {
               // 1. create a command object identifying the stored procedure
               SqlCommand SqlCommand_O = new SqlCommand("CreateEngine", mSqlConnection_O);

               // 2. set the command object so it knows to execute a stored procedure
               SqlCommand_O.CommandType = CommandType.StoredProcedure;

               // 3. add parameter to command, which will be passed to the stored procedure
               SqlCommand_O.Parameters.Add(new SqlParameter("@Nom", EngineName_ST));
               SqlCommand_O.Parameters.Add(new SqlParameter("@HallID", (int)HallId));

               NewID_O = SqlCommand_O.Parameters.Add("@newid", SqlDbType.Int);
               NewID_O.Direction = ParameterDirection.Output;

               // execute the command
               try
               {
                  SqlCommand_O.ExecuteNonQuery();
                  if (!(UInt32.TryParse(NewID_O.Value.ToString(), out NewID_UL)))
                  {
                     System.Diagnostics.Debug.WriteLine("Error in stored procedure CreateEngine : ID returned is not integer type.\r\n");
                  }
               }
               catch (SqlException Error_O)
               {
                  System.Diagnostics.Debug.WriteLine("Cannot execute stored procedure CreateEngine SQL exception.\r\n" + Error_O.ToString());
               }
            }

            return NewID_UL;
         }

         // CreateClientCom
         public UInt32 STPROC_CreateClientCom(UInt32 ClientID_UL, String NumRefInterne_st)
         {
            SqlParameter NewID_O = null;
            UInt32 NewID_UL = 0;

            if (mConnected_b)
            {
               // 1. create a command object identifying the stored procedure
               SqlCommand SqlCommand_O = new SqlCommand("CreateClientCom", mSqlConnection_O);

               // 2. set the command object so it knows to execute a stored procedure
               SqlCommand_O.CommandType = CommandType.StoredProcedure;

               // 3. add parameter to command, which will be passed to the stored procedure
               SqlCommand_O.Parameters.Add(new SqlParameter("@ClientID", (int)ClientID_UL));
               SqlCommand_O.Parameters.Add(new SqlParameter("@NumRefInterne", NumRefInterne_st));

               NewID_O = SqlCommand_O.Parameters.Add("@newid", SqlDbType.Int);
               NewID_O.Direction = ParameterDirection.Output;

               // execute the command
               try
               {
                  SqlCommand_O.ExecuteNonQuery();
                  if (!(UInt32.TryParse(NewID_O.Value.ToString(), out NewID_UL)))
                  {
                     System.Diagnostics.Debug.WriteLine("Error in stored procedure CreateClientCom : ID returned is not integer type.\r\n");
                  }
               }
               catch (SqlException Error_O)
               {
                  System.Diagnostics.Debug.WriteLine("Cannot execute stored procedure CreateClientCom SQL exception.\r\n" + Error_O.ToString());
               }
            }

            return NewID_UL;
         }

         //CreateCom
         //CreateComJob
         //CreateComJobAchat

         //CreateComJobEtape
         public UInt32 STPROC_CreateComJobEtape(UInt32 ComJobID_UL, UInt32 TypeTacheID_UL, UInt32 NrOrdre_UL)
         {
            SqlParameter NewID_O = null;
            UInt32 NewID_UL = 0;

            if (mConnected_b)
            {
               // 1. create a command object identifying the stored procedure
               SqlCommand SqlCommand_O = new SqlCommand("CreateComJobEtape", mSqlConnection_O);

               // 2. set the command object so it knows to execute a stored procedure
               SqlCommand_O.CommandType = CommandType.StoredProcedure;

               // 3. add parameter to command, which will be passed to the stored procedure
               SqlCommand_O.Parameters.Add(new SqlParameter("@ComJobID", (int)ComJobID_UL));
               SqlCommand_O.Parameters.Add(new SqlParameter("@TypeTacheID", (int)TypeTacheID_UL));
               SqlCommand_O.Parameters.Add(new SqlParameter("@NrOrdre", (int)NrOrdre_UL));

               NewID_O = SqlCommand_O.Parameters.Add("@newID", SqlDbType.Int);
               NewID_O.Direction = ParameterDirection.Output;

               // execute the command
               try
               {
                  SqlCommand_O.ExecuteNonQuery();
                  if (!(UInt32.TryParse(NewID_O.Value.ToString(), out NewID_UL)))
                  {
                     System.Diagnostics.Debug.WriteLine("Error in stored procedure CreateComJobEtape : ID returned is not integer type.\r\n");
                  }
               }
               catch (SqlException Error_O)
               {
                  System.Diagnostics.Debug.WriteLine("Cannot execute stored procedure CreateComJobEtape SQL exception.\r\n" + Error_O.ToString());
               }
            }

            return NewID_UL;
         }
         //CreateCP
         //CreateDep
         //CreateEmptyCom

         //CreateEmptyJob
         public UInt32 STPROC_CreateEmptyJob(UInt32 ComID_UL)
         {
            SqlParameter NewID_O = null;
            UInt32 NewID_UL = 0;

            if (mConnected_b)
            {
               // 1. create a command object identifying the stored procedure
               SqlCommand SqlCommand_O = new SqlCommand("CreateEmptyJob", mSqlConnection_O);

               // 2. set the command object so it knows to execute a stored procedure
               SqlCommand_O.CommandType = CommandType.StoredProcedure;

               // 3. add parameter to command, which will be passed to the stored procedure
               SqlCommand_O.Parameters.Add(new SqlParameter("@ComID", (int)ComID_UL));

               NewID_O = SqlCommand_O.Parameters.Add("@newid", SqlDbType.Int);
               NewID_O.Direction = ParameterDirection.Output;

               // execute the command
               try
               {
                  SqlCommand_O.ExecuteNonQuery();
                  if (!(UInt32.TryParse(NewID_O.Value.ToString(), out NewID_UL)))
                  {
                     System.Diagnostics.Debug.WriteLine("Error in stored procedure CreateEmptyJob : ID returned is not integer type.\r\n");
                  }
               }
               catch (SqlException Error_O)
               {
                  System.Diagnostics.Debug.WriteLine("Cannot execute stored procedure CreateEmptyJob SQL exception.\r\n" + Error_O.ToString());
               }
            }

            return NewID_UL;
         }


         //CreateFourn
         public UInt32 STPROC_CreateProvider(String ClientName_ST)
         {
            SqlParameter NewID_O = null;
            UInt32 NewID_UL = 0;

            if (mConnected_b)
            {
               // 1. create a command object identifying the stored procedure
               SqlCommand SqlCommand_O = new SqlCommand("CreateFourn", mSqlConnection_O);

               // 2. set the command object so it knows to execute a stored procedure
               SqlCommand_O.CommandType = CommandType.StoredProcedure;

               // 3. add parameter to command, which will be passed to the stored procedure
               SqlCommand_O.Parameters.Add(new SqlParameter("@Nom", ClientName_ST));

               NewID_O = SqlCommand_O.Parameters.Add("@newid", SqlDbType.Int);
               NewID_O.Direction = ParameterDirection.Output;

               // execute the command
               try
               {
                  SqlCommand_O.ExecuteNonQuery();
                  if (!(UInt32.TryParse(NewID_O.Value.ToString(), out NewID_UL)))
                  {
                     System.Diagnostics.Debug.WriteLine("Error in stored procedure CreateFourn : ID returned is not integer type.\r\n");
                  }
               }
               catch (SqlException Error_O)
               {
                  System.Diagnostics.Debug.WriteLine("Cannot execute stored procedure CreateFourn SQL exception.\r\n" + Error_O.ToString());
               }
            }

            return NewID_UL;
         }

         //CreateNE

         // CreateFullNE
         public UInt32 STPROC_CreateFullNE(UInt32 ComJobID_UL, double	QteNE, DateTime DateExpedition_O,	bool ChkPartiel_b, String PathNE_st, String JobLib_st, String NumCmdClient_st, String Obs_st)
         {
            SqlParameter NewID_O = null;
            UInt32 NewID_UL = 0;

            if (mConnected_b)
            {
               // 1. create a command object identifying the stored procedure
               SqlCommand SqlCommand_O = new SqlCommand("CreateFullNE", mSqlConnection_O);

               // 2. set the command object so it knows to execute a stored procedure
               SqlCommand_O.CommandType = CommandType.StoredProcedure;

               // 3. add parameter to command, which will be passed to the stored procedure
               SqlCommand_O.Parameters.Add(new SqlParameter("@ComJobID", (int)ComJobID_UL));
               SqlCommand_O.Parameters.Add(new SqlParameter("@QteNE", QteNE));
               SqlCommand_O.Parameters.Add(new SqlParameter("@DateExpedition", DateExpedition_O));
               SqlCommand_O.Parameters.Add(new SqlParameter("@ChkPartiel", ChkPartiel_b));
               SqlCommand_O.Parameters.Add(new SqlParameter("@PathNE", PathNE_st));
               SqlCommand_O.Parameters.Add(new SqlParameter("@JobLib", JobLib_st));
               SqlCommand_O.Parameters.Add(new SqlParameter("@NumCmdClient", NumCmdClient_st));
               SqlCommand_O.Parameters.Add(new SqlParameter("@Obs", Obs_st));

               NewID_O = SqlCommand_O.Parameters.Add("@newID", SqlDbType.Int);
               NewID_O.Direction = ParameterDirection.Output;

               // execute the command
               try
               {
                  SqlCommand_O.ExecuteNonQuery();
                  if (!(UInt32.TryParse(NewID_O.Value.ToString(), out NewID_UL)))
                  {
                     System.Diagnostics.Debug.WriteLine("Error in stored procedure CreateFullNE : ID returned is not integer type.\r\n");
                  }
               }
               catch (SqlException Error_O)
               {
                  System.Diagnostics.Debug.WriteLine("Cannot execute stored procedure CreateFullNE SQL exception.\r\n" + Error_O.ToString());
               }
            }

            return NewID_UL;
         }

         //CreatePers
         public UInt32 STPROC_CreatePers(String Name_st)
         {
            SqlParameter NewID_O = null;
            UInt32 NewID_UL = 0;

            if (mConnected_b)
            {
               // 1. create a command object identifying the stored procedure
               SqlCommand SqlCommand_O = new SqlCommand("CreatePers", mSqlConnection_O);

               // 2. set the command object so it knows to execute a stored procedure
               SqlCommand_O.CommandType = CommandType.StoredProcedure;

               // 3. add parameter to command, which will be passed to the stored procedure
               SqlCommand_O.Parameters.Add(new SqlParameter("@PersNom", Name_st));

               NewID_O = SqlCommand_O.Parameters.Add("@newID", SqlDbType.Int);
               NewID_O.Direction = ParameterDirection.Output;

               // execute the command
               try
               {
                  SqlCommand_O.ExecuteNonQuery();
                  if (!(UInt32.TryParse(NewID_O.Value.ToString(), out NewID_UL)))
                  {
                     System.Diagnostics.Debug.WriteLine("Error in stored procedure CreatePers : ID returned is not integer type.\r\n");
                  }
               }
               catch (SqlException Error_O)
               {
                  System.Diagnostics.Debug.WriteLine("Cannot execute stored procedure CreatePers SQL exception.\r\n" + Error_O.ToString());
               }
            }

            return NewID_UL;
         }

         //CreatePersStatus
         //CreatePlan

         //CreatePointage
         public UInt32 STPROC_CreatePointage(UInt32 ComJobID_UL, UInt32 ComJobEtapeID_UL, UInt32 PersID_UL, double NbrH, String Rem_ST, DateTime DatePrest_O)
         {
            SqlParameter NewID_O = null;
            UInt32 NewID_UL = 0;

            if (mConnected_b)
            {
                  // 1. create a command object identifying the stored procedure
                  SqlCommand SqlCommand_O = new SqlCommand("CreatePointage", mSqlConnection_O);

                  // 2. set the command object so it knows to execute a stored procedure
                  SqlCommand_O.CommandType = CommandType.StoredProcedure;

                  // 3. add parameter to command, which will be passed to the stored procedure
                  SqlCommand_O.Parameters.Add(new SqlParameter("@ComJobID", (int)ComJobID_UL));
                  SqlCommand_O.Parameters.Add(new SqlParameter("@ComJobEtapeID", (int)ComJobEtapeID_UL));
                  SqlCommand_O.Parameters.Add(new SqlParameter("@PersID", (int)PersID_UL));
                  SqlCommand_O.Parameters.Add(new SqlParameter("@NbrH", NbrH));
                  SqlCommand_O.Parameters.Add(new SqlParameter("@Rem", Rem_ST));
                  SqlCommand_O.Parameters.Add(new SqlParameter("@DatePrest", DatePrest_O));

                  NewID_O = SqlCommand_O.Parameters.Add("@newID", SqlDbType.Int);
                  NewID_O.Direction = ParameterDirection.Output;

                  // execute the command
                  try
                  {
                     SqlCommand_O.ExecuteNonQuery();
                     if (!(UInt32.TryParse(NewID_O.Value.ToString(), out NewID_UL)))
                     {
                        System.Diagnostics.Debug.WriteLine("Error in stored procedure CreatePointage : ID returned is not integer type.\r\n");
                     }
                  }
                  catch (SqlException Error_O)
                  {
                     System.Diagnostics.Debug.WriteLine("Cannot execute stored procedure CreatePointage SQL exception.\r\n" + Error_O.ToString());
                  }
            }

            return NewID_UL;
         }

         //CreatePointageGlobal

         //CreatePointageMachine
         public UInt32 STPROC_CreatePointageMachine(UInt32 ComJobEtapeID_UL, UInt32 MachineID_UL, double NbrHMachine)
         {
            SqlParameter NewID_O = null;
            UInt32 NewID_UL = 0;

            if (mConnected_b)
            {
               // 1. create a command object identifying the stored procedure
               SqlCommand SqlCommand_O = new SqlCommand("CreatePointageMachine", mSqlConnection_O);

               // 2. set the command object so it knows to execute a stored procedure
               SqlCommand_O.CommandType = CommandType.StoredProcedure;

               // 3. add parameter to command, which will be passed to the stored procedure
               SqlCommand_O.Parameters.Add(new SqlParameter("@ComJobEtapeID", (int)ComJobEtapeID_UL));
               SqlCommand_O.Parameters.Add(new SqlParameter("@MachineID", (int)MachineID_UL));
               SqlCommand_O.Parameters.Add(new SqlParameter("@NbrHMachine", NbrHMachine));

               NewID_O = SqlCommand_O.Parameters.Add("@newID", SqlDbType.Int);
               NewID_O.Direction = ParameterDirection.Output;

               // execute the command
               try
               {
                  SqlCommand_O.ExecuteNonQuery();
                  if (!(UInt32.TryParse(NewID_O.Value.ToString(), out NewID_UL)))
                  {
                     System.Diagnostics.Debug.WriteLine("Error in stored procedure CreatePointageMachine : ID returned is not integer type.\r\n");
                  }
               }
               catch (SqlException Error_O)
               {
                  System.Diagnostics.Debug.WriteLine("Cannot execute stored procedure CreatePointageMachine SQL exception.\r\n" + Error_O.ToString());
               }
            }

            return NewID_UL;
         }
         //CreateSubDep
         //CreateTask
         //CreateTypeSoc

         //DeleteCom
         public void STPROC_DeleteCom(UInt32 ComID_UL)
         {
            if (mConnected_b)
            {
               // 1. create a command object identifying the stored procedure
               SqlCommand SqlCommand_O = new SqlCommand("DeleteCom", mSqlConnection_O);

               // 2. set the command object so it knows to execute a stored procedure
               SqlCommand_O.CommandType = CommandType.StoredProcedure;

               // 3. add parameter to command, which will be passed to the stored procedure
               SqlCommand_O.Parameters.Add(new SqlParameter("@ComID", (int)ComID_UL));

               // execute the command
               try
               {
                  SqlCommand_O.ExecuteNonQuery();
               }
               catch (SqlException Error_O)
               {
                  System.Diagnostics.Debug.WriteLine("Cannot execute stored procedure DeleteCom SQL exception.\r\n" + Error_O.ToString());
               }
            }
         }

         //DeleteComJob
         //DeleteComJobEtape
         //DeleteDepPref
         //DeleteJobDep

         //DeleteMsg
         public void STPROC_DeleteMsg(UInt32 MsgID_UL)
         {
            if (mConnected_b)
            {
               // 1. create a command object identifying the stored procedure
               SqlCommand SqlCommand_O = new SqlCommand("DeleteMsg", mSqlConnection_O);

               // 2. set the command object so it knows to execute a stored procedure
               SqlCommand_O.CommandType = CommandType.StoredProcedure;

               // 3. add parameter to command, which will be passed to the stored procedure
               SqlCommand_O.Parameters.Add(new SqlParameter("@MsgID", (int)MsgID_UL));

               // execute the command
               try
               {
                  SqlCommand_O.ExecuteNonQuery();
               }
               catch (SqlException Error_O)
               {
                  System.Diagnostics.Debug.WriteLine("Cannot execute stored procedure DeleteMsg SQL exception.\r\n" + Error_O.ToString());
               }
            }
         }


         //DeleteNE

         //DeletePointageAndEtape
         public bool STPROC_DeletePointageAndEtape(UInt32 ComJobEtapeID_UL)
         {
            bool Rts_b = false;

            if (mConnected_b)
            {
               // 1. create a command object identifying the stored procedure
               SqlCommand SqlCommand_O = new SqlCommand("DeletePointageAndEtape", mSqlConnection_O);

               // 2. set the command object so it knows to execute a stored procedure
               SqlCommand_O.CommandType = CommandType.StoredProcedure;

               // 3. add parameter to command, which will be passed to the stored procedure
               SqlCommand_O.Parameters.Add(new SqlParameter("@ComJobEtapeID", (int)ComJobEtapeID_UL));

               // execute the command
               try
               {
                  SqlCommand_O.ExecuteNonQuery();
                  Rts_b = true;
               }
               catch (SqlException Error_O)
               {
                  System.Diagnostics.Debug.WriteLine("Cannot execute stored procedure DeletePointageAndEtape SQL exception.\r\n" + Error_O.ToString());
               }
            }

            return Rts_b;
         }
         //DeleteSingleJob


         //ExpedierJob
         public bool STPROC_ExpedierJob(UInt32 ComJobID_UL)
         {
            bool Rts_b = false;

            if (mConnected_b)
            {
               // 1. create a command object identifying the stored procedure
               SqlCommand SqlCommand_O = new SqlCommand("ExpedierJob", mSqlConnection_O);

               // 2. set the command object so it knows to execute a stored procedure
               SqlCommand_O.CommandType = CommandType.StoredProcedure;

               // 3. add parameter to command, which will be passed to the stored procedure
               SqlCommand_O.Parameters.Add(new SqlParameter("@ComJobID", (int)ComJobID_UL));

               // execute the command
               try
               {
                  Rts_b = (SqlCommand_O.ExecuteNonQuery() == 1);
               }
               catch (SqlException Error_O)
               {
                  System.Diagnostics.Debug.WriteLine("Cannot execute stored procedure ArchiverJob SQL exception.\r\n" + Error_O.ToString());
               }
            }

            return Rts_b;
         }

         //FacturerJob
         public bool STPROC_FacturerJob(UInt32 ComJobID_UL)
         {
            bool Rts_b = false;

            if (mConnected_b)
            {
               // 1. create a command object identifying the stored procedure
               SqlCommand SqlCommand_O = new SqlCommand("FacturerJob", mSqlConnection_O);

               // 2. set the command object so it knows to execute a stored procedure
               SqlCommand_O.CommandType = CommandType.StoredProcedure;

               // 3. add parameter to command, which will be passed to the stored procedure
               SqlCommand_O.Parameters.Add(new SqlParameter("@ComJobID", (int)ComJobID_UL));

               // execute the command
               try
               {
                  Rts_b = (SqlCommand_O.ExecuteNonQuery() == 1);
               }
               catch (SqlException Error_O)
               {
                  System.Diagnostics.Debug.WriteLine("Cannot execute stored procedure ArchiverJob SQL exception.\r\n" + Error_O.ToString());
               }
            }

            return Rts_b;
         }

         //GetNumClient
         //GetTaskByOrder

         /// <summary>
         /// Get user password for a given ID
         /// </summary>
         public string STPROC_GetUserPwd(UInt32 PersID_UL)
         {
            SqlParameter Pwd_O = null;
            string Pwd_ST = null;

            if (mConnected_b)
            {
                  // 1. create a command object identifying the stored procedure
                  SqlCommand SqlCommand_O = new SqlCommand("GetUserPwd", mSqlConnection_O);

                  // 2. set the command object so it knows to execute a stored procedure
                  SqlCommand_O.CommandType = CommandType.StoredProcedure;

                  // 3. add parameter to command, which will be passed to the stored procedure
                  SqlCommand_O.Parameters.Add(new SqlParameter("@PersID", (int)PersID_UL));

                  Pwd_O = SqlCommand_O.Parameters.Add("@Pwd", SqlDbType.VarChar,20);
                  Pwd_O.Direction = ParameterDirection.Output;

                  // execute the command
                  try
                  {
                     SqlCommand_O.ExecuteNonQuery();
                     Pwd_ST = Pwd_O.Value.ToString();
                  }
                  catch (SqlException Error_O)
                  {
                     System.Diagnostics.Debug.WriteLine("Cannot execute stored procedure GetUserPwd SQL exception.\r\n" + Error_O.ToString());
                  }
            }

            return Pwd_ST;
         }
         //LockJobCorrectedHours
         //RecepAchat
         //RecordZipCode

         //SendMsg
         public bool STPROC_SendMsg(String Message_ST, UInt32 PersID_UL)
         {
            bool Rts_b = false;

            if (mConnected_b)
            {
               // 1. create a command object identifying the stored procedure
               SqlCommand SqlCommand_O = new SqlCommand("SendMsg", mSqlConnection_O);

               // 2. set the command object so it knows to execute a stored procedure
               SqlCommand_O.CommandType = CommandType.StoredProcedure;

               // 3. add parameter to command, which will be passed to the stored procedure
               SqlCommand_O.Parameters.Add(new SqlParameter("@Msg", Message_ST));
               SqlCommand_O.Parameters.Add(new SqlParameter("@PersID", (int)PersID_UL));

               // execute the command
               try
               {
                  Rts_b = (SqlCommand_O.ExecuteNonQuery() == 1);
               }
               catch (SqlException Error_O)
               {
                  System.Diagnostics.Debug.WriteLine("Cannot execute stored procedure SendMsg SQL exception.\r\n" + Error_O.ToString());
               }
            }

            return Rts_b;
         }

         // StartJob
         public bool STPROC_StartJob(UInt32 ComJobID_UL)
         {
            bool Rts_b = false;

            if (mConnected_b)
            {
               // 1. create a command object identifying the stored procedure
               SqlCommand SqlCommand_O = new SqlCommand("StartJob", mSqlConnection_O);

               // 2. set the command object so it knows to execute a stored procedure
               SqlCommand_O.CommandType = CommandType.StoredProcedure;

               // 3. add parameter to command, which will be passed to the stored procedure
               SqlCommand_O.Parameters.Add(new SqlParameter("@ComJobID", (int)ComJobID_UL));

               // execute the command
               try
               {
                  Rts_b = (SqlCommand_O.ExecuteNonQuery() == 1);
               }
               catch (SqlException Error_O)
               {
                  System.Diagnostics.Debug.WriteLine("Cannot execute stored procedure StartJob SQL exception.\r\n" + Error_O.ToString());
               }
            }

            return Rts_b;
         }

         //SetNumInterne
         //SetTaskOrder
         //UpdateAllNonCorrectedHours
         //UpdateClient
         //UpdateCom
         //UpdateComJob
         //UpdateCorrectedHours
         //UpdateCP
         //UpdateDepName
         //UpdateFourn
         //UpdateHeuresTotOnJobs
         //UpdateHourscorrected
         //UpdateJobStatus

         //UpdateJobSumHours
         public bool STPROC_UpdateJobSumHours(UInt32 ComJobID_UL)
         {
            bool Rts_b = false;

            if (mConnected_b)
            {
               // 1. create a command object identifying the stored procedure
               SqlCommand SqlCommand_O = new SqlCommand("UpdateJobSumHours", mSqlConnection_O);

               // 2. set the command object so it knows to execute a stored procedure
               SqlCommand_O.CommandType = CommandType.StoredProcedure;

               // 3. add parameter to command, which will be passed to the stored procedure
               SqlCommand_O.Parameters.Add(new SqlParameter("@ComJobID", (int)ComJobID_UL));

               // execute the command
               try
               {
                  Rts_b = (SqlCommand_O.ExecuteNonQuery() == 1);
               }
               catch (SqlException Error_O)
               {
                  System.Diagnostics.Debug.WriteLine("Cannot execute stored procedure UpdateJobSumHours SQL exception.\r\n" + Error_O.ToString());
               }
            }

            return Rts_b;
         }

         //UpdatePathCertif
         //UpdatePathNE
         //UpdatePers
         //UpdatePersStatus
         //UpdateSubDepName
         //UpdateTask
         //UpdateTypeSoc

         

         /// <summary>
         /// Verify if the username exists in database and if password match with it. If it is not the case, the default ID returned is 0 (meaning an error occured).
         /// </summary>
         public UInt32 STPROC_VerifyUser(string Username_ST, string Pwd_ST, out UInt32 UserID_UL, out bool IsManager_b)
         {
            SqlParameter UserID_O = null;
            SqlParameter IsManager_O = null;
            UserID_UL = 0;
            IsManager_b = false;

            if (mConnected_b)
            {
                  // 1. create a command object identifying the stored procedure
                  SqlCommand SqlCommand_O = new SqlCommand("VerifyUser", mSqlConnection_O);

                  // 2. set the command object so it knows to execute a stored procedure
                  SqlCommand_O.CommandType = CommandType.StoredProcedure;

                  // 3. add parameter to command, which will be passed to the stored procedure
                  SqlCommand_O.Parameters.Add(new SqlParameter("@UserLogin", Username_ST));
                  SqlCommand_O.Parameters.Add(new SqlParameter("@Pwd", Pwd_ST));

                  UserID_O = SqlCommand_O.Parameters.Add("@PersId", SqlDbType.Int);
                  UserID_O.Direction = ParameterDirection.Output;

                  IsManager_O = SqlCommand_O.Parameters.Add("@IsManager", SqlDbType.Bit);
                  IsManager_O.Direction = ParameterDirection.Output;

                  // execute the command
                  try
                  {
                     SqlCommand_O.ExecuteNonQuery();
                     UInt32.TryParse(UserID_O.Value.ToString(), out UserID_UL);
                     bool.TryParse(IsManager_O.Value.ToString(), out IsManager_b);
                  }
                  catch (SqlException Error_O)
                  {
                     System.Diagnostics.Debug.WriteLine("Cannot execute stored procedure VerifyUser SQL exception.\r\n" + Error_O.ToString());
                  }
            }

            return UserID_UL;
         }
      }
}
