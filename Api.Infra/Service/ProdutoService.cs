using Api.Core.DTOs.Produto;
using Api.Core.Interfaces;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace Api.Infra.Service
{
    public class ProdutoService : IProdutoService
    {
        public async Task<ReadProduto> GetReadProduto(Guid IdProduto)
        {
            var _mapper = Config.Inject.Load<IMapper>();

            var repoProduto = Config.Inject.Load<IRepository<Core.Models.Produto>>();
            var repoCategoria = Config.Inject.Load<IRepository<Core.Models.Categoria>>();

            var produto = _mapper.Map<ReadProduto>(await repoProduto.GetAsync(IdProduto));
            var categoria = _mapper.Map<Core.DTOs.Categoria.ReadCategoria>(await repoCategoria.GetAsync(produto.CategoriaId));
            produto.Categoria = categoria;
            return produto;
        }
    }
}

