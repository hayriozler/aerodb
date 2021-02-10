using System;
using System.Threading;
using System.Threading.Tasks;
using Core.Domain;
using MediatR;

namespace Core.Services.Infrastructure.Handler
{
    public class UserLoggedInEventHandler : INotificationHandler<UserLoggedInEvent>
    {

        public UserLoggedInEventHandler()
        {

        }
        public Task Handle(UserLoggedInEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
