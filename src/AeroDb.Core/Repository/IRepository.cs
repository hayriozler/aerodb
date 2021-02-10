using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace AeroDb.Core.Jwt
{
    public interface IRepository<T> where T : ParentEntity
    {

        IMongoCollection<T> Collection { get; }

        IMongoDatabase Database { get; }

        Task<T> GetByIdAsync(string id);
        Task<T> InsertAsync(T entity);

        Task<IEnumerable<T>> InsertAsync(IEnumerable<T> entities);

        Task InsertManyAsync(IEnumerable<T> entities);
        Task<T> UpdateAsync(T entity);

        Task<IEnumerable<T>> UpdateAsync(IEnumerable<T> entities);

        Task<T> DeleteAsync(T entity);

        Task<IEnumerable<T>> DeleteAsync(IEnumerable<T> entities);

        IMongoQueryable<T> Table { get; }

    }
}
