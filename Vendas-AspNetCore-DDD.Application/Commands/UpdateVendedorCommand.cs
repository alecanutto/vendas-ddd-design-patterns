using MediatR;

namespace Vendas_AspNetCore_DDD.Application.Commands
{
    public class UpdateVendedorCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }
}