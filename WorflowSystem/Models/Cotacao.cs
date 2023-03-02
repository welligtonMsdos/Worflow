using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;

namespace Worflow.Models
{
    public class Cotacao
    {
        [Key] 
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} é obrigatória")]
        [Display(Name = "Data Emissão", Prompt = "Digite a data de emissão")]
        public DateTime DataEmissao { get; set; }

        [Required(ErrorMessage = "{0} é obrigatória")]
        [Display(Name = "Data Vencimento", Prompt = "Digite a data de vencimento")]
        public DateTime DataVencimento { get; set; }

        [Required]
        public decimal Valor { get; set; }

        public bool Ativo { get; set; }

        public bool StatusFinalizada { get; set; }

        [Required(ErrorMessage = "Seguradora é obrigatória!")]
        [Range(1, 4, ErrorMessage = "Selecione uma seguradora")]
        public int SeguradoraId { get; set; }

        public Seguradora Seguradora { get; set; }

        public int LeadId { get; set; }

        public Lead Lead { get; set; }
    }
}
