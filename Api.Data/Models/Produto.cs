﻿using System;
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
        public string Nome { get; set; }
        public Guid CategoriaId { get; set; }
    }
}
