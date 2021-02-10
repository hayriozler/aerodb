using MongoDB.Driver;

namespace AeroDb.Core.Database
{
    public class MongoDBProvider : IMongoDBProvider
    {
        public MongoClient MongoClient => new MongoClient(new MongoUrl(DatabaseConnectionSetting.ConnectionString()));
        public IMongoDatabase MongoDatabase => MongoClient.GetDatabase(DatabaseConnectionSetting.DatabaseName);
        public string DatabaseName => DatabaseConnectionSetting.DatabaseName;
    }

}
