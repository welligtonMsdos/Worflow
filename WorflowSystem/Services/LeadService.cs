using System.Collections.Generic;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services
{
    public class LeadService : ILeadService
    {
        ILeadDao _leadDao;

        public LeadService(ILeadDao leadDao)
        {
            _leadDao = leadDao;
        }
        public void Alterar(Lead obj)
        {
            _leadDao.Alterar(obj);
        }

        public ICollection<Lead> BuscarLeads()
        {
            return _leadDao.BuscarTodos();
        }

        public Lead BuscarPorId(int id)
        {
            return _leadDao.BuscarPorId(id);
        }

        public void Excluir(Lead obj)
        {
            _leadDao.Excluir(obj);
        }

        public void Incluir(Lead obj, string[] produtos)
        {
            SetObservacao(ref obj);

            foreach (var produtoId in produtos)
            {
                obj.ProdutoId = int.Parse(produtoId);

                _leadDao.Incluir(obj);

                obj.Id = 0;
            }
        }     

        public ICollection<Lead> Pesquisar(string value)
        {
            return _leadDao.Pesquisar(value);
        }

        private void SetObservacao(ref Lead lead)
        {
            lead.Observacao = lead.Observacao == null ? "" : lead.Observacao;
        }
    }
}
