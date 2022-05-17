using Api.Core.Interfaces;
using Api.Extension;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> NewProduto([FromBody] Core.DTOs.Produto.AddProduto produto)
        {
            var repositoryProd = Infra.Config.Inject.Load<IRepository<Core.Models.Produto>>();
            var _produto = new Core.Models.Produto()
            {
                Id = Guid.NewGuid(),
                Nome = produto.Nome,
                DataAtualizacao = DateTime.Now.SetKindUtc(),
                DataCadastro = DateTime.Now.SetKindUtc(),
                DataExclusao = null
            };
            await repositoryProd.InsertAsync(_produto);
            return Ok(_produto);
        }
        [HttpGet]
        public async Task<IActionResult> GetProduto([FromQuery] Guid IdProduto)
        {
            var repositoryProd = Infra.Config.Inject.Load<IRepository<Core.Models.Produto>>();
            var _produto = await repositoryProd.GetAsync(IdProduto);
            return Ok(_produto);
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetProduto([FromQuery] int PageSize, [FromQuery] int PageNumber)
        {
            var repositoryProd = Infra.Config.Inject.Load<IRepository<Core.Models.Produto>>();
            var _produtos = await repositoryProd.GetAllPaginated(PageSize, PageNumber);
            return Ok(_produtos);
        }
        [HttpPut]
        public async Task<IActionResult> PutProduto([FromQuery] Guid IdProduto, [FromBody] Core.DTOs.Produto.AddProduto addProduto)
        {
            var repositoryProd = Infra.Config.Inject.Load<IRepository<Core.Models.Produto>>();
            var _produto = await repositoryProd.GetAsync(IdProduto);
            if (_produto is not null)
            {
                _produto.Nome = addProduto.Nome;
                _produto.DataAtualizacao = DateTime.Now.SetKindUtc();
                await repositoryProd.UpdateAsync(_produto);
            }
            return Ok(_produto);
        }

    }
}
