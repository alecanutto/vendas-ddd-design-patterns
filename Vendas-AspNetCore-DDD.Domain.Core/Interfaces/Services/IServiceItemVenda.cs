using System.Collections.Generic;
using Vendas_AspNetCore_DDD.Domain.Entities;

namespace Vendas_AspNetCore_DDD.Domain.Core.Interfaces.Services
{
    public interface IServiceItemVenda
    {
        void Add(ItemVenda obj);

        void Update(ItemVenda obj);

        void Remove(ItemVenda obj);

        IEnumerable<ItemVenda> GetAllByVendaId(int idVenda);
    }
}