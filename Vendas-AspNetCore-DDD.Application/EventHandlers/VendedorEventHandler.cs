using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Vendas_AspNetCore_DDD.Application.Notifications;

namespace Vendas_AspNetCore_DDD.Application.EventHandlers
{
    public class VendedorEventHandler :
                             INotificationHandler<VendedorAddNotification>,
                             INotificationHandler<VendedorUpdateNotification>,
                             INotificationHandler<VendedorRemoveNotification>,
                             INotificationHandler<ErroNotification>
    {
        public Task Handle(VendedorRemoveNotification notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(VendedorUpdateNotification notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(ErroNotification notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(VendedorAddNotification notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}