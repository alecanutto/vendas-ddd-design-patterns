using System;
using System.ComponentModel.DataAnnotations;

namespace Vendas_AspNetCore_DDD.Application.DTOs
{
    public class VendedorDTO
    {
        [Display(Name = "Código")]
        public int Id { get; private set; }

        [Required]
        [MaxLength(60)]
        public string Nome { get; set; }

        [Display(Name = "Data de cadastro")]
        public DateTime DataCadastro { get; private set; }

        [Display(Name = "Ativo?")]
        public bool Ativo { get; set; }
    }
}