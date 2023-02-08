
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Worflow.Models
{
    public class Usuario
    {
        public Usuario()
        {

        }
        public Usuario(int id, string nome, string racf, int perfilId)
        {
            Id = id;
            Nome = nome;
            Ativo = true;
            RACF = racf;
            PerfilId = perfilId;
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório!")]
        [Display(Name = "Nome", Prompt = "Digite o nome.")]
        [MinLength(3,ErrorMessage = "Nome necessita de 3 caracteres.")]      
        public string Nome { get; set; }

        [Required(ErrorMessage = "RACF é obrigatória!")]
        [Display(Name = "RACF", Prompt = "Digite a RACF.")]
        [MinLength(5, ErrorMessage = "RACF necessita de 5 caracteres.")]
        public string RACF { get; set; }

        public bool Ativo { get; set; }

        [Required(ErrorMessage = "Perfil é obrigatório!")]
        [Range(1,4, ErrorMessage ="Selecione um perfil")]
        public int PerfilId { get; set; }

        public Perfil Perfil { get; set; }      
        public ICollection<Lead> Lead { get; set; }
        public ICollection<Agenda> Agenda { get; set; }
    }
}
