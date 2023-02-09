using System.Collections.Generic;
using Worflow.Models;

namespace Worflow.Dados.Interfaces
{
    public interface IStatusService
    {
        ICollection<Status> BuscarStatus(Lead lead);
    }
}
