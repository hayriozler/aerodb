using System;
using System.Text;
using AeroDb.Core.Configs;
using AeroDb.Core.Security;

namespace AeroDb.Core.Data
{
    public static class DatabaseConnectionSetting
    {
        private static string _connectionString;
        private static void InitConnectionString()
        {
            //mongodb://[username:password@]host1[:port1][,...hostN[:portN]][/[defaultauthdb][?options]]
            //username:password@
            var setting = ConfigReader.ConnectionSetting;
            _connectionString = $"mongodb://{setting.UserName}:{ Protection.Unprotect(setting.Password)}{setting.HostNames}";
        }
        public static string ConnectionString()
        {
            if(string.IsNullOrEmpty(_connectionString.ToString()))
            InitConnectionString();
            return _connectionString.ToString();
        }
    }
}
