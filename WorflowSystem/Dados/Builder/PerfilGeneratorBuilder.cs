using Worflow.Dados.Builder.Interfaces;
using Worflow.Models;

namespace Worflow.Dados.Builder;

public class PerfilGeneratorBuilder : IPerfilBuilder, IDadosBuilder<Perfil>
{
    private Perfil perfil;

    public PerfilGeneratorBuilder()
    {
        DadosPerfil();
    }

    public int Id { get => 1; }

    public void DadosPerfil() => perfil = new Perfil(Id, "Admin");

    public Perfil DeleteNotValid()
    {
        perfil.Id = 0;
        return perfil;
    }

    public Perfil DeleteValid() => Get();

    public Perfil Get()
    {
        perfil.Id = Id;
        return perfil;
    }

    public Perfil Post() => perfil;

    public Perfil Put() => Get();
}
