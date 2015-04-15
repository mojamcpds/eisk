using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Utilities;
using System.Collections.ObjectModel;

namespace Entity
{
    /// <summary>
    /// This class represents an Employee object, which is responsible for Create, Read, Update & Delete (CRUD) operations of an Employee entity.
    /// This class also includes the collection generator utility method for Employee entity, which is required to Create strong typed data container for a set/collection of employees.
    /// In this starter kit, we have only one entity, named “Employee” for which we have a database table named “Employees”. The entity based data access layer for this entity contains all of the required and common data access logics that can be typically generated using a code generator. 
    /// Design and Architecture: Mohammad Ashraful Alam [ashraf@mvps.org]
    /// 
    /// Major considerations:
    /// (1): Uses custom entity model, for faster data operation.
    /// (2): Using primitive type as data field types
    /// (3): Secured approach regarding primary key (which is read-only) to retrieve and update object. 
    /// (4): Data validation
    /// (5): Utilizing well modeled database utility to reduce lines of codes for data operation
    /// (6): Utilizing generic class to reduce lines of codes regarding custom entity class collection.
    /// (7): Encapsulating names of all the stored procedure used for the entity below, as constant fields
    /// (8): XML commentation for methods
    /// (9): Efficient paging support
    /// (10): Batch delete support
    /// (11): Design time support for Object Data Source
    /// Last update: 20-apr-2009
    /// </summary>
    //[System.ComponentModel.DataObject]
    public class Employee
    {
        #region Employee Private Fields

        /************************* Architecture note:**********************************
         * Instruction: 
         * For primary key, it is set the default value of private data of data field as zero.
         ****************************************************************************/

        int _employeeId = SelectEmployeeIdMinValue;
        string _lastName;
        string _firstName;
        string _title;
        string _titleOfCourtesy;
        DateTime? _birthDate;//is set to allow null in underlying database table field
        DateTime _hireDate;
        string _address;
        string _city;
        string _region;
        string _postalCode;
        string _country;
        string _homePhone;
        string _extension;
        byte[] _photo;
        string _notes;
        int? _reportsTo;//is set to allow null in underlying database table field
        string _photoPath;

        #endregion

        #region Employee Constractor

        /// <summary>
        /// Creates an empty object of Employee. 
        /// This is mainly used to create a new instance of Employee to add a new Employee.
        /// </summary>
        public Employee() { }

        /// <summary>
        /// Used to retrieve employee information from database, 
        /// which is also used by Update method to save information of an existing Employee.
        /// </summary>
        /// <param name="employeeId">Id of the employee</param>
        /// <param name="lastName">Employee's last name</param>
        /// <param name="firstName">Employee's first name</param>
        /// <param name="title">Title of the Employee</param>
        /// <param name="titleOfCourtesy">Employee's title of courtesy</param>
        /// <param name="birthDate">Employee's birth date</param>
        /// <param name="hireDate">Employee's joining date in the job</param>
        /// <param name="address">Employee's home address</param>
        /// <param name="city">Employee's home city</param>
        /// <param name="region">Employee's home region</param>
        /// <param name="postalCode">Employee's home postal code</param>
        /// <param name="country">Employee's home country</param>
        /// <param name="homePhone">Employee's contact phone</param>
        /// <param name="extension">Employee's photo extension (.jpg/.gif/.png)</param>
        /// <param name="photo">Employee's photo (binary data)</param>
        /// <param name="notes">Note about employee</param>
        /// <param name="reportsTo">Employee's boss</param>
        /// <param name="photoPath">Employee's photo path (if stored as physical file)</param>
        public Employee
        (
            int employeeId,
            string lastName,
            string firstName,
            string title,
            string titleOfCourtesy,
            DateTime? birthDate,
            DateTime hireDate,
            string address,
            string city,
            string region,
            string postalCode,
            string country,
            string homePhone,
            string extension,
            byte[] photo,
            string notes,
            int? reportsTo,
            string photoPath
        )
        {
            EmployeeId = employeeId;
            LastName = lastName;
            FirstName = firstName;
            Title = title;
            TitleOfCourtesy = titleOfCourtesy;
            BirthDate = birthDate;
            HireDate = hireDate;
            Address = address;
            City = city;
            Region = region;
            PostalCode = postalCode;
            Country = country;
            HomePhone = homePhone;
            Extension = extension;
            Photo = photo;
            Notes = notes;
            ReportsTo = reportsTo;
            PhotoPath = photoPath;
        }

        #endregion

        #region Employee Properties

        /***********************************************************************************************
                                    -- PROPERTIES --        
         Contains all the properties representing the data fields of the current entity.
         ***********************************************************************************************/

        /// <summary>
        /// This is the Primary key value of the EmployeeId, which can't be assigned from the application,
        /// to ensure the data consistency, by not letting the user to change the EmployeeId to update the data of an another Employee instance.
        /// For view or updating purpose, every Employee will be retrieved thru the proper 'Get' method.
        /// </summary>
        public int EmployeeId
        {
            get { return _employeeId; }
            set { _employeeId = value; }
        }

