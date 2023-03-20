using Moq;
using Worflow.Dados.Interfaces.Builder;
using Worflow.Models;
using Worflow.Repository;
using Worflow.Services;
using Xunit;

namespace Worflow.Tests.Services;

public class StatusServiceTests
{

    private StatusService service;

    public StatusServiceTests()
    {
        service = new StatusService(new Mock<IStatusRepository>().Object);
    }

    [Fact]
    [Trait("Get", "Pesquisando pela descrição")]
    public void Pesquisar_PesquisandoValido()
    {
        List<Status> status = new List<Status>();

        status.Add(new StatusGeneratorBuilder().Get());

        var repository = new Mock<IStatusRepository>();

        repository.Setup(x => x.Pesquisar(status.First().Descricao)).Returns(status);

        service = new StatusService(repository.Object);

        var result = service.Pesquisar(status.First().Descricao);

        Assert.True(result.Count > 0);
    }

    [Fact]
    [Trait("Get","Pesquisando passando o id zerado")]
    public void BuscarPorId_EnviandoZero()
    {
        var exception = Assert.Throws<Exception>(() => service.BuscarPorId(0));

        Assert.Equal("Erro ao buscar status por id: Detalhes: Id não pode ser zerado", exception.Message);
    }

    [Fact]
    [Trait("Get","Pesquisando passado o id válido")]
    public void BuscarPorId_EnviandoIdValido()
    {
        Status status = new StatusGeneratorBuilder().Get();

        var repository = new Mock<IStatusRepository>();

        repository.Setup(x => x.BuscarPorId(status.Id)).Returns(status);

        service = new StatusService(repository.Object);

        var result = service.BuscarPorId(status.Id);

        Assert.True(result.Id > 0);
    }

    [Fact]
    [Trait("Post","Adicionando status válido")]
    public void Incluir_AddStatusValido()
    {
        Assert.True(service.Incluir(new StatusGeneratorBuilder().Post()));
    }

    [Fact]
    [Trait("Put","Alterando status válido")]
    public void Alterar_AlterandoStatusValido()
    {
        Assert.True(service.Alterar(new StatusGeneratorBuilder().Put()));
    }

    [Fact]
    [Trait("Delete", "Excluindo status id zerado")]
    public void Excluir_EnviandoIdZero()
    {
        Status status = new StatusGeneratorBuilder().DeleteNotValid();

        var exception = Assert.Throws<Exception>(() => service.Excluir(status));

        Assert.Equal("Erro ao excluir status: Detalhes: Id não pode ser zerado", exception.Message);
    }

    [Fact]
    [Trait("Delete","Excluindo status id válido")]
    public void Excluir_ExcluindoStatusValido()
    {
        Status status = new StatusGeneratorBuilder().DeleteValid();

        Assert.True(service.Excluir(status));
    }
}
