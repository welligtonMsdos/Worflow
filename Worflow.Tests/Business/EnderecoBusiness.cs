using Moq;
using Worflow.Dados.Interfaces.Builder;
using Worflow.Models;
using Worflow.Repository;
using Worflow.Services;
using Worflow.Tests.Interfaces;
using Xunit;

namespace Worflow.Tests.Business;

internal class EnderecoBusiness : ITests
{
    private EnderecoService service;
    private EnderecoGeneratorBuilder builder;

    public EnderecoBusiness()
    {
        service = new EnderecoService(new Mock<IEnderecoRepository>().Object);
        builder = new EnderecoGeneratorBuilder();        
    }

    public bool Alterar() => service.Alterar(builder.Put());

    public bool BuscarIdValido()
    {
        var entidade = builder.Get();

        var repository = new Mock<IEnderecoRepository>();

        repository.Setup(x => x.BuscarPorId(entidade.Id)).Returns(entidade);

        service = new EnderecoService(repository.Object);

        return service.BuscarPorId(entidade.Id).Id > 0;
    }

    public string BuscarIdZerado() => Assert.Throws<Exception>(() => service.BuscarPorId(0)).Message;

    public bool ExcluirIdValido() => service.Excluir(builder.DeleteValid());

    public string ExcluirIdZerado() => Assert.Throws<Exception>(() => service.Excluir(builder.DeleteNotValid())).Message;

    public int GetTodos()
    {
        List<Endereco> entidade = new List<Endereco>();

        entidade.Add(builder.Get());

        var repository = new Mock<IEnderecoRepository>();

        repository.Setup(x => x.BuscarTodos()).Returns(entidade);

        service = new EnderecoService(repository.Object);

        return service.BuscarTodos().Count;
    }

    public bool Incluir() => service.Incluir(builder.Post());
}
