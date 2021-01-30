using System.Collections.Generic;
using Vendas_AspNetCore_DDD.Application.DTOs;

namespace Vendas_AspNetCore_DDD.Application.Interfaces
{
    public interface IApplicationServiceVenda
    {
        void Add(VendaDTO vendaDTO);

        void Remove(VendaDTO vendaDTO);

        void RemoveById(int id);

        VendaDTO GetById(int id);

        IEnumerable<VendaDTO> GetAll();
    }
}