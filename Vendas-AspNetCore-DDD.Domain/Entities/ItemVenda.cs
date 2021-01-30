using FluentValidation;
using Vendas_AspNetCore_DDD.Domain.Entities.Generics;

namespace Vendas_AspNetCore_DDD.Domain.Entities
{
    public class ItemVenda : Base
    {
        public ItemVenda()
        {
        }

        public ItemVenda(int id, int idVenda, int idProduto, int quantidade, decimal valor, decimal desconto)
        {
            Id = id;
            IdVenda = idVenda;
            IdProduto = idProduto;
            Quantidade = quantidade;
            Valor = valor;
            Desconto = desconto;
        }

        public int IdVenda { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public decimal Desconto { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual Venda Venda { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new ItemValidacao().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class ItemValidacao : AbstractValidator<ItemVenda>
    {
        public ItemValidacao()
        {
            RuleFor(a => a.IdVenda)
            .NotEmpty().WithMessage("O campo IdVenda é obrigatório.");

            RuleFor(a => a.IdProduto)
            .NotEmpty().WithMessage("O campo IdProduto é obrigatório.");

            RuleFor(o => o.Quantidade)
            .NotEmpty().WithMessage("O campo Quantidade deve ser preenchido.")
            .Must(v => v > 0).WithMessage("O campo Quantidade é inválido.");

            RuleFor(o => o.Valor)
            .NotEmpty().WithMessage("O campo Valor deve ser preenchido.")
            .Must(v => v > 0).WithMessage("O campo Valor é inválido.");
        }
    }
}