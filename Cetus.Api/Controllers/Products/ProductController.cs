
using Microsoft.AspNetCore.Mvc;

namespace Cetus.Api.Controllers.Productos
{
    [ApiController]
    [Route("products/")]
    public class ProductController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {
            return "Running";
        }

    }
}
