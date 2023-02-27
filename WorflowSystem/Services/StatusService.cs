using System.Collections.Generic;
using Worflow.Core.Status;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services
{
    public class StatusService : IStatusService
    {
        IStatusRepository _statusDao;
        IStatusLead _statusLead;

        public StatusService(IStatusRepository statusDao)
        {
            _statusDao = statusDao;
        }

        public ICollection<Status> BuscarStatus(Lead lead)
        {
            RecuperaStatusAtual(lead.StatusId);

            return _statusDao.BuscarProximoStatus(_statusLead.ProximoStatus());           
        }

        private void RecuperaStatusAtual(int statusId)
        {
            switch (statusId)
            {
                case 1: _statusLead = new StatusAtivo(); break;
                case 2: _statusLead = new StatusEmAndamento(); break;
                case 3: _statusLead = new StatusFinalizao(); break;
                case 4: _statusLead = new StatusCotacao(); break;
                case 5: _statusLead = new StatusImplantacao(); break;
            }
        }
    }
}
