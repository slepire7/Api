using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Models
{
    [Table("produto")]
    public class Produto : BaseEntity
    {
        public string Nome { get; set; }
    }
}
