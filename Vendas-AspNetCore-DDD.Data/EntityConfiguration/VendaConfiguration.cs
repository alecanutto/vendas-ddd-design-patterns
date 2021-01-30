using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vendas_AspNetCore_DDD.Domain.Entities;

namespace Vendas_AspNetCore_DDD.Infra.Data.EntityConfiguration
{
    public class VendaConfiguration : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.ToTable("TB_VENDAS");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.DataEmissao).HasColumnName("DataCadastro");

            builder.Property(c => c.ValorDesconto).HasPrecision(10, 2);

            builder.Property(c => c.ValorProdutos).HasPrecision(10, 2);

            builder.Property(c => c.ValorTotal).HasPrecision(10, 2);

            builder.HasMany(c => c.Itens).WithOne(c => c.Venda).HasForeignKey(c => c.IdVenda).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Cliente).WithOne().HasForeignKey<Venda>(c => c.IdCliente).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Vendedor).WithOne().HasForeignKey<Venda>(c => c.IdVendedor).OnDelete(DeleteBehavior.NoAction);
        }
    }
}