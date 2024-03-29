﻿using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using Worflow.Dados.Interfaces;
using Worflow.Dtos;
using Worflow.Enum;
using Worflow.Models;
using Worflow.Repository;
using Worflow.ValidatorFluent;

namespace Worflow.Services;

public class CotacaoService : ICotacaoService
{
    ICotacaoRepository _repository;
    public CotacaoService(ICotacaoRepository cotacaoRepository) => (_repository) = (cotacaoRepository);
    
    public bool Alterar(Cotacao obj)
    {
        _repository.Alterar(obj);

        return true;
    }

    public ICollection<Cotacao> BuscarTodos() => _repository.BuscarTodos();    

    public ICollection<Cotacao> BuscarCotacoesPorLeadId(int leadId) => _repository.BuscarCotacoesPorLeadId(leadId);
    
    public SeguradoraDto BuscarDadosSeguradora(int leadId)
    {
        var listaCotacoes = _repository.BuscarCotacoesPorLeadId(leadId);

        var cotacao = listaCotacoes.Where(x => x.StatusFinalizada).FirstOrDefault();   

        SeguradoraDto seguradoraDto = cotacao == null ? 
                                                      new SeguradoraDto("Seguradora","0,00") :
                                                      new SeguradoraDto(cotacao.Seguradora.Nome, cotacao.Valor.ToString());

        return seguradoraDto;
    }

    public Cotacao BuscarPorId(int id)
    {
        if (id == 0)
            throw new Exception(Mensagens.COTACAO_BUSCAR_ID_ZERADO);

        return _repository.BuscarPorId(id);
    }

    public bool Excluir(Cotacao obj)
    {
        if (obj.Id == 0)
            throw new Exception(Mensagens.COTACAO_EXLUCIR_ID_ZERADO);

        _repository.Excluir(obj);

        return true;
    }

    public bool Incluir(Cotacao obj)
    {
        obj.Ativo = true;

        _repository.Incluir(obj);

        return true;
    }

    public string IsCotacaoValid(string dataEmissao, string dataVencimento, decimal valor, int leadId, int seguradoraId, int cotacaoId, string statusCotacao)
    {
        Cotacao cotacao = new Cotacao(cotacaoId, dataEmissao, dataVencimento, valor, leadId, seguradoraId, statusCotacao);

        CotacaoValidator validator = new CotacaoValidator();

        ValidationResult results = validator.Validate(cotacao);

        if (!results.IsValid) return results.ToString("~");

        Alterar(cotacao);

        return "OK";
    }

    public ICollection<Cotacao> Pesquisar(string value) => _repository.Pesquisar(value);    
}
