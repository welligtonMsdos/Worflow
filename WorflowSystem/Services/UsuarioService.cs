using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services
{
    public class UsuarioService : IUsuarioService
    {
        IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public bool Alterar(Usuario obj)
        {
            Validator.ValidateObject(obj, new ValidationContext(obj), true);

            _usuarioRepository.Alterar(obj);

            return obj.Id > 0 ? true : false;
        }

        public Usuario BuscarPorId(int id)
        {
            if (id == 0)
                throw new Exception("Erro ao buscar usuário por id: Detalhes: Id não pode ser zerado");

            return _usuarioRepository.BuscarPorId(id);
        }

        public ICollection<Usuario> BuscarUsuarios()
        {
            return _usuarioRepository.BuscarTodos();
        }

        public bool Excluir(Usuario obj)
        {
            if (obj.Id == 0)
                throw new Exception("Erro ao excluir usuário: Detalhes: Id não pode ser zerado");

            _usuarioRepository.Excluir(obj);

            return obj.Id > 0 ? true : false;
        }

        public bool Incluir(Usuario obj)
        {
            if (!_usuarioRepository.UsuarioExiste(obj))
            {
                Validator.ValidateObject(obj, new ValidationContext(obj), true);

                _usuarioRepository.Incluir(obj);

                return true;
            }
            else
                return false;               
        }

        public ICollection<Usuario> Pesquisar(string value)
        {
            return _usuarioRepository.Pesquisar(value);
        }
    }
}
