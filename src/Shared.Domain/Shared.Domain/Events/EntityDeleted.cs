using MediatR;

namespace Shared.Domain.Events
{
    public class EntityDeleted<T> : INotification where T : ParentEntity

    {
        public EntityDeleted(T entity)
        {
            Entity = entity;
        }
        public T Entity { get; private set; }
    }
}
