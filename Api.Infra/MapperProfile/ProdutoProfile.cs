using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Infra.MapperProfile
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<Core.DTOs.Produto.AddProduto, Core.Models.Produto>();
            CreateMap<Core.Models.Produto, Core.DTOs.Produto.ReadProduto>();
        }
    }
}
