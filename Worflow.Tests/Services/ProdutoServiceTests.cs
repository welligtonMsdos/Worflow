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

public class ProdutoServiceTests
{
    private readonly ITests _tests;
    private ProdutoService service;
    private string buscar = Mensagens.ProdutoEditarIdZerado;
    private string excluir = Mensagens.ProdutoExcluirIdZerado;

    public ProdutoServiceTests()
    {
        _tests = new ProdutoBusiness();
        service = new ProdutoService(new Mock<IProdutoRepository>().Object);
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
        var entidade = new List<Produto>();

        entidade.Add(new ProdutoGeneratorBuilder().Get());

        var repository = new Mock<IProdutoRepository>();

        repository.Setup(x => x.Pesquisar(entidade.First().Descricao)).Returns(entidade);

        service = new ProdutoService(repository.Object);

        var result = service.Pesquisar(entidade.First().Descricao);

        Assert.True(result.Count > 0);
    }
}
