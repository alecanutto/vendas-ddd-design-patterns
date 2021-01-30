using AutoMapper;
using Vendas_AspNetCore_DDD.Application.DTOs;
using Vendas_AspNetCore_DDD.Application.Interfaces;
using Vendas_AspNetCore_DDD.Domain.Core.Interfaces.Services;
using Vendas_AspNetCore_DDD.Domain.Entities;

namespace Vendas_AspNetCore_DDD.Application.Services
{
    public class ApplicationServiceCliente : ApplicationServiceBase<Cliente, ClienteDTO>, IApplicationServiceCliente
    {
        public ApplicationServiceCliente(IServiceCliente serviceCliente, IMapper mapper)
            : base(serviceCliente, mapper)
        {
        }
    }
}