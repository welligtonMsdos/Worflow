using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services
{
    public class PerfilService : IPerfilService
    {
        IPerfilRepository _perfilRepository;
        public PerfilService(IPerfilRepository perfilRepository)
        {
            _perfilRepository = perfilRepository;
        }

        public bool Alterar(Perfil obj)
        {
            Validator.ValidateObject(obj, new ValidationContext(obj), true);

            _perfilRepository.Alterar(obj);

            return obj.Id > 0 ? true : false;
        }

        public ICollection<Perfil> BuscarPerfil()
        {
            return _perfilRepository.BuscarTodos();
        }

        public List<Perfil> BuscarPerfilList()
        {
            return _perfilRepository.BuscarPerfilList();
        }

        public Perfil BuscarPorId(int id)
        {
            if (id == 0)
                throw new Exception("Erro ao buscar perfil por id: Detalhes: Id não pode ser zerado");

            return _perfilRepository.BuscarPorId(id);
        }

        public bool Excluir(Perfil obj)
        {
            if (obj.Id == 0)
                throw new Exception("Erro ao excluir perfil: Detalhes: Id não pode ser zerado");

            _perfilRepository.Excluir(obj);

            return obj.Id > 0 ? true : false;
        }

        public bool Incluir(Perfil obj)
        {
            Validator.ValidateObject(obj, new ValidationContext(obj), true);

            _perfilRepository.Incluir(obj);

            return obj.Id > 0 ? true : false;
        }

        public ICollection<Perfil> Pesquisar(string value)
        {
            return _perfilRepository.Pesquisar(value);
        }
    }
}
