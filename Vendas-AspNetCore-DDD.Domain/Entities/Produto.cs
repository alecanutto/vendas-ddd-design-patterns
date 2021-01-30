using FluentValidation;
using System;
using Vendas_AspNetCore_DDD.Domain.Entities.Generics;

namespace Vendas_AspNetCore_DDD.Domain.Entities
{
    public class Produto : Base
    {
        public Produto()
        {
        }

        public Produto(int id, string nome, decimal valor, string unidade, int estoque, bool ativo)
        {
            Id = id;
            Nome = nome;
            Valor = valor;
            Unidade = unidade;
            Estoque = estoque;
            Ativo = ativo;
        }

        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Unidade { get; set; }
        public int Estoque { get; set; }
        public DateTime DataCadastro { get; internal set; }
        public bool Ativo { get; set; }

        public void AtualizarDataCadastro()
        {
            DataCadastro = DateTime.Now;
        }

        public bool Disponivel()
        {
            return Valor > 0 && Estoque > 0;
        }

        public override bool IsValid()
        {
            ValidationResult = new ProdutoValidacao().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class ProdutoValidacao : AbstractValidator<Produto>
    {
        private const int MAX_LENGTH_NOME = 150;

        public ProdutoValidacao()
        {
            RuleFor(o => o.Nome)
                .NotEmpty().WithMessage("O campo Nome deve ser preenchido")
                .MaximumLength(MAX_LENGTH_NOME).WithMessage($"O campo Nome deve possuir no máximo {MAX_LENGTH_NOME} caracteres");

            RuleFor(a => a.Unidade)
                .NotEmpty().WithMessage("O campo Unidade é obrigatório.")
                .MaximumLength(2).WithMessage("O campo Unidade deve possuir no máximo 2 caracteres.");

            RuleFor(o => o.Valor)
               .NotEmpty().WithMessage("O campo Valor deve ser preenchido.")
               .Must(v => v > 0).WithMessage("O campo Valor é inválido.");
        }
    }
}