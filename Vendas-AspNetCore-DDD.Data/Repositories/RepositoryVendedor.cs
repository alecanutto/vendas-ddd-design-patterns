using Vendas_AspNetCore_DDD.Domain.Core.Interfaces.Repositories;
using Vendas_AspNetCore_DDD.Domain.Entities;

namespace Vendas_AspNetCore_DDD.Infra.Data.Repositories
{
    public class RepositoryVendedor : RepositoryBase<Vendedor>, IRepositoryVendedor
    {
        public RepositoryVendedor() : base()
        {
        }
    }
}