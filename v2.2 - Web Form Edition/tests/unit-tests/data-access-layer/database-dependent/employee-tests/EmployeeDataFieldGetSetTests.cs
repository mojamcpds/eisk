using System;
using System.Collections.Generic;
using System.Text;  
using TestHelperRoot;
using Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.EnterpriseServices;

namespace Tests.UnitTests.DataAccessLayer.DatabaseDependent.EmployeeTests
{
    [TestClass]
    public class EmployeeDataFieldGetSetTests : TestHelperRoot.DataAccessLayerBaseTest
    {
        #region [DataFieldName]_ValidValueToBeInsertedToDatabase_ShouldReturnSameValueFromDatabase

        [TestMethod()]
        public void FirstName_ValidValueToBeInsertedToDatabase_ShouldReturnSameValueFromDatabase()
        {
            //creating a fresh employee object that contains sample data
            Employee freshEmployeeObjectWithValidSampleData = EntityFactory.Factory_CreateFreshEmployeeWithValidSampleData();
            
            //value to be saved along with new employee, which will be finally checked with the inserted employee record to test if the value was saved succefully
            const string TARGET_FIRST_NAME = "John";
            
            //putting the target value in the employee entity that will be inserted in database
            freshEmployeeObjectWithValidSampleData.FirstName = TARGET_FIRST_NAME;
            
            //invoking the data access layer function to create a new employee in database
            int newEmployeeId = Employee.CreateNewEmployee(freshEmployeeObjectWithValidSampleData);
            
            //retriving the newly inserted employee from database to check if the value was inserted successfully
            Employee insertedEmployee = Employee.GetEmployeeByEmployeeId(newEmployeeId);

            //retriving the value from the newly inserted employee
            string ACTUAL_FIRST_NAME = insertedEmployee.FirstName;
            
            //perform final testing
            Assert.AreEqual(TARGET_FIRST_NAME, ACTUAL_FIRST_NAME, "value was NOT inserted successfully.");
        }

        [TestMethod()]
        public void LastName_ValidValueToBeInsertedToDatabase_ShouldReturnSameValueFromDatabase()
        {
            //creating a fresh employee object that contains sample data
            Employee freshEmployeeObjectWithValidSampleData = EntityFactory.Factory_CreateFreshEmployeeWithValidSampleData();

            //value to be saved along with new employee, which will be finally checked with the inserted employee record to test if the value was saved succefully
            const string TARGET_LAST_NAME = "Doe";

            //putting the target value in the employee entity that will be inserted in database
            freshEmployeeObjectWithValidSampleData.LastName = TARGET_LAST_NAME;

            //invoking the data access layer function to create a new employee in database
            int newEmployeeId = Employee.CreateNewEmployee(freshEmployeeObjectWithValidSampleData);

            //retriving the newly inserted employee from database to check if the value was inserted successfully
            Employee insertedEmployee = Employee.GetEmployeeByEmployeeId(newEmployeeId);

            //retriving the value from the newly inserted employee
            string ACTUAL_LAST_NAME = insertedEmployee.LastName;

            //perform final testing
            Assert.AreEqual(TARGET_LAST_NAME, ACTUAL_LAST_NAME, "value was NOT inserted successfully.");
        }

        #endregion

        #region [DataFieldName]_InvalidSizeValueToBeInsertedToDatabase_ShouldNotReturnSameValueFromDatabase

        [TestMethod()]
        public void FirstName_InvalidSizeValueToBeInsertedToDatabase_ShouldNotReturnSameValueFromDatabase()
        {
            //creating a fresh employee object that contains sample data
            Employee freshEmployeeObjectWithValidSampleData = EntityFactory.Factory_CreateFreshEmployeeWithValidSampleData();

            //value with size 11, which is an invliad size
            const string INVALID_SIZE_FIRST_NAME = "Ashrafuludd";

            //putting the target value in the employee entity that will be inserted in database
            freshEmployeeObjectWithValidSampleData.FirstName = INVALID_SIZE_FIRST_NAME;

            //invoking the data access layer function to create a new employee in database
            int newEmployeeId = Employee.CreateNewEmployee(freshEmployeeObjectWithValidSampleData);

            //retriving the newly inserted employee from database
            Employee insertedEmployee = Employee.GetEmployeeByEmployeeId(newEmployeeId);

            //retriving the value from the newly inserted employee,
            //which has maximum size 10
            string ACTUAL_FIRST_NAME = insertedEmployee.FirstName;
            //perform final testing
            Assert.AreNotEqual(INVALID_SIZE_FIRST_NAME.Length, ACTUAL_FIRST_NAME.Length, "value was inserted with invalid size.");
        }

