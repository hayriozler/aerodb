using System;

namespace Shared.Domain
{
    [Serializable]
    public abstract class ParentException : Exception
    {
        public ParentException(): base()
        {
        }
    }
}
