using Airports.Domain.Enums;

namespace Airports.Domain.Entities
{
    public class Runway
    {
        public ResourceType ResourceType { get; } = ResourceType.Runway;
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
