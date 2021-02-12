namespace Core.Domain
{
    [CollectioName("Languages")]
    public class Language : ParentEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
