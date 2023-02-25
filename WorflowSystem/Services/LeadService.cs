using System.Collections.Generic;
using Worflow.Core;
using Worflow.Dados.Interfaces;
using Worflow.Models;
using Worflow.Repository;
using X.PagedList;

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
            var lead = _leadDao.BuscarPorId(obj.Id);
            lead.StatusId = obj.StatusId;
            _leadDao.Alterar(lead);
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
                    ProdutoId = int.Parse(produtoId),
                    SegmentoId = obj.SegmentoId
                    
                 });                
            }

            return lead;
        }

        public ICollection<Lead> Pesquisar(string value)
        {
           return ConversaoTipos.IsNumber(value) ? _leadDao.PesquisarPorId(int.Parse(value)) : _leadDao.Pesquisar(value);           
        }       

        private void SetObservacao(ref Lead lead)
        {
            lead.Observacao = lead.Observacao == null ? "" : lead.Observacao;
        }

        public IPagedList<Lead> BuscarLeadsByPageList(int pagina)
        {
            return _leadDao.BuscarLeadsByPageList(pagina);
        }

        public IPagedList<Lead> PesquisarByPageList(string value, int pagina)
        {
            return _leadDao.PesquisarByPageList(value, pagina);
        }
    }
}
