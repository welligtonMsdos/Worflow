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

        public Agenda(DateTime data) 
        {
            DataAgendada = data;
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Data agendada é obrigatória")]
        [Display(Name = "Data Agendada", Prompt = "Digite a data agendada")]
        public DateTime DataAgendada { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [DataType(DataType.Time)]
        public string Horario { get; set; }

        public int LeadId { get; set; }
        public Lead Lead { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [Display(Name = "Comentário", Prompt = "Digite comentário")]
        public string Comentario { get; set; }

        public bool Ativo { get; set; }
    }
}
