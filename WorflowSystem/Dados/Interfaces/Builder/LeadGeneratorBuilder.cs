using Worflow.Models;
using X.PagedList;

namespace Worflow.Dados.Interfaces.Builder
{
    public class LeadGeneratorBuilder : ILeadBuilder
    {
        private Lead _lead;

        public LeadGeneratorBuilder()
        {
            _lead = new Lead();
            Cliente();
            Produto();
            Segmento();
            Status();
            Usuario();
        }

        public Lead LeadPost()
        {
            return _lead;
        }

        public Lead LeadPut(int leadId = 0)
        {
            _lead.Id = leadId;
            return _lead;
        }

        public Lead LeadGet()
        {
            _lead.Id = 1;
            return _lead;   
        }

        public void Cliente()
        {
            Endereco endereco = new Endereco(1, "01310200", "Av.Paulista", "1578", "Bela Vista", "São Paulo", "SP");

            Cliente cliente = new Cliente(1,
                    endereco,
                    "60664745000187",
                    "Museu de arte moderna de São Paulo Assis Chateubriand",
                    "MASP",
                    "0102",
                    "45678",
                    "contabil_fiscal@masp.org.br",
                    "1131495959");

            _lead.Cliente = cliente;
            _lead.ClienteId = 1;
        }

        public void Produto()
        {
            Produto produto = new Produto(1, "Garantia");

            _lead.Produto = produto;
            _lead.ProdutoId = 1;
        }

        public void Segmento()
        {
            Segmento segmento = new Segmento(1, "Agro");
            _lead.Segmento = segmento;
            _lead.SegmentoId = 1;
        }

        public void Status()
        {
            Status status = new Status(1, "Inicial");
            _lead.Status = status;
            _lead.StatusId = 1;
        }

        public void Usuario()
        {
            Usuario usuario = new Usuario(1,"João Silva","JOAVA",1);
            _lead.Usuario = usuario;
            _lead.UsuarioId = 1;
        }     
    }
}
