using System;
using System.Runtime.Serialization;

namespace CMS.Models
{
    [DataContract]
    public class Client
    {
        [DataMember]
        public Guid ClientId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Lastname { get; set; }
        [DataMember]
        public Address Address { get; set; }
        [DataMember]
        public ClientTypeEnum Type { get; set; }
        [DataMember]
        public DateTime ClientSince { get; set; }
        [DataMember]
        public DateTime Birthday { get; set; }
        [DataMember]
        public bool TACAccepted { get; set; }
    }
}
