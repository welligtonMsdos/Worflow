using Moq;
using Worflow.Dados.Builder;
using Worflow.Models;
using Worflow.Repository;
using Worflow.Services;
using Worflow.Tests.Interfaces;
using Xunit;

namespace Worflow.Tests.Business;

public class SegmentoBusiness: ITests
{
    private SegmentoService service;
    public SegmentoBusiness()
    {
        service = new SegmentoService(new Mock<ISegmentoRepository>().Object);
    }

    public bool Alterar() => service.Alterar(new SegmentoGeneratorBuilder().Put());

    public bool BuscarIdValido()
    {
        var entidade = new SegmentoGeneratorBuilder().Get();

        var repository = new Mock<ISegmentoRepository>();

        repository.Setup(x => x.BuscarPorId(entidade.Id)).Returns(entidade);

        service = new SegmentoService(repository.Object);

        return service.BuscarPorId(entidade.Id).Id > 0;
    }

    public string BuscarIdZerado() => Assert.Throws<Exception>(() => service.BuscarPorId(0)).Message;

    public bool ExcluirIdValido() => service.Excluir(new SegmentoGeneratorBuilder().DeleteValid());

    public string ExcluirIdZerado() => Assert.Throws<Exception>(() => service.Excluir(new SegmentoGeneratorBuilder().DeleteNotValid())).Message;

    public bool Incluir() => service.Incluir(new SegmentoGeneratorBuilder().Post());

    public int GetTodos()
    {
        var entidade = new List<Segmento>();

        entidade.Add(new SegmentoGeneratorBuilder().Get());

        var repository = new Mock<ISegmentoRepository>();

        repository.Setup(x => x.BuscarTodos()).Returns(entidade);

        service = new SegmentoService(repository.Object);

        return service.BuscarTodos().Count;
    }
}
