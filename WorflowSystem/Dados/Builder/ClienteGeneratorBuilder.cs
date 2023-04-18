using Worflow.BuilderModels;
using Worflow.Dados.Builder.Interfaces;
using Worflow.Models;

namespace Worflow.Dados.Builder;

public class ClienteGeneratorBuilder : IClienteBuilder, IDadosBuilder<Cliente>
{
    private Endereco endereco;
    private Cliente cliente;

    public ClienteGeneratorBuilder() => Dados();
    public int Id => 1;

    public void Dados()
    {
        DadosEndereco();
        DadosCliente();
    }

    public void DadosCliente()
    {
        cliente = new ClienteBuilder()
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
    }

    public void DadosEndereco()
    {
        endereco = new EnderecoBuilder()
            .Id(Id)
            .Cep("01020000")
            .Logadouro("Rua do centro")
            .Numero("100")
            .Bairro("Bairro")
            .Cidade("Cidade")
            .Uf("UF")
            .Build();
    }

    public Cliente DeleteNotValid()
    {
        cliente.Id = 0;
        return cliente;
    }

    public Cliente DeleteValid() => Get();
    public Cliente Get()
    {
        cliente.Id = Id;
        return cliente;
    }

    public Cliente Post() => cliente; 

    public Cliente Put() => Get();
}
