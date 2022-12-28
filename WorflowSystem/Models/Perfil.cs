using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Worflow.Models
{
    public class Perfil
    {
        public Perfil(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
            Ativo = true;
        }
        public int Id { get; set; }

        [Display(Name = "Perfil")]
        public string Descricao { get; set; }

        public bool Ativo { get; set; }

        public ICollection<Usuario> Usuario { get; set; }
    }
}
