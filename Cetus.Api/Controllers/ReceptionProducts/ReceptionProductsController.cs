using Microsoft.AspNetCore.Mvc;
using Service.Queries;
using Service.Queries.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cetus.Api.Controllers.ReceptionProducts
{
    [ApiController]
    [Route("receptionProducts")]
    public class ReceptionProductsController : ControllerBase
    {
        private readonly IReceptionsQueryService _receptionProductsQueryService;
        
        public ReceptionProductsController(IReceptionsQueryService receptionProductsQueryService)
        {
            _receptionProductsQueryService = receptionProductsQueryService;
        }

        [HttpGet]
        public List<ReceptionProductsDTO> GetAll()
            => _receptionProductsQueryService.GetAll();

        /// <summary>
        /// Obtiene la lista recepciones de productos
        /// </summary>
        /// <param name="receptionId"></param>
        /// <returns>Lista recepciones.</returns>
        /// <author>Nanci Meza</author>
        [HttpGet("{receptionId}")]
        public ReceptionProductsDTO GetReceptionProductsById(int receptionId)
            => _receptionProductsQueryService.GetReceptionProductsById(receptionId);
        

    }
}
