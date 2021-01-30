using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vendas_AspNetCore_DDD.Domain.Core.Interfaces.Repositories;
using Vendas_AspNetCore_DDD.Domain.Entities.Generics;

namespace Vendas_AspNetCore_DDD.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Base
    {
        private readonly DbContextOptions<SqlContext> contextOptions;
        private readonly SqlContext sqlContext;

        public RepositoryBase()
        {
            contextOptions = new DbContextOptions<SqlContext>();
            sqlContext = new SqlContext(contextOptions);
        }

        async Task IRepositoryBase<TEntity>.Add(TEntity obj)
        {
            await Task.Run(() =>
            {
                sqlContext.Set<TEntity>().Add(obj);
                sqlContext.SaveChanges();
            });
        }

        async Task IRepositoryBase<TEntity>.Update(TEntity obj)
        {
            await Task.Run(() => sqlContext.Entry(obj).State = EntityState.Modified);
        }

        async Task IRepositoryBase<TEntity>.Remove(int id)
        {
            await Task.Run(() => sqlContext.Set<TEntity>().Remove(sqlContext.Set<TEntity>().Find(id)));
        }

        async Task<TEntity> IRepositoryBase<TEntity>.GetById(int id)
        {
            return await Task.Run(() => sqlContext.Set<TEntity>().Find(id));
        }

        async Task<IEnumerable<TEntity>> IRepositoryBase<TEntity>.GetAll()
        {
            return await Task.Run(() => sqlContext.Set<TEntity>().ToList());
        }
    }
}