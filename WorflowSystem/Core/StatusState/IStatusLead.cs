using System.Collections.Generic;

namespace Worflow.Core.StatusState;

public interface IStatusLead
{
    List<int> ProximoStatus();

    int Porcentagem();
}
