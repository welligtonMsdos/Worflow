using Moq;
using Worflow.Dados.Interfaces.Builder;
using Worflow.Models;
using Worflow.Repository;
using Worflow.Services;
using Worflow.Tests.Interfaces;
using Xunit;

namespace Worflow.Tests.Business;

public class SeguradoraBusiness : ITests
{
    private SeguradoraService service;

    public SeguradoraBusiness()
    {
        service = new SeguradoraService(new Mock<ISeguradoraRepository>().Object);
    }
    public bool Alterar() => service.Alterar(new SeguradoraGeneratorBuilder().Put());

    public bool BuscarIdValido()
    {
        var entidade = new SeguradoraGeneratorBuilder().Get();

        var repository = new Mock<ISeguradoraRepository>();

        repository.Setup(x => x.BuscarPorId(entidade.Id)).Returns(entidade);

        service = new SeguradoraService(repository.Object);

        return service.BuscarPorId(entidade.Id).Id > 0;
    }

    public string BuscarIdZerado() => Assert.Throws<Exception>(() => service.BuscarPorId(0)).Message;

    public bool ExcluirIdValido() => service.Excluir(new SeguradoraGeneratorBuilder().DeleteValid());

    public string ExcluirIdZerado() => Assert.Throws<Exception>(() => service.Excluir(new SeguradoraGeneratorBuilder().DeleteNotValid())).Message;

    public int GetTodos()
    {
        List<Seguradora> entidade = new List<Seguradora>();

        entidade.Add(new SeguradoraGeneratorBuilder().Get());

        var repository = new Mock<ISeguradoraRepository>();

        repository.Setup(x => x.BuscarTodos()).Returns(entidade);

        service = new SeguradoraService(repository.Object);

        return service.BuscarTodos().Count;
    }

    public bool Incluir() => service.Incluir(new SeguradoraGeneratorBuilder().Post());
}
