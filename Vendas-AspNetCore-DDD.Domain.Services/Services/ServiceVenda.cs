using System.Collections.Generic;
using Vendas_AspNetCore_DDD.Domain.Core.Interfaces.Repositories;
using Vendas_AspNetCore_DDD.Domain.Core.Interfaces.Services;
using Vendas_AspNetCore_DDD.Domain.Entities;

namespace Vendas_AspNetCore_DDD.Domain.Services
{
    public class ServiceVenda : IServiceVenda
    {
        private readonly IRepositoryVenda repository;

        public ServiceVenda(IRepositoryVenda repository)
        {
            this.repository = repository;
        }

        public void Add(Venda obj)
        {
            repository.Add(obj);
        }

        public IEnumerable<Venda> GetAll()
        {
            return repository.GetAll();
        }

        public Venda GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Remove(Venda obj)
        {
            repository.Remove(obj);
        }

        public void RemoveById(int id)
        {
            repository.RemoveById(id);
        }
    }
}