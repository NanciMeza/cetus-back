
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

        [HttpGet]
        public List<ProductsDTO> GetAll()
        {
            return _productQueryService.GetAll();
        }

        [HttpGet("{id}")]
        public ProductsDTO GetProductById(int id)
        {
            return _productQueryService.GetProductById(id);
        }

    }
}
