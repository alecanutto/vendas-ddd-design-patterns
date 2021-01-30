using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Vendas_AspNetCore_DDD.Domain.Core.Interfaces.Repositories;
using Vendas_AspNetCore_DDD.Domain.Entities;

namespace Vendas_AspNetCore_DDD.Infra.Data.Repositories
{
    public class RepositoryItemVenda : IRepositoryItemVenda
    {
        private readonly DbContextOptions<SqlContext> contextOptions;
        private readonly SqlContext sqlContext;

        public RepositoryItemVenda()
        {
            contextOptions = new DbContextOptions<SqlContext>();
            sqlContext = new SqlContext(contextOptions);
        }

        public void Add(ItemVenda obj)
        {
            try
            {
                sqlContext.Set<ItemVenda>().Add(obj);
                sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(ItemVenda obj)
        {
            try
            {
                sqlContext.Entry(obj).State = EntityState.Modified;
                sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(ItemVenda obj)
        {
            try
            {
                sqlContext.Set<ItemVenda>().Remove(obj);
                sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<ItemVenda> GetAllByVendaId(int idVenda)
        {
            try
            {
                return sqlContext.Set<ItemVenda>().ToList().Where(x => x.IdVenda == idVenda);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}