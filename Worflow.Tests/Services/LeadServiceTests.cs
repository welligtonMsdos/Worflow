using Moq;
using Worflow.Dados.Interfaces.Builder;
using Worflow.Models;
using Worflow.Repository;
using Worflow.Services;
using Worflow.Tests.Business;
using Worflow.Tests.Enum;
using Worflow.Tests.Interfaces;
using Xunit;

namespace Worflow.Tests.Services
{
    public class LeadServiceTests
    {
        private readonly ITests _tests;
        private LeadService service;
        public LeadServiceTests()
        {
            _tests = new LeadBusiness();
            service = new LeadService(new Mock<ILeadRepository>().Object);
        }

        [Fact]
        public void BuscarLead_GetTodos() => Assert.True(_tests.GetTodos() > 0);

        [Fact]
        public void BuscarPorId_EnviandoZero() => Assert.Equal(Mensagens.LeadEditarIdZerado, _tests.BuscarIdZerado());

        [Fact]
        public void BuscarPorId_EnviandoIdValido() => Assert.True(_tests.BuscarIdValido());

        [Fact]
        public void Incluir_AddLeadValido() => Assert.True(_tests.Incluir());

        [Fact]
        public void Excluir_EnviandoIdZero() => Assert.Equal(Mensagens.LeadExcluirIdZerado, _tests.ExcluirIdZerado());

        [Fact]
        public void Excluir_ExcluindoIdValido() => Assert.True(_tests.ExcluirIdValido());

        [Fact]
        public void Incluir_AddProdutoNull() => Assert.Equal(Mensagens.LeadInclurirErro, Assert.Throws<Exception>(() => service.Incluir(new LeadGeneratorBuilder().Post(), null)).Message);
        
        [Fact]
        public void Alterar_IdNaoEncontrado() => Assert.Equal(Mensagens.Reference, Assert.Throws<NullReferenceException>(() => service.Alterar(new LeadGeneratorBuilder().Put())).Message);

        [Fact]
        public void Pesquisar_EnviandoValueNull()
        {
            List<Lead> leads = new List<Lead>();

            leads.Add(new LeadGeneratorBuilder().Get());

            string[] produtos = new string[1];
            produtos[0] = "1";

            var repository = new Mock<ILeadRepository>();

            repository.Setup(x => x.Pesquisar(null)).Returns(leads);

            service = new LeadService(repository.Object);

            var result = service.Pesquisar(null);

            Assert.True(result.Count > 0);
        }

        [Fact]
        public void Pesquisar_EnviandoValueVazio()
        {
            List<Lead> leads = new List<Lead>();

            leads.Add(new LeadGeneratorBuilder().Get());

            string[] produtos = new string[1];
            produtos[0] = "1";

            var _leadRepository = new Mock<ILeadRepository>();

            _leadRepository.Setup(x => x.Pesquisar("")).Returns(leads);

            service = new LeadService(_leadRepository.Object);

            var result = service.Pesquisar("");

            Assert.True(result.Count > 0);
        }

        [Fact]
        public void Pesquisar_EnviandoValueValido()
        {
            List<Lead> leads = new List<Lead>();

            leads.Add(new LeadGeneratorBuilder().Get());

            string[] produtos = new string[1];
            produtos[0] = "1";

            var _leadRepository = new Mock<ILeadRepository>();

            _leadRepository.Setup(x => x.Pesquisar("a")).Returns(leads);

            service = new LeadService(_leadRepository.Object);

            var result = service.Pesquisar("a");

            Assert.True(result.Count > 0);
        }
    }
}
