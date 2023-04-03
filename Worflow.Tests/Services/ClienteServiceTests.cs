using Moq;
using Worflow.Dados.Builder;
using Worflow.Enum;
using Worflow.Models;
using Worflow.Repository;
using Worflow.Services;
using Worflow.Tests.Business;
using Worflow.Tests.Interfaces;
using Xunit;

namespace Worflow.Tests.Services;

public class ClienteServiceTests
{
    private readonly ITests _tests;
    private ClienteService service;
    private const string BUSCAR = Mensagens.CLIENTE_BUSCAR_ID_ZERADO;
    private const string EXCLUIR = Mensagens.CLIENTE_EXCLUIR_ID_ZERADO;

    public ClienteServiceTests()
    {
        _tests = new ClienteBusiness();
        service = new ClienteService(new Mock<IClienteRepository>().Object);
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
    public void Pesquisar_PesquisandoValido()
    {
        var entidade = new List<Cliente>();

        entidade.Add(new ClienteGeneratorBuilder().Get());

        var repository = new Mock<IClienteRepository>();

        repository.Setup(x => x.Pesquisar(entidade.First().Fantasia)).Returns(entidade);

        service = new ClienteService(repository.Object);

        var result = service.Pesquisar(entidade.First().Fantasia);

        Assert.True(result.Count > 0);
    }
}
