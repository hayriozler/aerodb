using Airports.Domain.Enums;

namespace Airports.Domain.Entities
{
    public class Counter
    {
        public ResourceType ResourceType { get; } = ResourceType.Counter;
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
