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
    public class VendaController : Controller
    {
        readonly private IApplicationServiceVenda applicationService;

        public VendaController(IApplicationServiceVenda applicationService)
        {
            this.applicationService = applicationService;
        }

        /// <summary>
        /// Retorna todos os registros
        /// </summary>
        /// <returns>return status ok</returns>
        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            try
            {
                return new OkObjectResult(applicationService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retorna registro por Id
        /// </summary>
        /// <returns>Returns status ok</returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return new OkObjectResult(applicationService.GetById(id));
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
        public IActionResult Post([FromBody] VendaDTO venda)
        {
            try
            {
                if (venda == null)
                    return NotFound();

                applicationService.Add(venda);
                return Created("", venda);
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
        public ActionResult Delete([FromBody] VendaDTO entityDTO)
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

        /// <summary>
        /// Exclui um registro
        /// </summary>
        /// <returns>return status ok</returns>
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteById([FromBody] int id)
        {
            try
            {
                var obj = applicationService.GetById(id);
                if (obj == null)
                    return NotFound();

                applicationService.RemoveById(id);
                return Created("", obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}