using System.Collections.Generic;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services
{
    public class EnderecoService : IEnderecoService
    {
        IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }
        public void Alterar(Endereco obj)
        {
            _enderecoRepository.Alterar(obj);
        }

        public ICollection<Endereco> BuscarEnderecos()
        {
            return _enderecoRepository.BuscarTodos();
        }

        public Endereco BuscarPorId(int id)
        {
            return _enderecoRepository.BuscarPorId(id);
        }

        public void Excluir(Endereco obj)
        {
            _enderecoRepository.Excluir(obj);
        }

        public void Incluir(Endereco obj)
        {
            _enderecoRepository.Incluir(obj);
        }

        public ICollection<Endereco> Pesquisar(string value)
        {
            return _enderecoRepository.Pesquisar(value);
        }
    }
}
