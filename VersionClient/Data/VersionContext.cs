using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace VersionClient.Models
{
    public class VersionContext : IdentityDbContext
    {
        private readonly DbContextOptions _options;



        public VersionContext(DbContextOptions options) : base(options)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Client> Client { get; set; }
        //public DbSet<LoginUser> LoginUsers { get; set; }
        //public DbSet<RegisterUser> RegisterUsers { get; set; }




    }
}
