using Microsoft.AspNetCore.Identity;


namespace VersionClient.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int TipoUsuario { get; set; }
    }
}
