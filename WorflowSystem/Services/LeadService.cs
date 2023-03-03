using Microsoft.CodeAnalysis.Elfie.Serialization;
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
        ILeadRepository _leadRepository;

        public LeadService(ILeadRepository leadRepository)
        {
            _leadRepository = leadRepository;
        }
        public void Alterar(Lead obj)
        {
            var lead = _leadRepository.BuscarPorId(obj.Id);
            lead.StatusId = obj.StatusId;
            _leadRepository.Alterar(lead);
        }

        public ICollection<Lead> BuscarLeads()
        {
            return _leadRepository.BuscarTodos();
        }

        public void Excluir(Lead obj)
        {
            _leadRepository.Excluir(obj);
        }

        public void Incluir(Lead obj, string[] produtos)
        {
            SetObservacao(ref obj);

            _leadRepository.Incluir(SetListaLeads(obj, produtos));
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
           return ConversaoTipos.IsNumber(value) ? _leadRepository.PesquisarPorId(int.Parse(value)) : _leadRepository.Pesquisar(value);         
        }       

        private void SetObservacao(ref Lead lead)
        {
            lead.Observacao = lead.Observacao == null ? "" : lead.Observacao;
        }

        public IPagedList<Lead> BuscarLeadsByPageList(int pagina)
        {
            return _leadRepository.BuscarLeadsByPageList(pagina);
        }

        public IPagedList<Lead> PesquisarByPageList(string value, int pagina)
        {
            return _leadRepository.PesquisarByPageList(value, pagina);
        }

        public LeadCotacao BuscarLeadCotacaoPorId(int id)
        {
            LeadCotacao leadCotacao = new LeadCotacao(_leadRepository.BuscarPorId(id), new Cotacao());

            return leadCotacao;
        }

        public Lead BuscarPorId(int id)
        {
            return _leadRepository.BuscarPorId(id);
        }
    }
}
