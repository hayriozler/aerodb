using Core.Domain.Users;
using MediatR;

namespace Core.Domain.Events
{
    public class UserLoggedInEvent : INotification
    {
        public UserLoggedInEvent(User user)
        {
            User = user;
        }
        public User User
        {
            get; private set;
        }
    }
}
