using System.Collections.Generic;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services
{
    public class PerfilService : IPerfilService
    {
        IPerfilRepository _perfilDao;
        public PerfilService(IPerfilRepository perfilDao)
        {
            _perfilDao = perfilDao;
        }

        public List<Perfil> BuscarPerfilList()
        {
            return _perfilDao.BuscarPerfilList();
        }
    }
}
