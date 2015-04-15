using System;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.IO;
using System.Net;
using System.Web;
using Entity;
using Utilities;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;


namespace TestHelperRoot
{

    /// <summary>
    /// Design and Architecture: Mohammad Ashraful Alam [ashraf@mvps.org]
    /// </summary>
    public sealed class ReflectorHelper
    {
        ReflectorHelper() { }

        private const BindingFlags CommonFlags = BindingFlags.Public | BindingFlags.NonPublic;

        /// <summary>
        /// 
        /// </summary>
        public static object CreateInstance(Type type, params object[] args)
        {
            return ReflectorHelper.InvokeMember(
                type, null, null,
                ReflectorHelper.CommonFlags | BindingFlags.CreateInstance | BindingFlags.Instance, args);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void SetField(object target, string fieldName, object value)
        {
            ReflectorHelper.InvokeMember(
                target.GetType(), target, fieldName,
                ReflectorHelper.CommonFlags | BindingFlags.SetField | BindingFlags.Instance, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public static object GetField(object target, string fieldName)
        {
            return ReflectorHelper.InvokeMember(
                target.GetType(), target, fieldName,
                ReflectorHelper.CommonFlags | BindingFlags.GetField | BindingFlags.Instance);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void SetProperty(object target, string propertyName, object value)
        {
            ReflectorHelper.InvokeMember(
                target.GetType(), target, propertyName,
                ReflectorHelper.CommonFlags | BindingFlags.SetProperty | BindingFlags.Instance, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public static object GetProperty(object target, string propertyName)
        {
            return ReflectorHelper.InvokeMember(
                target.GetType(), target, propertyName,
                ReflectorHelper.CommonFlags | BindingFlags.GetProperty | BindingFlags.Instance);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void StaticSetField(Type type, string fieldName, object value)
        {
            ReflectorHelper.InvokeMember(
                type, null, fieldName,
                ReflectorHelper.CommonFlags | BindingFlags.SetField | BindingFlags.Static, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public static object StaticGetField(Type type, string fieldName)
        {
            return ReflectorHelper.InvokeMember(
                type, null, fieldName,
                ReflectorHelper.CommonFlags | BindingFlags.GetField | BindingFlags.Static);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void StaticSetProperty(Type type, string propertyName, object value)
        {
            ReflectorHelper.InvokeMember(
                type, null, propertyName,
                ReflectorHelper.CommonFlags | BindingFlags.SetProperty | BindingFlags.Static, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public static object StaticGetProperty(Type type, string propertyName)
        {
            return ReflectorHelper.InvokeMember(
                type, null, propertyName,
                ReflectorHelper.CommonFlags | BindingFlags.GetProperty | BindingFlags.Static);
        }

        /// <summary>
        /// 
        /// </summary>
        public static object CallMethod(object target, string methodName, params object[] args)
        {
            return ReflectorHelper.InvokeMember(
                target.GetType(), target, methodName,
                ReflectorHelper.CommonFlags | BindingFlags.InvokeMethod | BindingFlags.Instance, args);
        }

        public static object StaticCallMethod(Type classType, string methodName)
        {
            return StaticCallMethod(classType, methodName, null);
        }

        public static object StaticCallMethod(Type classType, string methodName, object onlyArgument)
        {
            object[] arguments = new object[] { onlyArgument };
            return StaticCallMethod(classType, methodName, arguments);
        }

        public static object StaticCallMethod(Type classType, string methodName, object[] arguments)
        {
            //return ReflectorHelper.InvokeMember(
            //    type, null, null,
            //    ReflectorHelper.CommonFlags | BindingFlags.InvokeMethod | BindingFlags.Static, args);
            return classType.InvokeMember
                (methodName,
                BindingFlags.InvokeMethod,
                null, null, arguments, System.Globalization.CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// 
        /// </summary>
        private static object InvokeMember(
            Type type, object target, string memberName, BindingFlags flags, params object[] args)
        {
            return type.InvokeMember(memberName, flags, null, target, args);
        }

    }
    
    /// <summary>
    /// Design and Architecture: Mohammad Ashraful Alam [ashraf@mvps.org]
    /// </summary>
    public enum EmployeeDataField
    {
        EmployeeId, FirstName, LastName, Title, TitleOfCourtesy, BirthDate,
        HireDate, Address, City, Region, PostalCode, Country, HomePhone,
        Extension, Photo, Notes, ReportsTo, PhotoPath
    }

    /// <summary>
    /// Having a Factory Method for data entity greatly helps of isolate the instance creation of entity classes that are required to be created in the test cases and thus managing the test cases becomes very easy. The TestHelperRoot.EntityFactory provides these helpful stuffs.
    /// Design and Architecture: Mohammad Ashraful Alam [ashraf@mvps.org]
    /// </summary>
    public sealed class EntityFactory
    {
        EntityFactory() { }

        struct EmployeeSampleData
        {
            public static int EmployeeId = 0;
            public static string LastName = "Alam";
            public static string FirstName = "Ashraful";
            public static string Title = "Mohammad";
            public static string TitleOfCourtesy = "Mr. ";
            public static DateTime BirthDate = new DateTime(1980, 04, 23);
            public static DateTime HireDate = new DateTime(2007, 05, 16);
            public static string Address = "8/3 Kollyanpur Housing Estate";
            public static string City = "Dhaka";
            public static string Region = "Mirpur";
            public static string PostalCode = "1207";
            public static string Country = "Bangladesh";
            public static string HomePhone = "88-02-9010882";
            public static string Extension = "001";
            public static byte[] Photo = new byte[1] { 0 };
            public static string Notes = "Ashraf is a Microsoft MVP.";
            public static int ReportsTo = 1;
            public static string PhotoPath = "/photo/";
        }

        public static Employee Factory_CreateFreshEmployeeWithConstructor(EmployeeDataField dataField, object dataFieldValue)
        {
            string dataFieldValueString = dataFieldValue as string;
            DateTime dataFieldValueDateTime = (dataFieldValue is DateTime ? (DateTime)dataFieldValue : DateTime.MinValue);
            int dataFieldValueInt = (dataFieldValue is int ? (int)dataFieldValue : int.MinValue);

            Employee employee = new Employee(
                (dataField == EmployeeDataField.EmployeeId ? dataFieldValueInt : EmployeeSampleData.EmployeeId),
                (dataField == EmployeeDataField.LastName ? dataFieldValueString : EmployeeSampleData.LastName),
                (dataField == EmployeeDataField.FirstName ? dataFieldValueString : EmployeeSampleData.FirstName),
                (dataField == EmployeeDataField.Title ? dataFieldValueString : EmployeeSampleData.Title),
                (dataField == EmployeeDataField.TitleOfCourtesy ? dataFieldValueString : EmployeeSampleData.TitleOfCourtesy),
                (dataField == EmployeeDataField.BirthDate ? dataFieldValueDateTime : EmployeeSampleData.BirthDate),
                (dataField == EmployeeDataField.HireDate ? dataFieldValueDateTime : EmployeeSampleData.HireDate),
                (dataField == EmployeeDataField.Address ? dataFieldValueString : EmployeeSampleData.Address),
                (dataField == EmployeeDataField.City ? dataFieldValueString : EmployeeSampleData.City),
                (dataField == EmployeeDataField.Region ? dataFieldValueString : EmployeeSampleData.Region),
                (dataField == EmployeeDataField.PostalCode ? dataFieldValueString : EmployeeSampleData.PostalCode),
                (dataField == EmployeeDataField.Country ? dataFieldValueString : EmployeeSampleData.Country),
                (dataField == EmployeeDataField.HomePhone ? dataFieldValueString : EmployeeSampleData.HomePhone),
                (dataField == EmployeeDataField.Extension ? dataFieldValueString : EmployeeSampleData.Extension),
                (dataField == EmployeeDataField.Photo ? (byte[])dataFieldValue : EmployeeSampleData.Photo),
                (dataField == EmployeeDataField.Notes ? dataFieldValueString : EmployeeSampleData.Notes),
                (dataField == EmployeeDataField.ReportsTo ? dataFieldValueInt : EmployeeSampleData.ReportsTo),
                (dataField == EmployeeDataField.PhotoPath ? dataFieldValueString : EmployeeSampleData.PhotoPath)
                );

            return employee;
        }

        public static Employee Factory_CreateFreshEmployeeWithValidSampleData()
        {
            Employee employee = new Employee();

            //------------------------------------

            employee.EmployeeId = EmployeeSampleData.EmployeeId;
            employee.LastName = EmployeeSampleData.LastName;
            employee.FirstName = EmployeeSampleData.FirstName;
            employee.Title = EmployeeSampleData.Title;
            employee.TitleOfCourtesy = EmployeeSampleData.TitleOfCourtesy;
            employee.BirthDate = EmployeeSampleData.BirthDate;
            employee.HireDate = EmployeeSampleData.HireDate;
            employee.Address = EmployeeSampleData.Address;
            employee.City = EmployeeSampleData.City;
            employee.Region = EmployeeSampleData.Region;
            employee.PostalCode = EmployeeSampleData.PostalCode;
            employee.Country = EmployeeSampleData.Country;
            employee.HomePhone = EmployeeSampleData.HomePhone;
            employee.Extension = EmployeeSampleData.Extension;
            employee.Photo = EmployeeSampleData.Photo;
            employee.Notes = EmployeeSampleData.Notes;
            employee.ReportsTo = EmployeeSampleData.ReportsTo;
            employee.PhotoPath = EmployeeSampleData.PhotoPath;

            //------------------------------------

            return employee;
        }

        public static object Factory_CreateFreshEntityWithValidSampleData(string entityName)
        {
            string methodName = "Factory_CreateFresh" + entityName + "WithValidSampleData";
            return
                ReflectorHelper.StaticCallMethod(typeof(TestHelperRoot.EntityFactory), methodName);
        }

    }

    /// <summary>
    /// While doing test, you may want to generate the test schema and data prior to the test case execution, let the test cases modify as required by them and finally turn the database back as it was before the test. This is an excellent process to perform test operations on the live database without having any impact due to test executions. This can be possible with very tiny effort by using COM+ Transaction, which has been implementing in TestHelperRoot.TransactionHelper class.
    /// Design and Architecture: Mohammad Ashraful Alam [ashraf@mvps.org]
    /// </summary>
    public sealed class TransactionHelper
    {
        TransactionHelper() { }

        public static void TransactionStart()
        {
            // Enter a new transaction without inheriting from ServicedComponent
            Console.WriteLine("Attempting to enter a transactional context...");
            ServiceConfig config = new ServiceConfig();
            config.Transaction = TransactionOption.RequiresNew;
            ServiceDomain.Enter(config);
            Console.WriteLine("Attempt suceeded!");

        }

        public static void TransactionLeave()
        {
            Console.WriteLine("Attempting to Leave transactional context...");
            if (ContextUtil.IsInTransaction)
            {
                // Abort the running transaction
                ContextUtil.SetAbort();
            }
            ServiceDomain.Leave();
            Console.WriteLine("Left context!");
        }
    }

    /// <summary>
    /// Design and Architecture: Mohammad Ashraful Alam [ashraf@mvps.org]
    /// </summary>
    public sealed class TestDataHelper
    {
        TestDataHelper(){}

        public static void CreateSchema()
        {
            Utilities.SqlScriptUtility.RunScript(@"..\..\..\..\database\primary-scripts\CreateSchema.sql");
        }

        public static void CleanSchema()
        {
            Utilities.SqlScriptUtility.RunScript(@"..\..\..\..\database\primary-scripts\Clean-Schema.sql");
        }

        public static void GenerateTestData()
        {
            Utilities.SqlScriptUtility.RunScript(@"..\..\..\..\database\primary-scripts\CreateSetupData.sql");
        }

        public static void CleanTestData()
        {
            Utilities.SqlScriptUtility.RunScript(@"..\..\..\..\database\primary-scripts\Clean-Data.sql");
        }

    }

    public sealed class WebServerHelper
    {
        WebServerHelper() { }
        //static Process server;

        public static void StartWebServer()
        {
            if (Process.GetProcessesByName("WebDev.WebServer").Length == 0)
            {
                string webServerExePath = (string)ConfigurationManager.AppSettings["WebServerExePath"];
                //server = new Process();
                Process.Start(webServerExePath, GetWebServerArguments());
            }
        }

        static string GetWebServerArguments()
        {
            string args = String.Format(System.Globalization.CultureInfo.CurrentCulture, "/port:{0} /path:\"{1}\" /vpath:\"{2}\"", GetPort(), GetWebApplicationPath(), GetVPath());
            return args;
        }

        static string GetVPath()
        {
            return "/web";
        }

        static string GetPort()
        {
            return "3301";
        }

        static string GetWebApplicationPath()
        {
            FileInfo f = new FileInfo(@"..\..\..\..\web");
            return f.FullName;
        }
    }

    /// <summary>
    /// Design and Architecture: Mohammad Ashraful Alam [ashraf@mvps.org]
    /// </summary>
    public enum RequiredAccess { Public, Member, Admin }

    /// <summary>
    /// The TestHelperRoot.WebRequestHelper class provides a useful technique to access the pages programmatically that requires authentication.
    /// Design and Architecture: Mohammad Ashraful Alam [ashraf@mvps.org]
    /// </summary>
    public sealed class WebRequestHelper
    {
        public WebRequestHelper()
        {
        }

        public WebRequestHelper(string loginUrl, string userName, string password) 
        {
            _logOnUrl = new Uri(loginUrl);
            _userName = userName;
            _password = password;
        }

        Uri _logOnUrl = null;
        string _userName = string.Empty;
        string _password = string.Empty;

        public HttpStatusCode GetWebpageStatusCode(Uri url, RequiredAccess requiredAccess)
        {
            HttpWebRequest req = ((HttpWebRequest)(WebRequest.Create(url)));
            req.Proxy = new WebProxy();
            req.Proxy.Credentials = CredentialCache.DefaultCredentials;

            if (requiredAccess == RequiredAccess.Member)
                req.CookieContainer = GetSecurityCookie(false);
            else if (requiredAccess == RequiredAccess.Admin)
                req.CookieContainer = GetSecurityCookie(true);

            HttpWebResponse resp = null;
            try
            {
                resp = ((HttpWebResponse)(req.GetResponse()));
                if (resp.StatusCode == HttpStatusCode.OK)
                {
                    if (url.ToString().ToLower(System.Globalization.CultureInfo.CurrentCulture).IndexOf("redirect", StringComparison.CurrentCulture) == -1 && url.ToString().ToLower(System.Globalization.CultureInfo.CurrentCulture).IndexOf(resp.ResponseUri.AbsolutePath.ToLower(System.Globalization.CultureInfo.CurrentCulture), StringComparison.CurrentCulture) == -1)
                    {
                        return HttpStatusCode.NotFound;
                    }
                }
            }
            catch (System.Exception ex)
            {
                while (!(ex == null))
                {
                    Console.WriteLine(ex.ToString());
                    Console.WriteLine("INNER EXCEPTION");
                    ex = ex.InnerException;
                }

                throw;
            }
            finally
            {
                if (!(resp == null))
                {
                    resp.Close();
                }
            }
            return resp.StatusCode;
        }

        public CookieContainer GetSecurityCookie(bool isAdminCookieRequired)
        {
            // first, request the login form to get the viewstate value
            Uri uri = _logOnUrl;
            
            HttpWebRequest webRequest = ((HttpWebRequest)WebRequest.Create(uri));
            StreamReader responseReader = new StreamReader(
                  webRequest.GetResponse().GetResponseStream()
               );
            string responseData = responseReader.ReadToEnd();
            responseReader.Close();

            // extract the viewstate value and build out POST data
            string viewState = ExtractViewState(responseData);

            string postData = string.Empty;

            if (isAdminCookieRequired)
            {
                postData = String.Format(System.Globalization.CultureInfo.CurrentCulture,
                   "__VIEWSTATE={0}&ctl00$ContentPlaceholder1$txtUserName={1}&ctl00$ContentPlaceholder1$txtPassword={2}&ctl00$ContentPlaceholder1$buttonAdminLogOn=admin log in",
                   viewState, _userName, _password
                );
            }
            else
            {
                postData = String.Format(System.Globalization.CultureInfo.CurrentCulture,
                       "__VIEWSTATE={0}&ctl00$ContentPlaceholder1$txtUserName={1}&ctl00$ContentPlaceholder1$txtPassword={2}&ctl00$ContentPlaceholder1$buttonLogOn=log in",
                       viewState, _userName, _password
                    );
            }

            // have a cookie container ready to receive the forms auth cookie
            CookieContainer cookies = new CookieContainer();

            // now post to the login form
            webRequest = WebRequest.Create(uri) as HttpWebRequest;
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.CookieContainer = cookies;

            // write the form values into the request message
            StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());
            requestWriter.Write(postData);
            requestWriter.Close();

            // we don't need the contents of the response, just the cookie it issues
            webRequest.GetResponse().Close();

            //return the cookie
            return cookies;
        }

        private string ExtractViewState(string s)
        {
            string viewStateNameDelimiter = "__VIEWSTATE";
            string valueDelimiter = "value=\"";

            int viewStateNamePosition = s.IndexOf(viewStateNameDelimiter, StringComparison.CurrentCulture);
            int viewStateValuePosition = s.IndexOf(
                  valueDelimiter, viewStateNamePosition, StringComparison.CurrentCulture
               );

            int viewStateStartPosition = viewStateValuePosition +
                                         valueDelimiter.Length;
            int viewStateEndPosition = s.IndexOf("\"", viewStateStartPosition, StringComparison.CurrentCulture);

            return HttpUtility.UrlEncodeUnicode(
                     s.Substring(
                        viewStateStartPosition,
                        viewStateEndPosition - viewStateStartPosition
                     )
                  );
        }
    }
}