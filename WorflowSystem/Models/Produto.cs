﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Worflow.Models
{
    public class Produto
    {
        public Produto()
        {

        }
        public Produto(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
            Ativo = true;
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }        

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public bool Ativo { get; set; } 
        public ICollection<Lead> Lead { get; set; }
        public virtual ICollection<ProdutoSegmento> ProdutoSegmento { get; set; }
    }
}
