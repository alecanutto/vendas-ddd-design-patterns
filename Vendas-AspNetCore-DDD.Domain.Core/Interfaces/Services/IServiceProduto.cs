using System.Threading.Tasks;
using Vendas_AspNetCore_DDD.Domain.Entities;

namespace Vendas_AspNetCore_DDD.Domain.Core.Interfaces.Services
{
    public interface IServiceProduto : IServiceBase<Produto>
    {
        Task<Produto> GetByName(string name);
    }
}