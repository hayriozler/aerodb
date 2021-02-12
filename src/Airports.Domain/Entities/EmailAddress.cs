using Core.Domain;

namespace Airports.Domain.Entities
{
    [CollectioName("EmailAddresses")]

    public class EmailAddress
    {
        public string Email { get; set; }
        public string EmailType { get; set; }
    }
}
