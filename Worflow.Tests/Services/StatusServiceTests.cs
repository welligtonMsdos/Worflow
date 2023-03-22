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

public class StatusServiceTests
{
    private readonly ITests _tests;
    private StatusService service;
    private string buscar = Mensagens.StatusEditarIdZerado;
    private string excluir = Mensagens.StatusExcluirIdZerado;

    public StatusServiceTests()
    {
        _tests = new StatusBusiness();
        service = new StatusService(new Mock<IStatusRepository>().Object);
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
        List<Status> status = new List<Status>();

        status.Add(new StatusGeneratorBuilder().Get());

        var repository = new Mock<IStatusRepository>();

        repository.Setup(x => x.Pesquisar(status.First().Descricao)).Returns(status);

        service = new StatusService(repository.Object);

        var result = service.Pesquisar(status.First().Descricao);

        Assert.True(result.Count > 0);
    }
}
