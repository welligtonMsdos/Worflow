using Moq;
using Worflow.Dados.Interfaces.Builder;
using Worflow.Models;
using Worflow.Repository;
using Worflow.Services;
using Worflow.Tests.Interfaces;
using Xunit;

namespace Worflow.Tests.Business;

public class ProdutoBusiness: ITests
{
    private ProdutoService service;
    public ProdutoBusiness()
    {
        service = new ProdutoService(new Mock<IProdutoRepository>().Object);
    }

    public bool Alterar() => service.Alterar(new ProdutoGeneratorBuilder().Put());

    public bool BuscarIdValido()
    {
        var entidade = new ProdutoGeneratorBuilder().Get();

        var repository = new Mock<IProdutoRepository>();

        repository.Setup(x => x.BuscarPorId(entidade.Id)).Returns(entidade);

        service = new ProdutoService(repository.Object);

        return service.BuscarPorId(entidade.Id).Id > 0;
    }

    public string BuscarIdZerado() => Assert.Throws<Exception>(() => service.BuscarPorId(0)).Message;

    public bool ExcluirIdValido() => service.Excluir(new ProdutoGeneratorBuilder().DeleteValid());

    public string ExcluirIdZerado() => Assert.Throws<Exception>(() => service.Excluir(new ProdutoGeneratorBuilder().DeleteNotValid())).Message;

    public bool Incluir() => service.Incluir(new ProdutoGeneratorBuilder().Post());

    public int GetTodos()
    {
        var entidade = new List<Produto>();

        entidade.Add(new ProdutoGeneratorBuilder().Get());

        var repository = new Mock<IProdutoRepository>();

        repository.Setup(x => x.BuscarTodos()).Returns(entidade);

        service = new ProdutoService(repository.Object);

        return service.BuscarProdutos().Count;
    }
}
