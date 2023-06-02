using Entities.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataBase.Configuration
{
    public class ProviderConfiguration
    {
        public ProviderConfiguration(EntityTypeBuilder<Provider> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.ProveedorId);
            entityBuilder.Property(x => x.NumIdentificacion).IsRequired().HasMaxLength(10);
            entityBuilder.Property(x => x.NombreRazonSocial).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.NombreContacto).IsRequired().HasMaxLength(100);

            //Data por default
            var providers = new List<Provider>();

            for (int i = 1; i <= 20; i++)
            {
                providers.Add(new Provider
                {
                    ProveedorId = i,
                    NumIdentificacion = 1,
                    TipoIdentificacion = "NIT",
                    NombreRazonSocial = $"Provider {i}",
                    Direccion = $"Address for Provider {i}",
                    NombreContacto = $"Contact Name for Provider {i}",
                    CelularContacto = $"Contact Mobile for Provider {i}",
                    Estado = true
                });
            }

            entityBuilder.HasData(providers);
        }
    }
}
