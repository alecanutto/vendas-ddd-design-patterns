using System.Collections.Generic;
using Vendas_AspNetCore_DDD.Application.DTOs;

namespace Vendas_AspNetCore_DDD.Application.Interfaces
{
    public interface IApplicationServiceItemVenda
    {
        void Add(ItemVendaDTO itemVendaDTO);

        void Update(ItemVendaDTO itemVendaDTO);

        void Remove(ItemVendaDTO itemVendaDTO);

        IEnumerable<ItemVendaDTO> GetAllByVendaId(int idVenda);
    }
}