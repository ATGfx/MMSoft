using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace MMSoft
{
    [Serializable()]
    public class UserConnexionInfo
    {
        public String mUserName_st;
        public bool mPersistSecurityInfo_b;
        public String mDataSource_st;
        public String mIntegratedSecurity_st;
        public String mInitialCatalog_st;
        public bool mMultipleActiveResultSets_b;
        public bool mSaveInfoOnLogin_b;

        public UserConnexionInfo()
        {
            mUserName_st = "";
            mPersistSecurityInfo_b = false;
            mDataSource_st = "SVR2012\\SQLEXPRESS";
            mIntegratedSecurity_st = "SSPI";
            mInitialCatalog_st = "MMSoft";
            mMultipleActiveResultSets_b = true;
            mSaveInfoOnLogin_b = false;
        }

        public void SerializeToFile(String FileName_st)
        {
            TextWriter WriteFileStream_O = null;

            try
            {
                // Create a new XmlSerializer instance with the type of the test class
                XmlSerializer SerializerObj_O = new XmlSerializer(typeof(UserConnexionInfo));

                // Create a new file stream to write the serialized object to a file
                WriteFileStream_O = new StreamWriter(FileName_st);
                SerializerObj_O.Serialize(WriteFileStream_O, this);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Error while serializing file " + FileName_st + "\n" + e.Message);
            }

            if (WriteFileStream_O != null)
            {
                WriteFileStream_O.Close();
            }
        }

        public static UserConnexionInfo DeserializeFromFile(String FileName_st)
        {
            UserConnexionInfo LoadedObj_O = null;

            FileStream ReadFileStream_O = null;

            try
            {
                // Create a new XmlSerializer instance with the type of the test class
                XmlSerializer SerializerObj_O = new XmlSerializer(typeof(UserConnexionInfo));

                // Create a new file stream for reading the XML file
                ReadFileStream_O = new FileStream(FileName_st, FileMode.Open, FileAccess.Read, FileShare.Read);

                // Load the object saved above by using the Deserialize function
                LoadedObj_O = (UserConnexionInfo)SerializerObj_O.Deserialize(ReadFileStream_O);                
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Error while deserializing file " + FileName_st + "\n" + e.Message);
            }

            if (ReadFileStream_O != null)
            {
                ReadFileStream_O.Close();
            }

            return LoadedObj_O;
        }
    }
}
