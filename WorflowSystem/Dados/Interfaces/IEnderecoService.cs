using System.Net.Sockets;
using WFAPI.Models;
using Worflow.Models;

namespace Worflow.Dados.Interfaces;

public interface IEnderecoService: IServiceDefault<Endereco>
{
    public Address BuscarEnderecoPorCep(string cep);
}
