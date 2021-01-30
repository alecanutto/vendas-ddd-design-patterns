using System;
using System.ComponentModel.DataAnnotations;

namespace Vendas_AspNetCore_DDD.Application.DTOs
{
    public class ProdutoDTO
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Nome { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Preço")]
        public decimal Valor { get; set; }

        [MaxLength(2)]
        public string Unidade { get; set; }

        [Range(1, 999999999)]
        public int Estoque { get; set; }

        [Display(Name = "Data de cadastro")]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "Ativo?")]
        public bool Ativo { get; set; }
    }
}