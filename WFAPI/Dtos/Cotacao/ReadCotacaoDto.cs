namespace WFAPI.Dtos.Cotacao;

public class ReadCotacaoDto
{
    public int Id { get; set; }    
    public DateTime DataEmissao { get; set; }    
    public DateTime DataVencimento { get; set; }    
    public decimal Valor { get; set; }
    public bool Ativo { get; set; }
    public bool StatusFinalizada { get; set; }    
    public int SeguradoraId { get; set; }
    public string SeguradoraNome { get; set; }    
    public int LeadId { get; set; }
}
