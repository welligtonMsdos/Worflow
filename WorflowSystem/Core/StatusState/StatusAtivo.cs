using System.Collections.Generic;
using Worflow.Enum;

namespace Worflow.Core.StatusState;

public class StatusAtivo : IStatusLead
{
    public int Porcentagem() => 10;

    public List<int> ProximoStatus()
    {
        List<int> statusId = new List<int>();
        statusId.Add((int)EStatusLead.EmAndamento);
        statusId.Add((int)EStatusLead.Finalizado);

        return statusId;
    }
}
