using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services
{
    public class SegmentoService : ISegmentoService
    {
        ISegmentoRepository _repository;

        public SegmentoService(ISegmentoRepository repository)
        {
            _repository = repository;
        }

        public bool Alterar(Segmento obj)
        {
            Validator.ValidateObject(obj, new ValidationContext(obj), true);

            _repository.Alterar(obj);

            return obj.Id > 0 ? true : false;
        }

        public Segmento BuscarPorId(int id)
        {
            if (id == 0)
                throw new Exception("Erro ao buscar segmento por id: Detalhes: Id não pode ser zerado");

            return _repository.BuscarPorId(id);
        }       

        public ICollection<Segmento> BuscarSegmentos()
        {
            return _repository.BuscarTodos();
        }

        public bool Excluir(Segmento obj)
        {
            if (obj.Id == 0)
                throw new Exception("Erro ao excluir segmento: Detalhes: Id não pode ser zerado");

            _repository.Excluir(obj);

            return obj.Id > 0 ? true : false;
        }

        public bool Incluir(Segmento obj)
        {
            Validator.ValidateObject(obj, new ValidationContext(obj), true);

            _repository.Incluir(obj);

            return obj.Id > 0 ? true : false;
        }

        public ICollection<Segmento> Pesquisar(string value)
        {
            return _repository.Pesquisar(value);
        }
    }
}
