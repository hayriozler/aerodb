using AeroDb.Core.Configs;
using AeroDb.Core.Security;

namespace AeroDb.Core.Database
{
    public static class DatabaseConnectionSetting
    {
        private static string _connectionString;
        private static DbConnectionSetting _databaseConnetionSetting; 
        private static void InitConnectionString()
        {
            //mongodb://[username:password@]host1[:port1][,...hostN[:portN]][/[defaultauthdb][?options]]
            //username:password@
            _databaseConnetionSetting = ConfigReader.ConnectionSetting;
            _connectionString = $"mongodb://{_databaseConnetionSetting.UserName}:{ Protection.Unprotect(_databaseConnetionSetting.Password)}{_databaseConnetionSetting.HostNames}";
        }
        public static string ConnectionString()
        {
            if(string.IsNullOrEmpty(_connectionString.ToString()))
            InitConnectionString();
            return _connectionString.ToString();
        }
        public static string DatabaseName => _databaseConnetionSetting.DatabaseName;
    }
}
