using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Worflow.Models
{
    public class ProdutoSegmento
    {
        public ProdutoSegmento(int id, int produtoId,int segmentoId)
        {
            Id = id;
            ProdutoId = produtoId;
            SegmentoId = segmentoId;
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public virtual Produto produto { get; set; }
        public int SegmentoId { get; set; }
        public virtual Segmento Segmento { get; set; }
    }
}
