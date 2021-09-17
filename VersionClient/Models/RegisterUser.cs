using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace VersionClient.Models
{
    public class RegisterUser
    {
      
        [Required(ErrorMessage = ("Preenchimento Obrigatório"))]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = ("Preenchimento Obrigatório"))]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = ("Preenchimento Obrigatório"))]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "A senha deve conter no mínimo {2} caracteres.")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required(ErrorMessage = ("Preenchimento Obrigatório"))]
        [DataType(DataType.Password)]
        [Display(Name = "Confirma Senha")]
        [Compare("Password", ErrorMessage = "As senhas não são iguais")]
        public string ConfirmPassword { get; set; }

    }
}

