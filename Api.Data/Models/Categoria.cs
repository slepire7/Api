using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Models
{
    [Table("Categoria")]
    public class Categoria : BaseEntity
    {
        [Column("Nome")]
        public string Nome { get; set; }
        [Column("Descricao")]
        public string Descricao { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}
