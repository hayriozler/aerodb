using System;

namespace Core.Domain
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CollectioNameAttribute : Attribute
    {
        private readonly string collectioName;

        public string CollectioName => collectioName; 
        public CollectioNameAttribute(string collectioName)
        {
            this.collectioName = collectioName;
        }
    }
}
