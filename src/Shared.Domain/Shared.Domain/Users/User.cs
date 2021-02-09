using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public class User : ParentEntity
    {
        public IEnumerable<UserFavoriteAirlines> UserFavoriteAirlines { get; } = new List<UserFavoriteAirlines>();
        public ICollection<UserFavoriteAirports> UserFavoriteAirports { get; } = new List<UserFavoriteAirports>();
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public DateTime? LastLoginDateUtc { get; set; }
        public string Image { get; set; }
    }

}