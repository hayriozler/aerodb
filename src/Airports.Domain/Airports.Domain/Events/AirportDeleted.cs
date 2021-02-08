using Airports.Domain.Entities;
using Common.Domain.Events;

namespace Airports.Domain.Events
{
    public class AirportDeleted : EntityDeleted<Airport>
    {
        public AirportDeleted(Airport airport) : base(airport)
        {

        }
    }
}
