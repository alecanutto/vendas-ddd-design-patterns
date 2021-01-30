using Autofac;
using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Vendas_AspNetCore_DDD.Application.Commands;
using Vendas_AspNetCore_DDD.Application.Handlers;
using Vendas_AspNetCore_DDD.Application.Interfaces;
using Vendas_AspNetCore_DDD.Application.Mappers;
using Vendas_AspNetCore_DDD.Application.Services;
using Vendas_AspNetCore_DDD.Domain.Core.Interfaces.Repositories;
using Vendas_AspNetCore_DDD.Domain.Core.Interfaces.Services;
using Vendas_AspNetCore_DDD.Domain.Services;
using Vendas_AspNetCore_DDD.Infra.Data.Repositories;

namespace Project_Model_DDD.Infra.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC

            builder.RegisterType<ApplicationServiceVendedor>().As<IApplicationServiceVendedor>();
            builder.RegisterType<ApplicationServiceCliente>().As<IApplicationServiceCliente>();
            builder.RegisterType<ApplicationServiceProduto>().As<IApplicationServiceProduto>();
            builder.RegisterType<ApplicationServiceVenda>().As<IApplicationServiceVenda>();
            builder.RegisterType<ApplicationServiceItemVenda>().As<IApplicationServiceItemVenda>();

            builder.RegisterType<ServiceVendedor>().As<IServiceVendedor>();
            builder.RegisterType<ServiceCliente>().As<IServiceCliente>();
            builder.RegisterType<ServiceProduto>().As<IServiceProduto>();
            builder.RegisterType<ServiceVenda>().As<IServiceVenda>();
            builder.RegisterType<ServiceItemVenda>().As<IServiceItemVenda>();

            builder.RegisterType<RepositoryVendedor>().As<IRepositoryVendedor>();
            builder.RegisterType<RepositoryCliente>().As<IRepositoryCliente>();
            builder.RegisterType<RepositoryProduto>().As<IRepositoryProduto>();
            builder.RegisterType<RepositoryCliente>().As<IRepositoryCliente>();
            builder.RegisterType<RepositoryProduto>().As<IRepositoryProduto>();

            //builder.RegisterType<AddVendedorCommandHandler>().As<IRequestHandler<AddVendedorCommand>>();

            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperEntity());
            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();

            builder
                .RegisterAssemblyTypes(typeof(IRequest<>).Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IRequest<>)))
                .AsImplementedInterfaces();

            builder
                .RegisterAssemblyTypes(typeof(IRequestHandler<>).Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IRequestHandler<>)))
                .AsImplementedInterfaces();




        }

        #endregion IOC
    }
}