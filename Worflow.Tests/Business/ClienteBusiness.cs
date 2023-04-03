using Moq;
using Worflow.Dados.Builder;
using Worflow.Models;
using Worflow.Repository;
using Worflow.Services;
using Worflow.Tests.Interfaces;
using Xunit;

namespace Worflow.Tests.Business;

public class ClienteBusiness : ITests
{
    private ClienteService service;
    private ClienteGeneratorBuilder builder;

    public ClienteBusiness()
    {
        service = new ClienteService(new Mock<IClienteRepository>().Object);
        builder = new ClienteGeneratorBuilder();
    }

    public bool Alterar() => service.Alterar(builder.Put());

    public bool BuscarIdValido()
    {
        var entidade = builder.Get();

        var repository = new Mock<IClienteRepository>();

        repository.Setup(x => x.BuscarPorId(entidade.Id)).Returns(entidade);

        service = new ClienteService(repository.Object);

        return service.BuscarPorId(entidade.Id).Id > 0;
    }

    public string BuscarIdZerado() => Assert.Throws<Exception>(() => service.BuscarPorId(0)).Message;

    public bool ExcluirIdValido() => service.Excluir(builder.DeleteValid());

    public string ExcluirIdZerado() => Assert.Throws<Exception>(() => service.Excluir(builder.DeleteNotValid())).Message;

    public int GetTodos()
    {
        List<Cliente> entidade = new List<Cliente>();

        entidade.Add(builder.Get());

        var repository = new Mock<IClienteRepository>();

        repository.Setup(x => x.BuscarTodos()).Returns(entidade);

        service = new ClienteService(repository.Object);

        return service.BuscarTodos().Count;
    }

    public bool Incluir() => service.Incluir(builder.Post());
}
