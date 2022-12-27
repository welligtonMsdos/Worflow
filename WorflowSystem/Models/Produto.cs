using System.ComponentModel.DataAnnotations;

namespace Worflow.Models
{
    public class Produto
    {       
        public int Id { get; set; }        

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public bool Ativo { get; set; }
        public int SegmentoId { get; set; }
        public Segmento Segmento { get; set; }      
    }
}
