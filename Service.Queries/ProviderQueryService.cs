using Entities.Model;
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

        string InsertProvider(ProvidersDTO provider);
        string UpdateProvider(ProvidersDTO provider);
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
                    NumIdentificacion=p.NumIdentificacion,
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
                    NumIdentificacion = p.NumIdentificacion,
                    TipoIdentificacion = p.TipoIdentificacion,
                    ProveedorId = p.ProveedorId,
                    NombreRazonSocial = p.NombreRazonSocial,
                    Direccion = p.Direccion,
                    NombreContacto = p.NombreContacto,
                    CelularContacto = p.CelularContacto,
                    Estado = p.Estado
                }).FirstOrDefault();
        }

        public string InsertProvider(ProvidersDTO provider)
        {

            Provider ProviderBd = new Provider();

            ProviderBd.NombreRazonSocial=provider.NombreRazonSocial;
            ProviderBd.Direccion = provider.Direccion;
            ProviderBd.TipoIdentificacion = provider.TipoIdentificacion;
            ProviderBd.NumIdentificacion=provider.NumIdentificacion;
            ProviderBd.ProveedorId=provider.ProveedorId;
            ProviderBd.NombreContacto=provider.NombreContacto;
            ProviderBd.CelularContacto=provider.CelularContacto;
            ProviderBd.Estado = provider.Estado;
      


            Context.Providers.Add(ProviderBd);
            Context.SaveChanges();

            return "Proveedor Guardado";
        }

        public string UpdateProvider(ProvidersDTO provider)
        {

            Provider ProviderBd = Context.Providers.Where(x => x.ProveedorId==provider.ProveedorId).FirstOrDefault();

            if (ProviderBd == null)
            {
                return "El Proveedor no existe";
            }

            ProviderBd.NombreRazonSocial = provider.NombreRazonSocial;
            ProviderBd.Direccion = provider.Direccion;
            ProviderBd.TipoIdentificacion=provider.TipoIdentificacion;
            ProviderBd.NumIdentificacion = provider.NumIdentificacion;
            ProviderBd.NombreContacto = provider.NombreContacto;
            ProviderBd.CelularContacto = provider.CelularContacto;
            ProviderBd.Estado=provider.Estado;


            Context.SaveChanges();

            return "Proveedor actualizado";
        }


    }
}
