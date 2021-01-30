using FluentValidation;
using System;
using System.Collections.Generic;
using Vendas_AspNetCore_DDD.Domain.Entities.Generics;

namespace Vendas_AspNetCore_DDD.Domain.Entities
{
    public class Venda : Base
    {
        public Venda()
        {
        }

        public Venda(int id, int idVendedor, int idCliente, ICollection<ItemVenda> itens,
            decimal valorProdutos, decimal valorDesconto, decimal valorTotal)
        {
            Id = id;
            IdVendedor = idVendedor;
            IdCliente = idCliente;
            Itens = itens;
            ValorProdutos = valorProdutos;
            ValorDesconto = valorDesconto;
            ValorTotal = valorTotal;
        }

        public int IdVendedor { get; set; }
        public int IdCliente { get; set; }
        public decimal ValorProdutos { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorDesconto { get; set; }
        public DateTime DataEmissao { get; internal set; }
        public virtual ICollection<ItemVenda> Itens { get; set; }
        public virtual Vendedor Vendedor { get; set; }
        public virtual Cliente Cliente { get; set; }

        public void AtualizarDataEmissao()
        {
            DataEmissao = DateTime.Now;
        }

        public override bool IsValid()
        {
            ValidationResult = new VendaValidacao().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class VendaValidacao : AbstractValidator<Venda>
    {
        public VendaValidacao()
        {
            RuleFor(a => a.IdVendedor)
            .NotEmpty().WithMessage("O campo IdVendedor é obrigatório.");

            RuleFor(a => a.IdCliente)
            .NotEmpty().WithMessage("O campo IdCliente é obrigatório.");

            RuleFor(o => o.ValorProdutos)
            .NotEmpty().WithMessage("O campo valor dos produtos deve ser preenchido.")
            .Must(v => v > 0).WithMessage("O campo valor produtos é inválido.");

            RuleFor(o => o.Itens)
            .Must(i => i.Count > 0).WithMessage("A venda deve ter no minímo 1 item.");
        }
    }
}