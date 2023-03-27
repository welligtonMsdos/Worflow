using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Worflow.Dados.Interfaces;
using Worflow.Enum;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services;

public class AnexoService : IAnexoService
{
    private readonly IAnexoRepository _repository;

    public AnexoService(IAnexoRepository repository) => (_repository) = (repository); 
    
    public bool Alterar(Anexo obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        _repository.Alterar(obj);

        return obj.Id > 0 ? true : false;
    }

    public Anexo BuscarPorId(int id)
    {
        if (id == 0)
            throw new Exception(Mensagens.ANEXO_BUSCAR_ID_ZERADO);

        return _repository.BuscarPorId(id);
    }

    public ICollection<Anexo> BuscarPorLeadId(int leadId)
    {
        return _repository.BuscarPorLeadId(leadId);
    }

    public ICollection<Anexo> BuscarTodos() => _repository.BuscarTodos();        

    public bool Excluir(Anexo obj)
    {
        if (obj.Id == 0)
            throw new Exception(Mensagens.ANEXO_EXCLUIR_ID_ZERADO);

        _repository.Excluir(obj);

        return obj.Id > 0 ? true : false;
    }

    public bool Incluir(Anexo obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        _repository.Incluir(obj);

        return obj.Id > 0 ? true : false;
    }

    public bool IncluirArquivo(Arquivo arquivo, int leadId)
    {
        if (arquivo.listFiles == null) throw new Exception(Mensagens.ANEXO_ARQUIVO_INVALIDO);

        var arquivos = arquivo.listFiles.Count > 0 ? arquivo.listFiles : null;

        try
        { 
            foreach (var file in arquivos)
            {
                using (var target = new MemoryStream())
                {
                    file.CopyToAsync(target).Wait();

                    byte[] documento = target.ToArray();                   

                    Incluir(new Anexo(documento, file.ContentType, file.FileName, leadId));
                }
            }

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public ICollection<Anexo> Pesquisar(string value) => _repository.Pesquisar(value);         
}
