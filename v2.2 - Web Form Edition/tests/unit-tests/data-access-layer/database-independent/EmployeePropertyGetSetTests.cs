using System;
using System.Collections.Generic;
using System.Text;
using TestHelperRoot;
using Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.EnterpriseServices;

namespace Tests.UnitTests.DataAccessLayer.DatabaseIndependent.EmployeeTests
{
    /// <summary>
    /// Design and Architecture: Mohammad Ashraful Alam [ashraf@mvps.org]
    /// </summary>
    [TestClass]
    public class EmployeePropertyGetSetTests
    {
        [TestMethod]
        public void FirstName_ConstructorSetsValidValue_GetsSameValue()
        {
            const string EXPECTED_FIRST_NAME = "Ashraf";
            Employee employee = EntityFactory.Factory_CreateFreshEmployeeWithConstructor(EmployeeDataField.FirstName, EXPECTED_FIRST_NAME);
            string ACTUAL_FIRST_NAME = employee.FirstName;
            Assert.AreEqual(EXPECTED_FIRST_NAME, ACTUAL_FIRST_NAME, "First name has not been properly initialyzed via constructor.");
        }
    }
}
