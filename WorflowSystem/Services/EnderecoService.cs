using System.Collections.Generic;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services
{
    public class EnderecoService : IEnderecoService
    {
        IEnderecoDao _enderecoDao;

        public EnderecoService(IEnderecoDao enderecoDao)
        {
            _enderecoDao = enderecoDao;
        }
        public void Alterar(Endereco obj)
        {
            _enderecoDao.Alterar(obj);
        }

        public ICollection<Endereco> BuscarEnderecos()
        {
            return _enderecoDao.BuscarTodos();
        }

        public Endereco BuscarPorId(int id)
        {
            return _enderecoDao.BuscarPorId(id);
        }

        public void Excluir(Endereco obj)
        {
            _enderecoDao.Excluir(obj);
        }

        public void Incluir(Endereco obj)
        {
            _enderecoDao.Incluir(obj);
        }

        public ICollection<Endereco> Pesquisar(string value)
        {
            return _enderecoDao.Pesquisar(value);
        }
    }
}
