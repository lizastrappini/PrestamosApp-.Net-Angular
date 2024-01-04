using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using TP_Final.Domain;

namespace TP_Final.DataAccess
{
    public class PrestamosDbContext : DbContext
    {

        public PrestamosDbContext(DbContextOptions options) : base(options) {
            //this.Database.EnsureDeleted();
            //this.Database.EnsureCreated();
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            if (!modelBuilder.Model.GetEntityTypes().Any(e => e.Name == typeof(Category).Name))
            {
                modelBuilder.Entity<Category>().HasData(
                    new Category { Id = 1, Description = "Libros", CreationDate = DateTime.Now },
                    new Category { Id = 2, Description = "Indumentaria", CreationDate = DateTime.Now },
                    new Category { Id = 3, Description = "Herramientas", CreationDate = DateTime.Now },
                    new Category { Id = 4, Description = "Electronica", CreationDate = DateTime.Now },
                    new Category { Id = 5, Description = "Objetos Varios", CreationDate = DateTime.Now }
                );
                
                modelBuilder.Entity<Person>()
                                .Property(p => p.Dni)
                                .ValueGeneratedNever();
            }
            
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Thing> Thing { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Loan> Loan { get; set; }

        
    }
}
