using Microsoft.EntityFrameworkCore;

namespace dotnetAspExample
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Disco> Discos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) 
        => options.UseSqlite(@"Data Source=discos.db");
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artista>()
            .HasMany(b => b.discos).WithOne();
        }
    }
}