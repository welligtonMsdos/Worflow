using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public bool Alterar(Lead obj)
        {
            var lead = _leadRepository.BuscarPorId(obj.Id);
            lead.StatusId = obj.StatusId;
            _leadRepository.Alterar(lead);

            return obj.Id > 0 ? true : false;
        }

        public ICollection<Lead> BuscarLeads()
        {
            return _leadRepository.BuscarTodos();
        }

        public bool Excluir(Lead obj)
        {
            if (obj.Id == 0)
                throw new Exception("Erro ao excluir Lead: Detalhes: Id não pode ser zerado");

            _leadRepository.Excluir(obj);

            return obj.Id > 0 ? true : false;
        }

        public bool Incluir(Lead obj, string[] produtos)
        {
            try
            {
                Validator.ValidateObject(obj, new ValidationContext(obj), true);

                SetObservacao(ref obj);

                _leadRepository.Incluir(SetListaLeads(obj, produtos));

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao incluir Lead");               
            }            
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

        public IPagedList<Lead> BuscarLeadsByPageList(int pagina = 1)
        {
            return _leadRepository.BuscarLeadsByPageList(pagina);
        }

        public IPagedList<Lead> PesquisarByPageList(string value, int pagina = 1)
        {
            return _leadRepository.PesquisarByPageList(value, pagina);
        }

        public LeadCotacao BuscarLeadCotacaoPorId(int id)
        {
            LeadCotacao leadCotacao = new LeadCotacao(_leadRepository.BuscarPorId(id), new Cotacao(id));

            return leadCotacao;
        }

        public Lead BuscarPorId(int id)
        {
            if (id == 0)
                throw new Exception("Erro ao buscar Lead por id: Detalhes: Id não pode ser zerado");

            return _leadRepository.BuscarPorId(id);
        }       
    }
}
