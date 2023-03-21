using System.ComponentModel.DataAnnotations;

namespace WFAPI.Dtos.Seguradora;

public class CreateSeguradoraDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome é obrigatório")]   
    [MinLength(4, ErrorMessage = "Nome necessita de 4 caracteres.")]

    public string Nome { get; set; }

    public bool Ativo { get; set; }
}
