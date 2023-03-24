using Moq;
using Worflow.Dados.Interfaces.Builder;
using Worflow.Models;
using Worflow.Repository;
using Worflow.Services;
using Worflow.Tests.Interfaces;
using Xunit;

namespace Worflow.Tests.Bussines;

public class CotacaoBusiness : ITests
{
    private CotacaoService service;

    public CotacaoBusiness()
    {
        service = new CotacaoService(new Mock<ICotacaoRepository>().Object);
    }

    public bool Alterar() => service.Alterar(new CotacaoGeneratorBuilder().Put());    

    public string BuscarIdZerado() => Assert.Throws<Exception>(() => service.BuscarPorId(0)).Message;

    public bool ExcluirIdValido() => service.Excluir(new CotacaoGeneratorBuilder().DeleteValid());

    public string ExcluirIdZerado() => Assert.Throws<Exception>(() => service.Excluir(new CotacaoGeneratorBuilder().DeleteNotValid())).Message;

    public bool Incluir() => service.Incluir(new CotacaoGeneratorBuilder().Post());

    public int GetTodos()
    {
        List<Cotacao> cotacoes = new List<Cotacao>();

        cotacoes.Add(new CotacaoGeneratorBuilder().Get());

        var _cotacaoRepository = new Mock<ICotacaoRepository>();

        _cotacaoRepository.Setup(x => x.BuscarTodos()).Returns(cotacoes);

        service = new CotacaoService(_cotacaoRepository.Object);

        return service.BuscarTodos().Count;        
    }

    public bool BuscarIdValido()
    {
        Cotacao cotacao = new CotacaoGeneratorBuilder().Get();

        var repository = new Mock<ICotacaoRepository>();

        repository.Setup(x => x.BuscarPorId(cotacao.Id)).Returns(cotacao);

        service = new CotacaoService(repository.Object);

        return service.BuscarPorId(cotacao.Id).Id > 0;        
    }
}
