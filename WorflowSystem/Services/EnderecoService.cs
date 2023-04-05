using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using WFAPI.Models;
using Worflow.Dados.Interfaces;
using Worflow.Enum;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services;

public class EnderecoService : IEnderecoService
{
    private readonly IEnderecoRepository _repository;

    public EnderecoService(IEnderecoRepository repository) => (_repository) = (repository);

    public bool Alterar(Endereco obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        _repository.Alterar(obj);

        return obj.Id > 0 ? true : false;
    }

    public Address BuscarEnderecoPorCep(string cep)
    {
        var endereco = new Address();

        using(var httpClient = new HttpClient())
        {
            var result = httpClient.GetAsync($"https://localhost:44396/Address/{cep}").GetAwaiter().GetResult();

            var content = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            if(result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                endereco = (Address)JsonConvert.DeserializeObject(content, typeof(Address));
            }
        }

        return endereco;
    }

    public Endereco BuscarPorId(int id)
    {
        if (id == 0)
            throw new Exception(Mensagens.ENDERECO_BUSCAR_ID_ZERADO);

        return _repository.BuscarPorId(id);
    }

    public ICollection<Endereco> BuscarTodos() => _repository.BuscarTodos();     

    public bool Excluir(Endereco obj)
    {
        if (obj.Id == 0)
            throw new Exception(Mensagens.ENDERECO_EXCLUIR_ID_ZERADO);

        _repository.Excluir(obj);

        return obj.Id > 0 ? true : false;
    }

    public bool Incluir(Endereco obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        _repository.Incluir(obj);

        return true;
    }

    public ICollection<Endereco> Pesquisar(string value) => _repository.Pesquisar(value);   
}
