using System;
using System.Text;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Entity;
using TestHelperRoot;

namespace Tests.UnitTests.DataAccessLayer.DatabaseDependent.EmployeeTests
{
    /// <summary>
    /// Summary description for EmployeePerformanceTests
    /// </summary>
    [TestClass]
    public class EmployeePerformanceTests : TestHelperRoot.DataAccessLayerBaseTest
    {
        [TestMethod]
        public void CreateNewEmployee_ValidNewEmployeeObjectPassed_ShouldExecutedInLessThan1Sec()
        {
            //expected loading time is 1 second
            TimeSpan _ExpectedLoadTime = TimeSpan.FromSeconds(1);
            
            Stopwatch stopwatch = new Stopwatch();
            Employee freshEmployeeObjectWithValidSampleData = EntityFactory.Factory_CreateFreshEmployeeWithValidSampleData();
            
            //string the stopwatch
            stopwatch.Start();

            //test method goes here
            Employee.CreateNewEmployee(freshEmployeeObjectWithValidSampleData);

            //stopping the stowatch
            stopwatch.Stop();

            Console.WriteLine("Method executed in toal seconds : " + stopwatch.Elapsed.TotalSeconds);
            Assert.IsTrue(stopwatch.Elapsed < _ExpectedLoadTime,
                string.Format(System.Globalization.CultureInfo.CurrentCulture, 
                "Loading time ({0:#,##0.0} seconds) exceed the expected time ({1:#,##0.0} seconds).",
                stopwatch.Elapsed.TotalSeconds, _ExpectedLoadTime.TotalSeconds));

        }
    }
}
