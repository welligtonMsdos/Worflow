using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace WFAPI.Dtos.Usuario
{
    public class ReadUsuarioDto
    {
        public int Id { get; set; }       
        public string Nome { get; set; }       
        public string RACF { get; set; }
        public bool Ativo { get; set; }      
        public int PerfilId { get; set; }
        public string PerfilDescricao { get; set; }
    }
}
