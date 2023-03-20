using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Worflow.Core.StatusState;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services
{
    public class StatusService : IStatusService
    {
        IStatusRepository _statusRepository;
        IStatusLead _statusLeadRepository;

        public StatusService(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;           
        }

        public bool Alterar(Status obj)
        {
            Validator.ValidateObject(obj, new ValidationContext(obj), true);

            _statusRepository.Alterar(obj);

            return obj.Id > 0 ? true : false;
        }

        public Status BuscarPorId(int id)
        {
            if (id == 0)
                throw new Exception("Erro ao buscar status por id: Detalhes: Id não pode ser zerado");

            return _statusRepository.BuscarPorId(id);
        }

        public ICollection<Status> BuscarStatus(Lead lead)
        {
            RecuperaStatusAtual(lead.StatusId);
        
            return _statusRepository.BuscarProximoStatus(_statusLeadRepository.ProximoStatus()); 
        }

        public ICollection<Status> BuscarTodos()
        {
            return _statusRepository.BuscarTodos();
        }

        public bool Excluir(Status obj)
        {
            if (obj.Id == 0)
                throw new Exception("Erro ao excluir status: Detalhes: Id não pode ser zerado");

            _statusRepository.Excluir(obj);

            return obj.Id > 0 ? true : false;
        }

        public bool Incluir(Status obj)
        {
            Validator.ValidateObject(obj, new ValidationContext(obj), true);

            _statusRepository.Incluir(obj);

            return obj.Id > 0 ? true : false;
        }

        public ICollection<Status> Pesquisar(string value)
        {
            return _statusRepository.Pesquisar(value);
        }

        private void RecuperaStatusAtual(int statusId)
        {
            switch (statusId)
            {
                case 1: _statusLeadRepository = new StatusAtivo(); break;
                case 2: _statusLeadRepository = new StatusEmAndamento(); break;
                case 3: _statusLeadRepository = new StatusFinalizao(); break;
                case 4: _statusLeadRepository = new StatusCotacao(); break;
                case 5: _statusLeadRepository = new StatusImplantacao(); break;
            }
        }
    }
}
