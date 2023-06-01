using Persistence.DataBase;
using Service.Queries.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Queries
{
    public interface IProductQueryService
    {
        List<ProductsDTO> GetAll();

        ProductsDTO GetProductById(int id);
    }
    
    public class ProductQueryService : IProductQueryService
    {
        //Inyeccion de dependencia
        private readonly ApplicationDbContext Context;
        public ProductQueryService(ApplicationDbContext context)
        {
            Context = context;
        }

        public List<ProductsDTO> GetAll()
        {
            return Context.Products.OrderBy(x => x.Nombre)
                .Select(p => new ProductsDTO()
                {
                    ProductoId = p.ProductoId,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    NombreLaboratorio = p.NombreLaboratorio,
                    Estado = p.Estado
                })
                .ToList();
        }

        public ProductsDTO GetProductById(int id)
        {
            return Context.Products.Where(x => x.ProductoId == id)
                .Select(p => new ProductsDTO()
                {
                    ProductoId = p.ProductoId,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion,
                    NombreLaboratorio = p.NombreLaboratorio,
                    Estado = p.Estado
                }).FirstOrDefault();
        }
    }
}
