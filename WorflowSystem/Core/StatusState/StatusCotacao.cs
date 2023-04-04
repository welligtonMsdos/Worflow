﻿using System.Collections.Generic;
using Worflow.Enum;

namespace Worflow.Core.StatusState;

public class StatusCotacao : IStatusLead
{
    public int Porcentagem() => 75;

    public List<int> ProximoStatus()
    {
        List<int> statusId = new List<int>();
        statusId.Add((int)EStatusLead.Implantacao);
        statusId.Add((int)EStatusLead.Finalizado);

        return statusId;
    }
}
