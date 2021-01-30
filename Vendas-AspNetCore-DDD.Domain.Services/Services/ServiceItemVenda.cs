using System.Collections.Generic;
using Vendas_AspNetCore_DDD.Domain.Core.Interfaces.Repositories;
using Vendas_AspNetCore_DDD.Domain.Core.Interfaces.Services;
using Vendas_AspNetCore_DDD.Domain.Entities;

namespace Vendas_AspNetCore_DDD.Domain.Services
{
    public class ServiceItemVenda : IServiceItemVenda
    {
        private readonly IRepositoryItemVenda repository;

        public ServiceItemVenda(IRepositoryItemVenda repositoryItem)
        {
            repository = repositoryItem;
        }

        public void Add(ItemVenda obj)
        {
            repository.Add(obj);
        }

        public IEnumerable<ItemVenda> GetAllByVendaId(int id)
        {
            return repository.GetAllByVendaId(id);
        }

        public void Remove(ItemVenda obj)
        {
            repository.Remove(obj);
        }

        public void Update(ItemVenda obj)
        {
            repository.Update(obj);
        }
    }
}