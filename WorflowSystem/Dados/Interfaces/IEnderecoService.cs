using System.Collections.Generic;
using Worflow.Models;

namespace Worflow.Dados.Interfaces
{
    public interface IEnderecoService
    {
        ICollection<Endereco> BuscarEnderecos();
        ICollection<Endereco> Pesquisar(string value);
        Endereco BuscarPorId(int id);
        void Incluir(Endereco obj);
        void Alterar(Endereco obj);
        void Excluir(Endereco obj);
    }
}
