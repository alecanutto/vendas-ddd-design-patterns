using System.Collections.Generic;
using System.Threading.Tasks;
using Vendas_AspNetCore_DDD.Domain.Core.Interfaces.Repositories;
using Vendas_AspNetCore_DDD.Domain.Core.Interfaces.Services;
using Vendas_AspNetCore_DDD.Domain.Entities.Generics;

namespace Vendas_AspNetCore_DDD.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : Base
    {
        private readonly IRepositoryBase<TEntity> repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            this.repository = repository;
        }

        async Task IServiceBase<TEntity>.Add(TEntity obj)
        {
            await Task.Run(() => repository.Add(obj));
        }

        async Task<IEnumerable<TEntity>> IServiceBase<TEntity>.GetAll()
        {
            return await Task.Run(() => repository.GetAll());
        }

        async Task<TEntity> IServiceBase<TEntity>.GetById(int id)
        {
            return await Task.Run(() => repository.GetById(id));
        }

        async Task IServiceBase<TEntity>.Remove(int id)
        {
            await Task.Run(() => repository.Remove(id));
        }

        async Task IServiceBase<TEntity>.Update(TEntity obj)
        {
            await Task.Run(() => repository.Update(obj));
        }
    }
}