using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VersionClient.Models
{
    public class Client
    {
        [Key]
        [Display(Name = "Código")]
        public int IdClient { get; set; }


        [Display(Name = "Nome")]
        [Index(IsUnique = true)]
        [Required(ErrorMessage = "{0} obrigatório")]
        public string NameClient { get; set; }

        public UrlClient UrlClient { get; set; }
        public int IdUrlClient { get; set; }

        public Client(int idClient, string nameClient, UrlClient urlClient)
        {
            IdClient = idClient;
            NameClient = nameClient;
            UrlClient = urlClient;
        }


        /*[Display(Name = "Endereço de Acesso")]
          [Required(ErrorMessage = "{0} obrigatório")]
          public string UrlLogin { get; set; }*/




    }
}
