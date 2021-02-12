using System.Collections.Generic;
using Airports.Domain.Enums;
using Core.Domain;

namespace Airports.Domain.Entities
{
    [CollectioName("Airports")]
    public class Airport : ParentEntity
    {
        public IEnumerable<ArrivalBelt> ArrivalBelts { get; }
        public IEnumerable<DepartureBelt> DepartureBelts { get; }
        public IEnumerable<Counter> Counters { get; }
        public IEnumerable<Gate> Gates { get; }
        public IEnumerable<Runway> Runways { get; }
        public IEnumerable<Spot> Spots { get; }
        public IEnumerable<Notam> Notams { get; }
        public IEnumerable<WalkiTalkiFrequency> WalkiTalkiFrequencies { get; }
        public IEnumerable<AirportImage> AirportImages { get; }
        public Contact Contact { get; set; }
        public string IataCode { get; set; }
        public string IcaoCode { get; set; }
        public string Name { get; set; }
        public AirportType AirportType { get; set; }
        public string CountryId { get; set; }
        public string IataRegion { get; set; }
        public double? Latitude { get; set; }
        public double? Longtitude { get; set; }
    }
}
