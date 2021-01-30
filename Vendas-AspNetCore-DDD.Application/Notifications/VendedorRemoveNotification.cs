using MediatR;

namespace Vendas_AspNetCore_DDD.Application.Notifications
{
    public class VendedorRemoveNotification : INotification
    {
        public int Id { get; set; }
        public bool IsEfetivado { get; set; }
    }
}