using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Models
{
    public class BaseEntity
    {
        [Column("Id")]
        public Guid Id { get; set; }
        [Column("DataCadastro")]
        public DateTime DataCadastro { get; set; }
        [Column("DataAtualizacao")]
        public DateTime DataAtualizacao { get; set; }
        [Column("DataExclusao")]
        public DateTime? DataExclusao { get; set; }
    }
}
