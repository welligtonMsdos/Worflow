using System;
using Worflow.Models;

namespace Worflow.Dados.Interfaces.Builder;

public class CotacaoGeneratorBuilder : ICotacaoBuilder
{
    private Cotacao _cotacao;

    public CotacaoGeneratorBuilder()
    {
        DadosCotacao();
    }

    public Cotacao Post()
    {
        return _cotacao;
    }

    public Cotacao Put(int id)
    {
        _cotacao.Id = id;
        return _cotacao;
    }

    public Cotacao Get()
    {
        _cotacao.Id = 1;
        return _cotacao;
    }

    public void DadosCotacao()
    {
        _cotacao = new Cotacao(DateTime.Now,DateTime.Now,100,1,1);
    }
}
