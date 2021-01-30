using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Vendas_AspNetCore_DDD.Application.DTOs
{
    public class ClienteDTO
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public string CEP { get; set; }

        [Display(Name = "Endereço")]
        [Required]
        public string TextoEndereco { get; set; }

        [Display(Name = "Número")]
        public string Numero { get; set; }

        public string Bairro { get; set; }
        public string Cidade { get; set; }

        [Display(Name = "UF")]
        public string Estado { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Display(Name = "E-mail")]
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Data de cadastro")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "Ativo?")]
        public bool Ativo { get; set; }
    }
}