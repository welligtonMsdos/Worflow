using Moq;
using Worflow.Dados.Interfaces.Builder;
using Worflow.Models;
using Worflow.Repository;
using Worflow.Services;
using Xunit;

namespace Worflow.Tests.Services;

public class PerfilTests
{
    private PerfilService service;

    public PerfilTests()
    {
        service = new PerfilService(new Mock<IPerfilRepository>().Object);
    }

    [Fact]
    public void BuscarPerfil_GetTodos()
    {
        List<Perfil> perfis = new List<Perfil>();

        perfis.Add(new PerfilGeneratorBuilder().Get());

        var repository = new Mock<IPerfilRepository>();

        repository.Setup(x => x.BuscarTodos()).Returns(perfis);

        service = new PerfilService(repository.Object);

        var result = service.BuscarPerfil();

        Assert.True(result.Count > 0);
    }

    [Fact]
    public void BuscarPorId_EnviandoZero()
    {
        var exception = Assert.Throws<Exception>(() => service.BuscarPorId(0));

        Assert.Equal("Erro ao buscar perfil por id: Detalhes: Id não pode ser zerado", exception.Message);
    }

    [Fact]
    public void BuscarPorId_EnviandoIdValido()
    {
        Perfil perfil = new PerfilGeneratorBuilder().Get();

        var repository = new Mock<IPerfilRepository>();

        repository.Setup(x => x.BuscarPorId(perfil.Id)).Returns(perfil);

        service = new PerfilService(repository.Object);

        var result = service.BuscarPorId(perfil.Id);

        Assert.True(result.Id > 0);
    }

    [Fact]
    public void Pesquisar_PesquisandoValido()
    {
        List<Perfil> perfis = new List<Perfil>();

        perfis.Add(new PerfilGeneratorBuilder().Get());

        var repository = new Mock<IPerfilRepository>();

        repository.Setup(x => x.Pesquisar(perfis.First().Descricao)).Returns(perfis);

        service = new PerfilService(repository.Object);

        var result = service.Pesquisar(perfis.First().Descricao);

        Assert.True(result.Count > 0);
    }

    [Fact]
    public void Incluir_AddPerfilValido()
    {
        Assert.True(service.Incluir(new PerfilGeneratorBuilder().Post()));
    }

    [Fact]
    public void Alterar_AlterandoPerfilValido()
    {
        Assert.True(service.Alterar(new PerfilGeneratorBuilder().Put()));
    }

    [Fact]
    public void Excluir_EnviandoIdZero()
    {
        Perfil perfil = new PerfilGeneratorBuilder().DeleteNotValid();

        var exception = Assert.Throws<Exception>(() => service.Excluir(perfil));

        Assert.Equal("Erro ao excluir perfil: Detalhes: Id não pode ser zerado", exception.Message);
    }

    [Fact]
    public void Excluir_ExcluindoUsuarioValido()
    {
        Perfil perfil = new PerfilGeneratorBuilder().DeleteValid();       

        Assert.True(service.Excluir(perfil));
    }
}
