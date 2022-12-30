
namespace Worflow.Models
{
    public class Usuario
    {
        public Usuario()
        {

        }
        public Usuario(int id, string nome, int perfilId)
        {
            Id = id;
            Nome = nome;
            Ativo = true;
            PerfilId = perfilId;
        }
        public int Id { get; set; } 
        public string Nome { get; set; }
        public string RACF { get; set; }
        public bool Ativo { get; set; }
        public int PerfilId { get; set; }
        public Perfil Perfil { get; set; }      
    }
}
