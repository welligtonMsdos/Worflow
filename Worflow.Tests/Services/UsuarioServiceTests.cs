using Moq;
using System.ComponentModel.DataAnnotations;
using Worflow.Dados.Interfaces.Builder;
using Worflow.Enum;
using Worflow.Models;
using Worflow.Repository;
using Worflow.Services;
using Worflow.Tests.Business;
using Worflow.Tests.Interfaces;
using Xunit;

namespace Worflow.Tests.Services;

public class UsuarioServiceTests
{
    private readonly ITests _tests;
    private readonly ITestsPesquisar _testsPesquisar;
    private UsuarioService service;
    private const string BUSCAR = Mensagens.USUARIO_BUSCAR_ID_ZERADO;
    private const string EXCLUIR = Mensagens.USUARIO_EXCLUIR_ID_ZERADO;

    public UsuarioServiceTests()
    {
        _tests = new UsuarioBusiness();
        _testsPesquisar = new UsuarioBusiness();
        service = new UsuarioService(new Mock<IUsuarioRepository>().Object);
    }

    [Fact]
    public void Buscar_GetTodos() => Assert.True(_tests.GetTodos() > 0);

    [Fact]
    public void BuscarPorId_EnviandoZero() => Assert.Equal(BUSCAR, _tests.BuscarIdZerado());

    [Fact]
    public void BuscarPorId_EnviandoIdValido() => Assert.True(_tests.BuscarIdValido());

    [Fact]
    public void Incluir_AddValido() => Assert.True(_tests.Incluir());

    [Fact]
    public void Alterar_AlterandoValido() => Assert.True(_tests.Alterar());

    [Fact]
    public void Excluir_EnviandoIdZero() => Assert.Equal(EXCLUIR, _tests.ExcluirIdZerado());

    [Fact]
    public void Excluir_ExcluindoValido() => Assert.True(_tests.ExcluirIdValido());

    [Fact]
    public void Pesquisar_PesquisandoValido() => Assert.True(_testsPesquisar.PesquisarValido());        
   
    [Fact]
    public void Incluir_AddUsuarioInvalidoPerfilZerado()
    {
        Usuario usuario = new UsuarioGeneratorBuilder().Post();

        usuario.PerfilId = 0;

        var exception = Assert.Throws<ValidationException>(() => service.Incluir(usuario));

        Assert.Equal(Mensagens.USUARIO_SELECIONE_PERFIL, exception.Message);
    }

    [Fact]
    public void Alterar_AlterandoUsuarioInvalidoPerfilZerado()
    {
        Usuario usuario = new UsuarioGeneratorBuilder().Put();

        usuario.PerfilId = 0;

        var exception = Assert.Throws<ValidationException>(() => service.Alterar(usuario));

        Assert.Equal(Mensagens.USUARIO_SELECIONE_PERFIL, exception.Message);
    }      
}
