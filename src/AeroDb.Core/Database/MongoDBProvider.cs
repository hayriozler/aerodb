namespace AeroDb.Core.Database
{
    public class MongoDBProvider
    {
        public string ConnectionString => DatabaseConnectionSetting.ConnectionString();
    }
}
