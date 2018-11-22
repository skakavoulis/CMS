using System;
using System.Runtime.Serialization;

namespace CMS.Repositories.Models
{
    public class ClientRepo
    {
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public AddressRepo Address { get; set; }
        public ClientTypeRepoEnum Type { get; set; }
        public DateTime ClientSince { get; set; }
        public DateTime Birthday { get; set; }
        public bool TACAccepted { get; set; }
    }
}
