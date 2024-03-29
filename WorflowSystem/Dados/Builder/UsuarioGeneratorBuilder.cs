﻿using Worflow.Dados.Builder.Interfaces;
using Worflow.Models;

namespace Worflow.Dados.Builder;

public class UsuarioGeneratorBuilder : IDadosBuilder<Usuario>
{
    private Usuario usuario;
    public UsuarioGeneratorBuilder() => Dados();

    public int Id => 1;

    public void Dados() => usuario = new Usuario(0, "João da Silva", "JOAVA", 1);

    public Usuario DeleteNotValid()
    {
        usuario.Id = 0;
        return usuario;
    }

    public Usuario DeleteValid() => Get();

    public Usuario Get()
    {
        usuario.Id = Id;
        return usuario;
    }

    public Usuario Post() => usuario;

    public Usuario Put() => Get();
}
