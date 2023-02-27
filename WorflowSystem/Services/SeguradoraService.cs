using System.Collections.Generic;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services
{
    public class SeguradoraService: ISeguradoraService
    {
        ISeguradoraRepository _seguradoraRepository;
        public SeguradoraService(ISeguradoraRepository seguradoraRepository)
        {
            _seguradoraRepository = seguradoraRepository;
        }

        public Seguradora BuscarPorId(int id)
        {
            return _seguradoraRepository.BuscarPorId(id);
        }

        public ICollection<Seguradora> BuscarSeguradoras()
        {
            return _seguradoraRepository.BuscarTodos();
        }
    }
}
