using Airports.Domain.Enums;

namespace Airports.Domain.Entities
{
    public class DepartureBelt
    {
        public ResourceType ResourceType { get; } = ResourceType.DepartureBelt;
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
