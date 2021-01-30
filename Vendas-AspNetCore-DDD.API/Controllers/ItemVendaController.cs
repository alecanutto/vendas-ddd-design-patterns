using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using Vendas_AspNetCore_DDD.API.Filters;
using Vendas_AspNetCore_DDD.Application.DTOs;
using Vendas_AspNetCore_DDD.Application.Interfaces;

namespace Vendas_AspNetCore_DDD.API.Controllers
{
    [Route("api/v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ItemVendaController : Controller
    {
        readonly private IApplicationServiceItemVenda applicationService;

        public ItemVendaController(IApplicationServiceItemVenda applicationService)
        {
            this.applicationService = applicationService;
        }

        /// <summary>
        /// Retorna todos os itens da venda
        /// </summary>
        /// <returns>Returns status ok</returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAllByVendaId(int id)
        {
            try
            {
                return new OkObjectResult(applicationService.GetAllByVendaId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Adiciona novo registro
        /// </summary>
        /// <returns>return status ok</returns>
        [HttpPost]
        [Route("")]
        public IActionResult Post([FromBody] ItemVendaDTO entityDTO)
        {
            try
            {
                if (entityDTO == null)
                    return NotFound();

                applicationService.Add(entityDTO);
                return Created("", entityDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Altera um registro
        /// </summary>
        /// <returns>return status ok</returns>
        [HttpPut]
        [Route("")]
        public ActionResult Put([FromBody] ItemVendaDTO entityDTO)
        {
            try
            {
                if (entityDTO == null)
                    return NotFound();

                applicationService.Update(entityDTO);
                return Created("", entityDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Exclui um registro
        /// </summary>
        /// <returns>return status ok</returns>
        [HttpDelete]
        [Route("")]
        public ActionResult Delete([FromBody] ItemVendaDTO entityDTO)
        {
            try
            {
                if (entityDTO == null)
                    return NotFound();

                applicationService.Remove(entityDTO);
                return Created("", entityDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}