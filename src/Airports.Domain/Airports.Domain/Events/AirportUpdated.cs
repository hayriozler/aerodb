using Airports.Domain.Entities;
using Shared.Domain.Events;

namespace Airports.Domain.Events
{
    public class AirportUpdated : EntityUpdated<Airport>
    {
        public AirportUpdated(Airport airport) : base(airport)
        {

        }
    }
}
