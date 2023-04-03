using Worflow.BuilderModels;
using Worflow.Dados.Builder.Interfaces;
using Worflow.Models;

namespace Worflow.Dados.Builder;

public class LeadGeneratorBuilder : ILeadBuilder, IDadosBuilder<Lead>
{
    private Lead _lead;
    private Endereco endereco;

    public LeadGeneratorBuilder()
    {
        _lead = new Lead();
        Endereco();
        Cliente();
        Produto();
        Segmento();
        Status();
        Usuario();
    }

    public int Id => 1;

    public void Cliente()
    {        
        Cliente cliente = new ClienteBuilder()
            .Id(Id)
            .Endereco(endereco)
            .Cnpj("60664745000187")
            .RazaoSocial("Museu de arte moderna de São Paulo Assis Chateubriand")
            .Fantasia("MASP")
            .Agencia("0102")
            .Conta("45678")
            .Email("contabil_fiscal@masp.org.br")
            .Telefone("1131495959")
            .Build();

        _lead.Cliente = cliente;
        _lead.ClienteId = 1;
    }

    public Lead DeleteNotValid()
    {
        _lead.Id = 0;
        return _lead;
    }

    public Lead DeleteValid() => Get();

    public void Endereco()
    {
        endereco = new EnderecoBuilder()
              .Id(Id)
              .Cep("01310200")
              .Logadouro("Av.Paulista")
              .Numero("1578")
              .Bairro("Bela Vista")
              .Cidade("Cidade")
              .Uf("SP")
              .Build();
    }

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
        Usuario usuario = new Usuario(1, "João Silva", "JOAVA", 1);
        _lead.Usuario = usuario;
        _lead.UsuarioId = 1;
    }
}
