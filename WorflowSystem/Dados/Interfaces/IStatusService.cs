using System.Collections.Generic;
using Worflow.Models;

namespace Worflow.Dados.Interfaces
{
    public interface IStatusService
    {
        ICollection<Status> BuscarStatus(Lead lead);
        ICollection<Status> Pesquisar(string value);
        Status BuscarPorId(int id);
        bool Incluir(Status obj);
        bool Alterar(Status obj);
        bool Excluir(Status obj);
    }
}
