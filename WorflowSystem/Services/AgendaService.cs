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
        IAgendaRepository _agendaRepository;

        public AgendaService(IAgendaRepository agendaRepository)
        {
            _agendaRepository = agendaRepository;
        }

        public void Alterar(Agenda obj)
        {
            AgendaDefault(ref obj);

            _agendaRepository.Alterar(obj);
        }

        public ICollection<Agenda> BuscarAgenda()
        {
            return _agendaRepository.BuscarTodos();
        }

        public List<DatasAgenda> BuscarDatas()
        {
            return SetarDatasAgenda(ListarDatas());
        }

        public ICollection<Agenda> BuscarHorarios(DateTime data)
        {
            return _agendaRepository.BuscarHorarios(data);
        }

        public Agenda BuscarPorId(int id)
        {
            return _agendaRepository.BuscarPorId(id);
        }

        public void Excluir(Agenda obj)
        {
            _agendaRepository.Excluir(obj);
        }

        public void Incluir(Agenda obj)
        {
            AgendaDefault(ref obj);

            _agendaRepository.Incluir(obj);
        }

        private void AgendaDefault(ref Agenda agenda)
        {
            agenda.Ativo = true;
            agenda.LeadId = 1;
            agenda.UsuarioId = 1;
        }

        private List<Agenda> ListarDatas()
        {
            var query = _agendaRepository.BuscarDatas();

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
