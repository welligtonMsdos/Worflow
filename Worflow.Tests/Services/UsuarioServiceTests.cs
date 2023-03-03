using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Usuario usuario = new Usuario(1, "João da Silva", "JOAVA", 1);

            var result = _usuarioService.Incluir(usuario);

            Assert.True(result);
        }

        [Fact]
        public void Incluir_AddUsuarioInvalidoPerfilZerado()
        {
            Usuario usuario = new Usuario(1, "João da Silva", "JOAVA", 0);

            var exception = Assert.Throws<ValidationException>(() => _usuarioService.Incluir(usuario));

            Assert.Equal("Selecione um perfil", exception.Message);
        }

        [Fact]
        public void Alterar_AlterandoUsuarioValido()
        {
            Usuario usuario = new Usuario(1, "João da Silva", "JOAVA", 1);

            var result = _usuarioService.Alterar(usuario);

            Assert.True(result);
        }

        [Fact]
        public void Alterar_AlterandoUsuarioInvalidoPerfilZerado()
        {
            Usuario usuario = new Usuario(1, "João da Silva", "JOAVA", 0);

            var exception = Assert.Throws<ValidationException>(() => _usuarioService.Alterar(usuario));

            Assert.Equal("Selecione um perfil", exception.Message);
        }

        [Fact]
        public void Excluir_EnviandoIdZero()
        {
            Usuario usuario = new Usuario(0, "João da Silva", "JOAVA", 1);

            var exception = Assert.Throws<Exception>(() => _usuarioService.Excluir(usuario));

            Assert.Equal("Erro ao excluir usuário: Detalhes: Id não pode ser zerado", exception.Message);
        }

        [Fact]
        public void Excluir_ExcluindoUsuarioValido()
        {
            Usuario usuario = new Usuario(1, "João da Silva", "JOAVA", 1);

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
            Usuario usuarios = new Usuario(1, "João da Silva","JOAVA",1);            

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
            
            usuarios.Add(new Usuario { Id = 1, Nome = "João da Silva", RACF = "JOAVA", PerfilId = 1, Ativo = true });

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

            usuarios.Add(new Usuario { Id = 1, Nome = "João da Silva", RACF = "JOAVA", PerfilId = 1, Ativo = true });

            var _usuarioRepository = new Mock<IUsuarioRepository>();

            _usuarioRepository.Setup(x => x.Pesquisar("João")).Returns(usuarios);

            _usuarioService = new UsuarioService(_usuarioRepository.Object);

            var result = _usuarioService.Pesquisar("João");

            Assert.True(result.Count > 0);
        }
    }
}
