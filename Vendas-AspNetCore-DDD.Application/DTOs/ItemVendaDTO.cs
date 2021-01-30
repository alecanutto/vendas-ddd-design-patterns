using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Vendas_AspNetCore_DDD.Application.DTOs
{
    public class ItemVendaDTO
    {
        [DisplayName("Código")]
        public int Id { get; set; }

        [Display(Name = "Código da venda")]
        public int IdVenda { get; set; }

        [DisplayName("Código do produto")]
        public int IdProduto { get; set; }

        [Range(1, 99999999)]
        public int Quantidade { get; set; }

        [Range(0.1, 99999999)]
        public decimal Valor { get; set; }

        [DisplayName("Valor de desconto")]
        public decimal Desconto { get; set; }

        public ProdutoDTO Produto { get; set; }

        public VendaDTO Venda { get; set; }
    }
}