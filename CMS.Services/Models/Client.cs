using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Services.Models
{
    public class Client
    {
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public Address Address { get; set; }
        public ClientTypeEnum Type { get; set; }
        public DateTime ClientSince { get; set; }
        public DateTime Birthday { get; set; }
        public bool TACAccepted { get; set; }
    }
}
