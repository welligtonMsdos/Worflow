using System;
using System.ComponentModel.DataAnnotations;

namespace Worflow.Models;

public class Anexo
{
    public Anexo(int id, byte[] documento, string extensao, string nome, int usuarioId)
    {
        Id = id;
        Documento = documento;
        Extensao = extensao;
        Nome = nome;
        DataCriacao = DateTime.Now;
        UsuarioId = usuarioId;
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
}
