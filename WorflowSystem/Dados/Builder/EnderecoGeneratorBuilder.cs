using Worflow.BuilderModels;
using Worflow.Dados.Builder.Interfaces;
using Worflow.Models;

namespace Worflow.Dados.Builder;

public class EnderecoGeneratorBuilder : IDadosBuilder<Endereco>
{
    private Endereco endereco;

    public int Id => 1;

    public EnderecoGeneratorBuilder() => Dados();

    public void Dados()
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

    public Endereco DeleteNotValid()
    {
        endereco.Id = 0;
        return endereco;
    }

    public Endereco DeleteValid() => Get();

    public Endereco Get()
    {
        endereco.Id = Id;
        return endereco;
    }

    public Endereco Post() => endereco;

    public Endereco Put() => Get();   
}
