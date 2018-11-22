using System.Runtime.Serialization;

namespace CMS.Repositories.Models
{
    public class AddressRepo
    {
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}