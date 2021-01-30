using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vendas_AspNetCore_DDD.Domain.Core.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        Task Add(TEntity obj);

        Task Update(TEntity obj);

        Task Remove(int id);

        Task<TEntity> GetById(int id);

        Task<IEnumerable<TEntity>> GetAll();
    }
}