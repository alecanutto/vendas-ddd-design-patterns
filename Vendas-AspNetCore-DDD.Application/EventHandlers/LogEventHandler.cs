using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Vendas_AspNetCore_DDD.Application.Notifications;

namespace Vendas_AspNetCore_DDD.Application.EventHandlers
{
    public class LogEventHandler :
                             INotificationHandler<VendedorAddNotification>,
                             INotificationHandler<VendedorUpdateNotification>,
                             INotificationHandler<VendedorRemoveNotification>,
                             INotificationHandler<ErroNotification>
    {
        public Task Handle(VendedorAddNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"CRIACAO: '{notification.Id} - {notification.Nome} - {notification.DataCadastro} - {notification.Ativo}'");
            });
        }

        public Task Handle(VendedorUpdateNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ALTERACAO: '{notification.Id} - {notification.Nome} - {notification.DataCadastro} - {notification.Ativo} - {notification.IsEfetivado}'");
            });
        }

        public Task Handle(VendedorRemoveNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"EXCLUSAO: '{notification.Id} - {notification.IsEfetivado}'");
            });
        }

        public Task Handle(ErroNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ERRO: '{notification.Excecao} \n {notification.PilhaErro}'");
            });
        }
    }
}