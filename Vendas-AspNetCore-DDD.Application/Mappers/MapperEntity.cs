using AutoMapper;
using Vendas_AspNetCore_DDD.Application.Commands;
using Vendas_AspNetCore_DDD.Application.DTOs;
using Vendas_AspNetCore_DDD.Domain.Entities;

namespace Vendas_AspNetCore_DDD.Application.Mappers
{
    public class MapperEntity : Profile
    {
        public MapperEntity()
        {
            CreateMap<Vendedor, VendedorDTO>();

            CreateMap<Vendedor, AddVendedorCommand>().ReverseMap();

            CreateMap<Cliente, ClienteDTO>();
            CreateMap<Produto, ProdutoDTO>();
            CreateMap<Venda, VendaDTO>();
            CreateMap<ItemVenda, ItemVendaDTO>();

            CreateMap<VendedorDTO, Vendedor>();
            CreateMap<ClienteDTO, Cliente>();
            CreateMap<ProdutoDTO, Produto>();
            CreateMap<VendaDTO, Venda>();
            CreateMap<ItemVendaDTO, ItemVenda>();


        }
    }
}