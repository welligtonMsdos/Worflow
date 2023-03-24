using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Worflow.Core;
using Worflow.Dados.Interfaces;
using Worflow.Enum;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services;

public class LeadService : ILeadService
{
    private readonly ILeadRepository _repository;      

    public LeadService(ILeadRepository repository) => (_repository) = (repository);
    
    public bool Alterar(Lead obj)
    {
        var lead = _repository.BuscarPorId(obj.Id);

        lead.StatusId = obj.StatusId;
        
        _repository.Alterar(lead);

        return obj.Id > 0 ? true : false;
    }

    public ICollection<Lead> BuscarTodos() => _repository.BuscarTodos();
    
    public bool Excluir(Lead obj)
    {
        if (obj.Id == 0)
            throw new Exception(Mensagens.LEAD_EXCLUIR_ID_ZERADO);

        _repository.Excluir(obj);

        return obj.Id > 0 ? true : false;
    }

    public bool Incluir(Lead obj, string[] produtos)
    {
        try
        {
            Validator.ValidateObject(obj, new ValidationContext(obj), true);

            SetObservacao(ref obj);

            _repository.Incluir(SetListaLeads(obj, produtos));

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(Mensagens.LEAD_INCLUIR_ERRO);               
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

    public ICollection<Lead> Pesquisar(string value) => ConversaoTipos.IsNumber(value) ? _repository.PesquisarPorId(int.Parse(value)) : _repository.Pesquisar(value);                        

    private void SetObservacao(ref Lead lead) => lead.Observacao = lead.Observacao == null ? "" : lead.Observacao;        

    public LeadCotacao BuscarLeadCotacaoPorId(int id) => new LeadCotacao(_repository.BuscarPorId(id), new Cotacao(id));
    
    public Lead BuscarPorId(int id)
    {
        if (id == 0)
            throw new Exception(Mensagens.LEAD_BUSCAR_ID_ZERADO);

        return _repository.BuscarPorId(id);
    }

    public bool Incluir(Lead obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        _repository.Incluir(obj);

        return obj.Id > 0 ? true : false;
    }
}
