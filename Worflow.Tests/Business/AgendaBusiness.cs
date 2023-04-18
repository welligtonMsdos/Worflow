using Moq;
using Worflow.Dados.Builder;
using Worflow.Models;
using Worflow.Repository;
using Worflow.Services;
using Worflow.Tests.Interfaces;
using Xunit;

namespace Worflow.Tests.Business;

public class AgendaBusiness : ITests
{
    private AgendaService service;

    public AgendaBusiness()
    {
        service = new AgendaService(new Mock<IAgendaRepository>().Object);
    }
    public bool Alterar() => service.Alterar(new AgendaGeneratorBuilder().Put());

    public bool BuscarIdValido()
    {
        var entidade = new AgendaGeneratorBuilder().Get();

        var repository = new Mock<IAgendaRepository>();

        repository.Setup(x => x.BuscarPorId(entidade.Id)).Returns(entidade);

        service = new AgendaService(repository.Object);

        return service.BuscarPorId(entidade.Id).Id > 0;
    }

    public string BuscarIdZerado() => Assert.Throws<Exception>(() => service.BuscarPorId(0)).Message;

    public bool ExcluirIdValido() => service.Excluir(new AgendaGeneratorBuilder().DeleteValid());

    public string ExcluirIdZerado() => Assert.Throws<Exception>(() => service.Excluir(new AgendaGeneratorBuilder().DeleteNotValid())).Message;

    public int GetTodos()
    {
        List<Agenda> agendas = new List<Agenda>();

        agendas.Add(new AgendaGeneratorBuilder().Get());

        var repository = new Mock<IAgendaRepository>();

        repository.Setup(x => x.BuscarTodos()).Returns(agendas);

        service = new AgendaService(repository.Object);

        return service.BuscarTodos().Count;
    }

    public bool Incluir() => service.Incluir(new AgendaGeneratorBuilder().Post());
}
