﻿using System.ComponentModel.DataAnnotations;

namespace WFAPI.Dtos.Endereco;

public class EnderecoBase
{   
    public int Id { get; set; }

    [Required(ErrorMessage = "CEP é obrigatório")]
    [Display(Name = "CEP", Prompt = "Digite o CEP")]
    [MinLength(8, ErrorMessage = "CEP necessita de 8 caracteres.")]
    [MaxLength(8)]
    public string CEP { get; set; }

    [Required(ErrorMessage = "Logadouro é obrigatório")]
    [Display(Name = "Rua/Av", Prompt = "Digite o Logadouro")]
    [MinLength(5, ErrorMessage = "Logadouro necessita de 5 caracteres.")]
    public string Logadouro { get; set; }

    [Required(ErrorMessage = "Número é obrigatório")]
    [Display(Name = "Número", Prompt = "Digite o Número")]
    public string Numero { get; set; }

    [Required(ErrorMessage = "Bairro é obrigatório")]
    [Display(Name = "Bairro", Prompt = "Digite o Bairro")]
    [MinLength(3, ErrorMessage = "Bairro necessita de 3 caracteres.")]
    public string Bairro { get; set; }

    [Required(ErrorMessage = "Cidade é obrigatória")]
    [Display(Name = "Cidade", Prompt = "Digite a Cidade")]
    [MinLength(5, ErrorMessage = "Cidade necessita de 5 caracteres.")]
    public string Cidade { get; set; }

    [Required(ErrorMessage = "UF é obrigatória")]
    [Display(Name = "UF", Prompt = "UF")]
    [MinLength(2, ErrorMessage = "UF necessita de 2 caracteres.")]
    [MaxLength(2)]
    [RegularExpression(@"[A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ ]+$", ErrorMessage = "Use apenas caracteres alfabéticos.")]
    public string UF { get; set; }    
}
