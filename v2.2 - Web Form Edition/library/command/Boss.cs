namespace Commands
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Collections;
    using Utilities;
    /// <summary>
    /// Design and Architecture: Mohammad Ashraful Alam [ashraf@mvps.org]
    /// Last update: 27-Mar-2008
    /// </summary>
    public class Boss
    {
        #region Boss Private Fields

        int _employeeId = GetIdMinValue;
        string _lastName = string.Empty;
        string _firstName = string.Empty;
        int _bossId = GetIdMinValue;
        string _bossLastName = string.Empty;
        string _bossFirstName = string.Empty;

        #endregion

        #region Boss Constractor

        Boss() { }

        /// <summary>
        /// Used to retrieve employee information from database, 
        /// which is also used by Update method to save information of an existing Employee.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="lastName"></param>
        /// <param name="firstName"></param>
        /// <param name="bossId"></param>
        /// <param name="bossLastName"></param>
        /// <param name="bossFirstName"></param>
        Boss
        (
            int employeeId,
            string lastName,
            string firstName,
            int bossId,
            string bossLastName,
            string bossFirstName
        )
        {
            _employeeId = employeeId;
            _lastName = lastName;
            _firstName = firstName;
            _bossId = bossId;
            _bossLastName = bossLastName;
            _bossFirstName = bossFirstName;
        }

        #endregion

        #region Boss Properties

        /***********************************************************************************************
                                    -- PROPERTIES --        
         Contains all the properties representing the data fields of the current entity.
         ***********************************************************************************************/

        public int EmployeeId
        {
            get { return _employeeId; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public int BossId
        {
            get { return _bossId; }
        }

        public string BossLastName
        {
            get { return _bossLastName; }
            set { _bossLastName = value; }
        }

        public string BossFirstName
        {
            get { return _bossFirstName; }
            set { _bossFirstName = value; }
        }

        #endregion

        #region GET Methods

        //Utils.GenerationCommandType.CustomEntitySingleRecord
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static Boss GetEmployeeBossByEmployeeId(int employeeId)
        {
            if (employeeId < GetIdMinValue)
                throw (new ArgumentOutOfRangeException("employeeId"));

            // Execute SQL Command
            SqlCommand sqlCmd = new SqlCommand();
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@employeeId", SqlDbType.Int, 0, ParameterDirection.Input, employeeId);
            DatabaseUtility.SetCommandType(sqlCmd, CommandType.StoredProcedure, SP_CUSTOM_EMPLOYEES_GETEMPLOYEEBOSSBYEMPLOYEEID);
            GenerateCollectionFromReader test = new GenerateCollectionFromReader(GenerateBossCollectionFromReader);
            CustomCollection<Boss> objCollection = ((CustomCollection<Boss>)DatabaseUtility.ExecuteReaderCmd(sqlCmd, test));

            if (objCollection.Count > 0)
                return objCollection[0];
            else
                return null;
        }

        //Utils.GenerationCommandType.CustomEntityTabular
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static CustomCollection<Boss> SelectAllEmployeeBosses()
        {
            // Execute SQL Command
            SqlCommand sqlCmd = new SqlCommand();
            DatabaseUtility.SetCommandType(sqlCmd, CommandType.StoredProcedure, SP_CUSTOM_EMPLOYEES_GETALLEMPLOYEEBOSSES);
            GenerateCollectionFromReader test = new GenerateCollectionFromReader(GenerateBossCollectionFromReader);
            CustomCollection<Boss> objCollection = ((CustomCollection<Boss>)DatabaseUtility.ExecuteReaderCmd(sqlCmd, test));

            return objCollection;
        }

        /// <summary>
        /// The sample below retutns a set of tabular data, getting the data tables dynamically
        /// for this run time solution we need to use the set of data collection with EXACT same set of 'data fields'
        /// </summary>
        /// <returns></returns>
        //Utils.GenerationCommandType.CustomEntityTabularCollection
        public static ArrayList SelectTwoLevelBossesSameCustomEntity()
        {
            IDataReader myDataReader;

            // Execute SQL Command

            SqlConnection cn = new SqlConnection(ConnectionStringManager.DefaultDBConnectionString);
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = cn;
            DatabaseUtility.SetCommandType(sqlCmd, CommandType.StoredProcedure, SP_CUSTOM_EMPLOYEES_GETALLEMPLOYEEBOSSES);
            cn.Open();

            myDataReader = sqlCmd.ExecuteReader();
            ArrayList customEntitySet = new ArrayList();

            do
            {
                CollectionBase objCollection = Boss.GenerateBossCollectionFromReader(myDataReader);
                customEntitySet.Add(objCollection);
            }
            while (myDataReader.NextResult());

            cn.Close();

            return customEntitySet;

        }

        #endregion

        #region Boss Related Collections

        /// <summary>
        /// Creates and returns a strongly typed collection of Employee custom entity. 
        /// The collection is created through iterating on the IdataReader object which contains Employee information, as a set of records, similar to tabular format.
        /// </summary>
        /// <param name="returnData">Contains the data retrieved from database.</param>
        /// <returns>A collection of Employee custom entity.</returns>
        public static CollectionBase GenerateBossCollectionFromReader(IDataReader returnData)
        {

            //creating the instance of Employee collection
            CustomCollection<Boss> colBoss = new CustomCollection<Boss>();

            /************************* Architecture note:**********************************
             * Below code includes the null value functionality to retrieve the data which has nill value in database end.
             * Design consideration:
             * Besides general data fields, special care should be taken for primary keys, to assign '0'/default value, rather passing 'Null' value in constructor parameter.
             * Although we are considering sqldb type data for the current data container, but while retrieving data from database end, through datareader object, we need to cast data reader objects using .net primitive data type, 
             * rather using sqldb type to cast, since data reader objects don't support sql db type to be casted.
             *****************************************************************************/

            //Iterating through the data reader, to generate Employee collection.
            //each iteration cause to create a separate instance of Employee and be added to the Employee collection.
            while (returnData.Read())
            {
                Boss newBoss = new Boss
                (
                    returnData["EmployeeId"] == System.DBNull.Value ? GetIdMinValue : (int)returnData["EmployeeId"],
                    returnData["LastName"] == System.DBNull.Value ? string.Empty : (string)returnData["LastName"],
                    returnData["FirstName"] == System.DBNull.Value ? string.Empty : (string)returnData["FirstName"],
                    returnData["BossId"] == System.DBNull.Value ? GetIdMinValue : (int)returnData["BossId"],
                    returnData["BossLastName"] == System.DBNull.Value ? string.Empty : (string)returnData["BossLastName"],
                    returnData["BossFirstName"] == System.DBNull.Value ? string.Empty : (string)returnData["BossFirstName"]
                );

                colBoss.Add(newBoss);
            }

            //returns the collection of Employee objects
            return (colBoss);

        }//GenerateEmployeeCollectionFromReader

        #endregion

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
        internal const string SP_CUSTOM_EMPLOYEES_GETALLEMPLOYEEBOSSES = "Custom_Employees_GetAllEmployeeBosses";
        internal const string SP_CUSTOM_EMPLOYEES_GETEMPLOYEEBOSSBYEMPLOYEEID = "Custom_Employees_GetEmployeeBossByEmployeeId";

        #endregion
    }
}
