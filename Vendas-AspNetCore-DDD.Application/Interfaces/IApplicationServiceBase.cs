using System.Collections.Generic;
using System.Threading.Tasks;
using Vendas_AspNetCore_DDD.Domain.Entities.Generics;

namespace Vendas_AspNetCore_DDD.Application.Interfaces
{
    public interface IApplicationServiceBase<TEntity, TEntityDTO> where TEntity : Base where TEntityDTO : class
    {
        Task Add(TEntityDTO obj);

        Task Update(TEntityDTO obj);

        Task Remove(int id);

        Task<TEntityDTO> GetById(int id);

        Task<IEnumerable<TEntityDTO>> GetAll();
    }
}