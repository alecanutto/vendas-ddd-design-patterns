using MediatR;
using System;

namespace Vendas_AspNetCore_DDD.Application.Notifications
{
    public class VendedorUpdateNotification : INotification
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public bool IsEfetivado { get; set; }
    }
}