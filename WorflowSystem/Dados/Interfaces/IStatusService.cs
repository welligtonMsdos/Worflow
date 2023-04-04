using System.Collections.Generic;
using Worflow.Models;

namespace Worflow.Dados.Interfaces;

public interface IStatusService: IServiceDefault<Status>
{
    ICollection<Status> BuscarStatus(Lead lead);   
    int BuscarPorcentagem(Lead lead);
}
