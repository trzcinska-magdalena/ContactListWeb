using ContactListWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactListWeb.Data
{
    public class ContactListWebContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public ContactListWebContext()
        {
        }

        public ContactListWebContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {  
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(100).IsRequired();

                entity.HasData(
                    new Category { Id = 1, Name = "Służbowy" },
                    new Category { Id = 2, Name = "Prywatny" },
                    new Category { Id = 3, Name = "Inny" }
                    );
            });

            modelBuilder.Entity<Subcategory>(entity =>
            {
                entity.ToTable("Subcategory");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(100).IsRequired();

                entity.HasData(
                    new Subcategory { Id = 1, Name = "Szef", CategoryId = 1 },
                    new Subcategory { Id = 2, Name = "Klient", CategoryId = 1 }
                    );

                // Relacja 1-*
                entity.HasOne(e => e.Category)
                .WithMany(e => e.Subcategories)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Surname).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(150).IsRequired();
                entity.Property(e => e.Password).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Phone).HasMaxLength(9).IsRequired();
                entity.Property(e => e.BirthDate).IsRequired();

                // Relacja 1-*
                entity.HasOne(e => e.Category)
                .WithMany(e => e.Contacts)
                .HasForeignKey(e => e.CategoryID);

                // Relacja 1-*
                entity.HasOne(e => e.Subcategory)
                .WithMany(e => e.Contacts)
                .HasForeignKey(e => e.SubcategoryID);

                entity.HasData(
                    new Contact { Id = 1, Name = "Anna", Surname = "Kowal", Email = "anna.kowal@qw.pl", Password = "aniako123A", Phone = "123456789", BirthDate = DateTime.Parse("1900-04-04"), CategoryID = 1, SubcategoryID = 2  }
                    );
            });
        }
    }
}
