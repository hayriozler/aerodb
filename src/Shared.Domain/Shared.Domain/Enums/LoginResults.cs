namespace Core.Domain
{
    public enum LoginResults
    {
        Successful = 1,
        NotExist = 2,
        WrongPassword = 3,
        NotActive = 4,
        Deleted = 5,
    }
}