        public string LastName
        {
            get
            {
                //if (_lastName == null) throw new InvalidOperationException();
                return _lastName;
            }
            set 
            {
                if (string.IsNullOrEmpty(value)) throw new InvalidOperationException();
                _lastName = value; 
            }
        }

        public string FirstName
        {
            get 
            {
                //if (_firstName == null) throw new InvalidOperationException();
                return _firstName; 
            }
            set 
            {
                if (string.IsNullOrEmpty(value)) throw new InvalidOperationException();
                _firstName = value; 
            }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string TitleOfCourtesy
        {
            get { return _titleOfCourtesy; }
            set { _titleOfCourtesy = value; }
        }

        public DateTime? BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        public DateTime HireDate
        {
            get
            {
                if (_hireDate == DateTime.MinValue) throw new InvalidOperationException();
                return _hireDate;
            }
            set 
            {
                if (value == DateTime.MinValue) throw new InvalidOperationException();
                _hireDate = value; 
            }
        }

        public string Address
        {
            get
            {
                //if (_address == null) throw new InvalidOperationException();
                return _address;
            }
            set 
            {
                if (string.IsNullOrEmpty(value)) throw new InvalidOperationException();
                _address = value; 
            }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string Region
        {
            get { return _region; }
            set { _region = value; }
        }

        public string PostalCode
        {
            get { return _postalCode; }
            set { _postalCode = value; }
        }

        public string Country
        {
            get
            {
                if (_country == null) throw new InvalidOperationException();
                return _country;
            }
            set 
            {
                if (value == null) throw new InvalidOperationException();
                _country = value; 
            }
        }

        public string HomePhone
        {
            get
            {
                if (_homePhone == null) throw new InvalidOperationException();
                return _homePhone;
            }
            set 
            {
                if (value == null) throw new InvalidOperationException();
                _homePhone = value; 
            }
        }

        public string Extension
        {
            get { return _extension; }
            set { _extension = value; }
        }

        public byte[] Photo
        {
            get { return _photo; }
            set { _photo = value; }
        }

        public string Notes
        {
            get { return _notes; }
            set { _notes= value; }
        }

        public int? ReportsTo
        {
            get { return _reportsTo; }
            set { _reportsTo = value; }
        }

        public string PhotoPath
        {
            get { return _photoPath; }
            set { _photoPath = value; }
        }

        #endregion

        #region Employee Static Methods

        /************************************************************************************
                                    -- CREATE METHOD (STATIC) --
        *************************************************************************************/

        /************************* Architecture note:**********************************
        Note 1:
        This method is specially useful for the case, where we need to use Object Data Source controls.
        For ObjectDataSource/SqlDataSource controls, the insert/update method requires parameters methods, rather property based methods.
        However, there is still a way to pass property based objects as method parameter for data source controls, 
        but in that case we could not use Sql type, as view controls or asp parameter control can only contain few of primitive type.
        The main reason to remain the Sql Type in our object architecture is it is faster and contains better way for null value support.
        
        Note 2: 
        Non-primary key: it should be primitive type, as the asp parameter control (included in data source control) supports only primitive types.
        /*****************************************************************************/
        /// <summary>
        /// Inserts an employee
        /// </summary>
        /// <param name="lastName">Employee's last name</param>
        /// <param name="firstName">Employee's first name</param>
        /// <param name="title">Title of the Employee</param>
        /// <param name="titleOfCourtesy">Employee's title of courtesy</param>
        /// <param name="birthDate">Employee's birth date</param>
        /// <param name="hireDate">Employee's joining date in the job</param>
        /// <param name="address">Employee's home address</param>
        /// <param name="city">Employee's home city</param>
        /// <param name="region">Employee's home region</param>
        /// <param name="postalCode">Employee's home postal code</param>
        /// <param name="country">Employee's home country</param>
        /// <param name="homePhone">Employee's contact phone</param>
        /// <param name="extension">Employee's photo extension (.jpg/.gif/.png)</param>
        /// <param name="photo">Employee's photo (binary data)</param>
        /// <param name="notes">Note about employee</param>
        /// <param name="reportsTo">Employee's boss</param>
        /// <param name="photoPath">Employee's photo path (if stored as physical file)</param>
        /// <returns>Returns the primary key of the newly inserted record</returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public static int CreateNewEmployee(string lastName, string firstName, string title, 
            string titleOfCourtesy, DateTime? birthDate, DateTime hireDate, 
            string address, string city, string region, string postalCode,
            string country, string homePhone, string extension, byte[] photo, string notes,
            int? reportsTo, string photoPath
            )
        {
            //creating an empty employee object
            Employee employee = new Employee();

            //filling the data in the data container
            employee.LastName = lastName;
            employee.FirstName = firstName;
            employee.Title = title;
            employee.TitleOfCourtesy = titleOfCourtesy;
            employee.BirthDate = birthDate;
            employee.HireDate = hireDate;
            employee.Address = address;
            employee.City = city;
            employee.Region = region;
            employee.PostalCode = postalCode;
            employee.Country = country;
            employee.HomePhone = homePhone;
            employee.Extension = extension;
            employee.Photo = photo;
            employee.Notes = notes;
            employee.ReportsTo = reportsTo;
            employee.PhotoPath = photoPath;

            //perform insertion via object and retiring the status
            return Employee.CreateNewEmployee(employee);
        }

        

        /************************************************************************************
                 -- UPDATE METHOD (STATIC) --
        *************************************************************************************/

        /************************* Architecture note:**********************************
        Note 1:
        This method is specially useful for the case, where we need to use Object Data Source controls.
        For ObjectDataSource/SqlDataSource controls, the insert/update method requires parameters methods, rather property based methods.
        However, there is still a way to pass property based objects as method parameter for data source controls, 
        but in that case we could not use Sql type, as view controls or asp parameter control can only contain few of primitive type.
        The main reason to remain the Sql Type in our object architecture is it is faster and contains better way for null value support.
        
        Note 2: 
        There the two types of parameters will be passed here.
         * a. Primary key parameter: it should be Sql type, as we will bind the primary key property for the view controls (form view, details view etc) as datakey.
         * b. Non-primary key: it should be primitive type, as the asp parameter control (included in data source control) supports only primitive types.
        /*****************************************************************************/
        /// <summary>
        /// Updates an Employee
        /// </summary>
        /// <param name="employeeId">Id of the employee</param>
        /// <param name="lastName">Employee's last name</param>
        /// <param name="firstName">Employee's first name</param>
        /// <param name="title">Title of the Employee</param>
        /// <param name="titleOfCourtesy">Employee's title of courtesy</param>
        /// <param name="birthDate">Employee's birth date</param>
        /// <param name="hireDate">Employee's joining date in the job</param>
        /// <param name="address">Employee's home address</param>
        /// <param name="city">Employee's home city</param>
        /// <param name="region">Employee's home region</param>
        /// <param name="postalCode">Employee's home postal code</param>
        /// <param name="country">Employee's home country</param>
        /// <param name="homePhone">Employee's contact phone</param>
        /// <param name="extension">Employee's photo extension (.jpg/.gif/.png)</param>
        /// <param name="photo">Employee's photo (binary data)</param>
        /// <param name="notes">Note about employee</param>
        /// <param name="reportsTo">Employee's boss</param>
        /// <param name="photoPath">Employee's photo path (if stored as physical file)</param>
        /// <returns>Returns status of the update (True - success /False -  failure)</returns>

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        public static bool UpdateEmployee(int employeeId, 
            string lastName, string firstName, string title, 
            string titleOfCourtesy, DateTime? birthDate, DateTime hireDate, 
            string address, string city, string region, string postalCode,
            string country, string homePhone, string extension, byte[] photo, string notes,
            int? reportsTo, string photoPath)
        {
            //creating an empty employee object
            Employee employee = Employee.GetEmployeeByEmployeeId((int)employeeId);

            //filling the data in the data container
            employee.LastName = lastName;
            employee.FirstName = firstName;
            employee.Title = title;
            employee.TitleOfCourtesy = titleOfCourtesy;
            employee.BirthDate = birthDate;
            employee.HireDate = hireDate;
            employee.Address = address;
            employee.City = city;
            employee.Region = region;
            employee.PostalCode = postalCode;
            employee.Country = country;
            employee.HomePhone = homePhone;
            employee.Extension = extension;
            employee.Photo = photo;
            employee.Notes = notes;
            employee.ReportsTo = reportsTo;
            employee.PhotoPath = photoPath;
            
            //performs updating via object and returning the status
            return Employee.UpdateEmployee(employee);
        }      

        /************************************************************************************
                         -- DELETE METHODS --
        *************************************************************************************/

        /************************* Architecture note:**********************************
        We have used the employeeId parameter as int, to bind the delete method with object data source and view control directly.
        ****************************************************************************/
        /// <summary>
        /// Deletes an Employee from the database.
        /// </summary>
        /// <param name="employeeId">This is the primary key which is used to remove an employee from the database</param>
        /// <returns>The success status, whether the deletion process of an Employee is successful or not.</returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public static bool DeleteEmployee(int employeeId)
        {
            //Validate Input
            if (employeeId <= SelectEmployeeIdMinValue)
                throw (new ArgumentOutOfRangeException("employeeId"));

            // Execute SQL Command
            SqlCommand sqlCmd = new SqlCommand();

            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@ReturnValue", SqlDbType.Int, 0, ParameterDirection.ReturnValue, null);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@EmployeeId", SqlDbType.Int, 0, ParameterDirection.Input, employeeId);
            DatabaseUtility.SetCommandType(sqlCmd, CommandType.StoredProcedure, SP_EMPLOYEES_DELETE);
            DatabaseUtility.ExecuteScalarCmd(sqlCmd);

            //returns the number of affected rows
            int returnValue = (int)sqlCmd.Parameters["@ReturnValue"].Value;
            return (returnValue == 0 ? false : true);
        }

