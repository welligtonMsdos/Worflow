using System.Collections.Generic;
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

        public ICollection<Status> BuscarStatus(Lead lead)
        {
            RecuperaStatusAtual(lead.StatusId);

            return _statusRepository.BuscarProximoStatus(_statusLeadRepository.ProximoStatus());           
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
