using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worflow.Dados.Interfaces.Builder;
using Worflow.Enum;
using Worflow.Models;
using Worflow.Repository;
using Worflow.Services;
using Worflow.Tests.Business;
using Worflow.Tests.Interfaces;
using Xunit;

namespace Worflow.Tests.Services;

public class EnderecoServiceTests
{
    private readonly ITests _tests;
    private EnderecoService service;
    private const string BUSCAR = Mensagens.ENDERECO_BUSCAR_ID_ZERADO;
    private const string EXCLUIR = Mensagens.ENDERECO_EXCLUIR_ID_ZERADO;

    public EnderecoServiceTests()
    {
        _tests = new EnderecoBusiness();
        service = new EnderecoService(new Mock<IEnderecoRepository>().Object);
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
        var entidade = new List<Endereco>();

        entidade.Add(new EnderecoGeneratorBuilder().Get());

        var repository = new Mock<IEnderecoRepository>();

        repository.Setup(x => x.Pesquisar(entidade.First().Logadouro)).Returns(entidade);

        service = new EnderecoService(repository.Object);

        var result = service.Pesquisar(entidade.First().Logadouro);

        Assert.True(result.Count > 0);
    }
}
