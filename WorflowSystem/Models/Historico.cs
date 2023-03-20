using System.ComponentModel.DataAnnotations.Schema;

namespace Worflow.Models
{
    public class Historico
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public string Mensagem { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }       
        public int LeadId { get; set; }
        public Lead Lead { get; set; }
    }
}
