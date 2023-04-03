using Worflow.Models;

namespace Worflow.BuilderModels;

public class EnderecoBuilder
{
    private readonly Endereco _endereco;

    public EnderecoBuilder()
    {
        _endereco = new Endereco();
    }

    public Endereco Build() => _endereco;

    public EnderecoBuilder Id(int id)
    {
        _endereco.Id = id;
        return this;
    }

    public EnderecoBuilder Cep(string cep)
    {
        _endereco.CEP = cep;
        return this;
    }

    public EnderecoBuilder Logadouro(string logadouro)
    {
        _endereco.Logadouro = logadouro;
        return this;
    }

    public EnderecoBuilder Numero(string numero)
    {
        _endereco.Numero = numero;
        return this;
    }

    public EnderecoBuilder Bairro(string bairro)
    {
        _endereco.Bairro = bairro;
        return this;
    }

    public EnderecoBuilder Cidade(string cidade)
    {
        _endereco.Cidade = cidade;
        return this;
    }

    public EnderecoBuilder Uf(string uf)
    {
        _endereco.UF = uf;
        return this;
    }
}
