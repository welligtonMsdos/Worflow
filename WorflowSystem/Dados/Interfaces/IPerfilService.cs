using System.Collections.Generic;
using Worflow.Models;

namespace Worflow.Dados.Interfaces;

public interface IPerfilService
{
    List<Perfil> BuscarPerfilList();
    ICollection<Perfil> BuscarPerfil();
    ICollection<Perfil> Pesquisar(string value);
    Perfil BuscarPorId(int id);
    bool Incluir(Perfil obj);
    bool Alterar(Perfil obj);
    bool Excluir(Perfil obj);
}
