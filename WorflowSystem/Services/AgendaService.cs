using System;
using System.Collections.Generic;
using System.Linq;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services
{
    public class AgendaService : IAgendaService
    {
        IAgendaRepository _agendaDao;

        public AgendaService(IAgendaRepository agendaDao)
        {
            _agendaDao = agendaDao;
        }

        public void Alterar(Agenda obj)
        {
            AgendaDefault(ref obj);
            
            _agendaDao.Alterar(obj);
        }

        public ICollection<Agenda> BuscarAgenda()
        {
            return _agendaDao.BuscarTodos();
        }

        public List<DatasAgenda> BuscarDatas()
        {
            return SetarDatasAgenda(ListarDatas());
        }

        public ICollection<Agenda> BuscarHorarios(DateTime data)
        {
            return _agendaDao.BuscarHorarios(data);
        }

        public Agenda BuscarPorId(int id)
        {
            return _agendaDao.BuscarPorId(id);
        }

        public void Excluir(Agenda obj)
        {
            _agendaDao.Excluir(obj);
        }

        public void Incluir(Agenda obj)
        {
            AgendaDefault(ref obj);

            _agendaDao.Incluir(obj);
        }

        private void AgendaDefault(ref Agenda agenda)
        {
            agenda.Ativo = true;
            agenda.LeadId = 1;
            agenda.UsuarioId = 1;
        }

        private List<Agenda> ListarDatas()
        {
            var query = _agendaDao.BuscarDatas();

            List<Agenda> listaAgenda = new List<Agenda>();

            foreach (IGrouping<DateTime, Agenda> group in query)
            {
                foreach (Agenda agenda in group)
                {
                    listaAgenda.Add(new Agenda(agenda.DataAgendada));
                    break;
                }
            }

            return listaAgenda;
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
