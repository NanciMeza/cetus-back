using Persistence.DataBase;
using Service.Queries.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Queries
{
    public interface IProviderQueryService
    {
        List<ProvidersDTO> GetAll();

        ProvidersDTO GetProviderById(int id);
    }

    public class ProviderQueryService : IProviderQueryService
    {
        //Inyeccion de dependencia
        private readonly ApplicationDbContext Context;
        public ProviderQueryService(ApplicationDbContext context)
        {
            Context = context;
        }

        public List<ProvidersDTO> GetAll()
        {
            return Context.Providers.OrderBy(x => x.NombreRazonSocial)
                .Select(p => new ProvidersDTO()
                {
                    TipoIdentificacion = p.TipoIdentificacion,
                    ProveedorId = p.ProveedorId,
                    NombreRazonSocial = p.NombreRazonSocial,
                    Direccion = p.Direccion,
                    NombreContacto = p.NombreContacto,
                    CelularContacto = p.CelularContacto,
                    Estado = p.Estado
                })
                .ToList();
        }

        public ProvidersDTO GetProviderById(int id)
        {
            return Context.Providers.Where(x => x.ProveedorId == id)
                .Select(p => new ProvidersDTO()
                {
                    TipoIdentificacion = p.TipoIdentificacion,
                    ProveedorId = p.ProveedorId,
                    NombreRazonSocial = p.NombreRazonSocial,
                    Direccion = p.Direccion,
                    NombreContacto = p.NombreContacto,
                    CelularContacto = p.CelularContacto,
                    Estado = p.Estado
                }).FirstOrDefault();
        }
    }
}
