using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worflow.Dados.EFCore;
using Worflow.Dados.Interfaces;
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
            
            leads.Add(new LeadGeneratorBuilder().LeadNew());

            var _leadRepository = new Mock<ILeadRepository>();

            _leadRepository.Setup(x => x.BuscarTodos()).Returns(leads);

            _leadService = new LeadService(_leadRepository.Object);

            var result = _leadService.BuscarLeads();

            Assert.True(result.Count > 0);
        }
    }
}
