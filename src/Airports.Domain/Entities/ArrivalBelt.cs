using Airports.Domain.Enums;

namespace Airports.Domain.Entities
{
    public class ArrivalBelt
    {
        public ResourceType ResourceType { get; } = ResourceType.ArrivalBelt;
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
