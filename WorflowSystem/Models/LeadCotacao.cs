namespace Worflow.Models
{
    public class LeadCotacao
    {
        public LeadCotacao(Lead lead, Cotacao cotacao)
        {
            Lead = lead;
            Cotacao = cotacao;
        }

        public Lead Lead { get; set; }
        public Cotacao Cotacao { get; set; }
    }
}
