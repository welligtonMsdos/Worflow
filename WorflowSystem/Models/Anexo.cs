using System;
using System.ComponentModel.DataAnnotations;

namespace Worflow.Models;

public class Anexo
{
    public Anexo()
    {
        
    }
    public Anexo(byte[] documento, string extensao, string nome, int leadId)
    {
        extensao = extensao.Contains("wordprocessing") ? "msword" : 
            extensao.Contains("spreadsheet") ? "xlsx" :
            extensao.Contains("text/plain") ? "txt" :
            extensao.Replace("application/", "");

        Documento = documento;
        Extensao = extensao;
        Nome = nome;
        DataCriacao = DateTime.Now;
        UsuarioId = 1;
        LeadId = leadId;
    }

    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Arquivo é obrigatório")]
    public byte[] Documento { get; set; } 
    
    public string Extensao { get; set; }

    public string Nome { get; set; }

    public DateTime DataCriacao { get; set; }

    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
    public int LeadId { get; set; }
    public Lead Lead { get; set; }
}
