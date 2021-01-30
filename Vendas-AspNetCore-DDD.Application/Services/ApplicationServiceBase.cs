using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vendas_AspNetCore_DDD.Application.Interfaces;
using Vendas_AspNetCore_DDD.Domain.Core.Interfaces.Services;
using Vendas_AspNetCore_DDD.Domain.Entities.Generics;

namespace Vendas_AspNetCore_DDD.Application.Services
{
    public class ApplicationServiceBase<TEntity, TEntityDTO> : IApplicationServiceBase<TEntity, TEntityDTO>
        where TEntity : Base where TEntityDTO : class
    {
        private readonly IServiceBase<TEntity> service;
        private readonly IMapper mapper;

        public ApplicationServiceBase(IServiceBase<TEntity> service, IMapper mapper) : base()
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task Add(TEntityDTO obj)
        {
            await Task.Run(() => service.Add(mapper.Map<TEntity>(obj)));
        }

        public async Task<IEnumerable<TEntityDTO>> GetAll()
        {
            return await Task.Run(() => mapper.Map<IEnumerable<TEntityDTO>>(service.GetAll()));
        }

        public async Task<TEntityDTO> GetById(int id)
        {
            return await Task.Run(() => mapper.Map<TEntityDTO>(service.GetById(id)));
        }

        public async Task Remove(int id)
        {
            await Task.Run(() => service.Remove(id));
        }

        public async Task Update(TEntityDTO obj)
        {
            await Task.Run(() => service.Update(mapper.Map<TEntity>(obj)));
        }
    }
}