        #endregion

        #region [DataFieldName]_NullValueToBeInsertedToDatabase_ShouldReturnNullValueFromDatabase			[WHERE APPLICABLE: for allow null data fields]

        [TestMethod()]
        public void Title_NullValueToBeInsertedToDatabase_ShouldReturnNullValueFromDatabase()
        {
            //creating a fresh employee object that contains sample data
            Employee freshEmployeeObjectWithValidSampleData = EntityFactory.Factory_CreateFreshEmployeeWithValidSampleData();
            
            //value to be saved along with new employee, which will be finally checked with the inserted employee record to test if the value was saved succefully
            const string TARGET_TITLE = null;
                        
            //putting the target value in the employee entity that will be inserted in database
            freshEmployeeObjectWithValidSampleData.Title = TARGET_TITLE;
            
            //invoking the data access layer function to create a new employee in database
            int newEmployeeId = Employee.CreateNewEmployee(freshEmployeeObjectWithValidSampleData);
            
            //retriving the newly inserted employee from database
            Employee insertedEmployee = Employee.GetEmployeeByEmployeeId(newEmployeeId);

            //retriving the value from the newly inserted employee
            string ACTUAL_TITLE = insertedEmployee.Title;
            
            //perform final testing
            Assert.AreEqual(TARGET_TITLE, ACTUAL_TITLE, "Title was not saved with null value.");
        }

        [TestMethod()]
        public void TitleOfCourtecy_NullValueToBeInsertedToDatabase_ShouldReturnNullValueFromDatabase()
        {
            //creating a fresh employee object that contains sample data
            Employee freshEmployeeObjectWithValidSampleData = EntityFactory.Factory_CreateFreshEmployeeWithValidSampleData();

            //value to be saved along with new employee, which will be finally checked with the inserted employee record to test if the value was saved succefully
            const string TARGET_TITLE_OF_COURTECY = null;

            //putting the target value in the employee entity that will be inserted in database
            freshEmployeeObjectWithValidSampleData.TitleOfCourtesy = TARGET_TITLE_OF_COURTECY;

            //invoking the data access layer function to create a new employee in database
            int newEmployeeId = Employee.CreateNewEmployee(freshEmployeeObjectWithValidSampleData);

            //retriving the newly inserted employee from database
            Employee insertedEmployee = Employee.GetEmployeeByEmployeeId(newEmployeeId);

            //retriving the value from the newly inserted employee
            string ACTUAL_TITLE_OF_COURTECY = insertedEmployee.TitleOfCourtesy;

            //perform final testing
            Assert.AreEqual(TARGET_TITLE_OF_COURTECY, ACTUAL_TITLE_OF_COURTECY, "Title of Courtecy was not saved with null value.");
        }

        [TestMethod()]
        public void BirthDate_NullValueToBeInsertedToDatabase_ShouldReturnNullValueFromDatabase()
        {
            //creating a fresh employee object that contains sample data
            Employee freshEmployeeObjectWithValidSampleData = EntityFactory.Factory_CreateFreshEmployeeWithValidSampleData();

            //value to be saved along with new employee, which will be finally checked with the inserted employee record to test if the value was saved succefully
            DateTime? TARGET_BIRTH_DATE = null;

            //putting the target value in the employee entity that will be inserted in database
            freshEmployeeObjectWithValidSampleData.BirthDate = TARGET_BIRTH_DATE;

            //invoking the data access layer function to create a new employee in database
            int newEmployeeId = Employee.CreateNewEmployee(freshEmployeeObjectWithValidSampleData);

            //retriving the newly inserted employee from database
            Employee insertedEmployee = Employee.GetEmployeeByEmployeeId(newEmployeeId);

            //retriving the value from the newly inserted employee
            DateTime? ACTUAL_BIRTH_DATE = insertedEmployee.BirthDate;

            //perform final testing
            Assert.AreEqual(TARGET_BIRTH_DATE, ACTUAL_BIRTH_DATE, "BirthDate was not saved with null value.");
        }

