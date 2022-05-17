using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Infra.MapperProfile
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<Core.DTOs.Categoria.AddCategoria, Core.Models.Categoria>();
            CreateMap<Core.Models.Categoria, Core.DTOs.Categoria.ReadCategoria>();
        }
    }
}