        /// <summary>
        /// Deletes a set of employees from the database.
        /// </summary>
        /// <param name="employessIdsToDelete">List of employee's ID to be deleted</param>
        /// <returns>Result of the delete operation (true: success, false: failure)</returns>
        public static bool DeleteEmployees(Collection<int> employeesIdsToDelete)
        {
            //Validate Input
            foreach (int employeeId in employeesIdsToDelete)
                if (employeeId <= SelectEmployeeIdMinValue)
                    throw (new ArgumentOutOfRangeException("employeesIdsToDelete"));

            //performing deletion operation //

            string xmlString = DatabaseUtility.FormatXmlForIdArray(employeesIdsToDelete);

            // Execute SQL Command
            SqlCommand sqlCmd = new SqlCommand();

            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@ReturnValue", SqlDbType.Int, 0, ParameterDirection.ReturnValue, null);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@employeeIds", SqlDbType.Xml, xmlString.ToString().Length, ParameterDirection.Input, xmlString.ToString());
            DatabaseUtility.SetCommandType(sqlCmd, CommandType.StoredProcedure, SP_EMPLOYEES_DELETE_LIST);
            DatabaseUtility.ExecuteScalarCmd(sqlCmd);

            //returns the number of affected rows
            int returnValue = (int)sqlCmd.Parameters["@ReturnValue"].Value;
            return (returnValue == employeesIdsToDelete.Count ? true : false);

        }

