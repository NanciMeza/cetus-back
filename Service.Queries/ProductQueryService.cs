using Entities.Model;
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

        string InsertProduct(ProductsDTO product);
        string UpdateProduct(ProductsDTO product);
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

        public string InsertProduct(ProductsDTO products)
        {

            Product ProductoBd = new Product();

            ProductoBd.Nombre= products.Nombre;
            ProductoBd.Descripcion= products.Descripcion;
            ProductoBd.NombreLaboratorio= products.NombreLaboratorio;
            ProductoBd.Estado = products.Estado;
            Context.Products.Add(ProductoBd);
            Context.SaveChanges();

            return "Ok";
        }

        public string UpdateProduct(ProductsDTO products)
        {

            Product ProductoBd =Context.Products.Where(x => x.ProductoId==products.ProductoId).FirstOrDefault();

            if(ProductoBd == null)
            {
                return "el producto no existe";
            }

            ProductoBd.Nombre = products.Nombre;
            ProductoBd.Descripcion = products.Descripcion;
            ProductoBd.NombreLaboratorio = products.NombreLaboratorio;
            ProductoBd.Estado = products.Estado;
            Context.SaveChanges();

            return "producto actualizado";
        }
    }
}
