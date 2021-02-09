using Airports.Domain.Entities;
using Shared.Domain.Events;

namespace Airports.Domain.Events
{
    public class AirportCreated : EntityCreated<Airport>
    {
        public AirportCreated(Airport airport):base(airport)
        {

        }
    }
}
