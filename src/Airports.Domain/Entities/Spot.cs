using Airports.Domain.Enums;

namespace Airports.Domain.Entities
{
    public class Spot
    {
        public ResourceType ResourceType { get; } = ResourceType.Spot;
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
