using MediatR;

namespace Common.Domain.Events
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
