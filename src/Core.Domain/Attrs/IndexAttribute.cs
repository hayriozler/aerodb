using Core.Domain.Enums;
using System;

namespace Core.Domain
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IndexAttribute : Attribute
    {
        public OrderBy OrderBy { get; }
        public string Name { get; }
        public bool Unique { get; }

        public IndexAttribute(string name, OrderBy orderBy, bool unique )
        {
            OrderBy = orderBy;
            Name = name;
            Unique = unique;
        }
    }
}
