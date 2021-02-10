using Core.Domain;
using Microsoft.Extensions.Configuration;

namespace AeroDb.Core.Configs
{
    public static class ConfigReader
    {
        private static DbConnectionSetting _connectionSetting;

        public static IConfiguration Configuration { get; set; }
        public static T ReadConfig<T>(string section) where T : class, new()
        {
            var t = new T();
            Configuration.GetSection(section).Bind(t);
            return t;
        }

        public static IConfigurationSection GetSection(string section)
        {
            return Configuration.GetSection(section);
        }
        public static DbConnectionSetting ConnectionSetting
        {
            get
            {
                if (_connectionSetting is null)
                {
                    _connectionSetting = new DbConnectionSetting();
                    var connectionSetting = Configuration.GetSection("DbConnections");
                    if (connectionSetting != null)
                        connectionSetting.Bind(_connectionSetting);
                }
                return _connectionSetting;
            }
        }
    }
}
