using Entities.Model;
using Microsoft.EntityFrameworkCore;
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

        // Se crea metodo para insertar

        string InsertReceptionsProduct(ReceptionProductsDTO reception);
        // se crea para uodate

        string UpdateReceptionsProduct(ReceptionProductsDTO reception);

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
            return Context.ReceptionProducts
                .Include(x => x.ProductNavigation.Nombre)
                .Include(x => x.ProviderNavigation.NombreRazonSocial)
                .OrderByDescending(x => x.FechaHoraRecepcion)
                .Select(r => new ReceptionProductsDTO()
                {
                    Id = r.Id,
                    FechaHoraRecepcion = r.FechaHoraRecepcion,
                    ProductoId = r.ProductoId,
                    ProveedorId = r.ProveedorId,
                    ProductoName = r.ProductNavigation.Nombre,
                    ProveedorName = r.ProviderNavigation.NombreRazonSocial,
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
                    ProductoName = r.ProductNavigation.Nombre,
                    ProveedorName = r.ProviderNavigation.NombreRazonSocial,
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

        public string InsertReceptionsProduct(ReceptionProductsDTO reception)
        {
           ReceptionProducts receptionProducts = new ReceptionProducts();

            receptionProducts.Id = reception.Id;
            receptionProducts.FechaHoraRecepcion=reception.FechaHoraRecepcion;
            receptionProducts.ProductoId = reception.ProductoId;
            receptionProducts.ProveedorId=reception.ProveedorId;
            receptionProducts.Factura =reception.Factura;
            receptionProducts.Cantidad = reception.Cantidad;
            receptionProducts.Lote = reception.Lote;
            receptionProducts.RegistroInvima=reception.RegistroInvima;
            receptionProducts.FechaVencimiento = reception.FechaVencimiento;
            receptionProducts.Descripcion =reception.Descripcion;
            receptionProducts.Estado = reception.Estado;

            Context.ReceptionProducts.Add(receptionProducts);
            Context.SaveChanges();

            return "Recepcion de Productos Guardado Correctamente";
        }

        public string UpdateReceptionsProduct(ReceptionProductsDTO reception)
        {
            ReceptionProducts receptionProducts = Context.ReceptionProducts.Where(p => p.Id == reception.Id).FirstOrDefault();

            if (receptionProducts == null)
            {
                return "La recepcion no existe";
            }


            receptionProducts.Id = reception.Id;
            receptionProducts.FechaHoraRecepcion = reception.FechaHoraRecepcion;
            receptionProducts.ProductoId = reception.ProductoId;
            receptionProducts.ProveedorId = reception.ProveedorId;
            receptionProducts.Factura = reception.Factura;
            receptionProducts.Cantidad = reception.Cantidad;
            receptionProducts.Lote = reception.Lote;
            receptionProducts.RegistroInvima = reception.RegistroInvima;
            receptionProducts.FechaVencimiento = reception.FechaVencimiento;
            receptionProducts.Descripcion = reception.Descripcion;
            receptionProducts.Estado = reception.Estado;

           
            Context.SaveChanges();

            return "Recepcion de Productos actualizado Correctamente";
        }
    }
}
