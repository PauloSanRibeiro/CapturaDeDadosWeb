using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace VersionClient.Models
{
    public class RegisterUser
    {
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha")]
        [Compare("Password", ErrorMessage = "As senhas não são iguais")]
        public string ConfirmPassword { get; set; }

    }
}
