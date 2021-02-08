using System;

namespace Common.Domain
{
    [Serializable]
    public abstract class ParentException : Exception
    {
        public ParentException(): base()
        {
        }
    }
}
