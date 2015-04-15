
namespace Utilities
{

    /// <summary>
    /// Utility class for logging error
    /// Design and Architecture: Mohammad Ashraful Alam [ashraf@mvps.org]
    /// </summary>
    public sealed class ErrorLogger
    {
        private ErrorLogger() { }

        /// <summary>
        /// Sends mail about the lastly occured error to the admin
        /// </summary>
        public static void ReportLastError()
        {
            System.Exception ex = System.Web.HttpContext.Current.Server.GetLastError();
            string logTextHeader = FormatLogText(ex.GetBaseException().Message);
            string logTextBody = ex.ToString();
            Emailer.SendMail("ashraf@mvps.org", "joy_csharp@yahoo.com", logTextHeader, logTextBody, null);
        }

        /// <summary>
        /// Formates the error message
        /// </summary>
        /// <param name="logText">logged error message</param>
        /// <returns>formatted error message</returns>
        static string FormatLogText(string logText)
        {
            return "[ My Site ]" + " at: " + System.DateTime.Now.ToString() + " says: " + logText;
        }
    }
}