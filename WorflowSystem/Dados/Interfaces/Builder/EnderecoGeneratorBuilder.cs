using Worflow.Models;

namespace Worflow.Dados.Interfaces.Builder;

public class EnderecoGeneratorBuilder : IEnderecoBuilder, IDadosBuilder<Endereco>
{
    private Endereco endereco;

    public int Id => 1;

    public EnderecoGeneratorBuilder() => DadosEndereco();

    public void DadosEndereco()
    {
        endereco = new Endereco("01020000", "Rua do centro", "100", "Bairro", "Cidade", "SP");
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
