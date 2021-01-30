using Vendas_AspNetCore_DDD.Domain.Core.Interfaces.Repositories;
using Vendas_AspNetCore_DDD.Domain.Core.Interfaces.Services;
using Vendas_AspNetCore_DDD.Domain.Entities;

namespace Vendas_AspNetCore_DDD.Domain.Services
{
    public class ServiceVendedor : ServiceBase<Vendedor>, IServiceVendedor
    {
        public ServiceVendedor(IRepositoryVendedor repository) : base(repository)
        {
        }
    }
}