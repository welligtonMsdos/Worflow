using System.Collections.Generic;
using Worflow.Dtos;
using Worflow.Models;

namespace Worflow.Dados.Interfaces;

public interface ICotacaoService: IServiceDefault<Cotacao>
{
    ICollection<Cotacao> BuscarCotacoesPorLeadId(int leadId);
    SeguradoraDto BuscarDadosSeguradora(int leadId);
    string IsCotacaoValid(string dataEmissao, string dataVencimento, decimal valor, int leadId, int seguradoraId, int cotacaoId, string statusCotacao);
}
