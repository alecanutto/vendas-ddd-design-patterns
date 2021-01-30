using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Vendas_AspNetCore_DDD.Domain.Core.Interfaces.Repositories;
using Vendas_AspNetCore_DDD.Domain.Entities;

namespace Vendas_AspNetCore_DDD.Infra.Data.Repositories
{
    public class RepositoryVenda : IRepositoryVenda
    {
        private readonly DbContextOptions<SqlContext> contextOptions;
        private readonly SqlContext sqlContext;

        public RepositoryVenda()
        {
            contextOptions = new DbContextOptions<SqlContext>();
            sqlContext = new SqlContext(contextOptions);
        }

        public void Add(Venda venda)
        {
            try
            {
                sqlContext.Add(venda);
                sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(Venda venda)
        {
            try
            {
                sqlContext.Remove(venda);
                sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RemoveById(int id)
        {
            try
            {
                var obj = GetById(id);
                sqlContext.Set<Venda>().Remove(obj);
                sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Venda GetById(int id)
        {
            try
            {
                return sqlContext.Set<Venda>().Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Venda> GetAll()
        {
            try
            {
                return sqlContext.Set<Venda>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}