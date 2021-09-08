using Microsoft.EntityFrameworkCore;


namespace VersionClient.Models
{
    public class VersionContext : DbContext
    {
        public VersionContext(DbContextOptions<VersionContext> options) : base(options)
        {
        }

        public DbSet<Client> Client { get; set; }
        public DbSet<UrlClient> Version { get; set; }
    }
}
