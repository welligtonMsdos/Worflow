using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worflow.Repository;
using Worflow.Services;

namespace Worflow.Tests.Services
{
    public class LeadServiceTests
    {
        private LeadService _leadService;
        public LeadServiceTests()
        {
            _leadService = new LeadService(new Mock<ILeadRepository>().Object);
        }
    }
}
