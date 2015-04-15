
/// <summary>
/// Design and Architecture: Mohammad Ashraful Alam [ashraf@mvps.org]
/// Last update: 27-Mar-2008
/// </summary>
namespace Commands
{
    using System.Data;
    using Utilities;
    using System.Collections;
    
    /// <summary>
    /// Design and Architecture: Mohammad Ashraful Alam [ashraf@mvps.org]
    /// </summary>
    public class FirstLevelBoss
    {
        #region Boss Private Fields

        int _employeeId = GetIdMinValue;
        string _lastName = string.Empty;
        string _firstName = string.Empty;
        string _title = string.Empty;

        #endregion

        #region Boss Constractor

        FirstLevelBoss() { }

        /// <summary>
        /// Used to retrieve employee information from database, 
        /// which is also used by Update method to save information of an existing Employee.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="lastName"></param>
        /// <param name="firstName"></param>
        /// <param name="title"></param>
        FirstLevelBoss
        (
            int employeeId,
            string lastName,
            string firstName,
            string title
        )
        {
            _employeeId = employeeId;
            _lastName = lastName;
            _firstName = firstName;
            _title = title;
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

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

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
        #endregion

        #region Boss Related Collections

        public static CollectionBase GenerateBossCollectionFromReader(IDataReader returnData)
        {

            //creating the instance of Employee collection
            CustomCollection<FirstLevelBoss> colBoss = new CustomCollection<FirstLevelBoss>();

            //Iterating through the data reader, to generate Employee collection.
            //each iteration cause to create a separate instance of Employee and be added to the Employee collection.
            while (returnData.Read())
            {
                FirstLevelBoss newBoss = new FirstLevelBoss
                (
                    returnData["EmployeeId"] == System.DBNull.Value ? GetIdMinValue : (int)returnData["EmployeeId"],
                    returnData["LastName"] == System.DBNull.Value ? string.Empty : (string)returnData["LastName"],
                    returnData["FirstName"] == System.DBNull.Value ? string.Empty : (string)returnData["FirstName"],
                    returnData["Title"] == System.DBNull.Value ? string.Empty : (string)returnData["Title"]
                );

                colBoss.Add(newBoss);
            }

            //returns the collection of Employee objects
            return (colBoss);

        }//GenerateEmployeeCollectionFromReader

        #endregion
    }

    public class SecondLevelBoss
    {
        #region Boss Private Fields

        int _employeeId = GetIdMinValue;
        string _lastName = string.Empty;
        string _firstName = string.Empty;
        string _country = string.Empty;

        #endregion

        #region Boss Constractor

        SecondLevelBoss() { }

        /// <summary>
        /// Used to retrieve employee information from database, 
        /// which is also used by Update method to save information of an existing Employee.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="lastName"></param>
        /// <param name="firstName"></param>
        /// <param name="country"></param>
        SecondLevelBoss
        (
            int employeeId,
            string lastName,
            string firstName,
            string country
        )
        {
            _employeeId = employeeId;
            _lastName = lastName;
            _firstName = firstName;
            _country = country;
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

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public static int GetIdMinValue
        {
            get
            {
                return 0;
            }
        }

        #endregion

        #region Boss Related Collections

        public static CollectionBase GenerateBossCollectionFromReader(IDataReader returnData)
        {

            //creating the instance of Employee collection
            CustomCollection<SecondLevelBoss> colBoss = new CustomCollection<SecondLevelBoss>();

            //Iterating through the data reader, to generate Employee collection.
            //each iteration cause to create a separate instance of Employee and be added to the Employee collection.
            while (returnData.Read())
            {
                SecondLevelBoss newBoss = new SecondLevelBoss
                (
                    returnData["EmployeeId"] == System.DBNull.Value ? GetIdMinValue : (int)returnData["EmployeeId"],
                    returnData["LastName"] == System.DBNull.Value ? string.Empty : (string)returnData["LastName"],
                    returnData["FirstName"] == System.DBNull.Value ? string.Empty : (string)returnData["FirstName"],
                    returnData["Country"] == System.DBNull.Value ? string.Empty : (string)returnData["Country"]
                );

                colBoss.Add(newBoss);
            }

            //returns the collection of Employee objects
            return (colBoss);

        }//GenerateEmployeeCollectionFromReader

        #endregion

    }
}