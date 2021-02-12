using AeroDb.Core.Database;
using AeroDb.Core.Infrastructure;
using AeroDb.Core.Repositories;
using Core.Domain;
using Core.Domain.Users;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeroDb.Migration
{
    public class InstallationService
    {
        AppDomainTypeFinder typeFinder = new AppDomainTypeFinder();
        private readonly IRepository<AeroDbVersion> _versionRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Country> _countryRepository;
        private readonly IRepository<Region> _regionRepository;
        private readonly IRepository<Language> _languageRepository;
        private readonly IMongoDBContext _mongoDBContext;
        public InstallationService()
        {
            var mongoProvider = new MongoDBProvider();
            _mongoDBContext = new MongoDBContext(mongoProvider);
        }
        private async Task CreateIndexes()
        {
            var repositories = FindRepositories();
            var index = FindIndexiesAttributes();
            //IRepository<AeroDbVersion> repository1 = new Repository<AeroDbVersion>();
            //await _versionRepository.Collection.Indexes.CreateOneAsync(new CreateIndexModel<AeroDbVersion>((Builders<AeroDbVersion>.IndexKeys.Ascending(x => x.AppVersion)),
            // new CreateIndexOptions() { Name = "AppVersion", Unique = true }));
            await Task.CompletedTask;
            
        }
        private async Task CreateTables(string local)
        {
            if (string.IsNullOrEmpty(local))
                local = "en";
            try
            {
                var options = new CreateCollectionOptions();
                var collation = new Collation(local);
                options.Collation = collation;
                var collections = FindCollectionAttributes();
                foreach (var item in collections)
                {
                    await _mongoDBContext.MongoDatabase.CreateCollectionAsync(item.Name, options);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private List<Type> FindRepositories()
        {
            return typeFinder.FindClassesOfType(typeof(IRepository<>)).ToList();
        }
        private List<Type> FindCollectionAttributes()
        {
            return typeFinder.FindClassesOfAttribute(typeof(CollectioNameAttribute)).ToList();
        }
        private List<Type> FindIndexiesAttributes()
        {
            return typeFinder.FindClassesOfAttribute(typeof(IndexAttribute)).ToList();
        }
        public virtual async Task InstallDatabase()
        {
            await CreateTables("en");
            await CreateIndexes();
        }
    }
}
