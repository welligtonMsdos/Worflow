using Moq;
using Worflow.Dados.Interfaces.Builder;
using Worflow.Models;
using Worflow.Repository;
using Worflow.Services;
using Xunit;

namespace Worflow.Tests.Services
{
    public class SeguradoraServiceTests
    {
        private SeguradoraService service;

        public SeguradoraServiceTests()
        {
            service = new SeguradoraService(new Mock<ISeguradoraRepository>().Object);
        }

        [Fact]
        [Trait("Get", "Pesquisando por nome")]
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

        [Fact]
        [Trait("Get", "Pesquisando passando o id zerado")]
        public void BuscarPorId_EnviandoZero()
        {
            var exception = Assert.Throws<Exception>(() => service.BuscarPorId(0));

            Assert.Equal("Erro ao buscar seguradora por id: Detalhes: Id não pode ser zerado", exception.Message);
        }

        [Fact]
        [Trait("Get", "Pesquisando passado o id válido")]
        public void BuscarPorId_EnviandoIdValido()
        {
            Seguradora seguradora = new SeguradoraGeneratorBuilder().Get();

            var repository = new Mock<ISeguradoraRepository>();

            repository.Setup(x => x.BuscarPorId(seguradora.Id)).Returns(seguradora);

            service = new SeguradoraService(repository.Object);

            var result = service.BuscarPorId(seguradora.Id);

            Assert.True(result.Id > 0);
        }

        [Fact]
        [Trait("Post", "Adicionando seguradora válida")]
        public void Incluir_AddSeguradoraValida()
        {
            Assert.True(service.Incluir(new SeguradoraGeneratorBuilder().Post()));
        }

        [Fact]
        [Trait("Put", "Alterando seguradora válida")]
        public void Alterar_AlterandoSeguradoraValida()
        {
            Assert.True(service.Alterar(new SeguradoraGeneratorBuilder().Put()));
        }

        [Fact]
        [Trait("Delete", "Excluindo seguradora id zerado")]
        public void Excluir_EnviandoIdZero()
        {
            Seguradora seguradora = new SeguradoraGeneratorBuilder().DeleteNotValid();

            var exception = Assert.Throws<Exception>(() => service.Excluir(seguradora));

            Assert.Equal("Erro ao excluir seguradora: Detalhes: Id não pode ser zerado", exception.Message);
        }

        [Fact]
        [Trait("Delete", "Excluindo seguradora id válido")]
        public void Excluir_ExcluindoSeguradoraValida()
        {
            Seguradora seguradora = new SeguradoraGeneratorBuilder().DeleteValid();

            Assert.True(service.Excluir(seguradora));
        }
    }
}
