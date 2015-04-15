using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TeamSystem.Data.UnitTesting;

namespace Tests.DatabaseUnitTests
{
    [TestClass()]
    public class DatabaseUnitTest_CreateNewEmployee_ValidParametersPassed_ShouldReturnNonzeroClass : DatabaseTestClass
    {
        public DatabaseUnitTest_CreateNewEmployee_ValidParametersPassed_ShouldReturnNonzeroClass()
        {
            InitializeComponent();
        }

        [TestInitialize()]
        public void TestInitialize()
        {
            //TestHelper.Com_Plus_1_5_TransationStart();
            base.InitializeTest();
        }
        [TestCleanup()]
        public void TestCleanup()
        {
            //TestHelper.Com_Plus_1_5_TransactionLeave();            
            base.CleanupTest();
        }

        [TestMethod()]
        public void DatabaseUnitTest_CreateNewEmployee_ValidParametersPassed_ShouldReturnNonzero()
        {
            DatabaseTestActions testActions = this.DatabaseUnitTest_CreateNewEmployee_ValidParametersPassed_ShouldReturnNonZeroData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            //ExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            // Execute the test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
            //ExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            // Execute the post-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
            //ExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
        }
        public void DatabaseUnitTest_CreateNewEmployee_ValidParametersPassed_ShouldReturnNonZero()
        {
            DatabaseTestActions testActions = this.DatabaseUnitTest_CreateNewEmployee_ValidParametersPassed_ShouldReturnNonZeroData;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            ExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            // Execute the test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
            ExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            // Execute the post-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
            ExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
        }

        #region Designer support code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.VisualStudio.TeamSystem.Data.UnitTesting.DatabaseTestAction DatabaseUnitTest_CreateNewEmployee_ValidParametersPassed_ShouldReturnNonZero_TestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseUnitTest_CreateNewEmployee_ValidParametersPassed_ShouldReturnNonzeroClass));
            this.DatabaseUnitTest_CreateNewEmployee_ValidParametersPassed_ShouldReturnNonZeroData = new Microsoft.VisualStudio.TeamSystem.Data.UnitTesting.DatabaseTestActions();
            DatabaseUnitTest_CreateNewEmployee_ValidParametersPassed_ShouldReturnNonZero_TestAction = new Microsoft.VisualStudio.TeamSystem.Data.UnitTesting.DatabaseTestAction();
            // 
            // DatabaseUnitTest_CreateNewEmployee_ValidParametersPassed_ShouldReturnNonZero_TestAction
            // 
            resources.ApplyResources(DatabaseUnitTest_CreateNewEmployee_ValidParametersPassed_ShouldReturnNonZero_TestAction, "DatabaseUnitTest_CreateNewEmployee_ValidParametersPassed_ShouldReturnNonZero_Test" +
                    "Action");
            // 
            // DatabaseUnitTest_CreateNewEmployee_ValidParametersPassed_ShouldReturnNonZeroData
            // 
            this.DatabaseUnitTest_CreateNewEmployee_ValidParametersPassed_ShouldReturnNonZeroData.PosttestAction = null;
            this.DatabaseUnitTest_CreateNewEmployee_ValidParametersPassed_ShouldReturnNonZeroData.PretestAction = null;
            this.DatabaseUnitTest_CreateNewEmployee_ValidParametersPassed_ShouldReturnNonZeroData.TestAction = DatabaseUnitTest_CreateNewEmployee_ValidParametersPassed_ShouldReturnNonZero_TestAction;
        }

        #endregion

        private DatabaseTestActions DatabaseUnitTest_CreateNewEmployee_ValidParametersPassed_ShouldReturnNonZeroData;
    }
}
