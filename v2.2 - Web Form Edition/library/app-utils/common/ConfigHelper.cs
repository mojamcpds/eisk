using System.Configuration;
using System;
namespace HelperUtilities
{
	/// <summary>
    /// Design and Architecture: Mohammad Ashraful Alam [ashraf@mvps.org]
	/// </summary>
    public sealed class ConfigHelper
	{
        ConfigHelper() { }

        public static bool SaveConnectionStringKey(string configFilePhysicalPath, string key, string value)
        {
            try
            {
                ExeConfigurationFileMap m = new ExeConfigurationFileMap();
                m.ExeConfigFilename = configFilePhysicalPath;
                Configuration objConfig = System.Configuration.ConfigurationManager.OpenMappedExeConfiguration(m, ConfigurationUserLevel.None);
                ConnectionStringsSection objAppsettings = (ConnectionStringsSection)objConfig.GetSection("connectionStrings");
                if (objAppsettings != null)
                {
                    objAppsettings.ConnectionStrings[key].ConnectionString = value;
                    objConfig.Save();
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }
	}
}
