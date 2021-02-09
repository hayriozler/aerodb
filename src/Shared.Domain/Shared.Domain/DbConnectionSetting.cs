namespace Shared.Domain
{
    public class DbConnectionSetting
    {
       
        public string Url
        {
            get;
            set;
        }
        public int Port
        {
            get;
            set;
        }
        public string UserName
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
        public int ConnectTimeoutMS
        {
            get;
            set;
        }
        public string ReplicaSet { get; set; }
    }
}
