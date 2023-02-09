using System.Collections.Generic;
using Worflow.Enum;

namespace Worflow.Core.Status
{
    public class StatusFinalizao : IStatusLead
    {
        public bool ModoStatus()
        {
            return false;
        }

        public List<int> ProximoStatus()
        {
            List<int> statusId = new List<int>();           
            statusId.Add((int)EStatusLead.Finalizado);

            return statusId;
        }
    }
}
