using System;
using System.Collections.Generic;
using System.Text;
using TestHelperRoot;
using Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.EnterpriseServices;

namespace Tests.UnitTests.DataAccessLayer.DatabaseDependent.EmployeeTests
{
    /// <summary>
    /// Design and Architecture: Mohammad Ashraful Alam [ashraf@mvps.org]
    /// </summary>
    [TestClass]
    public class EmployeeValidArgumentReturnsSuccessTests : TestHelperRoot.DataAccessLayerBaseTest
    {
        [TestMethod()]
        public void CreateNewEmployee_ValidNewEmployeeObjectPassed_ShouldReturnNonzero()
        {
            Employee freshEmployeeObjectWithValidSampleData = EntityFactory.Factory_CreateFreshEmployeeWithValidSampleData();
            int NEW_EMPLOYEE_ID = Employee.CreateNewEmployee(freshEmployeeObjectWithValidSampleData);
            const int INITIAL_NO_EMPLOYEE_STATE = 0;
            Assert.AreNotEqual(INITIAL_NO_EMPLOYEE_STATE, NEW_EMPLOYEE_ID, "Employee was not created.");
        }
    }
}
