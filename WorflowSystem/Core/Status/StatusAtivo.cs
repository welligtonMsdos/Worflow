using System.Collections.Generic;
using Worflow.Enum;

namespace Worflow.Core.Status
{
    public class StatusAtivo : IStatusLead
    {
        public bool ModoStatus()
        {
            return true;
        }

        public List<int> ProximoStatus()
        {
            List<int> statusId = new List<int>();
            statusId.Add((int)EStatusLead.EmAndamento);
            statusId.Add((int)EStatusLead.Finalizado);

            return statusId;
        }
    }
}
