using Moq;
using System.ComponentModel.DataAnnotations;
using Worflow.Dados.Interfaces.Builder;
using Worflow.Models;
using Worflow.Repository;
using Worflow.Services;
using Xunit;

namespace Worflow.Tests.Services
{
    public class UsuarioServiceTests
    {
        private UsuarioService _usuarioService;

        public UsuarioServiceTests()
        {
            _usuarioService = new UsuarioService(new Mock<IUsuarioRepository>().Object);
        }

        [Fact]
        public void Incluir_AddUsuarioValido()
        {
            Assert.True(_usuarioService.Incluir(new UsuarioGeneratorBuilder().Post()));
        }

        [Fact]
        public void Incluir_AddUsuarioInvalidoPerfilZerado()
        {
            Usuario usuario = new UsuarioGeneratorBuilder().Post();

            usuario.PerfilId = 0;

            var exception = Assert.Throws<ValidationException>(() => _usuarioService.Incluir(usuario));

            Assert.Equal("Selecione um perfil", exception.Message);
        }

        [Fact]
        public void Alterar_AlterandoUsuarioValido()
        {   
            Assert.True(_usuarioService.Alterar(new UsuarioGeneratorBuilder().Put()));
        }

        [Fact]
        public void Alterar_AlterandoUsuarioInvalidoPerfilZerado()
        {
            Usuario usuario = new UsuarioGeneratorBuilder().Put();

            usuario.PerfilId = 0;

            var exception = Assert.Throws<ValidationException>(() => _usuarioService.Alterar(usuario));

            Assert.Equal("Selecione um perfil", exception.Message);
        }

        [Fact]
        public void Excluir_EnviandoIdZero()
        {
            Usuario usuario = new UsuarioGeneratorBuilder().DeleteNotValid();

            var exception = Assert.Throws<Exception>(() => _usuarioService.Excluir(usuario));

            Assert.Equal("Erro ao excluir usuário: Detalhes: Id não pode ser zerado", exception.Message);
        }

        [Fact]
        public void Excluir_ExcluindoUsuarioValido()
        {
            Usuario usuario = new UsuarioGeneratorBuilder().DeleteValid();

            var result = _usuarioService.Excluir(usuario);

            Assert.True(result);
        }

        [Fact]
        public void BuscarPorId_EnviandoIdZero()
        {
            var exception = Assert.Throws<Exception>(() => _usuarioService.BuscarPorId(0));

            Assert.Equal("Erro ao buscar usuário por id: Detalhes: Id não pode ser zerado", exception.Message);
        }

        [Fact]
        public void BuscarPorId_EnviandoIdValido()
        {
            Usuario usuarios = new UsuarioGeneratorBuilder().Get();    

            var _usuarioRepository = new Mock<IUsuarioRepository>();
           
            _usuarioRepository.Setup(x => x.BuscarPorId(usuarios.Id)).Returns(usuarios);

            _usuarioService = new UsuarioService(_usuarioRepository.Object);

            var result = _usuarioService.BuscarPorId(usuarios.Id);

            Assert.True(result.Id > 0);
        }

        [Fact]
        public void BuscarUsuarios_GetTodos()
        {
            List<Usuario> usuarios = new List<Usuario>();
            
            usuarios.Add(new UsuarioGeneratorBuilder().Get());

            var _usuarioRepository = new Mock<IUsuarioRepository>();

            _usuarioRepository.Setup(x => x.BuscarTodos()).Returns(usuarios);

            _usuarioService = new UsuarioService(_usuarioRepository.Object);

            var result = _usuarioService.BuscarUsuarios();

            Assert.True(result.Count > 0);
        }

        [Fact]
        public void Pesquisar_PesquisandoValido()
        {
            List<Usuario> usuarios = new List<Usuario>();

            usuarios.Add(new UsuarioGeneratorBuilder().Get());

            var _usuarioRepository = new Mock<IUsuarioRepository>();

            _usuarioRepository.Setup(x => x.Pesquisar(usuarios.First().Nome)).Returns(usuarios);

            _usuarioService = new UsuarioService(_usuarioRepository.Object);

            var result = _usuarioService.Pesquisar(usuarios.First().Nome);

            Assert.True(result.Count > 0);
        }
    }
}
