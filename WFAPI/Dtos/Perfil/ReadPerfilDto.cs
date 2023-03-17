using System.ComponentModel.DataAnnotations;

namespace WFAPI.Dtos.Perfil;

public class ReadPerfilDto
{
    public int Id { get; set; }  
    public string Descricao { get; set; }
    public bool Ativo { get; set; }
}
