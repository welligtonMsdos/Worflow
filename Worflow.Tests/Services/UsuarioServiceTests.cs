using Moq;
using System.ComponentModel.DataAnnotations;
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
    public class UsuarioServiceTests
    {
        private readonly ITests _tests;
        private UsuarioService service;
        private string buscar = Mensagens.UsuarioEditarIdZerado;
        private string excluir = Mensagens.UsuarioExcluirIdZerado;

        public UsuarioServiceTests()
        {
            _tests = new UsuarioBusiness();
            service = new UsuarioService(new Mock<IUsuarioRepository>().Object);
        }

        [Fact]
        public void Buscar_GetTodos() => Assert.True(_tests.GetTodos() > 0);

        [Fact]
        public void BuscarPorId_EnviandoZero() => Assert.Equal(buscar, _tests.BuscarIdZerado());

        [Fact]
        public void BuscarPorId_EnviandoIdValido() => Assert.True(_tests.BuscarIdValido());

        [Fact]
        public void Incluir_AddValido() => Assert.True(_tests.Incluir());

        [Fact]
        public void Alterar_AlterandoValido() => Assert.True(_tests.Alterar());

        [Fact]
        public void Excluir_EnviandoIdZero() => Assert.Equal(excluir, _tests.ExcluirIdZerado());

        [Fact]
        public void Excluir_ExcluindoValido() => Assert.True(_tests.ExcluirIdValido());

        [Fact]
        public void Pesquisar_PesquisandoValido()
        {
            var entidade = new List<Usuario>();

            entidade.Add(new UsuarioGeneratorBuilder().Get());

            var repository = new Mock<IUsuarioRepository>();

            repository.Setup(x => x.Pesquisar(entidade.First().Nome)).Returns(entidade);

            service = new UsuarioService(repository.Object);

            var result = service.Pesquisar(entidade.First().Nome);

            Assert.True(result.Count > 0);
        }
       
        [Fact]
        public void Incluir_AddUsuarioInvalidoPerfilZerado()
        {
            Usuario usuario = new UsuarioGeneratorBuilder().Post();

            usuario.PerfilId = 0;

            var exception = Assert.Throws<ValidationException>(() => service.Incluir(usuario));

            Assert.Equal(Mensagens.UsuarioSelecionePerfil, exception.Message);
        }

        [Fact]
        public void Alterar_AlterandoUsuarioInvalidoPerfilZerado()
        {
            Usuario usuario = new UsuarioGeneratorBuilder().Put();

            usuario.PerfilId = 0;

            var exception = Assert.Throws<ValidationException>(() => service.Alterar(usuario));

            Assert.Equal(Mensagens.UsuarioSelecionePerfil, exception.Message);
        }      
    }
}
