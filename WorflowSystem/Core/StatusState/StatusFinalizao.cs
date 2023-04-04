using System.Collections.Generic;
using Worflow.Enum;

namespace Worflow.Core.StatusState;

public class StatusFinalizao : IStatusLead
{
    public int Porcentagem() => 100;

    public List<int> ProximoStatus()
    {
        List<int> statusId = new List<int>();           
        statusId.Add((int)EStatusLead.Finalizado);

        return statusId;
    }
}
