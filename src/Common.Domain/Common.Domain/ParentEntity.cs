namespace Common.Domain 
{ 
    public abstract class ParentEntity : AuditableEntity
    {
        private string _id;
        public string Id
        {
            get { return _id; }
            set
            {
                if(_id != value)
                    _id = value;
            }
        }
    }
}
