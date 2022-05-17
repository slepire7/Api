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
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
