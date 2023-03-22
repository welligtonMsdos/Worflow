using Moq;
using Worflow.Dados.Interfaces.Builder;
using Worflow.Models;
using Worflow.Repository;
using Worflow.Services;
using Worflow.Tests.Business;
using Worflow.Tests.Enum;
using Worflow.Tests.Interfaces;
using Xunit;

namespace Worflow.Tests.Services
{
    public class SeguradoraServiceTests
    {
        private readonly ITests _tests;
        private SeguradoraService service;

        public SeguradoraServiceTests()
        {
            _tests = new SeguradoraBusiness();
            service = new SeguradoraService(new Mock<ISeguradoraRepository>().Object);
        }

        [Fact]
        public void BuscarSeguradora_GetTodos() => Assert.True(_tests.GetTodos() > 0);

        [Fact]
        public void BuscarPorId_EnviandoZero() => Assert.Equal(Mensagens.SeguradoraEditarIdZerado, _tests.BuscarIdZerado());

        [Fact]
        public void BuscarPorId_EnviandoIdValido() => Assert.True(_tests.BuscarIdValido());

        [Fact]
        public void Incluir_AddSeguradoraValida() => Assert.True(_tests.Incluir());

        [Fact]
        public void Alterar_AlterandoSeguradoraValido() => Assert.True(_tests.Alterar());

        [Fact]
        public void Excluir_EnviandoIdZero() => Assert.Equal(Mensagens.SeguradoraExcluirIdZerado, _tests.ExcluirIdZerado());

        [Fact]
        public void Excluir_ExcluindoPerfilValido() => Assert.True(_tests.ExcluirIdValido());

        [Fact]      
        public void Pesquisar_PesquisandoValido()
        {
            List<Seguradora> seguradoras = new List<Seguradora>();

            seguradoras.Add(new SeguradoraGeneratorBuilder().Get());

            var repository = new Mock<ISeguradoraRepository>();

            repository.Setup(x => x.Pesquisar(seguradoras.First().Nome)).Returns(seguradoras);

            service = new SeguradoraService(repository.Object);

            var result = service.Pesquisar(seguradoras.First().Nome);

            Assert.True(result.Count > 0);
        }
    }
}
