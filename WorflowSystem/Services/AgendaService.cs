using System;
using System.Collections.Generic;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services
{
    public class AgendaService : IAgendaService
    {
        IAgendaDao _agendaDao;

        public AgendaService(IAgendaDao agendaDao)
        {
            _agendaDao = agendaDao;
        }

        public ICollection<Agenda> BuscarAgenda()
        {
            return _agendaDao.BuscarTodos();
        }

        public List<DatasAgenda> BuscarAgendaList()
        {
            return SetarDatasAgenda(ListarDatas());
        }

        public ICollection<Agenda> BuscarHorarios(DateTime data)
        {
            return _agendaDao.BuscarHorarios(data);
        }

        private List<Agenda> ListarDatas()
        {
            return (List<Agenda>)_agendaDao.BuscarAgendaList();
        }

        private List<DatasAgenda> SetarDatasAgenda(List<Agenda> listaAgenda)
        {
            List<DatasAgenda> listaDatasAgenda = new List<DatasAgenda>();

            listaAgenda.ForEach(delegate (Agenda agenda)
            {
                listaDatasAgenda.Add(new DatasAgenda(agenda.DataAgendada.ToShortDateString(), 
                                                     "collapse" + agenda.DataAgendada.ToShortDateString().Replace("/", "")));
            });

            return listaDatasAgenda;
        }
    }
}
