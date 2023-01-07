﻿using Worflow.Dados.Interfaces;
using Worflow.Models;
namespace Worflow.Repository
{
    public interface IEnderecoDao : IQuery<Endereco>, ICommand<Endereco>, IQueryPesquisa<Endereco>
    {
    }
}
