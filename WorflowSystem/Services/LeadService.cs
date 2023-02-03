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

            _leadDao.Incluir(SetListaLeads(obj, produtos));
        }

        private List<Lead> SetListaLeads(Lead obj, string[] produtos)
        {
            List<Lead> lead = new List<Lead>();

            foreach (var produtoId in produtos)
            {
                lead.Add(new Lead()
                {
                    DataAgendada = obj.DataAgendada,
                    ClienteId = obj.ClienteId,
                    Observacao = obj.Observacao,
                    StatusId = obj.StatusId,
                    UsuarioId = obj.UsuarioId,
                    ProdutoId = int.Parse(produtoId)
                 });                
            }

            return lead;
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
