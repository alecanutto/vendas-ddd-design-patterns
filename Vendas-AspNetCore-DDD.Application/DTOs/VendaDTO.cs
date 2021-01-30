using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Vendas_AspNetCore_DDD.Application.DTOs
{
    public class VendaDTO
    {
        [DisplayName("Código")]
        public int Id { get; set; }

        [DisplayName("Vendedor")]
        public int IdVendedor { get; set; }

        [DisplayName("Cliente")]
        public int IdCliente { get; set; }

        [DisplayName("Data de emissão")]
        public DateTime DataEmissao { get; set; }

        [DisplayName("Valor do(s) produto(s)")]
        public decimal ValorProdutos { get; set; }

        [DisplayName("Valot total")]
        public decimal ValorTotal { get; set; }

        [DisplayName("Valor de desconto")]
        public decimal ValorDesconto { get; set; }

        public virtual VendedorDTO Vendedor { get; set; }
        public virtual ClienteDTO Cliente { get; set; }

        [DisplayName("Produtos")]
        public virtual IEnumerable<ItemVendaDTO> Itens { get; set; }
    }
}