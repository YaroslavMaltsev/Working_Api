using Microsoft.EntityFrameworkCore;
using Working_Api.Domain.Entities;

namespace Working_Api.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Worker> Workers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>().
                 HasIndex(p => p.NameService).IsUnique(true);

            modelBuilder.Entity<Post>()
                .HasIndex(p => p.NamePost).IsUnique(true);

            modelBuilder.Entity<Project>()
                .HasIndex(p => new { p.NameProject, p.Link }).IsUnique(true);
        }
    }
}
