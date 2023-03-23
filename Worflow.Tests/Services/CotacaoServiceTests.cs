using Worflow.Enum;
using Worflow.Tests.Bussines;
using Worflow.Tests.Interfaces;
using Xunit;

namespace Worflow.Tests.Services;

public class CotacaoServiceTests
{       
    private readonly ITests _tests;
    private const string BUSCAR = Mensagens.COTACAO_BUSCAR_ID_ZERADO;
    private const string EXCLUIR = Mensagens.COTACAO_EXLUCIR_ID_ZERADO;

    public CotacaoServiceTests()
    {  
        _tests = new CotacaoBusiness();
    }

    [Fact]       
    public void BuscarCotacoes_GetTodos() => Assert.True(_tests.GetTodos() > 0);      

    [Fact]      
    public void BuscarPorId_EnviandoZero() => Assert.Equal(BUSCAR, _tests.BuscarIdZerado());        

    [Fact]       
    public void BuscarPorId_EnviandoIdValido() => Assert.True(_tests.BuscarIdValido());                

    [Fact]       
    public void Incluir_AddCotacaoValida() => Assert.True(_tests.Incluir());        

    [Fact]      
    public void Alterar_AlterandoCotacaoValido() => Assert.True(_tests.Alterar());        

    [Fact]      
    public void Excluir_EnviandoIdZero() => Assert.Equal(EXCLUIR, _tests.ExcluirIdZerado());
    
    [Fact]       
    public void Excluir_ExcluindoIdValido() => Assert.True(_tests.ExcluirIdValido());        
}
