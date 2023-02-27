using Worflow.Dados.Interfaces;
using Worflow.Models;
namespace Worflow.Repository
{
    public interface IEnderecoRepository : IQuery<Endereco>, ICommand<Endereco>, IQueryPesquisa<Endereco>
    {
    }
}
