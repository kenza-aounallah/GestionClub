using Microsoft.EntityFrameworkCore;

namespace ClubsGestionLastVersion.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Club> Clubs { get; set; }
        public DbSet<Membre> Membres { get; set; }
        public DbSet<Activite> Activites { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Evenement> Evenements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure any additional model relationships or constraints here

            base.OnModelCreating(modelBuilder);
        }

    }
}
