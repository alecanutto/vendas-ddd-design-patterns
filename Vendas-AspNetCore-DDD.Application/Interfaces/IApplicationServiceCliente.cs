using Vendas_AspNetCore_DDD.Application.DTOs;
using Vendas_AspNetCore_DDD.Domain.Entities;

namespace Vendas_AspNetCore_DDD.Application.Interfaces
{
    public interface IApplicationServiceCliente : IApplicationServiceBase<Cliente, ClienteDTO>
    {
    }
}