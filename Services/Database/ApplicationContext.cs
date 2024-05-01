using fileServer.Models;
using Microsoft.EntityFrameworkCore;

namespace fileServer.Services.Databases{
    public class ApplicationContext : DbContext{
        public DbSet<DocumentFile> Files { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();  
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder){

        }
    }
}