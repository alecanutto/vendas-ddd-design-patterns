using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vendas_AspNetCore_DDD.Domain.Core.Interfaces.Repositories;
using Vendas_AspNetCore_DDD.Domain.Core.Interfaces.Services;
using Vendas_AspNetCore_DDD.Domain.Entities;

namespace Vendas_AspNetCore_DDD.Domain.Services
{
    public class ServiceProduto : ServiceBase<Produto>, IServiceProduto
    {
        private readonly IRepositoryProduto repository;

        public ServiceProduto(IRepositoryProduto repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<Produto> GetByName(string name)
        {
            IEnumerable<Produto> obj = await Task.Run(() => repository.GetAll());
            return await Task.Run(() => obj.Where(p => p.Nome.StartsWith(name)).First());
        }
    }
}