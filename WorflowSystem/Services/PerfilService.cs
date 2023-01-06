using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services
{
    public class PerfilService : IPerfilService
    {
        IPerfilDao _perfilDao;
        public PerfilService(IPerfilDao perfilDao)
        {
            _perfilDao = perfilDao;
        }

        public List<Perfil> BuscarPerfilList()
        {
            return _perfilDao.BuscarPerfilList();
        }

        public List<SelectListItem> BuscarPerfilSelectItem()
        {
            return _perfilDao.BuscarPerfilSelectItem();
        }
    }
}
