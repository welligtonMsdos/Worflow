using System.ComponentModel.DataAnnotations;

namespace WFAPI.Dtos.Cliente;

public class ClienteBase
{
    public int Id { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]
    public int EnderecoId { get; set; }

    [Required(ErrorMessage = "{0} é obrigatório")]
    public string CNPJ { get; set; }

    [Required(ErrorMessage = "{0} é obrigatória")]
    public string RazaoSocial { get; set; }

    [Required(ErrorMessage = "{0} é obrigatória")]
    public string Fantasia { get; set; }

    [Required(ErrorMessage = "{0} é obrigatória")]
    public string Agencia { get; set; }

    [Required(ErrorMessage = "{0} é obrigatória")]
    [Display(Name = "Conta")]
    public string Conta { get; set; }

    public string Email { get; set; }

    public string Telefone { get; set; }
}
