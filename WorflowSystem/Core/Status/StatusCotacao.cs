using System.Collections.Generic;
using Worflow.Enum;

namespace Worflow.Core.Status
{
    public class StatusCotacao : IStatusLead
    {
        public bool ModoStatus()
        {
            return true;
        }

        public List<int> ProximoStatus()
        {
            List<int> statusId = new List<int>();
            statusId.Add((int)EStatusLead.Implantacao);
            statusId.Add((int)EStatusLead.Finalizado);

            return statusId;
        }
    }
}
