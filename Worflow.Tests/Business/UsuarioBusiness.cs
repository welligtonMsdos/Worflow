using Moq;
using Worflow.Dados.Interfaces.Builder;
using Worflow.Models;
using Worflow.Repository;
using Worflow.Services;
using Worflow.Tests.Interfaces;
using Xunit;

namespace Worflow.Tests.Business;

public class UsuarioBusiness : ITests, ITestsPesquisar
{
    private UsuarioService service;
    public UsuarioBusiness()
    {
        service = new UsuarioService(new Mock<IUsuarioRepository>().Object);
    }
    public bool Alterar() => service.Alterar(new UsuarioGeneratorBuilder().Put());

    public bool BuscarIdValido()
    {
        var entidade = new UsuarioGeneratorBuilder().Get();

        var repository = new Mock<IUsuarioRepository>();

        repository.Setup(x => x.BuscarPorId(entidade.Id)).Returns(entidade);

        service = new UsuarioService(repository.Object);

        return service.BuscarPorId(entidade.Id).Id > 0;
    }

    public string BuscarIdZerado() => Assert.Throws<Exception>(() => service.BuscarPorId(0)).Message;

    public bool ExcluirIdValido() => service.Excluir(new UsuarioGeneratorBuilder().DeleteValid());

    public string ExcluirIdZerado() => Assert.Throws<Exception>(() => service.Excluir(new UsuarioGeneratorBuilder().DeleteNotValid())).Message;

    public bool Incluir() => service.Incluir(new UsuarioGeneratorBuilder().Post());

    public int GetTodos()
    {
        var entidade = new List<Usuario>();

        entidade.Add(new UsuarioGeneratorBuilder().Get());

        var repository = new Mock<IUsuarioRepository>();

        repository.Setup(x => x.BuscarTodos()).Returns(entidade);

        service = new UsuarioService(repository.Object);

        return service.BuscarUsuarios().Count;
    }

    public bool PesquisarValido()
    {
        var entidade = new List<Usuario>();

        entidade.Add(new UsuarioGeneratorBuilder().Get());

        var repository = new Mock<IUsuarioRepository>();

        repository.Setup(x => x.Pesquisar(entidade.First().Nome)).Returns(entidade);

        service = new UsuarioService(repository.Object);

        return service.Pesquisar(entidade.First().Nome).Count > 0;
    }
}
