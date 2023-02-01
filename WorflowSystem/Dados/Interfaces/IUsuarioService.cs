﻿using System.Collections.Generic;
using Worflow.Models;

namespace Worflow.Dados.Interfaces
{
    public interface IUsuarioService
    {
        ICollection<Usuario> BuscarUsuarios();
        ICollection<Usuario> Pesquisar(string value);
        Usuario BuscarPorId(int id);
        void Incluir(Usuario obj);
        void Alterar(Usuario obj);
        void Excluir(Usuario obj);
        bool UsuarioExiste(Usuario obj);
    }
}