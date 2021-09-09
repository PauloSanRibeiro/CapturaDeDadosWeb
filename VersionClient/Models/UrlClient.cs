using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VersionClient.Models
{
    public class UrlClient
    {
        [Key]
        public int IdUrlClient { get; set; }

        [Required(ErrorMessage = "Endereço obrigatório")]
        [Display(Name = "Endereço")]
        [Index(IsUnique = true)]
        public string Address { get; set; }

        public UrlClient()
        {
        }

        public UrlClient(int idUrlClient, string address)
        {
            IdUrlClient = idUrlClient;
            Address = address;
        }
    }
}
