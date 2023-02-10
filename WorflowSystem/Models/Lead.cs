using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Worflow.Models
{
    public class Lead
    {
        public Lead()
        {
        }

        public Lead(Usuario usuario, Cliente cliente, Produto produto, Segmento segmento, Status status)
        {
            Usuario = usuario;
            Cliente = cliente;
            Produto = produto;
            Segmento = segmento;
            Status = status;
            DataAgendada = DateTime.Now;
            Observacao = "Registro como fonte no Seed";
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Lead")]
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }      
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int SegmentoId { get; set; }
        public Segmento Segmento { get; set; }
        [Required(ErrorMessage = "Status é obrigatório!")]
        [Range(1, 5, ErrorMessage = "Selecione um status")]
        public int StatusId { get; set; }
        public Status Status { get; set; }

        [Required(ErrorMessage = "Data agendada é obrigatória")]
        [Display(Name = "Data Agendada", Prompt = "Digite a data agendada")]
        public DateTime DataAgendada { get; set; }
       
        [Display(Name = "Observação", Prompt = "Digite a observação")]
        public string Observacao { get; set; }
        public ICollection<Agenda> Agenda { get; set; }        
    }
}
