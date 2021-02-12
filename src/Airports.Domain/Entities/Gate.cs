using Airports.Domain.Enums;

namespace Airports.Domain.Entities
{
    public class Gate
    {
        public ResourceType ResourceType { get; } = ResourceType.Gate;
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
