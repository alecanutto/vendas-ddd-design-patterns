using Microsoft.EntityFrameworkCore;
using System.Linq;
using Vendas_AspNetCore_DDD.Domain.Core.Interfaces.Repositories;
using Vendas_AspNetCore_DDD.Domain.Entities;

namespace Vendas_AspNetCore_DDD.Infra.Data.Repositories
{
    public class RepositoryProduto : RepositoryBase<Produto>, IRepositoryProduto
    {
        private readonly DbContextOptions<SqlContext> contextOptions;
        private readonly SqlContext sqlContext;

        public RepositoryProduto() : base()
        {
            contextOptions = new DbContextOptions<SqlContext>();
            sqlContext = new SqlContext(contextOptions);
        }

        public Produto GetByName(string name)
        {
            return sqlContext.Set<Produto>().ToList().Where(p => p.Nome.StartsWith(name)).First();
        }
    }
}