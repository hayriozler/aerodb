using MediatR;

namespace Core.Domain
{
    public class EntityUpdated<T> : INotification where T : ParentEntity

    {
        public EntityUpdated(T entity)
        {
            Entity = entity;
        }
        public T Entity { get; private set; }
    }
}
