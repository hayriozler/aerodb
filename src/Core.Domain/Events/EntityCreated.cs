using MediatR;

namespace Core.Domain
{
    public class EntityCreated<T> : INotification where T : ParentEntity

    {
        public EntityCreated(T entity)
        {
            Entity = entity;
        }
        public T Entity { get; private set; }
    }
}
