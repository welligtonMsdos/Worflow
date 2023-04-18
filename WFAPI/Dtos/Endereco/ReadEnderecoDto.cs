﻿namespace WFAPI.Dtos.Endereco;

public class ReadEnderecoDto
{
    public int Id { get; set; }
    public string CEP { get; set; }    
    public string Logadouro { get; set; }    
    public string Numero { get; set; }    
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string UF { get; set; }
}
