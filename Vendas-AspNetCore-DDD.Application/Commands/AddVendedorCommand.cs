using MediatR;
using Vendas_AspNetCore_DDD.Domain.Entities;

namespace Vendas_AspNetCore_DDD.Application.Commands
{
    public class AddVendedorCommand : Vendedor, IRequest<string>
    {
        public AddVendedorCommand(string nome, bool ativo)
        {
            Nome = nome;
            Ativo = ativo;
        }

        public override bool IsValid()
        {
            return base.IsValid();
        }

    }
}