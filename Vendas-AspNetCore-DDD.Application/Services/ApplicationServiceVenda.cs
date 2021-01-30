using AutoMapper;
using System.Collections.Generic;
using Vendas_AspNetCore_DDD.Application.DTOs;
using Vendas_AspNetCore_DDD.Application.Interfaces;
using Vendas_AspNetCore_DDD.Domain.Core.Interfaces.Services;
using Vendas_AspNetCore_DDD.Domain.Entities;

namespace Vendas_AspNetCore_DDD.Application.Services
{
    public class ApplicationServiceVenda : IApplicationServiceVenda
    {
        private readonly IServiceVenda service;
        private readonly IMapper mapper;

        public ApplicationServiceVenda(IServiceVenda service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public void Add(VendaDTO obj)
        {
            service.Add(mapper.Map<Venda>(obj));
        }

        public IEnumerable<VendaDTO> GetAll()
        {
            return mapper.Map<IEnumerable<VendaDTO>>(service.GetAll());
        }

        public VendaDTO GetById(int id)
        {
            return mapper.Map<VendaDTO>(service.GetById(id));
        }

        public void Remove(VendaDTO obj)
        {
            service.Remove(mapper.Map<Venda>(obj));
        }

        public void RemoveById(int id)
        {
            var obj = service.GetById(id);
            service.Remove(mapper.Map<Venda>(obj));
        }
    }
}