        /************************************************************************************
                                 -- GET BY PRIMARY KEY METHOD --
        *************************************************************************************/

        /************************* Architecture note:**********************************
        Retrieves an Employee from database, based on it's primary key.
        To view or update an employee, every time we must have to use this type of 'get' method, 
        since we don't have direct access to the Primary key value for assigning value.
        We have used the employeeId parameter as int, to bind the delete method with object data source and view control directly.
        /*****************************************************************************/

        /// <summary>
        /// Retrieves an Employee from database, based on it's primary key.
        /// </summary>
        /// <param name="employeeId">The Employee Id, which is the primary key of the Employee entity.</param>
        /// <returns>An instance of Employee object, representing the employee having the primary key same as the provided parameter 'employeeId'.</returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static Employee GetEmployeeByEmployeeId(int employeeId)
        {
            //Validate Input
            if (employeeId <= SelectEmployeeIdMinValue)
                throw (new ArgumentOutOfRangeException("employeeId"));

            // Execute SQL Command
            SqlCommand sqlCmd = new SqlCommand();
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@EmployeeId", SqlDbType.Int, 0, ParameterDirection.Input, employeeId);
            DatabaseUtility.SetCommandType(sqlCmd, CommandType.StoredProcedure, SP_EMPLOYEES_GETEMPLOYEE_BY_EMPLOYEEID);
            GenerateCollectionFromReader test = new GenerateCollectionFromReader(GenerateEmployeeCollectionFromReader);
            CustomCollection<Employee> objCollection = ((CustomCollection<Employee>)DatabaseUtility.ExecuteReaderCmd(sqlCmd, test));

            if (objCollection.Count > 0)
                return objCollection[0];
            else
                return null;
        }

        /************************************************************************************
                         -- GET BY FOREIGN KEY METHODS --
        *************************************************************************************/

        /// <summary>
        /// Gets all the Employees regarding 'ReportsTo' foreign key.
        /// </summary>
        /// <param name="reportsTo">EmployeeId of the Boss</param>
        /// <returns>A collection of Employees.</returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static CustomCollection<Employee> GetEmployeesByReportsTo(int? reportsTo)
        {
            //Validate Input
            if (reportsTo == null)
                return SelectAllEmployees();
            else if (reportsTo <= Employee.SelectEmployeeIdMinValue)
                throw (new ArgumentOutOfRangeException("reportsTo"));

            // Execute SQL Command
            SqlCommand sqlCmd = new SqlCommand();
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@reportsTo", SqlDbType.Int, 0, ParameterDirection.Input, reportsTo);

            DatabaseUtility.SetCommandType(sqlCmd, CommandType.StoredProcedure, SP_EMPLOYEES_GETEMPLOYEES_BY_REPORTSTO);
            GenerateCollectionFromReader test = new GenerateCollectionFromReader(GenerateEmployeeCollectionFromReader);
            CustomCollection<Employee> objCollection = ((CustomCollection<Employee>)DatabaseUtility.ExecuteReaderCmd(sqlCmd, test));

            return objCollection;
        }

