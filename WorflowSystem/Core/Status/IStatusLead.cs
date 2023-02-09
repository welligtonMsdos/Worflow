using System.Collections.Generic;

namespace Worflow.Core.Status
{
    public interface IStatusLead
    {
        List<int> ProximoStatus();
        bool ModoStatus();
    }
}
