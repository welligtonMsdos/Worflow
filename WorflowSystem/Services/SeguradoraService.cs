using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services
{
    public class SeguradoraService: ISeguradoraService
    {
        ISeguradoraRepository _repository;
        public SeguradoraService(ISeguradoraRepository seguradoraRepository)
        {
            _repository = seguradoraRepository;
        }

        public bool Alterar(Seguradora obj)
        {
            Validator.ValidateObject(obj, new ValidationContext(obj), true);

            _repository.Alterar(obj);

            return obj.Id > 0 ? true : false;
        }

        public Seguradora BuscarPorId(int id)
        {
            if (id == 0)
                throw new Exception("Erro ao buscar seguradora por id: Detalhes: Id não pode ser zerado");

            return _repository.BuscarPorId(id);
        }

        public ICollection<Seguradora> BuscarSeguradoras()
        {
            return _repository.BuscarTodos();
        }

        public bool Excluir(Seguradora obj)
        {
            if (obj.Id == 0)
                throw new Exception("Erro ao excluir seguradora: Detalhes: Id não pode ser zerado");

            _repository.Excluir(obj);

            return obj.Id > 0 ? true : false;
        }

        public bool Incluir(Seguradora obj)
        {
            Validator.ValidateObject(obj, new ValidationContext(obj), true);

            _repository.Incluir(obj);

            return obj.Id > 0 ? true : false;
        }

        public ICollection<Seguradora> Pesquisar(string value)
        {
            return _repository.Pesquisar(value);
        }
    }
}