        /// <summary>
        /// Gets all the Employees regarding 'ReportsTo' foreign key.
        /// It supports efficient paging.
        /// </summary>
        /// <param name="reportsTo">EmployeeId of the Boss</param>
        /// <param name="orderBy">Sorting order</param>
        /// <param name="startRowIndex">Start row index of the paged data</param>
        /// <param name="maximumRows">Maximum record count of the paged data</param>
        /// <returns>A collection of Employees.</returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static CustomCollection<Employee> GetEmployeesByReportsToPaged(int? reportsTo, string orderBy, int startRowIndex, int maximumRows)
        {
            //Validate Input
            //If reportsTo is less than the MinValue then return all records of the corresponding table, regarding the page size
            if (reportsTo == null)
                return SelectAllEmployeesPaged(orderBy, startRowIndex, maximumRows);
            else if (reportsTo <= Employee.SelectEmployeeIdMinValue)
                throw (new ArgumentOutOfRangeException("reportsTo"));

            //If there is no sorting parameter, then by default consider the primary key as the sorting field
            if (string.IsNullOrEmpty(orderBy))
                orderBy = "EmployeeId";

            // Execute SQL Command
            SqlCommand sqlCmd = new SqlCommand();
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@reportsTo", SqlDbType.Int, 0, ParameterDirection.Input, reportsTo);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@orderby", SqlDbType.VarChar, 50, ParameterDirection.Input, orderBy);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@startrow", SqlDbType.Int, 0, ParameterDirection.Input, startRowIndex);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@pagesize", SqlDbType.Int, 0, ParameterDirection.Input, maximumRows);

            DatabaseUtility.SetCommandType(sqlCmd, CommandType.StoredProcedure, SP_EMPLOYEES_GETEMPLOYEES_BY_REPORTSTO_PAGED);

            GenerateCollectionFromReader test = new GenerateCollectionFromReader(GenerateEmployeeCollectionFromReader);
            CustomCollection<Employee> objCollection = ((CustomCollection<Employee>)DatabaseUtility.ExecuteReaderCmd(sqlCmd, test));

            return objCollection;
        }

        /// <summary>
        /// This is a supporting method of ''GetEmployeeByReportsToPaged'' method.
        /// Used in paging, which returns the total number of records, returned from the ''GetEmployeeByReportsToPaged'' method (regardless of page size).
        /// Although we are not using the parameters, but we need the same signature as ''GetEmployeeByReportsToPaged'' to support paging.
        /// </summary>
        /// <param name="reportsTo">EmployeeId of the Boss</param>
        /// <param name="orderBy">Sorting order</param>
        /// <param name="startRowIndex">Start row index of the paged data</param>
        /// <param name="maximumRows">Maximum record count of the paged data</param>
        /// <returns>Total number of rows regarding the ''GetEmployeeByReportsToPaged'' method (regardless of page size).</returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static int GetEmployeesByReportsToPagedCount(int? reportsTo, string orderBy, int startRowIndex, int maximumRows)
        {
            //Validate Input
            //If reportsTo is less than the MinValue then return number of all records of the corresponding table, regardless of page size
            if (reportsTo == null)
                return SelectAllEmployeesPagedCount(orderBy, startRowIndex, maximumRows);
            else if (reportsTo <= Employee.SelectEmployeeIdMinValue)
                throw (new ArgumentOutOfRangeException("reportsTo"));

            // Execute SQL Command
            SqlCommand sqlCmd = new SqlCommand();

            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@reportsTo", SqlDbType.Int, 0, ParameterDirection.Input, reportsTo);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@ReturnValue", SqlDbType.Int, 0, ParameterDirection.ReturnValue, null);
            DatabaseUtility.SetCommandType(sqlCmd, CommandType.StoredProcedure, SP_EMPLOYEES_GETEMPLOYEES_BY_REPORTSTO_PAGED_COUNT);
            DatabaseUtility.ExecuteScalarCmd(sqlCmd);

            int returnValue = (int)sqlCmd.Parameters["@ReturnValue"].Value;
            return returnValue;
        }

        /************************************************************************************
                 -- GET ALL METHODS --
        *************************************************************************************/

        /// <summary>
        /// Gets all the Employees.
        /// It supports efficient paging.
        /// </summary>
        /// <returns>A collection of Employees.</returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static CustomCollection<Employee> SelectAllEmployees()
        {
            // Execute SQL Command
            SqlCommand sqlCmd = new SqlCommand();
            DatabaseUtility.SetCommandType(sqlCmd, CommandType.StoredProcedure, SP_EMPLOYEES_GETALLEMPLOYEES);
            GenerateCollectionFromReader test = new GenerateCollectionFromReader(GenerateEmployeeCollectionFromReader);
            CustomCollection<Employee> objCollection = ((CustomCollection<Employee>)DatabaseUtility.ExecuteReaderCmd(sqlCmd, test));

            return objCollection;
        }

        /// <summary>
        /// Gets all the Employees.
        /// It supports efficient paging.
        /// </summary>
        /// <param name="orderBy">Sorting order</param>
        /// <param name="startRowIndex">Start row index of the paged data</param>
        /// <param name="maximumRows">Maximum record count of the paged data</param>
        /// <returns>A collection of Employees.</returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static CustomCollection<Employee> SelectAllEmployeesPaged(string orderBy, int startRowIndex, int maximumRows)
        {
            //Validate Input
            if (string.IsNullOrEmpty(orderBy))
                orderBy = "EmployeeId";

            // Execute SQL Command
            SqlCommand sqlCmd = new SqlCommand();
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@orderby", SqlDbType.VarChar, 50, ParameterDirection.Input, orderBy);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@startrow", SqlDbType.Int, 0, ParameterDirection.Input, startRowIndex);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@pagesize", SqlDbType.Int, 0, ParameterDirection.Input, maximumRows);

            DatabaseUtility.SetCommandType(sqlCmd, CommandType.StoredProcedure, SP_EMPLOYEES_GETALLEMPLOYEES_PAGED);

            GenerateCollectionFromReader test = new GenerateCollectionFromReader(GenerateEmployeeCollectionFromReader);
            CustomCollection<Employee> objCollection = ((CustomCollection<Employee>)DatabaseUtility.ExecuteReaderCmd(sqlCmd, test));

            return objCollection;
        }

        /// <summary>
        /// This is a supporting method of ''GetAllEmployeePaged'' method.
        /// Used in paging, which returns the total number of records, returned from the 'GetAllEmployeePaged' method (regardless of page size).
        /// Although we are not using the parameters, but we need the same signature as 'GetAllEmployeePaged' to support paging.
        /// </summary>
        /// <param name="orderBy">Sorting order</param>
        /// <param name="startRowIndex">Start row index of the paged data</param>
        /// <param name="maximumRows">Maximum record count of the paged data</param>
        /// <returns>Total number of rows regarding the ''GetAllEmployeePaged'' method (regardless of page size).</returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static int SelectAllEmployeesPagedCount(string orderBy, int startRowIndex, int maximumRows)
        {
            if (!string.IsNullOrEmpty(orderBy) && startRowIndex >= int.MinValue && maximumRows >= int.MinValue)
            {

            }

            // Execute SQL Command
            SqlCommand sqlCmd = new SqlCommand();

            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@ReturnValue", SqlDbType.Int, 0, ParameterDirection.ReturnValue, null);
            DatabaseUtility.SetCommandType(sqlCmd, CommandType.StoredProcedure, SP_EMPLOYEES_GETALLEMPLOYEES_PAGED_COUNT);
            DatabaseUtility.ExecuteScalarCmd(sqlCmd);

            int returnValue = (int)sqlCmd.Parameters["@ReturnValue"].Value;
            return returnValue;
        }

        #endregion

        #region Employee Instance Methods

        /************************************************************************************
                                    -- SAVE (INSERT/UPDATE) METHODS (INSTANCE) --
        *************************************************************************************/

        /// <summary>
        /// Saves (inserts and updates) an Employee into database.
        /// The insertion occur if the EmployeeId contains default value.
        /// Otherwise it updates the Employee into the database, based on the primary key value stored in EmployeeId.
        /// This technique ensures an Employee will not be updated without having a valid EmployeeId.
        /// </summary>
        /// <returns>The success status, whether the updating process of an Employee is successful or not.</returns>
        public bool Save()
        {
            if (_employeeId <= SelectEmployeeIdMinValue)
            {
                int TempId = CreateNewEmployee(this);
                if (TempId > SelectEmployeeIdMinValue)
                {
                    _employeeId = TempId;
                    return true;
                }
                else
                {
                    //error occurs
                    return false;
                }
            }
            else
            {	//This is a update Command
                return (UpdateEmployee(this));
            }
        }

        /// <summary>
        /// Inserts an Employee in  database.
        /// This private method is being used by 'Save'instance method. 
        /// </summary>
        /// <param name="newEmployee">An employee object that is going to be created</param>
        /// <returns>The generated Primary key value of the newly created Employee.</returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, false)]
        public static int CreateNewEmployee(Employee newEmployee)
        {
            // Validate Parameters
            if (newEmployee == null)
                throw (new ArgumentNullException("newEmployee"));

            // Validate Primary key value
            if (newEmployee.EmployeeId > SelectEmployeeIdMinValue)
                throw (new ArgumentOutOfRangeException("newEmployee"));

            // Execute SQL Command
            SqlCommand sqlCmd = new SqlCommand();
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@ReturnValue", SqlDbType.Int, 0, ParameterDirection.ReturnValue, null);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@LastName", SqlDbType.NVarChar, 20, ParameterDirection.Input, newEmployee.LastName);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@FirstName", SqlDbType.NVarChar, 10, ParameterDirection.Input, newEmployee.FirstName);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@Title", SqlDbType.NVarChar, 30, ParameterDirection.Input, newEmployee.Title);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@TitleOfCourtesy", SqlDbType.NVarChar, 25, ParameterDirection.Input, newEmployee.TitleOfCourtesy);
            
            //if (newEmployee.BirthDate != null)
                DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@BirthDate", SqlDbType.DateTime, 0, ParameterDirection.Input, newEmployee.BirthDate);
            //else
                //DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@BirthDate", SqlDbType.DateTime, 0, ParameterDirection.Input, System.DBNull.Value);

            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@HireDate", SqlDbType.DateTime, 0, ParameterDirection.Input, newEmployee.HireDate);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@Address", SqlDbType.NVarChar, 60, ParameterDirection.Input, newEmployee.Address);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@City", SqlDbType.NVarChar, 15, ParameterDirection.Input, newEmployee.City);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@Region", SqlDbType.NVarChar, 15, ParameterDirection.Input, newEmployee.Region);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@PostalCode", SqlDbType.NVarChar, 10, ParameterDirection.Input, newEmployee.PostalCode);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@Country", SqlDbType.NVarChar, 15, ParameterDirection.Input, newEmployee.Country);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@HomePhone", SqlDbType.NVarChar, 24, ParameterDirection.Input, newEmployee.HomePhone);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@Extension", SqlDbType.NVarChar, 4, ParameterDirection.Input, newEmployee.Extension);

            /************************* Architecture note:**********************************
            The data fields for which the size is not known at the beginning, for instance nText, Image DB types,
            while passing the data from application end, it's size should be determined from here, to pass the appropriate size to the stored procedure layer.
            /*****************************************************************************/

            int length = 0;

            //if (newEmployee.Photo != null)
            //{
            //    length = newEmployee.Photo.Length;
            //}

            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@Photo", SqlDbType.Image, length, ParameterDirection.Input, newEmployee.Photo);

            /************************* Architecture note:**********************************
            The data fields for which the size is not known at the beginning, for instance nText, Image DB types,
            while passing the data from application end, it's size should be determined from here, to pass the appropriate size to the stored procedure layer.
            /*****************************************************************************/

            length = 0;
            
            //if (newEmployee.Notes != null)
            //{
            //    length = newEmployee.Notes.Length;
            //}

            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@Notes", SqlDbType.NText, length, ParameterDirection.Input, newEmployee.Notes);

            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@ReportsTo", SqlDbType.Int, 0, ParameterDirection.Input, newEmployee.ReportsTo);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@PhotoPath", SqlDbType.NVarChar, 255, ParameterDirection.Input, newEmployee.PhotoPath);

            DatabaseUtility.SetCommandType(sqlCmd, CommandType.StoredProcedure, SP_EMPLOYEES_CREATE);
            DatabaseUtility.ExecuteScalarCmd(sqlCmd);
            return ((int)sqlCmd.Parameters["@ReturnValue"].Value);

        }

        /// <summary>
        /// Updates an Employee instance to the database.
        /// </summary>
        /// <param name="updatedEmployee">An employee object that is going to be updated</param>
        /// <returns>Returns status of the update (True - success /False -  failure)</returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, false)]
        public static bool UpdateEmployee(Employee updatedEmployee)
        {
            // Validate Parameters
            if (updatedEmployee == null)
                throw (new ArgumentNullException("updatedEmployee"));

            // Execute SQL Command
            SqlCommand sqlCmd = new SqlCommand();
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@ReturnValue", SqlDbType.Int, 0, ParameterDirection.ReturnValue, null);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@EmployeeId", SqlDbType.Int, 0, ParameterDirection.Input, updatedEmployee.EmployeeId);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@LastName", SqlDbType.NVarChar, 20, ParameterDirection.Input, updatedEmployee.LastName);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@FirstName", SqlDbType.NVarChar, 10, ParameterDirection.Input, updatedEmployee.FirstName);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@Title", SqlDbType.NVarChar, 30, ParameterDirection.Input, updatedEmployee.Title);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@TitleOfCourtesy", SqlDbType.NVarChar, 25, ParameterDirection.Input, updatedEmployee.TitleOfCourtesy);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@BirthDate", SqlDbType.DateTime, 0, ParameterDirection.Input, updatedEmployee.BirthDate);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@HireDate", SqlDbType.DateTime, 0, ParameterDirection.Input, updatedEmployee.HireDate);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@Address", SqlDbType.NVarChar, 60, ParameterDirection.Input, updatedEmployee.Address);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@City", SqlDbType.NVarChar, 15, ParameterDirection.Input, updatedEmployee.City);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@Region", SqlDbType.NVarChar, 15, ParameterDirection.Input, updatedEmployee.Region);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@PostalCode", SqlDbType.NVarChar, 10, ParameterDirection.Input, updatedEmployee.PostalCode);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@Country", SqlDbType.NVarChar, 15, ParameterDirection.Input, updatedEmployee.Country);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@HomePhone", SqlDbType.NVarChar, 24, ParameterDirection.Input, updatedEmployee.HomePhone);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@Extension", SqlDbType.NVarChar, 4, ParameterDirection.Input, updatedEmployee.Extension);

            /************************* Architecture note:**********************************
            The data fields for which the size is not known at the beginning, for instance nText, Image DB types,
            while passing the data from application end, it's size should be determined from here, to pass the appropriate size to the stored procedure layer.
            /*****************************************************************************/

            int length = 0;

            //if (updatedEmployee.Photo != null)
            //{
            //    length = updatedEmployee.Photo.Length;
            //}

            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@Photo", SqlDbType.Image, length, ParameterDirection.Input, updatedEmployee.Photo);

            /************************* Architecture note:**********************************
            The data fields for which the size is not known at the beginning, for instance nText, Image DB types,
            while passing the data from application end, it's size should be determined from here, to pass the appropriate size to the stored procedure layer.
            /*****************************************************************************/

            //length = 0;
            //if (updatedEmployee.Notes != null)
            //{
            //    length = updatedEmployee.Notes.Length;
            //}

            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@Notes", SqlDbType.NText, length, ParameterDirection.Input, updatedEmployee.Notes);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@ReportsTo", SqlDbType.Int, 0, ParameterDirection.Input, updatedEmployee.ReportsTo);
            DatabaseUtility.AddParameterToSqlCmd(sqlCmd, "@PhotoPath", SqlDbType.NVarChar, 255, ParameterDirection.Input, updatedEmployee.PhotoPath);

            DatabaseUtility.SetCommandType(sqlCmd, CommandType.StoredProcedure, SP_EMPLOYEES_UPDATE);
            DatabaseUtility.ExecuteScalarCmd(sqlCmd);
            int returnValue = (int)sqlCmd.Parameters["@ReturnValue"].Value;
            return (returnValue == 0 ? false : true);

        }

        #endregion

        #region Employee Related Collections

        /// <summary>
        /// Creates and returns a strongly typed collection of Employee custom entity. 
        /// The collection is created through iterating on the IdataReader object which contains Employee information, as a set of records, similar to tabular format.
        /// </summary>
        /// <param name="returnData">Contains the data retrieved from database.</param>
        /// <returns>A collection of Employee custom entity.</returns>
        protected static CollectionBase GenerateEmployeeCollectionFromReader(IDataReader returnData)
        {

            //creating the instance of Employee collection
            CustomCollection<Employee> colEmployee = new CustomCollection<Employee>();
            
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
                //passing the Employee constructor parameters from the current instance of data reader fields.
                Employee newEmployee = new Employee
                    (
                        returnData["EmployeeId"] == System.DBNull.Value ? SelectEmployeeIdMinValue : (int)returnData["EmployeeId"],
                        returnData["LastName"] == System.DBNull.Value ? null : (string)returnData["LastName"],
                        returnData["FirstName"] == System.DBNull.Value ? null : (string)returnData["FirstName"],
                        returnData["Title"] == System.DBNull.Value ? null : (string)returnData["Title"],
                        returnData["TitleOfCourtesy"] == System.DBNull.Value ? null : (string)returnData["TitleOfCourtesy"],
                        returnData["BirthDate"] == System.DBNull.Value ? (DateTime?)null : (DateTime)returnData["BirthDate"],
                        returnData["HireDate"] == System.DBNull.Value ? DateTime.MinValue : (DateTime)returnData["HireDate"],
                        returnData["Address"] == System.DBNull.Value ? null : (string)returnData["Address"],
                        returnData["City"] == System.DBNull.Value ? null : (string)returnData["City"],
                        returnData["Region"] == System.DBNull.Value ? null : (string)returnData["Region"],
                        returnData["PostalCode"] == System.DBNull.Value ? null : (string)returnData["PostalCode"],
                        returnData["Country"] == System.DBNull.Value ? null : (string)returnData["Country"],
                        returnData["HomePhone"] == System.DBNull.Value ? null : (string)returnData["HomePhone"],
                        returnData["Extension"] == System.DBNull.Value ? null : (string)returnData["Extension"],
                        returnData["Photo"] == System.DBNull.Value ? null : (byte[])returnData["Photo"],
                        returnData["Notes"] == System.DBNull.Value ? null : (string)returnData["Notes"],
                        returnData["ReportsTo"] == System.DBNull.Value ? (int?)null : (int)returnData["ReportsTo"],
                        returnData["PhotoPath"] == System.DBNull.Value ? null : (string)returnData["PhotoPath"]

                    );

                //adding the Employee to the collection
                colEmployee.Add(newEmployee);
            }

            //returns the collection of Employee objects
            return (colEmployee);

        }//GenerateEmployeeCollectionFromReader

        #endregion

        #region Constants and Default Values

        /// <summary>
        /// This property is being used by the crud methods, to validate EmployeeId parameter 
        /// </summary>
        public static int SelectEmployeeIdMinValue
        {
            get { return 0; }
        }

        //Employee entity related constants, which includes relevant stored procedure names

        // -- create method related constants -- //
        internal const string SP_EMPLOYEES_CREATE = "Employees_CreateNewEmployee";

        // -- update method related constants -- //
        internal const string SP_EMPLOYEES_UPDATE = "Employees_UpdateEmployee";
        
        // -- delete method related constants -- //
        internal const string SP_EMPLOYEES_DELETE = "Employees_DeleteEmployee";
        internal const string SP_EMPLOYEES_DELETE_LIST = "Employees_DeleteEmployees";

        //-- get method related constants -- //

        //get by primary key  stored procedure
        internal const string SP_EMPLOYEES_GETEMPLOYEE_BY_EMPLOYEEID = "Employees_GetEmployeeByEmployeeId";

        //get by foreign key stored procedures
        internal const string SP_EMPLOYEES_GETEMPLOYEES_BY_REPORTSTO = "Employees_GetEmployeesByReportsTo";
        internal const string SP_EMPLOYEES_GETEMPLOYEES_BY_REPORTSTO_PAGED = "Employees_GetEmployeesByReportsTo_Paged";
        internal const string SP_EMPLOYEES_GETEMPLOYEES_BY_REPORTSTO_PAGED_COUNT = "Employees_GetEmployeesByReportsTo_Paged_Count";

        //'get all'  stored procedures
        internal const string SP_EMPLOYEES_GETALLEMPLOYEES = "Employees_GetAllEmployees";
        internal const string SP_EMPLOYEES_GETALLEMPLOYEES_PAGED = "Employees_GetAllEmployees_Paged";
        internal const string SP_EMPLOYEES_GETALLEMPLOYEES_PAGED_COUNT = "Employees_GetAllEmployees_Paged_Count";
        
        #endregion

    }//end of Employee class
}
