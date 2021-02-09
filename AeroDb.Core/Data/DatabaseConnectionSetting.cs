using System;
using System.Text;
using AeroDb.Core.Configs;

namespace AeroDb.Core.Data
{
    public static class DatabaseConnectionSetting
    {
        private static string _prefix = "mongo://";
        private static bool? _databaseIsInstalled;
        private static StringBuilder _connectionString;
        public static bool DatabaseIsInstalled()
        {
            if (!_databaseIsInstalled.HasValue)
            {
               
            }
            return _databaseIsInstalled.Value;
        }
        public static void InitConnectionString()
        {
            //mongodb://mongodb0.example.com:27017 standAlone
            //mongodb://mongodb0.example.com:27017,mongodb1.example.com:27017,mongodb2.example.com:27017/?replicaSet=myRepl  //replicaSet
            //mongodb://mongos0.example.com:27017,mongos1.example.com:27017,mongos2.example.com:27017 //Shareded Cluster

            var settings = ConfigReader.ConnectionSetting;
            _connectionString.AppendLine(_prefix);
            foreach (var setting in settings)
            {
                _connectionString.AppendLine(setting.
            }
        }
        public static string ConnectionString()
        {
            return _connectionString;
        }
    }
}
