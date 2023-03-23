using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Worflow.Dados.Interfaces;
using Worflow.Enum;
using Worflow.Models;
using Worflow.Repository;

namespace Worflow.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repository;

    public UsuarioService(IUsuarioRepository usuarioRepository) => (_repository) = (usuarioRepository);       

    public bool Alterar(Usuario obj)
    {
        Validator.ValidateObject(obj, new ValidationContext(obj), true);

        _repository.Alterar(obj);

        return obj.Id > 0 ? true : false;
    }

    public Usuario BuscarPorId(int id)
    {
        if (id == 0)
            throw new Exception(Mensagens.USUARIO_BUSCAR_ID_ZERADO);

        return _repository.BuscarPorId(id);
    }

    public ICollection<Usuario> BuscarUsuarios() => _repository.BuscarTodos();        

    public bool Excluir(Usuario obj)
    {
        if (obj.Id == 0)
            throw new Exception(Mensagens.USUARIO_EXCLUIR_ID_ZERADO);

        _repository.Excluir(obj);

        return obj.Id > 0 ? true : false;
    }

    public bool Incluir(Usuario obj)
    {
        if (!_repository.UsuarioExiste(obj))
        {
            Validator.ValidateObject(obj, new ValidationContext(obj), true);

            _repository.Incluir(obj);

            return true;
        }
        else
            return false;               
    }

    public ICollection<Usuario> Pesquisar(string value) => _repository.Pesquisar(value);        
}
