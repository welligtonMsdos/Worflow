using System.ComponentModel.DataAnnotations;

namespace WFAPI.Dtos.Cotacao;

public class CotacaoBase
{  
    public int Id { get; set; }

    [Required(ErrorMessage = "{0} é obrigatória")]    
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime DataEmissao { get; set; }

    [Required(ErrorMessage = "{0} é obrigatória")]    
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime DataVencimento { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]    
    public decimal Valor { get; set; }

    public bool Ativo { get; set; }

    public bool StatusFinalizada { get; set; }

    [Required(ErrorMessage = "Seguradora é obrigatória!")]
    [Range(1, 4, ErrorMessage = "Selecione uma seguradora")]
    public int SeguradoraId { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]
    public int LeadId { get; set; }    
}
