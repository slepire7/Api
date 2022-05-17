using Api.Core.Interfaces;
using Api.Extension;
using AutoMapper;
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
            var _mapper = Infra.Config.Inject.Load<IMapper>();
            var repositoryProd = Infra.Config.Inject.Load<IRepository<Core.Models.Produto>>();
            var _produto = _mapper.Map<Core.Models.Produto>(produto);
            await repositoryProd.InsertAsync(_produto);
            return Ok(_produto);
        }
        [HttpGet]
        public async Task<IActionResult> GetProduto([FromQuery] Guid IdProduto)
        {
            var produtoService = Infra.Config.Inject.Load<IProdutoService>();
            var _produto = await produtoService.GetReadProduto(IdProduto);
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
                await repositoryProd.UpdateAsync(_produto);
                return Ok(_produto);
            }
            return NotFound();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduto([FromQuery] Guid IdProduto)
        {
            var repositoryProd = Infra.Config.Inject.Load<IRepository<Core.Models.Produto>>();
            var _produto = await repositoryProd.GetAsync(IdProduto);
            if (_produto is not null)
            {
                await repositoryProd.DeleteRowAsync(_produto.Id);
                return Ok();
            }
            return NotFound();
        }

    }
}
