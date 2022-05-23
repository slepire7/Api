using Api.Core.DTOs.Produto;
using Api.Core.Interfaces;
using AutoMapper;
using System;
using Dapper;
using Dommel;
using System.Threading.Tasks;

namespace Api.Infra.Service
{
    public class ProdutoService : IProdutoService
    {
        public Task<Core.Models.Produto> GetReadProduto(Guid IdProduto)
        {
            var _mapper = Config.Inject.Load<IMapper>();

            var repoProduto = Config.Inject.Load<IRepository<Core.Models.Produto>>();

            return repoProduto.DbAction(async (ctx) =>
            {
                return await ctx.GetAsync<Core.Models.Produto, Core.Models.Categoria, Core.Models.Produto>(IdProduto);
            });
        }
    }
}