        [TestMethod()]
        public void City_NullValueToBeInsertedToDatabase_ShouldReturnNullValueFromDatabase()
        {
            //creating a fresh employee object that contains sample data
            Employee freshEmployeeObjectWithValidSampleData = EntityFactory.Factory_CreateFreshEmployeeWithValidSampleData();

            //value to be saved along with new employee, which will be finally checked with the inserted employee record to test if the value was saved succefully
            const string TARGET_City = null;

            //putting the target value in the employee entity that will be inserted in database
            freshEmployeeObjectWithValidSampleData.City = TARGET_City;

            //invoking the data access layer function to create a new employee in database
            int newEmployeeId = Employee.CreateNewEmployee(freshEmployeeObjectWithValidSampleData);

            //retriving the newly inserted employee from database
            Employee insertedEmployee = Employee.GetEmployeeByEmployeeId(newEmployeeId);

            //retriving the value from the newly inserted employee
            string ACTUAL_City = insertedEmployee.City;

            //perform final testing
            Assert.AreEqual(TARGET_City, ACTUAL_City, "City was not saved with null value.");
        }

        [TestMethod()]
        public void Region_NullValueToBeInsertedToDatabase_ShouldReturnNullValueFromDatabase()
        {
            //creating a fresh employee object that contains sample data
            Employee freshEmployeeObjectWithValidSampleData = EntityFactory.Factory_CreateFreshEmployeeWithValidSampleData();

            //value to be saved along with new employee, which will be finally checked with the inserted employee record to test if the value was saved succefully
            const string TARGET_Region = null;

            //putting the target value in the employee entity that will be inserted in database
            freshEmployeeObjectWithValidSampleData.Region = TARGET_Region;

            //invoking the data access layer function to create a new employee in database
            int newEmployeeId = Employee.CreateNewEmployee(freshEmployeeObjectWithValidSampleData);

            //retriving the newly inserted employee from database
            Employee insertedEmployee = Employee.GetEmployeeByEmployeeId(newEmployeeId);

            //retriving the value from the newly inserted employee
            string ACTUAL_Region = insertedEmployee.Region;

            //perform final testing
            Assert.AreEqual(TARGET_Region, ACTUAL_Region, "Region was not saved with null value.");
        }

        [TestMethod()]
        public void PostalCode_NullValueToBeInsertedToDatabase_ShouldReturnNullValueFromDatabase()
        {
            //creating a fresh employee object that contains sample data
            Employee freshEmployeeObjectWithValidSampleData = EntityFactory.Factory_CreateFreshEmployeeWithValidSampleData();

            //value to be saved along with new employee, which will be finally checked with the inserted employee record to test if the value was saved succefully
            const string TARGET_PostalCode = null;

            //putting the target value in the employee entity that will be inserted in database
            freshEmployeeObjectWithValidSampleData.PostalCode = TARGET_PostalCode;

            //invoking the data access layer function to create a new employee in database
            int newEmployeeId = Employee.CreateNewEmployee(freshEmployeeObjectWithValidSampleData);

            //retriving the newly inserted employee from database
            Employee insertedEmployee = Employee.GetEmployeeByEmployeeId(newEmployeeId);

            //retriving the value from the newly inserted employee
            string ACTUAL_PostalCode = insertedEmployee.PostalCode;

            //perform final testing
            Assert.AreEqual(TARGET_PostalCode, ACTUAL_PostalCode, "PostalCode was not saved with null value.");
        }

        [TestMethod()]
        public void Extension_NullValueToBeInsertedToDatabase_ShouldReturnNullValueFromDatabase()
        {
            //creating a fresh employee object that contains sample data
            Employee freshEmployeeObjectWithValidSampleData = EntityFactory.Factory_CreateFreshEmployeeWithValidSampleData();

            //value to be saved along with new employee, which will be finally checked with the inserted employee record to test if the value was saved succefully
            const string TARGET_Extension = null;

            //putting the target value in the employee entity that will be inserted in database
            freshEmployeeObjectWithValidSampleData.Extension = TARGET_Extension;

            //invoking the data access layer function to create a new employee in database
            int newEmployeeId = Employee.CreateNewEmployee(freshEmployeeObjectWithValidSampleData);

            //retriving the newly inserted employee from database
            Employee insertedEmployee = Employee.GetEmployeeByEmployeeId(newEmployeeId);

            //retriving the value from the newly inserted employee
            string ACTUAL_Extension = insertedEmployee.Extension;

            //perform final testing
            Assert.AreEqual(TARGET_Extension, ACTUAL_Extension, "Extension was not saved with null value.");
        }

