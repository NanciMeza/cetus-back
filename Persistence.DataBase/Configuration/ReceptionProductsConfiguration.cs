using Entities.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataBase.Configuration
{
    class ReceptionProductsConfiguration
    {
        public ReceptionProductsConfiguration(EntityTypeBuilder<ReceptionProducts> entityBuilder)
        {

            entityBuilder.Property(x => x.ProductoId).IsRequired();
            entityBuilder.Property(x => x.ProveedorId).IsRequired();
            entityBuilder.Property(x => x.Factura).IsRequired();
            entityBuilder.Property(x => x.Cantidad).IsRequired();
            entityBuilder.Property(x => x.RegistroInvima).IsRequired();
            entityBuilder.Property(x => x.FechaVencimiento).IsRequired();
            entityBuilder.Property(x => x.Estado).IsRequired();
        }
    }
}
