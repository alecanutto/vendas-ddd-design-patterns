using AutoMapper;
using System.Collections.Generic;
using Vendas_AspNetCore_DDD.Application.DTOs;
using Vendas_AspNetCore_DDD.Application.Interfaces;
using Vendas_AspNetCore_DDD.Domain.Core.Interfaces.Services;
using Vendas_AspNetCore_DDD.Domain.Entities;

namespace Vendas_AspNetCore_DDD.Application.Services
{
    public class ApplicationServiceItemVenda : IApplicationServiceItemVenda
    {
        private readonly IServiceItemVenda service;
        private readonly IMapper mapper;

        public ApplicationServiceItemVenda(IServiceItemVenda service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public void Add(ItemVendaDTO obj)
        {
            service.Add(mapper.Map<ItemVenda>(obj));
        }

        public IEnumerable<ItemVendaDTO> GetAllByVendaId(int idVenda)
        {
            return mapper.Map<IEnumerable<ItemVendaDTO>>(service.GetAllByVendaId(idVenda));
        }

        public void Remove(ItemVendaDTO obj)
        {
            service.Remove(mapper.Map<ItemVenda>(obj));
        }

        public void Update(ItemVendaDTO obj)
        {
            service.Update(mapper.Map<ItemVenda>(obj));
        }
    }
}