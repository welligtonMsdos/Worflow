using System;
using Worflow.Dados.Builder.Interfaces;
using Worflow.Models;

namespace Worflow.Dados.Builder;

public class CotacaoGeneratorBuilder : IDadosBuilder<Cotacao>
{
    private Cotacao _cotacao;

    public CotacaoGeneratorBuilder() => Dados();    

    public int Id => 1;

    public void Dados() => _cotacao = new Cotacao(DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("dd/MM/yyyy"), 100, 1, 1);  

    public Cotacao DeleteValid() => Get();

    public Cotacao Post() => _cotacao;

    public Cotacao Put() => Get();

    public Cotacao DeleteNotValid()
    {
        _cotacao.Id = 0;
        return _cotacao;
    }

    public Cotacao Get()
    {
        _cotacao.Id = Id;
        return _cotacao;
    }  
}
