using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Worflow.Dados.Interfaces;
using Worflow.Models;

namespace Worflow.Repository
{
    public interface IPerfilRepository : IQuery<Perfil>, IQueryDescription<Perfil>
    {
        List<Perfil> BuscarPerfilList();
    }
}
