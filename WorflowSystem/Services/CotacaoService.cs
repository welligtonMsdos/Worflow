using System.Collections.Generic;
using Worflow.Dados.Interfaces;
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

        public void Alterar(Cotacao obj)
        {
            _cotacaoRepository.Alterar(obj);
        }

        public ICollection<Cotacao> BuscarCotacoes()
        {
            return _cotacaoRepository.BuscarTodos();
        }

        public Cotacao BuscarPorId(int id)
        {
            return _cotacaoRepository.BuscarPorId(id);
        }

        public void Excluir(Cotacao obj)
        {
            _cotacaoRepository.Excluir(obj);
        }

        public void Incluir(Cotacao obj)
        {
            _cotacaoRepository.Incluir(obj);
        }
    }
}
