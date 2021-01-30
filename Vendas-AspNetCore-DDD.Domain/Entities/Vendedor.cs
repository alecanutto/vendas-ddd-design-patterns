using System;
using Vendas_AspNetCore_DDD.Domain.Entities.Generics;
using Vendas_AspNetCore_DDD.Domain.Validations;

namespace Vendas_AspNetCore_DDD.Domain.Entities
{
    public class Vendedor : Base
    {
        public Vendedor()
        {
        }

        public Vendedor(int id, string nome, DateTime dataCadastro, bool ativo)
        {
            Id = id;
            Nome = nome;
            DataCadastro = dataCadastro;
            Ativo = ativo;
        }

        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        public void AtualizarDataCadastro()
        {
            DataCadastro = DateTime.Now;
        }

        public override bool IsValid()
        {
            ValidationResult = new VendedorValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}