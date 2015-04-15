using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.IO;
using TestHelperRoot;
using System.Web;

namespace Tests.UnitTests.ConfigurationTests
{
    /// <summary>
    /// Summary description for ProjectConfigurationTests
    /// </summary>
    [TestClass]
    public class ProjectConfigurationTests
    {
        public ProjectConfigurationTests()
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
            TestDataHelper.CreateSchema();
        }
        #endregion

        [TestMethod]
        [DeploymentItem("..\\tests\\App_Data\\Links.xml")]
        [DataSource("MyXmlDataSource")]
        public void LinkTest_ListingPage_ShouldPassIfFound()
        {
            string urlToTest = testContextInstance.DataRow["EmployeeListingPage"].ToString();
            HttpStatusCode result = new WebRequestHelper().GetWebpageStatusCode(new Uri(urlToTest), RequiredAccess.Public);
            Assert.IsTrue(result == HttpStatusCode.OK, result.ToString());
        }

        [TestMethod]
        [DeploymentItem("..\\tests\\App_Data\\Links.xml")]
        [DataSource("MyXmlDataSource")]
        public void LinkTest_AdminSecuredDefaultPage_ShouldPassIfFound()
        {
            string urlToTest = testContextInstance.DataRow["AdminSecuredDefaultPage"].ToString();
            string urlToLogin = testContextInstance.DataRow["LoginPage"].ToString();
            WebRequestHelper webRequestHelper = new WebRequestHelper(urlToLogin, "any", "any");
            HttpStatusCode result = webRequestHelper.GetWebpageStatusCode(new Uri(urlToTest), RequiredAccess.Admin);
            Assert.IsTrue(result == HttpStatusCode.OK, result.ToString());
        }

        [TestMethod]
        [DeploymentItem("..\\tests\\App_Data\\Links.xml")]
        [DataSource("MyXmlDataSource")]
        public void LinkTest_MemberSecuredDefaultPage_ShouldPassIfFound()
        {
            string urlToTest = testContextInstance.DataRow["MemberSecuredDefaultPage"].ToString();
            string urlToLogin = testContextInstance.DataRow["LoginPage"].ToString();
            WebRequestHelper webRequestHelper = new WebRequestHelper(urlToLogin, "any", "any");
            HttpStatusCode result = webRequestHelper.GetWebpageStatusCode(new Uri(urlToTest), RequiredAccess.Member);
            Assert.IsTrue(result == HttpStatusCode.OK, result.ToString());
        }

        [TestMethod]
        public void EmailTest_SendAnEmail_ShouldPassIfSuccessfullySent()
        {
            try
            {
                Utilities.Emailer.SendMail("ashraf@mvps.com", "joy_csharp@yahoo.com", "[ My Site ] at:" + DateTime.Now.ToString(), "test", null);
            }
            catch (SmtpException ex)
            {
                Assert.Fail("Send email is failed with the message: " + ex.Message);
            }
            catch (Exception ex2)
            {
                Assert.Fail("Send email is failed with the message: " + ex2.Message);
                throw;
            }

        }

        [TestMethod]
        public void ReferencedAssembliesTest_LoadsAllReferenceDll_PassesIfAllReferringDllExistsPhysically()
        {
            // Get the executing assembly
            Assembly asm = Assembly.GetExecutingAssembly();
            // Get the assemblies that are referenced
            AssemblyName[] refAsms = asm.GetReferencedAssemblies();
            // Loop through and try to load each assembly
            foreach (AssemblyName refAsmName in refAsms)
            {
                try
                {
                    Assembly.Load(refAsmName);
                    Console.WriteLine(refAsmName.FullName);
                }
                catch (FileNotFoundException)
                {
                    // Missing assembly
                    Assert.Fail(refAsmName.FullName + " failed to load");
                }
            }
        }

        [TestMethod]
        [DeploymentItem("..\\tests\\App_Data\\Links.xml")]
        public void FileTest_LinkXml()
        {
            System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();
            xDoc.Load("Links.xml");
        }
    }
}
