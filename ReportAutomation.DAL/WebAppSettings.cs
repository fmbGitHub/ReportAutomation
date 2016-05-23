using System;
using System.Configuration;

namespace ReportAutomation.Models
{
    public class WebAppSettings
    {
        #region Singleton of WebAppSettings
        private static WebAppSettings _Instance = null;

        public static WebAppSettings Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new WebAppSettings();

                return _Instance;
            }
        }
        #endregion
      
        public string GetConnectionString(string key)
        {
            return ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }

        public string ConnectString
        {
            get
            {
                var currentConnectionString = ConfigurationManager.AppSettings["DefaultConnectionString"];                
                return GetConnectionString(currentConnectionString);
            }
        }

        public string Username
        {
            get { return ConfigurationManager.AppSettings["Username"]; }
        }
    }
}