﻿using FluentValidation.Results;
using System.Collections.Generic;
using Worflow.Dados.Interfaces;
using Worflow.Dto;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services
{
    public class CotacaoService : ICotacaoService
    {
        ICotacaoRepository _cotacaoRepository;
        public CotacaoService(ICotacaoRepository cotacaoRepository)
        {
            _cotacaoRepository = cotacaoRepository;
        }

        public bool Alterar(Cotacao obj)
        {
            _cotacaoRepository.Alterar(obj);

            return true;
        }

        public ICollection<Cotacao> BuscarCotacoes()
        {
            return _cotacaoRepository.BuscarTodos();
        }              

        public ICollection<Cotacao> BuscarCotacoesPorLeadId(int leadId)
        {
            return _cotacaoRepository.BuscarCotacoesPorLeadId(leadId);
        }

        public Cotacao BuscarPorId(int id)
        {
            return _cotacaoRepository.BuscarPorId(id);
        }

        public bool Excluir(Cotacao obj)
        {
            _cotacaoRepository.Excluir(obj);

            return true;
        }

        public bool Incluir(Cotacao obj)
        {
            obj.Ativo = true;

            _cotacaoRepository.Incluir(obj);

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
    }
}
