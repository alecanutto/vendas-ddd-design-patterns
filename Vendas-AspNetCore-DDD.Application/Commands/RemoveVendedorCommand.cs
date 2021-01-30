using MediatR;

namespace Vendas_AspNetCore_DDD.Application.Commands
{
    public class RemoveVendedorCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}