using Entities.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataBase.Configuration
{
    public class ProductConfiguration
    {
        public ProductConfiguration(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.ProductoId);
            entityBuilder.Property(x => x.Nombre).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Descripcion).IsRequired().HasMaxLength(100);

            //Data por default
            var productos = new List<Product>();

            for (int i = 1; i <= 20; i++)
            {
                productos.Add(new Product{
                    ProductoId = i,
                    Nombre = $"Producto {i}",
                    Descripcion = $"Descripcion for product {i}",
                    NombreLaboratorio = $"Laboratory Name for product {i}",
                    Estado = true
                });
            }

            entityBuilder.HasData(productos);
        }
    }
}
