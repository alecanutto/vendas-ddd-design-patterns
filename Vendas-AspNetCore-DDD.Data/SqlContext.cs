using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Vendas_AspNetCore_DDD.Domain.Entities;
using Vendas_AspNetCore_DDD.Infra.Data.EntityConfiguration;

namespace Vendas_AspNetCore_DDD.Infra.Data
{
    public class SqlContext : DbContext
    {

        public SqlContext()
        {
        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
            //if (Database.GetPendingMigrations().Count() > 0)
            //{
            //    Database.Migrate();
            //}
        }

        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<ItemVenda> ItensVenda { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Ignore<ValidationResult>();

            foreach (var property in modelBuilder.Model.GetEntityTypes()
              .SelectMany(t => t.GetProperties())
              .Where(p => p.ClrType == typeof(string)))
            {
                property.SetColumnType("varchar");
                property.SetMaxLength(150);
            }

            modelBuilder.ApplyConfiguration(new VendedorConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new VendaConfiguration());
            modelBuilder.ApplyConfiguration(new ItemVendaConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data Source=Ale-Note;Initial Catalog=Vendas;Integrated Security=True");

            base.OnConfiguring(optionsBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Property("DataCadastro").IsModified = false;
                        break;
                }
            }
            return base.SaveChanges();
        }
    }
}