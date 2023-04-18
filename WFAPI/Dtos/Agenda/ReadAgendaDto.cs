namespace WFAPI.Dtos.Agenda;

public class ReadAgendaDto
{
    public int Id { get; set; }
    
    public DateTime DataAgendada { get; set; }

    public string Horario { get; set; }

    public int LeadId { get; set; }
    
    public int UsuarioId { get; set; }
    public string UsuarioNome { get; set; }
    
    public string Comentario { get; set; }

    public bool Ativo { get; set; }
}
