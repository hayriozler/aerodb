using System.Threading.Tasks;
using MongoDB.Driver;

namespace AeroDb.Core.Database
{
    public class MongoDBContext : IMongoDBContext
    {
        private readonly IMongoDBProvider _mongoDBProvider;
        public MongoDBContext(IMongoDBProvider mongoDBProvider)
        {
            _mongoDBProvider = mongoDBProvider;
        }

        public IMongoDatabase MongoDatabase => _mongoDBProvider.MongoDatabase;

        public string DatabaseName => _mongoDBProvider.DatabaseName;

        public async Task<TResult> RunCommandAsync<TResult>(string command)
        {
            return await _mongoDBProvider.MongoDatabase.RunCommandAsync<TResult>(command).ConfigureAwait(false);
        }
        public async Task<TResult> RunCommandAsync<TResult>(string command, ReadPreference readpreference)
        {
            return await _mongoDBProvider.MongoDatabase.RunCommandAsync<TResult>(command, readpreference).ConfigureAwait(false);
        }

    }
}
