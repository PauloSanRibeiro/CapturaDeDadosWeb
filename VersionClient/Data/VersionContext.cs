using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace VersionClient.Models
{
    public class VersionContext : IdentityDbContext
    {


        public VersionContext(DbContextOptions<VersionContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Client> Client { get; set; }


    }
}
