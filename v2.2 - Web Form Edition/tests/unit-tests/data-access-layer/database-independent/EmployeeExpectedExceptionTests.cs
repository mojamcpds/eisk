using System;
using System.Text;
using System.Collections.Generic;
using Entity;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestHelperRoot;

namespace Tests.UnitTests.DataAccessLayer.DatabaseIndependent.EmployeeTests
{
    /// <summary>
    /// Design and Architecture: Mohammad Ashraful Alam [ashraf@mvps.org]
    /// </summary>
    [TestClass]
    public class EmployeeExpectedExceptionTests
    {
        #region Method Level Exceptions

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Passing null 'Employee' parameter is invalid. Method should throw exception.")]
        public void CreateNewEmployee_NullEmployeeToBePassedAsArgument_ShouldThrowException()
        {
            Employee.CreateNewEmployee(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Non-zero EmployeeId while creating new employee is invalid.")]
        public void CreateNewEmployee_NonZeroEmployeeIdToBePassedAsArgument_ShouldThrowException()
        {
            Employee freshEmployeeObjectWithValidSampleData = EntityFactory.Factory_CreateFreshEmployeeWithValidSampleData();
            const int NON_ZERO_EMPLOYEE_ID = 1;
            freshEmployeeObjectWithValidSampleData.EmployeeId = NON_ZERO_EMPLOYEE_ID;
            Employee.CreateNewEmployee(freshEmployeeObjectWithValidSampleData);
        }

        #endregion

        #region Property Level Exceptions

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Passing null or empty 'FirstName' is invalid. Method should throw exception.")]
        public void FirstName_NullFirstNameToBeAssigned_ShouldThrowException()
        {
            Employee employee = EntityFactory.Factory_CreateFreshEmployeeWithValidSampleData();
            employee.FirstName = null;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Passing null or empty 'LastName' is invalid. Method should throw exception.")]
        public void LastName_NullLastNameToBeAssigned_ShouldThrowException()
        {
            Employee employee = EntityFactory.Factory_CreateFreshEmployeeWithValidSampleData();
            employee.LastName = null;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Passing empty value in this property is invalid. Method should throw exception.")]
        public void HireDate_EmptyHireDateToBeAssigned_ShouldThrowException()
        {
            Employee employee = EntityFactory.Factory_CreateFreshEmployeeWithValidSampleData();
            employee.HireDate = DateTime.MinValue;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Passing null or empty 'Address' is invalid. Method should throw exception.")]
        public void Address_NullAddressToBeAssigned_ShouldThrowException()
        {
            Employee employee = EntityFactory.Factory_CreateFreshEmployeeWithValidSampleData();
            employee.Address = null;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Passing null or empty 'Country' is invalid. Method should throw exception.")]
        public void Country_NullCountryToBeAssigned_ShouldThrowException()
        {
            Employee employee = EntityFactory.Factory_CreateFreshEmployeeWithValidSampleData();
            employee.Country = null;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Passing null or empty 'HomePhone' is invalid. Method should throw exception.")]
        public void HomePhone_NullHomePhoneToBeAssigned_ShouldThrowException()
        {
            Employee employee = EntityFactory.Factory_CreateFreshEmployeeWithValidSampleData();
            employee.HomePhone = null;
        }

        #endregion
    }
}