        [TestMethod()]
        public void Photo_NullValueToBeInsertedToDatabase_ShouldReturnNullValueFromDatabase()
        {
            //creating a fresh employee object that contains sample data
            Employee freshEmployeeObjectWithValidSampleData = EntityFactory.Factory_CreateFreshEmployeeWithValidSampleData();

            //value to be saved along with new employee, which will be finally checked with the inserted employee record to test if the value was saved succefully
            const byte[] TARGET_Photo = null;

            //putting the target value in the employee entity that will be inserted in database
            freshEmployeeObjectWithValidSampleData.Photo = TARGET_Photo;

            //invoking the data access layer function to create a new employee in database
            int newEmployeeId = Employee.CreateNewEmployee(freshEmployeeObjectWithValidSampleData);

            //retriving the newly inserted employee from database
            Employee insertedEmployee = Employee.GetEmployeeByEmployeeId(newEmployeeId);

            //retriving the value from the newly inserted employee
            byte[] ACTUAL_Photo = insertedEmployee.Photo;

            //perform final testing
            Assert.AreEqual(TARGET_Photo, ACTUAL_Photo, "Photo was not saved with null value.");
        }

        [TestMethod()]
        public void Notes_NullValueToBeInsertedToDatabase_ShouldReturnNullValueFromDatabase()
        {
            //creating a fresh employee object that contains sample data
            Employee freshEmployeeObjectWithValidSampleData = EntityFactory.Factory_CreateFreshEmployeeWithValidSampleData();

            //value to be saved along with new employee, which will be finally checked with the inserted employee record to test if the value was saved succefully
            const string TARGET_Notes = null;

            //putting the target value in the employee entity that will be inserted in database
            freshEmployeeObjectWithValidSampleData.Notes = TARGET_Notes;

            //invoking the data access layer function to create a new employee in database
            int newEmployeeId = Employee.CreateNewEmployee(freshEmployeeObjectWithValidSampleData);

            //retriving the newly inserted employee from database
            Employee insertedEmployee = Employee.GetEmployeeByEmployeeId(newEmployeeId);

            //retriving the value from the newly inserted employee
            string ACTUAL_Notes = insertedEmployee.Notes;

            //perform final testing
            Assert.AreEqual(TARGET_Notes, ACTUAL_Notes, "Notes was not saved with null value.");
        }

        [TestMethod()]
        public void ReportsTo_NullValueToBeInsertedToDatabase_ShouldReturnNullValueFromDatabase()
        {
            //creating a fresh employee object that contains sample data
            Employee freshEmployeeObjectWithValidSampleData = EntityFactory.Factory_CreateFreshEmployeeWithValidSampleData();

            //value to be saved along with new employee, which will be finally checked with the inserted employee record to test if the value was saved succefully
            int? TARGET_ReportsTo = null;

            //putting the target value in the employee entity that will be inserted in database
            freshEmployeeObjectWithValidSampleData.ReportsTo = TARGET_ReportsTo;

            //invoking the data access layer function to create a new employee in database
            int newEmployeeId = Employee.CreateNewEmployee(freshEmployeeObjectWithValidSampleData);

            //retriving the newly inserted employee from database
            Employee insertedEmployee = Employee.GetEmployeeByEmployeeId(newEmployeeId);

            //retriving the value from the newly inserted employee
            int? ACTUAL_ReportsTo = insertedEmployee.ReportsTo;

            //perform final testing
            Assert.AreEqual(TARGET_ReportsTo, ACTUAL_ReportsTo, "ReportsTo was not saved with null value.");
        }

        [TestMethod()]
        public void PhotoPath_NullValueToBeInsertedToDatabase_ShouldReturnNullValueFromDatabase()
        {
            //creating a fresh employee object that contains sample data
            Employee freshEmployeeObjectWithValidSampleData = EntityFactory.Factory_CreateFreshEmployeeWithValidSampleData();

            //value to be saved along with new employee, which will be finally checked with the inserted employee record to test if the value was saved succefully
            const string TARGET_PhotoPath = null;

            //putting the target value in the employee entity that will be inserted in database
            freshEmployeeObjectWithValidSampleData.PhotoPath = TARGET_PhotoPath;

            //invoking the data access layer function to create a new employee in database
            int newEmployeeId = Employee.CreateNewEmployee(freshEmployeeObjectWithValidSampleData);

            //retriving the newly inserted employee from database
            Employee insertedEmployee = Employee.GetEmployeeByEmployeeId(newEmployeeId);

            //retriving the value from the newly inserted employee
            string ACTUAL_PhotoPath = insertedEmployee.PhotoPath;

            //perform final testing
            Assert.AreEqual(TARGET_PhotoPath, ACTUAL_PhotoPath, "PhotoPath was not saved with null value.");
        }
        
        #endregion
    }
}
