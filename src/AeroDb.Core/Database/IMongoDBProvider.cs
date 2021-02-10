using MongoDB.Driver;

namespace AeroDb.Core.Database
{
    public interface IMongoDBProvider
    {
        MongoClient MongoClient { get; }
        string DatabaseName { get; }

        IMongoDatabase MongoDatabase { get; }
    }

}
