using Api.Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> NewProduto([FromBody] Core.DTOs.Categoria.AddCategoria categoria)
        {
            var _mapper = Infra.Config.Inject.Load<IMapper>();
            var repositoryCat = Infra.Config.Inject.Load<IRepository<Core.Models.Categoria>>();
            var _categoria = _mapper.Map<Core.Models.Categoria>(categoria);
            await repositoryCat.InsertAsync(_categoria);
            return Ok(_categoria);
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetProduto([FromQuery] int PageSize, [FromQuery] int PageNumber)
        {
            var repositoryCat = Infra.Config.Inject.Load<IRepository<Core.Models.Categoria>>();
            var _categorias = await repositoryCat.GetAllPaginated(PageSize, PageNumber);
            return Ok(_categorias);
        }
    }
}
