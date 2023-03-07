using Moq;
using Worflow.Dados.Interfaces.Builder;
using Worflow.Models;
using Worflow.Repository;
using Worflow.Services;
using Xunit;

namespace Worflow.Tests.Services
{
    public class LeadServiceTests
    {
        private LeadService _leadService;
        public LeadServiceTests()
        {
            _leadService = new LeadService(new Mock<ILeadRepository>().Object);
        }

        [Fact]
        public void BuscarLeads_GetTodos()
        {
            List<Lead> leads = new List<Lead>();
            
            leads.Add(new LeadGeneratorBuilder().LeadGet());

            var _leadRepository = new Mock<ILeadRepository>();

            _leadRepository.Setup(x => x.BuscarTodos()).Returns(leads);

            _leadService = new LeadService(_leadRepository.Object);

            var result = _leadService.BuscarLeads();

            Assert.True(result.Count > 0);
        }

        [Fact]
        public void BuscarPorId_EnviandoIdZero()
        {
            var exception = Assert.Throws<Exception>(() => _leadService.BuscarPorId(0));

            Assert.Equal("Erro ao buscar Lead por id: Detalhes: Id não pode ser zerado", exception.Message);
        }

        [Fact]
        public void BuscarPorId_EnviandoIdValido()
        {
            Lead lead = new LeadGeneratorBuilder().LeadPut(1);

            var _leadRepository = new Mock<ILeadRepository>();

            _leadRepository.Setup(x => x.BuscarPorId(lead.Id)).Returns(lead);

            _leadService = new LeadService(_leadRepository.Object);

            var result = _leadService.BuscarPorId(lead.Id);

            Assert.True(result.Id > 0);
        }

        [Fact]
        public void Incluir_AddLeadValido()
        {
            Lead lead = new LeadGeneratorBuilder().LeadPost();

            string[] produtos = new string[1];
            produtos[0] = "1";

            var result = _leadService.Incluir(lead,produtos);

            Assert.True(result);
        }

        [Fact]
        public void Incluir_AddProdutoNull()
        {
            Lead lead = new LeadGeneratorBuilder().LeadPost();         

            var exception = Assert.Throws<Exception>(() => _leadService.Incluir(lead,null));

            Assert.Equal("Erro ao incluir Lead", exception.Message);           
        }

        [Fact]
        public void Excluir_EnviandoIdZero()
        {
            Lead lead = new LeadGeneratorBuilder().LeadPost();

            lead.Id = 0;

            var exception = Assert.Throws<Exception>(() => _leadService.Excluir(lead));

            Assert.Equal("Erro ao excluir Lead: Detalhes: Id não pode ser zerado", exception.Message);
        }

        [Fact]
        public void Alterar_IdNaoEncontrado()
        {
            Lead lead = new LeadGeneratorBuilder().LeadPut();          

            var exception = Assert.Throws<NullReferenceException>(() => _leadService.Alterar(lead));

            Assert.Equal("Object reference not set to an instance of an object.", exception.Message);
        }

        [Fact]
        public void Alterar_LeadValido()
        {
            Lead lead = new LeadGeneratorBuilder().LeadPut(1);

            var _leadRepository = new Mock<ILeadRepository>();

            _leadRepository.Setup(x => x.BuscarPorId(lead.Id)).Returns(lead);

            _leadService = new LeadService(_leadRepository.Object);

            var result = _leadService.Alterar(lead);

            Assert.True(result);
        }

        [Fact]
        public void Pesquisar_EnviandoValueNull()
        {
            List<Lead> leads = new List<Lead>();

            leads.Add(new LeadGeneratorBuilder().LeadGet());

            string[] produtos = new string[1];
            produtos[0] = "1";

            var _leadRepository = new Mock<ILeadRepository>();            

            _leadRepository.Setup(x => x.Pesquisar(null)).Returns(leads);

            _leadService = new LeadService(_leadRepository.Object);

            var result = _leadService.Pesquisar(null);

            Assert.True(result.Count > 0);
        }

        [Fact]
        public void Pesquisar_EnviandoValueVazio()
        {
            List<Lead> leads = new List<Lead>();

            leads.Add(new LeadGeneratorBuilder().LeadGet());

            string[] produtos = new string[1];
            produtos[0] = "1";

            var _leadRepository = new Mock<ILeadRepository>();

            _leadRepository.Setup(x => x.Pesquisar("")).Returns(leads);

            _leadService = new LeadService(_leadRepository.Object);

            var result = _leadService.Pesquisar("");

            Assert.True(result.Count > 0);
        }

        [Fact]
        public void Pesquisar_EnviandoValueValido()
        {
            List<Lead> leads = new List<Lead>();

            leads.Add(new LeadGeneratorBuilder().LeadGet());

            string[] produtos = new string[1];
            produtos[0] = "1";

            var _leadRepository = new Mock<ILeadRepository>();

            _leadRepository.Setup(x => x.Pesquisar("a")).Returns(leads);

            _leadService = new LeadService(_leadRepository.Object);

            var result = _leadService.Pesquisar("a");

            Assert.True(result.Count > 0);
        }       
    }
}
