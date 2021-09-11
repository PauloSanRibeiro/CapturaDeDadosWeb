using HtmlAgilityPack;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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



        [Display(Name = "Endereço de Acesso")]
        [Required(ErrorMessage = "{0} obrigatório")]
        public string UrlLogin { get; set; }

        public string Versions { get; set; }

    }
}
