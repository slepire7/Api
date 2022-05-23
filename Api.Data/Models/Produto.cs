using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Models
{
    [Table("Produto")]
    public class Produto : BaseEntity
    {
        [Column("Nome")]
        public string Nome { get; set; }
        [Column("CategoriaId")]
        public Guid CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
