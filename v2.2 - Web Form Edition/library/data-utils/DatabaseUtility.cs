using System;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.IO;
using System.Configuration;

namespace Utilities
{
    #region GenerateCollectionFromReader Delegate

    /// <summary>
    /// The GenerateCollectionFromReader delegate represents any method which returns a collection from a Data Reader.
    /// Generating data collections [corresponding to dtata table] makes it more usable.
    /// This will return the corresponding data collections, by transforming the passed data reader object
    /// </summary>
    public delegate CollectionBase GenerateCollectionFromReader(IDataReader returnData);

    #endregion
    /// <summary>
    /// Contains necessary properties, methods and delegates regarding database operation.
    /// This class is extensively used by the custom business entity classes.
    /// Custom entities can use this class through the static method call or inheriting the database utility class.
    /// However, for the collection generator delegate, the classes must have to be inherited for this class.
    /// Class architecture designed by: Mohammad Ashraful Alam [ ashraf@mvps.org ]
    /// </summary>
    public sealed class DatabaseUtility
    {
        private DatabaseUtility() { }
        

        #region SQL Helper methods

        //*********************************************************************
        //
        // SQL Helper Methods
        //
        // The following utility methods are used to interact with SQL Server.
        //
        //*********************************************************************
        /// <summary>
        /// this method adds parameters to SQL command
        /// </summary>
        /// <param name="sqlCmd">sql command</param>
        /// <param name="paramId">parameter id</param>
        /// <param name="sqlType">sql server data type</param>
        /// <param name="paramSize">parameter size</param>
        /// <param name="paramDirection">parameter direction [in/out]</param>
        /// <param name="paramvalue">paramter value</param>
        public static void AddParameterToSqlCmd(SqlCommand sqlCmd, string parameterId, SqlDbType sqlType, int parameterSize, ParameterDirection parameterDirection, object parameterValue)
        {
            // Validate Parameter Properties
            if (sqlCmd == null)
                throw (new ArgumentNullException("sqlCmd"));
            if (parameterId == null)
                throw (new ArgumentNullException("parameterId"));
            if (parameterId.Length == 0)
                throw (new ArgumentOutOfRangeException("parameterId"));

            if (parameterValue == null)
                parameterValue = DBNull.Value;

            // Add Parameter
            SqlParameter newSqlParam = new SqlParameter();
            newSqlParam.ParameterName = parameterId;
            newSqlParam.SqlDbType = sqlType;
            newSqlParam.Direction = parameterDirection;

            if (parameterSize > 0)
                newSqlParam.Size = parameterSize;

            if (parameterValue != null)
                newSqlParam.Value = parameterValue;

            sqlCmd.Parameters.Add(newSqlParam);
        }

        /// <summary>
        /// Executes am scalar command.
        /// If no connection string is provided, Default database is assumed.
        /// </summary>
        /// <param name="sqlCmd">sql command</param>
        /// <returns>A single scalar value.</returns>
        public static Object ExecuteScalarCmd(SqlCommand sqlCmd)
        {
            if (sqlCmd == null)
                throw (new ArgumentNullException("sqlCmd"));

            return ExecuteScalarCmd(sqlCmd, ConnectionStringManager.DefaultDBConnectionString);
        }
        
        /// <summary>
        /// Executes a scalar command, and returns the result as an object
        /// </summary>
        /// <param name="sqlCmd">sql command</param>
        /// <returns>A single scalar value.</returns>
        public static Object ExecuteScalarCmd(SqlCommand sqlCmd, string connectionString)
        {
            // Validate Command Properties

            if (connectionString == null)
                throw (new ArgumentNullException("connectionString"));

            if ( connectionString.Length == 0)
                throw (new ArgumentOutOfRangeException("connectionString"));

            if (sqlCmd == null)
                throw (new ArgumentNullException("sqlCmd"));

            Object result = null;

            //The using block causes to close the data connection properly after the command execution.

                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    sqlCmd.Connection = cn;
                    cn.Open();
                    result = sqlCmd.ExecuteScalar();
                   
                }
            

            return result;
        }

        /// <summary>
        /// Executes a reader command, and returns the result as a collection of object.
        /// If no connection string is provided, Default database is assumed.
        /// </summary>
        /// <param name="sqlCmd">sql command</param>
        /// <param name="generateCollectionDelegateObject">The collection generator method delegate. 
        /// The passed delegate object will be used to call the appropriate collection generator method from the caller class.</param>
        /// <returns>The object collection.</returns>
        public static CollectionBase ExecuteReaderCmd(SqlCommand sqlCmd, GenerateCollectionFromReader generateCollectionDelegateObject)
        {
            if (generateCollectionDelegateObject == null)
                throw (new ArgumentNullException("generateCollectionDelegateObject"));

            if (sqlCmd == null)
                throw (new ArgumentNullException("sqlCmd"));

            return ExecuteReaderCmd(sqlCmd, generateCollectionDelegateObject, ConnectionStringManager.DefaultDBConnectionString);
        }
        
