using System.ComponentModel.DataAnnotations;

namespace WFAPI.Dtos.Status;

public class UpdateStatusDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Descrição é obrigatória")]
    public string Descricao { get; set; }

    public bool Ativo { get; set; }
}
