using Moq;
using Worflow.Dados.Builder;
using Worflow.Models;
using Worflow.Repository;
using Worflow.Services;
using Worflow.Tests.Interfaces;
using Xunit;

namespace Worflow.Tests.Business;

public class PerfilBusiness : ITests
{
    private PerfilService service;
    public PerfilBusiness()
    {
        service = new PerfilService(new Mock<IPerfilRepository>().Object);
    }
    public bool Alterar() => service.Alterar(new PerfilGeneratorBuilder().Put());

    public bool BuscarIdValido()
    {
        var entidade = new PerfilGeneratorBuilder().Get();

        var repository = new Mock<IPerfilRepository>();

        repository.Setup(x => x.BuscarPorId(entidade.Id)).Returns(entidade);

        service = new PerfilService(repository.Object);

        return service.BuscarPorId(entidade.Id).Id > 0;
    }

    public string BuscarIdZerado() => Assert.Throws<Exception>(() => service.BuscarPorId(0)).Message;

    public bool ExcluirIdValido() => service.Excluir(new PerfilGeneratorBuilder().DeleteValid());

    public string ExcluirIdZerado() => Assert.Throws<Exception>(() => service.Excluir(new PerfilGeneratorBuilder().DeleteNotValid())).Message;

    public int GetTodos()
    {
        List<Perfil> perfis = new List<Perfil>();

        perfis.Add(new PerfilGeneratorBuilder().Get());

        var repository = new Mock<IPerfilRepository>();

        repository.Setup(x => x.BuscarTodos()).Returns(perfis);

        service = new PerfilService(repository.Object);

        return service.BuscarTodos().Count;
    }

    public bool Incluir() => service.Incluir(new PerfilGeneratorBuilder().Post());
}
