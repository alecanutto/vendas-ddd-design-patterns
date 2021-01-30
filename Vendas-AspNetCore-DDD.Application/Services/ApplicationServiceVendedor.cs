using AutoMapper;
using Vendas_AspNetCore_DDD.Application.DTOs;
using Vendas_AspNetCore_DDD.Application.Interfaces;
using Vendas_AspNetCore_DDD.Domain.Core.Interfaces.Services;
using Vendas_AspNetCore_DDD.Domain.Entities;

namespace Vendas_AspNetCore_DDD.Application.Services
{
    public class ApplicationServiceVendedor : ApplicationServiceBase<Vendedor, VendedorDTO>, IApplicationServiceVendedor
    {
        public ApplicationServiceVendedor(IServiceVendedor service, IMapper mapper)
            : base(service, mapper)
        {
        }
    }
}
