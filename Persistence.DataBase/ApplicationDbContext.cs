using Entities.Model;
using Microsoft.EntityFrameworkCore;
using Persistence.DataBase.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataBase
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ReceptionProducts> ReceptionProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ReceptionProducts>()
               .HasOne(rp => rp.ProviderNavigation)
                .WithMany()
                .HasForeignKey(rp => rp.ProveedorId);

            builder.Entity<ReceptionProducts>()
                .HasOne(rp => rp.ProductNavigation)
                .WithMany()
               .HasForeignKey(rp => rp.ProductoId); builder.Entity<ReceptionProducts>()
               .HasOne(rp => rp.ProviderNavigation)
               .WithMany()
               .HasForeignKey(rp => rp.ProveedorId);

            builder.Entity<ReceptionProducts>()
                .HasOne(rp => rp.ProductNavigation)
              .WithMany()
               .HasForeignKey(rp => rp.ProductoId);
        }

        protected void ModelConfig(ModelBuilder modelBuilder)
        {
            new ProductConfiguration(modelBuilder.Entity<Product>());
            new ProviderConfiguration(modelBuilder.Entity<Provider>());
            new ReceptionProductsConfiguration(modelBuilder.Entity<ReceptionProducts>());
        }

    }
}
