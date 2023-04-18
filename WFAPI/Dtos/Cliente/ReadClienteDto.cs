using System.ComponentModel.DataAnnotations;

namespace WFAPI.Dtos.Cliente;

public class ReadClienteDto
{
    public int Id { get; set; }
    public int EnderecoId { get; set; }
    public string Rua { get; set; }
    public string Numero { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string UF { get; set; }    
    public string CNPJ { get; set; }    
    public string RazaoSocial { get; set; }    
    public string Fantasia { get; set; }    
    public string Agencia { get; set; }    
    public string Conta { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }    
}
