using System;

namespace Core.Domain
{
    [Serializable]
    public abstract class ParentException : Exception
    {
        public ParentException(): base()
        {
        }
    }
}
