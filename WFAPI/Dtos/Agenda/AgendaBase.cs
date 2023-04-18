using System.ComponentModel.DataAnnotations;

namespace WFAPI.Dtos.Agenda;

public class AgendaBase
{
    public int Id { get; set; }

    [Required(ErrorMessage = "{0} é obrigatória")]    
    public DateTime DataAgendada { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]
    [DataType(DataType.Time)]
    public string Horario { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]
    public int LeadId { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]
    public int UsuarioId { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]
    public string Comentario { get; set; }

    public bool Ativo { get; set; }
}
