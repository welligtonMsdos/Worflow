using System.ComponentModel.DataAnnotations;

namespace WFAPI.Dtos.Lead;

public class LeadBase
{
    public int Id { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]
    public int UsuarioId { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]
    public int ClienteId { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]
    public int ProdutoId { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]
    public int SegmentoId { get; set; }
    
    [Required(ErrorMessage = "Status é obrigatório!")]
    [Range(1, 5, ErrorMessage = "Selecione um status")]
    public int StatusId { get; set; }    

    [Required(ErrorMessage = "Data agendada é obrigatória")]    
    public DateTime DataAgendada { get; set; }
    
    public string Observacao { get; set; }    
}
