using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Worflow.Models
{
    public class Agenda
    {
        public Agenda()
        {

        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Data agendada é obrigatória")]
        [Display(Name = "Data Agendada", Prompt = "Digite a data agendada")]
        public DateTime DataAgendada { get; set; }

        public int LeadId { get; set; }
        public Lead Lead { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Display(Name = "Comentário", Prompt = "Digite comentário")]
        public string Comentario { get; set; }

        public bool Ativo { get; set; }
    }
}
