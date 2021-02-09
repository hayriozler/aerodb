using Airports.Domain.Entities;
using Shared.Domain.Events;

namespace Airports.Domain.Events
{
    public class AirportDeleted : EntityDeleted<Airport>
    {
        public AirportDeleted(Airport airport) : base(airport)
        {

        }
    }
}
