using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using Vendas_AspNetCore_DDD.API.Filters;
using Vendas_AspNetCore_DDD.Application.DTOs;
using Vendas_AspNetCore_DDD.Application.Interfaces;
using Vendas_AspNetCore_DDD.Domain.Entities;

namespace Vendas_AspNetCore_DDD.API.Controllers
{
    public class ProdutoController : BaseController<Produto, ProdutoDTO>
    {
        private readonly IApplicationServiceProduto applicationService;

        public ProdutoController(IMediator mediator, IApplicationServiceProduto applicationService) : base(mediator, applicationService)
        {
            this.applicationService = applicationService;
        }

        /// <summary>
        /// Retorna registro por nome
        /// </summary>
        /// <returns>Returns status ok</returns>
        [HttpGet]
        [Route("{name}")]
        public IActionResult GetByName(string name)
        {
            try
            {
                return new OkObjectResult(applicationService.GetByName(name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}