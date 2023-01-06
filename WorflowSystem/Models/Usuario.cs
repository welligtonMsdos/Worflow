
using System.ComponentModel.DataAnnotations;

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
       
        public int PerfilId { get; set; }

        public Perfil Perfil { get; set; }      
    }
}
