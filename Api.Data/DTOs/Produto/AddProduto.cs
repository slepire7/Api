using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.DTOs.Produto
{
    public class AddProduto
    {
        [Required]
        public string Nome { get; set; } = null;
        [Required]
        public Guid CategoriaId { get; set; }
    }
}
