using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Worflow.Models;

namespace Worflow.Dados.Interfaces
{
    public interface IPerfilService
    {
        List<SelectListItem> BuscarPerfilSelectItem();

        List<Perfil> BuscarPerfilList();
    }
}
