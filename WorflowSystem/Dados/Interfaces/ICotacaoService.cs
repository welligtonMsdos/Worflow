using System.Collections.Generic;
using Worflow.Models;

namespace Worflow.Dados.Interfaces
{
    public interface ICotacaoService
    {
        ICollection<Cotacao> BuscarCotacoes();
        Cotacao BuscarPorId(int id);
        ICollection<Cotacao> BuscarCotacoesPorLeadId(int leadId);       
        bool Incluir(Cotacao obj);
        bool Alterar(Cotacao obj);
        bool Excluir(Cotacao obj);
        string IsCotacaoValid(string dataEmissao, string dataVencimento, decimal valor, int leadId, int seguradoraId, int cotacaoId, string statusCotacao);
    }
}
