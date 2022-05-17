using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Utils
{
    public class PaginationResult<T>
    {
        public int TotalCount { get; set; }
        public ICollection<T> Data { get; set; }
    }
}
