using System.Runtime.Serialization;

namespace CMS.Models
{
    [DataContract]
    public class Address
    {
        [DataMember]
        public string StreetName { get; set; }
        [DataMember]
        public int StreetNumber { get; set; }
        [DataMember]
        public string PostCode { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Country { get; set; }
    }
}