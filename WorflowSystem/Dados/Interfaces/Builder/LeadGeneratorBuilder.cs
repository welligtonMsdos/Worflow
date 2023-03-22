using Worflow.Models;

namespace Worflow.Dados.Interfaces.Builder;

public class LeadGeneratorBuilder : ILeadBuilder, IDadosBuilder<Lead>
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

    public int Id => 1;   

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

    public Lead DeleteNotValid()
    {
        _lead.Id = 0;
        return _lead;
    }

    public Lead DeleteValid() => Get();

    public Lead Get()
    {
        _lead.Id = Id;
        return _lead;
    }

    public Lead Post() => _lead;

    public void Produto()
    {
        Produto produto = new Produto(1, "Garantia");

        _lead.Produto = produto;
        _lead.ProdutoId = 1;
    }

    public Lead Put() => Get(); 

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
