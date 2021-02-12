using System.Collections.Generic;

namespace Airports.Domain.Entities
{
    public class Contact
    {
        public IEnumerable<EmailAddress> EmailAddresses { get; set; }
        public string ManagementCompanyName { get; set; }
        public string WebAddress { get; set; }
    }
}
