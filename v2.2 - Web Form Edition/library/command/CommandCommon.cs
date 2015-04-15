namespace Commands
{
    using System;
    using System.Data;
    using Utilities;
    using System.Data.SqlClient;
    using System.Collections;

    /// <summary>
    /// Design and Architecture: Mohammad Ashraful Alam [ashraf@mvps.org]
    /// The Command Wrapper Data Access Layer contains a verity of ways to perform custom Crud operation efficiently. However, please note that, Command Wrapper code samples have provided only for demonstration purpose in this starter kit and not been used by user interface level. 
    /// Last update: 20-apr-2009
    /// </summary>
    public sealed class CommandCommon
    {
        private CommandCommon() { }

        /// <summary>
        /// Scalar Value: illustrates how to retrieve scalar (single value) data from database.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        ///Utils.GenerationCommandType.ScalarValue
        public static string GetFirstNameByEmployeeId (int employeeId)
        {
            if (employeeId < GetIdMinValue)
                throw (new ArgumentOutOfRangeException("employeeId"));

            // Execute SQL Command
            SqlCommand sqlCmd = new SqlCommand();

            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@employeeId", SqlDbType.Int, 0, ParameterDirection.Input, employeeId);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@ReturnVal", SqlDbType.NVarChar, 10, ParameterDirection.Output, null);
            DatabaseUtility.SetCommandType(sqlCmd, CommandType.StoredProcedure, SP_CUSTOM_EMPLOYEES_GETEMPLOYEEFIRSTNAME_BY_EMPLOYEEID);
            
            //executing the command
            DatabaseUtility.ExecuteScalarCmd(sqlCmd);

            string returnValue = (string)sqlCmd.Parameters["@ReturnVal"].Value;
            return returnValue;
        }

        /// <summary>
        /// sample custom method for get
        /// returns a collection for records of DataTable type
        /// Generic Data Table: illustrates how to retrieve a collection of data from database and populate it to a .NET generic DataTable instance.
        /// </summary>
        /// <param name="reportsTo"></param>
        /// <returns></returns>
        ///Utils.GenerationCommandType.GenericDataTable
        public static DataTable GetEmployeesByReportsTo(int reportsTo)
        {
            DataSet ds = new DataSet();
            ds.Locale = System.Globalization.CultureInfo.CurrentCulture;

            using (SqlConnection cn = new SqlConnection(ConnectionStringManager.DefaultDBConnectionString))
            {
                //sql command
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = cn;
                DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@ReportsTo", SqlDbType.Int, 0, ParameterDirection.Input, reportsTo);
                DatabaseUtility.SetCommandType(sqlCmd, CommandType.StoredProcedure, SP_EMPLOYEES_GETEMPLOYEES_BY_REPORTSTO);

                //adapter 
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = sqlCmd;
                adapter.Fill(ds);
            }
            
            return ds.Tables[0];
        }

        /// <summary>
        /// sample custom method for get
        /// returns a collection for data tables tables of DataSet type
        /// Generic DataSet: illustrates how to retrieve a collection of data from database and populate it to a .NET generic DataSet instance.
        /// </summary>
        /// <returns></returns>
        ///Utils.GenerationCommandType.GenericDataSet
        public static DataSet SelectTwoLevelBossesDataSet()
        {
            DataSet ds = new DataSet();
            ds.Locale = System.Globalization.CultureInfo.CurrentCulture;

            using (SqlConnection cn = new SqlConnection(ConnectionStringManager.DefaultDBConnectionString))
            {
                //sql command
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = cn;
                DatabaseUtility.SetCommandType(sqlCmd, CommandType.StoredProcedure, SP_CUSTOM_EMPLOYEES_GETTWOLEVELBOSSES);

                //adapter 
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = sqlCmd;
                adapter.Fill(ds);
            }

            ds.Tables[0].TableName = "firstlevel";
            ds.Tables[1].TableName = "secondlevel";
            return ds;
        }

        //Utils.GenerationCommandType.CustomEntityTabularCollection
        public static ArrayList SelectTwoLevelBossesCustomEntity()
        {
            IDataReader myDataReader;

            // Execute SQL Command

            SqlConnection cn = new SqlConnection(ConnectionStringManager.DefaultDBConnectionString);
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = cn;
            DatabaseUtility.SetCommandType(sqlCmd, CommandType.StoredProcedure, SP_CUSTOM_EMPLOYEES_GETTWOLEVELBOSSES);
            cn.Open();
            
            myDataReader = sqlCmd.ExecuteReader();

            CustomCollection<FirstLevelBoss> objFirstLevelBossCollection = (CustomCollection<FirstLevelBoss>)FirstLevelBoss.GenerateBossCollectionFromReader(myDataReader);

            //moving the data reader for next result set
            myDataReader.NextResult();

            CustomCollection<SecondLevelBoss> objSecondLevelBossCollection = (CustomCollection<SecondLevelBoss>)SecondLevelBoss.GenerateBossCollectionFromReader(myDataReader);

            ArrayList customEntitySet = new ArrayList();

            customEntitySet.Add(objFirstLevelBossCollection);
            customEntitySet.Add(objSecondLevelBossCollection);

            cn.Close();

            return customEntitySet;

        }

        #region Constants and Default Values

        /// <summary>
        /// This property is being used by the crud methods, to validate EmployeeId parameter 
        /// </summary>
        public static int GetIdMinValue
        {
            get
            {
                return 0;
            }
        }

        // -- get method related constants -- //
        internal const string SP_EMPLOYEES_GETEMPLOYEES_BY_REPORTSTO = "Employees_GetEmployeesByReportsTo";
        internal const string SP_CUSTOM_EMPLOYEES_GETEMPLOYEEFIRSTNAME_BY_EMPLOYEEID = "Custom_Employees_GetEmployeeFirstNameByEmployeeId";
        internal const string SP_CUSTOM_EMPLOYEES_GETTWOLEVELBOSSES = "Custom_Employees_GetTwoLevelBosses";

        // -- write method related constants -- //
                
        #endregion
    }
}
