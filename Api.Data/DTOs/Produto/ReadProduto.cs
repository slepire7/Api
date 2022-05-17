using Api.Core.DTOs.Categoria;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.DTOs.Produto
{
    public class ReadProduto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid CategoriaId { get; set; }
        public ReadCategoria Categoria { get; set; }
    }
}
