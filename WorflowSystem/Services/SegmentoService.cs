using System.Collections.Generic;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services
{
    public class SegmentoService : ISegmentoService
    {
        ISegmentoRepository _segmentoRepository;

        public SegmentoService(ISegmentoRepository segmentoRepository)
        {
            _segmentoRepository = segmentoRepository;
        }
        public Segmento BuscarPorId(int id)
        {
            return _segmentoRepository.BuscarPorId(id);
        }       

        public ICollection<Segmento> BuscarSegmentos()
        {
            return _segmentoRepository.BuscarTodos();
        }
    }
}
