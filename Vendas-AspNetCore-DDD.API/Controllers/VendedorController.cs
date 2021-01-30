using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Vendas_AspNetCore_DDD.Application.Commands;
using Vendas_AspNetCore_DDD.Application.Interfaces;

namespace Vendas_AspNetCore_DDD.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IApplicationServiceVendedor applicationService;

        public VendedorController(IMediator mediator, IApplicationServiceVendedor applicationService)
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
        public async Task<IActionResult> Post(AddVendedorCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// Altera um registro
        /// </summary>
        /// <returns>return status ok</returns>
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Put(UpdateVendedorCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// Exclui um registro
        /// </summary>
        /// <returns>return status ok</returns>
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var obj = new RemoveVendedorCommand { Id = id };
            var result = await mediator.Send(obj);
            return Ok(result);
        }
    }
}