using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Worflow.Models
{
    public class Segmento
    {
        public Segmento(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
            Ativo = true;
        }
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public ICollection<Produto> Produtos { get; set; }       
    }
}
