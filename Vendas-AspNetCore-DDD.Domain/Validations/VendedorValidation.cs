using FluentValidation;
using Vendas_AspNetCore_DDD.Domain.Entities;

namespace Vendas_AspNetCore_DDD.Domain.Validations
{
    public class VendedorValidation : AbstractValidator<Vendedor>
    {
        private const int MAX_LENGTH_NOME = 150;

        public VendedorValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo Nome deve ser preenchido")
                .MaximumLength(MAX_LENGTH_NOME).WithMessage($"O campo Nome deve possuir no máximo {MAX_LENGTH_NOME} caracteres");
        }
    }
}