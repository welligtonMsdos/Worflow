using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Worflow.Models.Dtos
{
    public class LeadDto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }      
        public int ClienteId { get; set; }
        public string RazaoSocial { get; set; }
        public string Fantasia { get; set; }
        public int ProdutoId { get; set; }
        public string ProdutoDescricao { get; set; }
        public string Segmento { get; set; }
        public int StatusId { get; set; }  
        public DateTime DataAgendada { get; set; }
        public string Observacao { get; set; }
    }
}
