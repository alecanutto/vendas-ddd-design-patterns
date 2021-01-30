using FluentValidation;
using System;
using System.Text.RegularExpressions;
using Vendas_AspNetCore_DDD.Domain.Entities.Generics;

namespace Vendas_AspNetCore_DDD.Domain.Entities
{
    public class Cliente : Base
    {
        public Cliente()
        {
        }

        public Cliente(int id, string nome, string cpf, string telefone, string email,
            string cep, string endereco, string numero, string bairro, string cidade, string estado, bool ativo)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            Telefone = telefone;
            Email = email;
            CEP = cep;
            Endereco = endereco;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Ativo = ativo;
        }

        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public DateTime DataCadastro { get; internal set; }
        public bool Ativo { get; set; }

        public void AtualizarDataCadastro()
        {
            DataCadastro = DateTime.Now;
        }

        public int DescontoVenda()
        {
            if (Ativo && (DateTime.Now.Subtract(DataCadastro).TotalDays / 365) >= 3)
            {
                return 3;
            }
            return 0;
        }
        public override bool IsValid()
        {
            ValidationResult = new ClienteValidacao().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class ClienteValidacao : AbstractValidator<Cliente>
    {
        private const int MAX_LENGTH_NOME = 150;
        private const int MAX_LENGTH_EMAIL = 150;
        private const int MAX_LENGTH_ENDERECO = 150;
        private const int MAX_LENGTH_NUMERO = 6;
        private const int MAX_LENGTH_BAIRRO = 100;
        private const int MAX_LENGTH_CIDADE = 100;

        public ClienteValidacao()
        {
            RuleFor(o => o.Nome)
               .NotEmpty().WithMessage("O campo Nome deve ser preenchido")
               .MaximumLength(MAX_LENGTH_NOME).WithMessage($"O campo Nome deve possuir no máximo {MAX_LENGTH_NOME} caracteres");

            RuleFor(a => a.Email)
                .NotEmpty().WithMessage("O campo Email é obrigatório.")
                .MaximumLength(MAX_LENGTH_EMAIL).WithMessage($"O campo Email deve possuir no máximo {MAX_LENGTH_EMAIL} caracteres.");

            RuleFor(a => a.Email).EmailAddress()
                .When(a => !string.IsNullOrEmpty(a.Email))
                .When(a => a?.Email?.Length <= MAX_LENGTH_EMAIL)
                .WithMessage("O campo Email é inválido.");

            RuleFor(o => o.Telefone)
               .NotEmpty().WithMessage("O campo Telefone deve ser preenchido.")
               .Must(ValidarTelefone).WithMessage("O campo Telefone é inválido.");

            RuleFor(o => o.CEP)
               .NotEmpty().WithMessage("O campo CEP deve ser preenchido.")
               .Must(ValidarCep).WithMessage("O campo CEP é inválido.");

            RuleFor(o => o.Endereco)
                .NotEmpty().WithMessage("O campo Endereço deve ser preenchido.")
                .MaximumLength(MAX_LENGTH_ENDERECO).WithMessage($"O campo Endereço deve possuir no máximo {MAX_LENGTH_ENDERECO} caracteres.");

            RuleFor(o => o.Numero)
                .NotEmpty().WithMessage("O campo Número deve ser preenchido.")
                .MaximumLength(MAX_LENGTH_NUMERO).WithMessage($"O campo Número deve possuir no máximo {MAX_LENGTH_NUMERO} caracteres.");

            RuleFor(o => o.Bairro)
               .MaximumLength(MAX_LENGTH_BAIRRO).WithMessage($"O campo Complemento deve possuir no máximo {MAX_LENGTH_BAIRRO} caracteres.");

            RuleFor(o => o.Cidade)
                .NotEmpty().WithMessage("O campo Cidade deve ser preenchido.")
                .MaximumLength(MAX_LENGTH_CIDADE).WithMessage($"O campo Cidade deve possuir no máximo {MAX_LENGTH_CIDADE} caracteres.");

            RuleFor(o => o.Estado)
                .Length(2).WithMessage("O campo Estado é inválido.");
        }

        private bool ValidarTelefone(string telefone)
        {
            if (string.IsNullOrEmpty(telefone)) return true;
            var rx = new Regex(@"^([0-9]{2})[0-9]{4,5}-[0-9]{4}$");
            return rx.Match(telefone).Success;
        }

        private bool ValidarCep(string cep)
        {
            if (string.IsNullOrEmpty(cep)) return true;
            var rx = new Regex(@"^[0-9]{5}-[0-9]{3}$");
            return rx.Match(cep).Success;
        }
    }
}