        /// <summary>
        /// this is the basic method that will be used by the underlying instance TestObjects.
        /// </summary>
        /// <param name="sqlCmd">sql command</param>
        /// <param name="generateCollectionDelegateObject">The collection generator method delegate. 
        /// The passed delegate object will be used to call the appropriate collection generator method from the caller class.</param>
        /// <returns>The object collection.</returns>
        public static CollectionBase ExecuteReaderCmd(SqlCommand sqlCmd, GenerateCollectionFromReader generateCollectionDelegateObject, string connectionString)
        {
            if (connectionString == null)
                throw (new ArgumentNullException("connectionString"));

            if (connectionString.Length == 0)
                throw (new ArgumentOutOfRangeException("connectionString"));

            if ( generateCollectionDelegateObject == null)
                throw (new ArgumentNullException("generateCollectionDelegateObject"));

            if (sqlCmd == null)
                throw (new ArgumentNullException("sqlCmd"));

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                sqlCmd.Connection = cn;
                cn.Open();
                CollectionBase temp = generateCollectionDelegateObject(sqlCmd.ExecuteReader());
                return (temp);
            }
        }

        /// <summary>
        /// Sets the SQL command type.
        /// </summary>
        /// <param name="sqlCmd">sql command</param>
        /// <param name="cmdType">command type [stored procedure/direct table/text]</param>
        /// <param name="cmdText">command text to be executed</param>
        public static void SetCommandType(DbCommand sqlCmd, CommandType cmdType, string cmdText)
        {
            if (cmdText == null)
                throw (new ArgumentNullException("cmdText"));

            if (sqlCmd == null)
                throw (new ArgumentNullException("sqlCmd"));

            sqlCmd.CommandType = cmdType;
            sqlCmd.CommandText = cmdText;
        }

        #endregion

        /// <summary>
        /// Formats the passed numbers with xml string, with <Id> tag, so that 
        /// there numbers can be parsed by SQL Server 2005 stored procedures as an array of Id's.
        /// </summary>
        /// <param name="idsToList">list of IDs to be deleted</param>
        /// <returns>formated xml as string, generated from the ID list</returns>
        public static string FormatXmlForIdArray(Collection<int> idsToList)
        {
            //converting the list to xml first
            StringBuilder xmlString = new StringBuilder();
            for (int i = 0; i < idsToList.Count; i++)
            {
                xmlString.AppendFormat("<Id>{0}</Id>", idsToList[i]);
            }

            return xmlString.ToString();
        }

        /// <summary>
        /// Formats the passed numbers with xml string, with <Id> tag, so that 
        /// there numbers can be parsed by SQL Server 2005 stored procedures as an array of Id's.
        /// </summary>
        /// <param name="idsToList">list of IDs to be deleted</param>
        /// <returns>formated xml as string, generated from the ID list</returns>
        public static string FormatXmlForIdArray(Collection<Guid> idsToList)
        {
            //converting the list to xml first
            StringBuilder xmlString = new StringBuilder();
            for (int i = 0; i < idsToList.Count; i++)
            {
                xmlString.AppendFormat("<Id>{0}</Id>", idsToList[i]);
            }

            return xmlString.ToString();
        }

        /// <summary>
        /// Formats the passed numbers with xml string, with <Id> tag, so that 
        /// there numbers can be parsed by SQL Server 2005 stored procedures as an array of Id's.
        /// </summary>
        /// <param name="idsToList">list of IDs to be deleted</param>
        /// <returns>formated xml as string, generated from the ID list</returns>
        public static string FormatXmlForIdArray(Collection<string> idsToList)
        {
            //converting the list to xml first
            StringBuilder xmlString = new StringBuilder();
            for (int i = 0; i < idsToList.Count; i++)
            {
                xmlString.AppendFormat("<Id>{0}</Id>", idsToList[i]);
            }

            return xmlString.ToString();
        }

    }

    public sealed class SqlScriptUtility
    {
        SqlScriptUtility() { }

        public static bool CreateDatabase(string dbName, string connectionString)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandText = "USE master CREATE DATABASE " + dbName;
                sqlCmd.CommandType = CommandType.Text;
                DatabaseUtility.ExecuteScalarCmd(sqlCmd, connectionString);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void RunScript(string scriptPath)
        {
            SqlCommand sqlCmd = new SqlCommand();

            sqlCmd.CommandText = ReadDataFromFile(scriptPath);
            sqlCmd.CommandType = CommandType.Text;
            DatabaseUtility.ExecuteScalarCmd(sqlCmd);
        }

        public static string ReadDataFromFile(string filePath)
        {
            FileStream fStream;

            // Reading the file content.
            fStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sReader = new StreamReader(fStream);
            string line = sReader.ReadToEnd();
            sReader.Close();

            return line;
        }
    }
}
