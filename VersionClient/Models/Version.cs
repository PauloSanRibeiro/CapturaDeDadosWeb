using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VersionClient.Models
{
    public class Version
    {
        [Key]
        public int IdVersion { get; set; }
        public string Address { get; set; }
        public Client Client { get; set; }

    }
}
