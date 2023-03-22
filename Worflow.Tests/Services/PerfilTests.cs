using Moq;
using Worflow.Dados.Interfaces.Builder;
using Worflow.Models;
using Worflow.Repository;
using Worflow.Services;
using Worflow.Tests.Business;
using Worflow.Tests.Enum;
using Worflow.Tests.Interfaces;
using Xunit;

namespace Worflow.Tests.Services;

public class PerfilTests
{
    private readonly ITests _tests;
    private PerfilService service;

    public PerfilTests()
    {
        _tests = new PerfilBusiness();
        service = new PerfilService(new Mock<IPerfilRepository>().Object);
    }

    [Fact]
    public void BuscarPerfil_GetTodos() => Assert.True(_tests.GetTodos() > 0);

    [Fact]
    public void BuscarPorId_EnviandoZero() => Assert.Equal(Mensagens.PerfilEditarIdZerado, _tests.BuscarIdZerado());

    [Fact]
    public void BuscarPorId_EnviandoIdValido() => Assert.True(_tests.BuscarIdValido());

    [Fact]
    public void Pesquisar_PesquisandoValido()
    {
        List<Perfil> perfis = new List<Perfil>();

        perfis.Add(new PerfilGeneratorBuilder().Get());

        var repository = new Mock<IPerfilRepository>();

        repository.Setup(x => x.Pesquisar(perfis.First().Descricao)).Returns(perfis);

        service = new PerfilService(repository.Object);        

        Assert.True(service.Pesquisar(perfis.First().Descricao).Count > 0);
    }

    [Fact]
    public void Incluir_AddPerfilValido() => Assert.True(_tests.Incluir());

    [Fact]
    public void Alterar_AlterandoPerfilValido() => Assert.True(_tests.Alterar());

    [Fact]
    public void Excluir_EnviandoIdZero() => Assert.Equal(Mensagens.PerfilExcluirIdZerado, _tests.ExcluirIdZerado());

    [Fact]
    public void Excluir_ExcluindoPerfilValido() => Assert.True(_tests.ExcluirIdValido());
}
