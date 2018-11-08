using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using nstu_olympiad_site.Models;

namespace nstu_olympiad_site.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Competitor> Competitors { get; set; }
        public DbSet<School> Organizations { get; set; }
        public DbSet<Clarification> Clarifications { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Compilator> Compilators { get; set; }
        public DbSet<Contest> Contests { get; set; }
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<CheckLog> CheckLogs { get; set; }
        public DbSet<BinaryData> BinaryData { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Ignore<Competitor>();
        }
    }

}