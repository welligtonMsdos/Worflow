namespace WFAPI.Dtos.Lead;

public class ReadLeadDto
{
    public int Id { get; set; }   
    public int UsuarioId { get; set; }
    public string UsuarioNome { get; set; }    
    public int ClienteId { get; set; }
    public string ClienteRazaoSocial { get; set; }
    public string ClienteFantasia { get; set; }
    public int ProdutoId { get; set; }
    public string ProdutoNome { get; set; }
    public int SegmentoId { get; set; }
    public string SegmentoNome { get; set; }
    public int StatusId { get; set; }
    public string StatusNome { get; set; }    
    public DateTime DataAgendada { get; set; }
    public string Observacao { get; set; }
}
