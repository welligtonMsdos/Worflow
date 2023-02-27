using System.Collections.Generic;
using Worflow.Models;

namespace Worflow.Dados.Interfaces
{
    public interface ICotacaoService
    {
        ICollection<Cotacao> BuscarCotacoes();
        Cotacao BuscarPorId(int id);
        void Incluir(Cotacao obj);
        void Alterar(Cotacao obj);
        void Excluir(Cotacao obj);       
    }
}
