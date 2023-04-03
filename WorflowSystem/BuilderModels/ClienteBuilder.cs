using Worflow.Models;

namespace Worflow.BuilderModels;

public class ClienteBuilder
{
    private readonly Cliente _cliente;

    public ClienteBuilder()
    {
        _cliente = new Cliente();
    }

    public Cliente Build() => _cliente;
    
    public ClienteBuilder Id(int id)
    {
        _cliente.Id = id;
        return this;
    }

    public ClienteBuilder Endereco(Endereco endereco)
    {
        _cliente.Endereco = endereco;
        return this;
    }

    public ClienteBuilder Cnpj(string cnpj)
    {
        _cliente.CNPJ = cnpj;
        return this;
    }

    public ClienteBuilder RazaoSocial(string razaoSocial)
    {
        _cliente.RazaoSocial = razaoSocial;
        return this;
    }

    public ClienteBuilder Fantasia(string fantasia) 
    {
        _cliente.Fantasia = fantasia;
        return this;
    }

    public ClienteBuilder Agencia(string agencia)
    {
        _cliente.Agencia = agencia;
        return this;
    }

    public ClienteBuilder Conta(string conta)
    {
        _cliente.Conta = conta;
        return this;
    }

    public ClienteBuilder Email(string email)
    {
        _cliente.Email = email;
        return this;
    }

    public ClienteBuilder Telefone(string telefone)
    {
        _cliente.Telefone = telefone;
        return this;
    }
}
