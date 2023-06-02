using Microsoft.AspNetCore.Mvc;
using Service.Queries;
using Service.Queries.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cetus.Api.Controllers.Providers
{
    [ApiController]
    [Route("providers")]
    public class ProvidersController : ControllerBase
    {
        private readonly IProviderQueryService _providerQueryService;
        public ProvidersController(IProviderQueryService providerQueryService)
        {
            _providerQueryService = providerQueryService;
        }

        [HttpGet]
        public List<ProvidersDTO> GetAll()
            => _providerQueryService.GetAll();
        

        [HttpGet("{providerId}")]
        public ProvidersDTO GetProviderById(int providerId)
            => _providerQueryService.GetProviderById(providerId);



        /// <summary>
        /// inserta  un Proveedor 
        /// </summary>
        /// <param name="providers"></param>
        /// <returns>Objeto tipo Proveedor</returns>
        /// <author>Nanci Meza</author>
        [HttpPost]
        public string InsertProduct(ProvidersDTO providers)
            => _providerQueryService.InsertProvider(providers);

        /// <summary>
        /// actualiza un Proveedor
        /// </summary>
        /// <param name="providers"></param>
        /// <returns>Objeto tipo Proveedor</returns>
        /// <author>Nanci Meza</author>
        [HttpPut]
        public string UpdateProduct(ProvidersDTO providers)
            => _providerQueryService.UpdateProvider(providers);

    }
}
