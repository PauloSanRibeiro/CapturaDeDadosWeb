using System.ComponentModel.DataAnnotations;

namespace VersionClient.Models
{
    public class LoginUser
    {

        [Required(ErrorMessage = "Informe {0} de Acesso")]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Lembrar-me")]
        public bool RememberMe { get; set; }

    }
}
