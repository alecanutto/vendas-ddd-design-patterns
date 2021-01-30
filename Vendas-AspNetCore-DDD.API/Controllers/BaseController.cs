using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;
using Vendas_AspNetCore_DDD.API.Filters;
using Vendas_AspNetCore_DDD.Application.Interfaces;
using Vendas_AspNetCore_DDD.Domain.Core.Interfaces.Repositories;
using Vendas_AspNetCore_DDD.Domain.Entities.Generics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Vendas_AspNetCore_DDD.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<Entity, EntityDTO> : ControllerBase where Entity : Base where EntityDTO : class
    {
        private readonly IMediator mediator;
        private readonly IApplicationServiceBase<Entity, EntityDTO> applicationService;

        public BaseController(IMediator mediator, IApplicationServiceBase<Entity, EntityDTO> applicationService)
        {
            this.mediator = mediator;
            this.applicationService = applicationService;
        }

        /// <summary>
        /// Retorna todos os registros
        /// </summary>
        /// <returns>return status ok</returns>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            return Ok(await applicationService.GetAll());
        }

        /// <summary>
        /// Retorna registro por Id
        /// </summary>
        /// <returns>Returns status ok</returns>      
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await applicationService.GetById(id));
        }

        /// <summary>
        /// Adiciona novo registro
        /// </summary>
        /// <returns>return status ok</returns>
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post(EntityDTO entityDTO)
        {
            try
            {
                if (entityDTO == null)
                {
                    return new JsonResult(NotFound());
                }

                applicationService.Add(entityDTO);

                return new JsonResult("Registro adicionado com sucesso!");
            }
            catch (Exception ex)
            {
                return new JsonResult(BadRequest(ex.Message));
            }
        }

        /// <summary>
        /// Altera um registro
        /// </summary>
        /// <returns>return status ok</returns>  
        [HttpPut]
        [Route("")]
        public IActionResult Put(EntityDTO entityDTO)
        {
            try
            {
                if (entityDTO == null)
                {
                    return new JsonResult(NotFound());
                }

                applicationService.Update(entityDTO);

                return new JsonResult("Registro alterado com sucesso!");
            }
            catch (Exception ex)
            {
                return new JsonResult(BadRequest(ex.Message));
            }
        }

        /// <summary>
        /// Exclui um registro
        /// </summary>
        /// <returns>return status ok</returns> 
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var obj = applicationService.GetById(id);
                if (obj == null)
                {
                    return new JsonResult(NotFound());
                }

                applicationService.Remove(id);
                return new JsonResult("Registro excluído com sucesso!");
            }
            catch (Exception ex)
            {
                return new JsonResult(BadRequest(ex.Message));
            }
        }
    }
}