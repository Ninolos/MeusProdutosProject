using DevIO.Business.Core.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Business.Models.Fornecedores
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);
    }
}
