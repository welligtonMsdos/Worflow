﻿using Worflow.Dados.Interfaces;
using Worflow.Models;

namespace Worflow.Repository
{
    public interface IClienteDao : IQuery<Cliente>, ICommand<Cliente>
    {
    }
}