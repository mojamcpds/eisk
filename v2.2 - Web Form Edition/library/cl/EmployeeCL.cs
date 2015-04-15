namespace CL
{
    using System;
    using System.Data;
    using System.Configuration;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    using System.Web.Caching;
    using System.Data.SqlTypes;
    using Entity;
    using Utilities;
    using System.Collections.ObjectModel;

    /// <summary>
    /// This class represents an Employee object, with web server side caching support.
    /// This class is responsible for Create, Read, Update & Delete (CRUD) operations of an Employee entity.
    /// Caching is an excellent way to improve application performance, specially the data that are semi-static (i.e. not frequently updated). You can gradually increase the site performance by just putting the corresponding cache layers of the data access/business logic layer. In this starter kit, the cache layer has been implemented as a proxy class of the Entity Based Data Access Layer (i.e. <Extraction directory>\library\entity\Employee.cs) which can be easily replaced between User Interface Layer and Data Access Layer, which less amount of code modification. The cache layer that has been provided in this starter kit contains additional methods that encapsulates cache mechanism which enables the update the cache automatically when there is any update in the underlying entity (however off course those updates needs to be performed via this cache layer).
    /// Design and Architecture: Mohammad Ashraful Alam [ashraf@mvps.org]
    /// Last update: 01-08-2007
    [System.ComponentModel.DataObject]
    public sealed class EmployeesCL
    {
        private EmployeesCL() { }

        #region Utility methods

        /// <summary>
        /// This is the key which enables us to reduce the chanse to overlap the chache key.
        /// In this case the master key is concated with individual cache items in the current entity.
        /// </summary>
        private static readonly string[] MasterCacheKeyArray = { "EmployeesCache" };
        
        /// <summary>
        /// Gets the chache key regadring the passed 'raw' key
        /// </summary>
        /// <param name="rawKey"></param>
        /// <returns></returns>
        private static string GetCacheKey(string rawKey)
        {
            return string.Concat(MasterCacheKeyArray[0], "-", rawKey);
        }

        /// <summary>
        /// Gets the cache item regarding the modified key of 'raw' key
        /// </summary>
        /// <param name="rawKey"></param>
        /// <returns></returns>
        private static object GetCacheItem(string rawKey)
        {
            return HttpRuntime.Cache[GetCacheKey(rawKey)];
        }

        /// <summary>
        /// Adds the item to the web cache, along with general dependency support
        /// </summary>
        /// <param name="rawKey"></param>
        /// <param name="value"></param>
        private static void AddCacheItem(string rawKey, object value)
        {
            System.Web.Caching.Cache DataCache = HttpRuntime.Cache;

            // Make sure MasterCacheKeyArray[0] is in the cache and create a depedency
            DataCache[MasterCacheKeyArray[0]] = DateTime.Now;
            System.Web.Caching.CacheDependency masterCacheKeyDependency = new System.Web.Caching.CacheDependency(null, MasterCacheKeyArray);

            //we are putting the cache without any expiration policy, 
            //we are expiring the cache programatically once when a new or existing instance of the current entity are being updated.
            DataCache.Insert(GetCacheKey(rawKey), value, masterCacheKeyDependency, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration);
        }

        #region SQL Cache Dependency

        ///// <summary>
        ///// Adds the item to the web cache, along with sql dependency support and general dependency support
        ///// To support sql cache dependeny, add the following xml snippet in web.config file
        /////<system.web>
        /////    <!-- Configure the polling service used for SQL cache dependencies
        /////    To set-up sql cache dependency in db level lets use the following command:
        /////    directory: C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727
        /////    db level:
        /////    aspnet_regsql.exe -S ASHRAF\SQLEXPRESS -E -d pubs -ed
        /////    table level:
        /////    aspnet_regsql.exe -S ASHRAF\SQLEXPRESS -E -d pubs -t authors -et
        /////    -->
        /////    <caching>
        /////      <sqlCacheDependency enabled="true" pollTime="1000" >
        /////        <databases>
        /////          <add name="SCDEmployeeDB" connectionStringName="EmployeeDB" />
        /////        </databases>
        /////      </sqlCacheDependency>
        /////    </caching>
        /////</system.web>
        ///// </summary>
        ///// <param name="rawKey"></param>
        ///// <param name="value"></param>
        ///// <param name="databaseEntryName">The name of a database defined in the databases element of the application's Web.config file. </param>
        ///// <param name="tableNames">The name of the database table that the System.Web.Caching.SqlCacheDependency is associated with. </param>
        //public static void AddCacheItem(string rawKey, object value, string databaseEntryName, string[] tableNames)
        //{
        //    System.Web.Caching.Cache DataCache = HttpRuntime.Cache;

        //    // Make sure MasterCacheKeyArray[0] is in the cache and create a depedency
        //    DataCache[MasterCacheKeyArray[0]] = DateTime.Now;
        //    System.Web.Caching.CacheDependency masterCacheKeyDependency = new System.Web.Caching.CacheDependency(null, MasterCacheKeyArray);

        //    //Add the SqlCacheDependency objects for relevant tables
        //    CacheDependency[] cacheDependencies = new CacheDependency[tableNames.Length + 1];

        //    cacheDependencies[0] = masterCacheKeyDependency;//adding the general dependency

        //    for (int i = 1; i < cacheDependencies.Length; i++)//adding sql dependencies
        //    {
        //        cacheDependencies[i] = new SqlCacheDependency(databaseEntryName, tableNames[i - 1]);
        //    }

        //    // Create an AggregateCacheDependency
        //    System.Web.Caching.AggregateCacheDependency aggregateDependencies = new System.Web.Caching.AggregateCacheDependency();
        //    aggregateDependencies.Add(cacheDependencies);

        //    DataCache.Insert(GetCacheKey(rawKey), value, aggregateDependencies, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration);        
        //}

        #endregion

        /// <summary>
        /// This method is called proramatically by the insert/update methods to expire the cache item.
        /// All the cache items related to the current entity is bound with dependency relation, which causes all the cache items related to 
        /// the current entity to be expired after calling this method.
        /// </summary>
        private static void InvalidateCache()
        {
            // Remove the cache dependency
            HttpRuntime.Cache.Remove(MasterCacheKeyArray[0]);
        }

        #endregion

        #region Get methods
        /// <summary>
        /// Gets all the employees from chache, returns from database if it doesn't exist in cache.
        /// </summary>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static CustomCollection<Employee> SelectAllEmployees()
        {
            const string rawKey = Employee.SP_EMPLOYEES_GETALLEMPLOYEES;

            // See if the item is in the cache
            CustomCollection<Employee> Employees = GetCacheItem(rawKey) as CustomCollection<Employee>;
            if (Employees == null)
            {
                // Item not found in cache - retrieve it and insert it into the cache
                Employees = Employee.SelectAllEmployees();
                AddCacheItem(rawKey, Employees);
            }

            return Employees;
        }

        /// <summary>
        /// /// Gets an employee from chache, returns from database if it doesn't exist in cache.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static Employee GetEmployeeByEmployeeId(int employeeId)
        {
            string rawKey = string.Concat(Employee.SP_EMPLOYEES_GETEMPLOYEE_BY_EMPLOYEEID + "-", employeeId);

            // See if the item is in the cache
            Employee employee = GetCacheItem(rawKey) as Employee;
            if (employee == null)
            {
                // Item not found in cache - retrieve it and insert it into the cache
                employee = Employee.GetEmployeeByEmployeeId(employeeId);
                AddCacheItem(rawKey, employee);
            }

            return employee;
        }

        #endregion

        #region Create methods

        /// <summary>
        /// Creates a new employee in database, along with expires all the cache items which are related to the cache layer of the current data entity.
        /// </summary>
        /// <param name="country"></param>
        /// <param name="firstName"></param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
        public static int CreateNewEmployee(string lastName, string firstName, string title,
            string titleOfCourtesy, DateTime? birthDate, DateTime hireDate,
            string address, string city, string region, string postalCode,
            string country, string homePhone, string extension, byte[] image, string notes,
            int? reportsTo, string photoPath)
        {
            int result = Employee.CreateNewEmployee(lastName, firstName, title, titleOfCourtesy,
                                                    birthDate, hireDate, address, city, region, postalCode,
                                                    country, homePhone, extension, image, notes, reportsTo,
                                                    photoPath);
            //Invalidate the chache
            InvalidateCache();

            return result;
        }

        #endregion

        #region Update methods

        /// <summary>
        /// Updates an existing employee in database, along with expires all the cache items which are related to the cache layer of the current data entity.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="country"></param>
        /// <param name="firstName"></param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        public static bool UpdateEmployee(int employeeId, string lastName, string firstName, string title,
           string titleOfCourtesy, DateTime? birthDate, DateTime hireDate,string address, string city, 
           string region, string postalCode,string country, string homePhone, string extension, byte[] image,
           string notes, int? reportsTo, string photoPath)
        {
            bool result = Employee.UpdateEmployee(employeeId, lastName, firstName, title, titleOfCourtesy, birthDate,
                                                    hireDate, address, city, region, postalCode, country, homePhone,
                                                    extension, image, notes, reportsTo, photoPath);
            //Invalidate the chache
            InvalidateCache();

            return result; ;
        }

        #endregion

        #region Delete methods

        /// <summary>
        /// Delete an employee from database, along with expires all the cache items which are related to the cache layer of the current data entity.
        /// </summary>
        /// <param name="employeeId">EmployeeID to delete</param>
        /// <returns></returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
        public static bool DeleteEmployee(int employeeId)
        {
            bool result = Employee.DeleteEmployee(employeeId);
            //Invalidate the chache
            InvalidateCache();

            return result;
        }

        /// <summary>
        /// Deletes a set of employees from the database., along with expires all the cache items which are related to the cache layer of the current data entity.
        /// </summary>
        /// <param name="employessIdsToDelete"></param>
        public static bool DeleteEmployees(Collection<int> employeesIdsToDelete)
        {
            bool result = Employee.DeleteEmployees(employeesIdsToDelete);
            //Invalidate the chache
            InvalidateCache();

            return result;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets all the Employees regarding 'ReportsTo' foreign key.Returns from database if it doesn't exist in cache.
        /// </summary>
        /// <returns>A collection of Employees.</returns>
        
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static CustomCollection<Employee> GetEmployeesByReportsTo(int reportsTo)
        {
            string rawKey = string.Concat(Employee.SP_EMPLOYEES_GETEMPLOYEES_BY_REPORTSTO + "-", reportsTo.ToString(System.Globalization.CultureInfo.CurrentCulture.NumberFormat));

            // See if the item is in the cache
            CustomCollection<Employee> Employees = GetCacheItem(rawKey) as CustomCollection<Employee>;
            if (Employees == null)
            {
                // Item not found in cache - retrieve it and insert it into the cache
                Employees = Employee.GetEmployeesByReportsTo(reportsTo);
                AddCacheItem(rawKey, Employees);
            }

            return Employees;
           
        }

        /// <summary>
        /// Gets all the Employees regarding 'ReportsTo' foreign key.
        /// It supports efficient paging.Returns from database if it doesn't exist in cache.
        /// </summary>
        /// <param name="reportsTo"></param>
        /// <param name="orderBy"></param>
        /// <param name="startRowIndex"></param>
        /// <param name="maximumRows"></param>
        /// <returns>A collection of Employees.</returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static CustomCollection<Employee> GetEmployeesByReportsToPaged(int reportsTo, string orderBy, int startRowIndex, int maximumRows)
        {
           string rawKey = string.Concat(Employee.SP_EMPLOYEES_GETEMPLOYEES_BY_REPORTSTO_PAGED + "-", reportsTo + "-" + orderBy + "-" + startRowIndex + "-" + maximumRows);

            // See if the item is in the cache
            CustomCollection<Employee> Employees = GetCacheItem(rawKey) as CustomCollection<Employee>;
            if (Employees == null)
            {
                // Item not found in cache - retrieve it and insert it into the cache
                Employees = Employee.GetEmployeesByReportsToPaged(reportsTo, orderBy, startRowIndex, maximumRows);
                AddCacheItem(rawKey, Employees);
            }

            return Employees;
        }

        /// <summary>
        /// This is a supporting method of ''GetEmployeeByReportsToPaged'' method.
        /// Returns from database if it doesn't exist in cache.
        /// </summary>
        /// <param name="orderBy"></param>
        /// <param name="startRowIndex"></param>
        /// <param name="maximumRows"></param>
        /// <returns>Total number of rows regarding the ''GetEmployeeByReportsToPaged'' method (regardless of page size).</returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static int GetEmployeesByReportsToPagedCount(int reportsTo, string orderBy, int startRowIndex, int maximumRows)
        {
            string rawKey = string.Concat(Employee.SP_EMPLOYEES_GETEMPLOYEES_BY_REPORTSTO_PAGED_COUNT + "-", reportsTo + "-" + orderBy + "-" + startRowIndex + "-" + maximumRows);

            // See if the item is in the cache
            int pagedCount = Convert.ToInt32(GetCacheItem(rawKey), System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            if (pagedCount == 0)
            {
                // Item not found in cache - retrieve it and insert it into the cache
                pagedCount = Employee.GetEmployeesByReportsToPagedCount(reportsTo, orderBy, startRowIndex, maximumRows);
                AddCacheItem(rawKey, pagedCount);
            }

            return pagedCount;
        }


        /// <summary>
        /// Gets all the Employees.
        /// It supports efficient paging.Returns from database if it doesn't exist in cache.
        /// </summary>
        /// <param name="orderBy"></param>
        /// <param name="startRowIndex"></param>
        /// <param name="maximumRows"></param>
        /// <returns>A collection of Employees.</returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static CustomCollection<Employee> SelectAllEmployeesPaged(String orderBy, int startRowIndex, int maximumRows)
        {
            string rawKey = string.Concat(Employee.SP_EMPLOYEES_GETALLEMPLOYEES_PAGED+ "-", orderBy + "-" + startRowIndex + "-" + maximumRows);

            // See if the item is in the cache
            CustomCollection<Employee> Employees = GetCacheItem(rawKey) as CustomCollection<Employee>;
            if (Employees == null)
            {
                // Item not found in cache - retrieve it and insert it into the cache
                Employees = Employee.SelectAllEmployeesPaged(orderBy, startRowIndex, maximumRows);
                AddCacheItem(rawKey, Employees);
            }

            return Employees;
        }


        /// <summary>
        /// This is a supporting method of ''GetAllEmployeePaged'' method.
        /// Returns from database if it doesn't exist in cache.
        /// </summary>
        /// <param name="orderBy"></param>
        /// <param name="startRowIndex"></param>
        /// <param name="maximumRows"></param>
        /// <returns>Total number of rows regarding the ''GetAllEmployeePaged'' method (regardless of page size).</returns>
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        public static int SelectAllEmployeesPagedCount(string orderBy, int startRowIndex, int maximumRows)
        {
            string rawKey = string.Concat(Employee.SP_EMPLOYEES_GETALLEMPLOYEES_PAGED_COUNT+ "-", orderBy + "-" + startRowIndex + "-" + maximumRows);

            // See if the item is in the cache
            int pagedCount = Convert.ToInt32(GetCacheItem(rawKey), System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            if (pagedCount == 0)
            {
                // Item not found in cache - retrieve it and insert it into the cache
                pagedCount = Employee.SelectAllEmployeesPagedCount(orderBy, startRowIndex, maximumRows);
                AddCacheItem(rawKey, pagedCount);
            }

            return pagedCount;
        }

        #endregion
       
    }
}
