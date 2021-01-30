using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vendas_AspNetCore_DDD.Domain.Entities;

namespace Vendas_AspNetCore_DDD.Infra.Data.EntityConfiguration
{
    public class ItemVendaConfiguration : IEntityTypeConfiguration<ItemVenda>
    {
        public void Configure(EntityTypeBuilder<ItemVenda> builder)
        {
            builder.ToTable("TB_ITENS_VENDA");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Valor).HasPrecision(10, 2);

            builder.Property(c => c.Desconto).HasPrecision(10, 2);

            builder.HasOne(c => c.Produto).WithOne().HasForeignKey<ItemVenda>(c => c.IdProduto).OnDelete(DeleteBehavior.NoAction);
        }
    }
}