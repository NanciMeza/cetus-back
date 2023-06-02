using Persistence.DataBase;
using Service.Queries.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Queries
{
    public interface IReceptionsQueryService
    {
        List<ReceptionProductsDTO> GetAll();
        ReceptionProductsDTO GetReceptionProductsById(int id);
    }

    public class ReceptionsQueryService : IReceptionsQueryService
    {
        //Inyeccion de dependencia
        private readonly ApplicationDbContext Context;
        public ReceptionsQueryService(ApplicationDbContext context)
        {
            Context = context;
        }

        public List<ReceptionProductsDTO> GetAll()
        {
            return Context.ReceptionProducts.OrderByDescending(x => x.FechaHoraRecepcion)
                .Select(r => new ReceptionProductsDTO()
                {
                    Id = r.Id,
                    FechaHoraRecepcion = r.FechaHoraRecepcion,
                    ProductoId = r.ProductoId,
                    ProveedorId = r.ProveedorId,
                    Factura = r.Factura,
                    Cantidad = r.Cantidad,
                    Lote = r.Lote,
                    RegistroInvima = r.RegistroInvima,
                    FechaVencimiento = r.FechaVencimiento,
                    Descripcion = r.Descripcion,
                    Estado = r.Estado,
                })
                .ToList();
        }

        public ReceptionProductsDTO GetReceptionProductsById(int id)
        {
            return Context.ReceptionProducts.Where(x => x.Id == id)
                .Select(r => new ReceptionProductsDTO()
                {
                    Id = r.Id,
                    FechaHoraRecepcion = r.FechaHoraRecepcion,
                    ProductoId = r.ProductoId,
                    ProveedorId = r.ProveedorId,
                    Factura = r.Factura,
                    Cantidad = r.Cantidad,
                    Lote = r.Lote,
                    RegistroInvima = r.RegistroInvima,
                    FechaVencimiento = r.FechaVencimiento,
                    Descripcion = r.Descripcion,
                    Estado = r.Estado,
                })
                .FirstOrDefault();
        }
    }
}
