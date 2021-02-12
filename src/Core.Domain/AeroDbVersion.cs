namespace Core.Domain
{
    [CollectioName("AeroDbVersions")]
    public class AeroDbVersion : ParentEntity
    {
        public string DataBaseVersion { get; set; }
        public string AppVersion { get; set; }
    }
}
