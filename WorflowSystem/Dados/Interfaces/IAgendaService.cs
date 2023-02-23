using System;
using System.Collections.Generic;
using Worflow.Models;

namespace Worflow.Dados.Interfaces
{
    public interface IAgendaService
    {
        ICollection<Agenda> BuscarAgenda();
        ICollection<Agenda> BuscarHorarios(DateTime data);
        List<DatasAgenda> BuscarDatas();
        Agenda BuscarPorId(int id);
        void Incluir(Agenda obj);
        void Alterar(Agenda obj);
        void Excluir(Agenda obj);
    }
}
