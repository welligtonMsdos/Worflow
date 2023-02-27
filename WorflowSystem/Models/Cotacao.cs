using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;

namespace Worflow.Models
{
    public class Cotacao
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        public DateTime DataEmissao { get; set; }

        [Required]
        public DateTime DataVencimento { get; set; }

        [Required]
        public decimal Valor { get; set; }

        public bool Ativo { get; set; }

        public bool StatusFinalizada { get; set; }

        public int SeguradoraId { get; set; }

        public Seguradora Seguradora { get; set; }

        public int LeadId { get; set; }

        public Lead Lead { get; set; }
    }
}
