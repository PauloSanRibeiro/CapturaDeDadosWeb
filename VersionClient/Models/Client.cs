using System.ComponentModel.DataAnnotations;

namespace VersionClient.Models
{
    public class Client
    {
        [Key]
        [Display(Name = "Código")]
        public int IdClient { get; set; }

        [Display(Name = "Nome")]
        public string NameClient { get; set; }

        [Display(Name = "Endereço de Acesso")]
        public string UrlLogin { get; set; }


    }
}
