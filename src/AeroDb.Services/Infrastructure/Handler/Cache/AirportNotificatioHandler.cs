using System.Threading;
using System.Threading.Tasks;
using AeroDb.Core.Caching;
using AeroDb.Services.Infrastructure.Handler.Cache;
using Airports.Domain.Entities;
using Core.Domain;
using MediatR;

namespace Airports.Services.Infrastructure
{
    public class AirportNotificatioHandler : INotificationHandler<EntityCreated<Airport>>, 
        INotificationHandler<EntityUpdated<Airport>>, 
        INotificationHandler<EntityDeleted<Airport>>
    {
        private ICacheManager _cacheManager;
        public AirportNotificatioHandler(ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }
        public async Task Handle(EntityCreated<Airport> eventMessage, CancellationToken cancellationToken)
        {
            await _cacheManager.RemoveAsync(string.Format(CacheConst.AIRPORT_PATTERN_KEY, eventMessage.Entity.Id), false).ConfigureAwait(false);
        }

        public async Task Handle(EntityUpdated<Airport> eventMessage, CancellationToken cancellationToken)
        {
            await _cacheManager.RemoveAsync(string.Format(CacheConst.AIRPORT_PATTERN_KEY, eventMessage.Entity.Id), false).ConfigureAwait(false);
        }

        public async Task Handle(EntityDeleted<Airport> eventMessage, CancellationToken cancellationToken)
        {
            await _cacheManager.RemoveAsync(string.Format(CacheConst.AIRPORT_PATTERN_KEY, eventMessage.Entity.Id), false).ConfigureAwait(false);
        }
    }
}