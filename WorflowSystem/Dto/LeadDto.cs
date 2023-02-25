using System;

namespace Worflow.Dto
{
    public class LeadDto
    {
        public int Id { get; set; }
        public DateTime DataAgendada { get; set; }
        public string Observacao { get; set; }
        public string Cliente { get; set; }
        public string Produto { get; set; }
        public string Segmento { get; set; }
        public string Status { get; set; }
    }
}
