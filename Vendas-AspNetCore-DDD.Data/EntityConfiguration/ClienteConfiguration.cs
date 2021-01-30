using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vendas_AspNetCore_DDD.Domain.Entities;

namespace Vendas_AspNetCore_DDD.Infra.Data.EntityConfiguration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("TB_CLIENTES");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
            .IsRequired();

            builder.Property(c => c.Telefone)
            .IsRequired()
            .HasMaxLength(14);

            builder.Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(150);

            builder.Property(c => c.Endereco)
            .IsRequired();

            builder.Property(c => c.Numero)
            .IsRequired()
            .HasMaxLength(6);

            builder.Property(c => c.CEP)
            .HasMaxLength(9);

            builder.Property(c => c.Bairro)
            .HasMaxLength(100);

            builder.Property(c => c.Cidade)
            .HasMaxLength(100);

            builder.Property(c => c.Estado)
            .HasColumnName("UF")
            .HasMaxLength(2);
        }
    }
}