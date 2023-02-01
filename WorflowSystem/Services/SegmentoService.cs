﻿using System.Collections.Generic;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services
{
    public class SegmentoService : ISegmentoService
    {
        ISegmentoDao _segmentoDao;

        public SegmentoService(ISegmentoDao segmentoDao)
        {
            _segmentoDao = segmentoDao;
        }
        public Segmento BuscarPorId(int id)
        {
            return _segmentoDao.BuscarPorId(id);
        }

        public ICollection<Segmento> BuscarSegmentos()
        {
            return _segmentoDao.BuscarTodos();
        }
    }
}