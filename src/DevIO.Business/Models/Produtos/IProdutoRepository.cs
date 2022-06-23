using DevIO.Business.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Models.Produtos
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutoPorFornecedor(Guid fornecedorId); //obtem prod por fornecedor
        Task<IEnumerable<Produto>> ObterProdutoFornecedores(); // obtem tudo
        Task<Produto> ObterProdutoFornecedor(Guid id); //obtem produto
    }
}
