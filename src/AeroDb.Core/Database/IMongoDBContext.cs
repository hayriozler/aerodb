using System.Threading.Tasks;
using MongoDB.Driver;

namespace AeroDb.Core.Database
{
    public interface IMongoDBContext
    {
        IMongoDatabase MongoDatabase { get; }
        string DatabaseName { get; }
        Task<TResult> RunCommandAsync<TResult>(string command);
        Task<TResult> RunCommandAsync<TResult>(string command, ReadPreference readpreference);
    }
}
