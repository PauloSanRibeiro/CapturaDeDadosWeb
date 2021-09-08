using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VersionClient.Models
{
    public class UrlClient
    {
        public int IdUrlClient { get; set; }
        public string Address { get; set; }

        public UrlClient()
        {
        }

        public UrlClient(int id, string address)
        {
            IdUrlClient = id;
            Address = address;
        }
    }
}
