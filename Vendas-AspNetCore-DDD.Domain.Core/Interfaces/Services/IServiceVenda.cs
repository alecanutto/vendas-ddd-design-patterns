using System.Collections.Generic;
using Vendas_AspNetCore_DDD.Domain.Entities;

namespace Vendas_AspNetCore_DDD.Domain.Core.Interfaces.Services
{
    public interface IServiceVenda
    {
        void Add(Venda venda);

        void Remove(Venda venda);

        void RemoveById(int id);

        Venda GetById(int id);

        IEnumerable<Venda> GetAll();
    }
}