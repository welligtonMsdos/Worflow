﻿using System.Collections.Generic;
using Worflow.Dados.Interfaces;
using Worflow.Models;

namespace Worflow.Repository
{
    public interface ILeadRepository : IQuery<Lead>, ICommand<Lead>, IQueryPesquisa<Lead>
    {
        void Incluir(List<Lead> obj);
        ICollection<Lead> PesquisarPorId(int value);      
    }
}
