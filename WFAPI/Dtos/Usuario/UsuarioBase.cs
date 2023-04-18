using System.ComponentModel.DataAnnotations;

namespace WFAPI.Dtos.Usuario;

public class UsuarioBase
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome é obrigatório!")]
    [Display(Name = "Nome", Prompt = "Digite o nome.")]
    [MinLength(3, ErrorMessage = "Nome necessita de 3 caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "RACF é obrigatória!")]
    [Display(Name = "RACF", Prompt = "Digite a RACF.")]
    [MinLength(5, ErrorMessage = "RACF necessita de 5 caracteres.")]
    public string RACF { get; set; }

    public bool Ativo { get; set; }

    [Required(ErrorMessage = "Perfil é obrigatório!")]
    [Range(1, 4, ErrorMessage = "Selecione um perfil")]
    public int PerfilId { get; set; }
}
