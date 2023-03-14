using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;

namespace Worflow.Models
{
    public class Cotacao
    {
        public Cotacao(DateTime dataEmissao, DateTime dataVencimento, decimal valor, int leadid, int seguradoraId, string statusCotacao = "")
        {
            Ativo = true;
            StatusFinalizada = false;
            DataEmissao = dataEmissao;
            DataVencimento = dataVencimento;
            Valor = valor;
            LeadId = leadid;
            SeguradoraId = seguradoraId;

            StatusFinalizada = statusCotacao.Equals("1") ? true : false;
        }
        public Cotacao(int leadId)
        {
            DataEmissao = DateTime.Now;
            DataVencimento = DateTime.Now.AddDays(30);
            LeadId = leadId;
        }

        public Cotacao()
        {
            DataEmissao = DateTime.Now;
            DataVencimento = DateTime.Now.AddDays(30);
        }

        [Key] 
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} é obrigatória")]
        [Display(Name = "Data Emissão", Prompt = "Digite a data de emissão")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]        
        public DateTime DataEmissao { get; set; }

        [Required(ErrorMessage = "{0} é obrigatória")]
        [Display(Name = "Data Vencimento", Prompt = "Digite a data de vencimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataVencimento { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [Range(10,1000, ErrorMessage = "Valor deve estar entre 10,00 e 1000,00.")]
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
