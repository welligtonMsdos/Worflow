using Moq;
using Worflow.Dados.Interfaces.Builder;
using Worflow.Models;
using Worflow.Repository;
using Worflow.Services;
using Xunit;

namespace Worflow.Tests.Services
{
    public class CotacaoServiceTests
    {
        private CotacaoService _cotacaoService;

        public CotacaoServiceTests()
        {
            _cotacaoService = new CotacaoService(new Mock<ICotacaoRepository>().Object);
        }

        [Fact]
        public void BuscarCotacoes_GetTodos()
        {
            List<Cotacao> cotacoes = new List<Cotacao>();

            cotacoes.Add(new CotacaoGeneratorBuilder().Get());

            var _cotacaoRepository = new Mock<ICotacaoRepository>();

            _cotacaoRepository.Setup(x => x.BuscarTodos()).Returns(cotacoes);

            _cotacaoService = new CotacaoService(_cotacaoRepository.Object);

            var result = _cotacaoService.BuscarCotacoes();

            Assert.True(result.Count > 0);
        }
    }
}
