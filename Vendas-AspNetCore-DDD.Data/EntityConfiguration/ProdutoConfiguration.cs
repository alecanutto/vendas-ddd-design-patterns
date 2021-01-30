using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vendas_AspNetCore_DDD.Domain.Entities;

namespace Vendas_AspNetCore_DDD.Infra.Data.EntityConfiguration
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("TB_PRODUTOS");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
            .IsRequired()
            .HasMaxLength(80);

            builder.Property(p => p.Unidade)
            .IsRequired()
            .HasMaxLength(2);

            builder.Property(p => p.Valor)
            .IsRequired()
            .HasPrecision(10, 2);

            builder.Property(p => p.Estoque)
            .IsRequired();
        }
    }
}