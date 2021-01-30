using MediatR;
using Vendas_AspNetCore_DDD.Application.DTOs;
using Vendas_AspNetCore_DDD.Application.Interfaces;
using Vendas_AspNetCore_DDD.Domain.Entities;

namespace Vendas_AspNetCore_DDD.API.Controllers
{
    public class ClienteController : BaseController<Cliente, ClienteDTO>
    {
        public ClienteController(IMediator mediator, IApplicationServiceCliente applicationService) : base(mediator, applicationService)
        {
        }
    }
}