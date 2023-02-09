﻿using System.Collections.Generic;
using Worflow.Core.Status;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services
{
    public class StatusService : IStatusService
    {
        IStatusDao _statusDao;
        IStatusLead _statusLead;

        public StatusService(IStatusDao statusDao)
        {
            _statusDao = statusDao;
        }

        public ICollection<Status> BuscarStatus(Lead lead)
        {
            RecuperaStatusAtual(lead.StatusId);

            //lead.Status.ModoStatus = _statusLead.ModoStatus();

            return _statusDao.BuscarProximoStatus(_statusLead.ProximoStatus());           
        }

        private void RecuperaStatusAtual(int statusId)
        {
            switch (statusId)
            {
                case 1: _statusLead = new StatusAtivo(); break;
                case 2: _statusLead = new StatusEmAndamento(); break;
                case 3: _statusLead = new StatusFinalizao(); break;
            }
        }
    }
}