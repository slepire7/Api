using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Interfaces
{
    public interface IProdutoService
    {
        Task<Core.Models.Produto> GetReadProduto(Guid IdProduto);

    }
}
