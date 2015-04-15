namespace Utilities
{
    using System;
    using System.Data.SqlClient;


    /// <summary>
    /// Includes necessary methods and properties considering dtabase connection string, used mainly by 'DatabaseUtility' class methods.
    /// Class architecture designed by: Mohammad Ashraful Alam [ ashraf@mvps.org ]
    /// </summary>
    public sealed class ConnectionStringManager
    {
        private ConnectionStringManager() { }

        #region Connection String

        static string _defaultDBConnectionString = string.Empty;

        /// <summary>
        /// Read connection string from web.config and
        /// set the default database connection string property.
        /// </summary>
        public static string DefaultDBConnectionString
        {
            get
            {
                _defaultDBConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[Keys.ConstConnectionStringKey].ConnectionString;
                if (String.IsNullOrEmpty(_defaultDBConnectionString))
                    return String.Empty;
                else
                    return _defaultDBConnectionString;
            }
            //set { _defaultDBConnectionString = value; }
        }

       #endregion

        /// <summary>
        /// Returns the formatted connection according to the parameters
        /// </summary>
        /// <param name="dataSource">Data source name</param>
        /// <param name="database">Database name</param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>Connection string</returns>
        public static string GetConnectionString(string dataSource, string database, string userName, string password)
        {
            return "Data Source=" + dataSource + ";Initial Catalog=" + database + 
                ";Persist Security Info=True;User ID=" + userName + "; Password=" + password + ";";
            
        }

        public static bool IsConnectionStringOk()
        {
            return IsConnectionStringOk(DefaultDBConnectionString);
        }

        public static bool IsConnectionStringOk(string connectionString)
        {
            try
            {
                SqlConnection sqlConn = new SqlConnection(connectionString);
                sqlConn.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}