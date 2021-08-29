using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DatabaseProvider
{
    public partial class MyDb : DbContext
    {
        public MyDb()
            : base("name=MyDb")
        {
        }

        public virtual DbSet<Carousel> Carousels { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ConstrucInformation> ConstrucInformations { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Function> Functions { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductDetail> ProductDetails { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Typee> Typees { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carousel>()
                .Property(e => e.Img)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.CategoriesID);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductDetail>()
                .Property(e => e.Img)
                .IsUnicode(false);

            modelBuilder.Entity<Typee>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Typee)
                .HasForeignKey(e => e.TypeID);
        }
    }
}
