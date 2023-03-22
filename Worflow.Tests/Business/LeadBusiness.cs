using Moq;
using Worflow.Dados.Interfaces.Builder;
using Worflow.Models;
using Worflow.Repository;
using Worflow.Services;
using Worflow.Tests.Interfaces;
using Xunit;

namespace Worflow.Tests.Business
{
    public class LeadBusiness : ITests
    {
        private LeadService service;
        public LeadBusiness()
        {
            service = new LeadService(new Mock<ILeadRepository>().Object);
        }

        public bool Alterar()         
        {
            var lead = new LeadGeneratorBuilder().Put();

            var repository = new Mock<ILeadRepository>();

            repository.Setup(x => x.Alterar(lead));            

            service = new LeadService(repository.Object);            

            return service.Alterar(new LeadGeneratorBuilder().Put());         
        }

        public bool BuscarIdValido()
        {
            Lead lead = new LeadGeneratorBuilder().Put();

            var repository = new Mock<ILeadRepository>();

            repository.Setup(x => x.BuscarPorId(lead.Id)).Returns(lead);

            service = new LeadService(repository.Object);

            return service.BuscarPorId(lead.Id).Id > 0;
        }

        public string BuscarIdZerado() => Assert.Throws<Exception>(() => service.BuscarPorId(0)).Message;

        public bool ExcluirIdValido() => service.Excluir(new LeadGeneratorBuilder().DeleteValid());

        public string ExcluirIdZerado() => Assert.Throws<Exception>(() => service.Excluir(new LeadGeneratorBuilder().DeleteNotValid())).Message;

        public int GetTodos()
        {
            List<Lead> leads = new List<Lead>();

            leads.Add(new LeadGeneratorBuilder().Get());

            var repository = new Mock<ILeadRepository>();

            repository.Setup(x => x.BuscarTodos()).Returns(leads);

            service = new LeadService(repository.Object);

            return service.BuscarLeads().Count;
        }

        public bool Incluir()
        {
            Lead lead = new LeadGeneratorBuilder().Post();

            string[] produtos = new string[1];
            produtos[0] = "1";

            return service.Incluir(lead, produtos);
        }          
    }
}
