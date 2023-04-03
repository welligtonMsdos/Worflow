using Moq;
using Worflow.Dados.Builder;
using Worflow.Models;
using Worflow.Repository;
using Worflow.Services;
using Worflow.Tests.Interfaces;
using Xunit;

namespace Worflow.Tests.Business;

public class StatusBusiness : ITests
{
    private StatusService service;

    public StatusBusiness()
    {
        service = new StatusService(new Mock<IStatusRepository>().Object);
    }
    public bool Alterar() => service.Alterar(new StatusGeneratorBuilder().Put());

    public bool BuscarIdValido()
    {
        var entidade = new StatusGeneratorBuilder().Get();

        var repository = new Mock<IStatusRepository>();

        repository.Setup(x => x.BuscarPorId(entidade.Id)).Returns(entidade);

        service = new StatusService(repository.Object);

        return service.BuscarPorId(entidade.Id).Id > 0;
    }

    public string BuscarIdZerado() => Assert.Throws<Exception>(() => service.BuscarPorId(0)).Message;

    public bool ExcluirIdValido() => service.Excluir(new StatusGeneratorBuilder().DeleteValid());

    public string ExcluirIdZerado() => Assert.Throws<Exception>(() => service.Excluir(new StatusGeneratorBuilder().DeleteNotValid())).Message;

    public int GetTodos()
    {
        List<Status> status = new List<Status>();

        status.Add(new StatusGeneratorBuilder().Get());

        var repository = new Mock<IStatusRepository>();

        repository.Setup(x => x.BuscarTodos()).Returns(status);

        service = new StatusService(repository.Object);      

        return service.BuscarTodos().Count;
    }

    public bool Incluir() => service.Incluir(new StatusGeneratorBuilder().Post());
}
