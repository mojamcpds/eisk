using System;
using System.Data.SqlClient;
using TestHelperRoot;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.UnitTests.ConfigurationTests
{
    /// <summary>
    /// Design and Architecture: Mohammad Ashraful Alam [ashraf@mvps.org]
    /// </summary>
    [TestClass]
    public class DatabaseConfigurationTests
    {
        public DatabaseConfigurationTests()
        {
            
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext) 
        {
        }
        #endregion

        [TestMethod]
        public void ConnectionTest_OpensAConnection_ShouldPassIfSuccessful()
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(Utilities.ConnectionStringManager.DefaultDBConnectionString))
                {
                    sqlCon.Open();
                }
            }
            catch (Exception e) 
            {
                Assert.Fail("Connection test is failed with the message: " + e.Message);
                throw;
            }
        }

        [TestMethod]
        public void SchemaGenerationTest_RunsSchemaGenerationScript_ShouldPassIfSuccessful()
        {
            try
            {
                TestDataHelper.CreateSchema();
            }
            catch (Exception e)
            {
                Assert.Fail("Schema Generation is failed with the message: " + e.Message);
                throw;
            }
        }

        [TestMethod]
        public void DataGenerationTest_RunsDataGenerationScript_ShouldPassIfSuccessful()
        {
            //TestHelper.Com_Plus_1_5_TransationStart();

            try
            {
                TestDataHelper.GenerateTestData();
            }
            catch (Exception e)
            {
                Assert.Fail("Data Generation is failed with the message: " + e.Message);
                throw;
            }

            //TestHelper.Com_Plus_1_5_TransactionLeave();
        }

        [TestMethod]
        public void SchemaCleanupTest_RunsSchemaCleanupScript_ShouldPassIfSuccessful()
        {
            TransactionHelper.TransactionStart();

            try
            {
                TestDataHelper.CleanSchema();
            }
            catch (Exception e)
            {
                Assert.Fail("Schema Cleanup is failed with the message: " + e.Message);
                throw;
            }

            TransactionHelper.TransactionLeave();
        }

        [TestMethod]
        public void DataCleanupTest_RunsDataCleanupScript_ShouldPassIfSuccessful()
        {
            TransactionHelper.TransactionStart();

            try
            {
                TestDataHelper.CleanTestData();
            }
            catch (Exception e)
            {
                Assert.Fail("Data Cleanup is failed with the message: " + e.Message);
                throw;
            }

            TransactionHelper.TransactionLeave();
        }
    }
}
