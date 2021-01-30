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
    public class RemoveVendedorCommandHandler : IRequestHandler<RemoveVendedorCommand, string>
    {
        private readonly IMediator mediator;
        private readonly IRepositoryBase<Vendedor> repository;

        public RemoveVendedorCommandHandler(IMediator mediator, IRepositoryBase<Vendedor> repository)
        {
            this.mediator = mediator;
            this.repository = repository;
        }

        public async Task<string> Handle(RemoveVendedorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await repository.Remove(request.Id);

                await mediator.Publish(new VendedorRemoveNotification
                {
                    Id = request.Id,
                    IsEfetivado = true
                }, cancellationToken); ;

                return await Task.FromResult("Vendedor excluído com sucesso!");
            }
            catch (Exception ex)
            {
                await mediator.Publish(new VendedorUpdateNotification
                {
                    Id = request.Id,
                    IsEfetivado = false
                }, cancellationToken);

                await mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace }, cancellationToken);
                return await Task.FromResult("Ocorreu um erro no momento da exclusão");
            }
        }
    }
}