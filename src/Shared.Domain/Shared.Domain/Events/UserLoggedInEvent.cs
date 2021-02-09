﻿using MediatR;

namespace Core.Domain
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
