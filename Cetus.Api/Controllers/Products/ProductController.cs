
using Microsoft.AspNetCore.Mvc;
using Service.Queries;
using Service.Queries.DTOs;
using System.Collections.Generic;

namespace Cetus.Api.Controllers.Productos
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductQueryService _productQueryService;
        public ProductController(IProductQueryService productQueryService)
        {
            _productQueryService = productQueryService;
        }

        /// <summary>
        /// Obtiene la lista de productos registrados
        /// </summary>
        /// <returns>Lista de productos.</returns>
        /// <author>Nanci Meza</author>
        [HttpGet]
        public List<ProductsDTO> GetAll()
            => _productQueryService.GetAll();
        

        /// <summary>
        /// Obtiene un producto por su id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>Objeto tipo producto</returns>
        /// <author>Nanci Meza</author>
        [HttpGet("{productId}")]
        public ProductsDTO GetProductById(int productId)
            => _productQueryService.GetProductById(productId);

    }
}
