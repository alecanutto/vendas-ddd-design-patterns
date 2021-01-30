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
    public class UpdateVendedorCommandHandler : IRequestHandler<UpdateVendedorCommand, string>
    {
        private readonly IMediator mediator;
        private readonly IRepositoryBase<Vendedor> repository;

        public UpdateVendedorCommandHandler(IMediator mediator, IRepositoryBase<Vendedor> repository)
        {
            this.mediator = mediator;
            this.repository = repository;
        }

        public async Task<string> Handle(UpdateVendedorCommand request, CancellationToken cancellationToken)
        {
            var vendedor = new Vendedor { Id = request.Id, Nome = request.Nome, Ativo = request.Ativo };

            try
            {
                await repository.Update(vendedor);

                await mediator.Publish(new VendedorUpdateNotification
                {
                    Id = vendedor.Id,
                    Nome = vendedor.Nome,
                    Ativo = vendedor.Ativo,
                    IsEfetivado = true
                }, cancellationToken); ;

                return await Task.FromResult("Vendedor alterado com sucesso!");
            }
            catch (Exception ex)
            {
                await mediator.Publish(new VendedorUpdateNotification
                {
                    Id = vendedor.Id,
                    Nome = vendedor.Nome,
                    DataCadastro = vendedor.DataCadastro,
                    Ativo = vendedor.Ativo,
                    IsEfetivado = false
                }, cancellationToken);

                await mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace }, cancellationToken);
                return await Task.FromResult("Ocorreu um erro no momento da alteração");
            }
        }
    }
}