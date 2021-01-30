using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Vendas_AspNetCore_DDD.Domain.Entities.Generics
{
    public abstract class Base
    {
        public Base()
        {
        }

        public abstract bool IsValid();

        [NotMapped]
        public int Id { get; set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; set; }

        [NotMapped]
        public string[] ErrorMessages => ValidationResult?.Errors?.Select(a => a.ErrorMessage)?.ToArray();
    }
}