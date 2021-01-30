using FluentValidation.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Vendas_AspNetCore_DDD.Application.Commands;
using Vendas_AspNetCore_DDD.Application.Notifications;
using Vendas_AspNetCore_DDD.Domain.Core.Interfaces.Repositories;
using Vendas_AspNetCore_DDD.Domain.Entities;

namespace Vendas_AspNetCore_DDD.Application.Handlers
{
    public class AddVendedorCommandHandler : IRequestHandler<AddVendedorCommand, string>
    {
        private readonly IMediator mediator;
        private readonly IRepositoryVendedor repository;

        public AddVendedorCommandHandler(IMediator mediator, IRepositoryVendedor repository)
        {
            this.mediator = mediator;
            this.repository = repository;
        }

        public async Task<string> Handle(AddVendedorCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                return await Task.FromResult(string.Join(";", request.ErrorMessages));
            }

            var vendedor = new Vendedor { Nome = request.Nome, Ativo = request.Ativo };

            try
            {
                await repository.Add(vendedor);

                await mediator.Publish(new VendedorAddNotification
                {
                    Nome = vendedor.Nome,
                    Ativo = vendedor.Ativo
                }, cancellationToken);

                return await Task.FromResult("Vendedor adicionado com sucesso!");
            }
            catch (Exception ex)
            {
                await mediator.Publish(new VendedorAddNotification
                {
                    Id = vendedor.Id,
                    Nome = vendedor.Nome,
                    DataCadastro = vendedor.DataCadastro,
                    Ativo = vendedor.Ativo
                }, cancellationToken);

                await mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace }, cancellationToken);
                return await Task.FromResult("Ocorreu um erro no momento da criação");
            }
        }
    }
}