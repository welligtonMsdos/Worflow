using System.Collections.Generic;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services
{
    public class PerfilService : IPerfilService
    {
        IPerfilRepository _perfilRepository;
        public PerfilService(IPerfilRepository perfilRepository)
        {
            _perfilRepository = perfilRepository;
        }

        public List<Perfil> BuscarPerfilList()
        {
            return _perfilRepository.BuscarPerfilList();
        }
    }
}
