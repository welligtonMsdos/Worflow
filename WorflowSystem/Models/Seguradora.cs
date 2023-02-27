using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Worflow.Models
{
    public class Seguradora
    {
        public Seguradora(int id, string nome)
        {
            Id = id;
            Nome = nome;
            Ativo = true;
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome", Prompt = "Digite o nome.")]
        [MinLength(4, ErrorMessage = "Nome necessita de 4 caracteres.")]
        
        public string Nome { get; set; }

        public bool Ativo { get; set; }

        public ICollection<Cotacao> Cotacao { get; set; }
    }
}
