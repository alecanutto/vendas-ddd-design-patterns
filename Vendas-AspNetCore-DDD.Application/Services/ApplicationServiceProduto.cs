using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using Vendas_AspNetCore_DDD.Application.DTOs;
using Vendas_AspNetCore_DDD.Application.Interfaces;
using Vendas_AspNetCore_DDD.Domain.Core.Interfaces.Services;
using Vendas_AspNetCore_DDD.Domain.Entities;

namespace Vendas_AspNetCore_DDD.Application.Services
{
    public class ApplicationServiceProduto : ApplicationServiceBase<Produto, ProdutoDTO>, IApplicationServiceProduto
    {
        private readonly IServiceBase<Produto> service;
        private readonly IMapper mapper;

        public ApplicationServiceProduto(IServiceProduto service, IMapper mapper)
            : base(service, mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public ProdutoDTO GetByName(string name)
        {
            throw new System.NotImplementedException();
        }

        // async Task<ProdutoDTO> IApplicationServiceProduto.GetByName(string name)
        //{
        //    IOrderedEnumerable<ProdutoDTO> obj = await Task.Run(() => mapper.Map<ProdutoDTO>(service.GetAll()));
        //    return await obj.Where(p => p.Nome.StartsWith(name)).First());
        //}
    }
}