using Airports.Domain.Entities;
using Common.Domain.Events;

namespace Airports.Domain.Events
{
    public class AirportUpdated : EntityUpdated<Airport>
    {
        public AirportUpdated(Airport airport) : base(airport)
        {

        }
    }
}
