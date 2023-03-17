using System.ComponentModel.DataAnnotations;

namespace WFAPI.Dtos.Perfil;

public class UpdatePerfilDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Descrição é obrigatório")]
    [StringLength(20)]
    [MinLength(4, ErrorMessage = "Mínimo de 4 caracteres")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "Ativo é obrigatório")]
    public bool Ativo { get; set; }
}
