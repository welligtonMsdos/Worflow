using Worflow.Models;

namespace Worflow.Dados.Interfaces.Builder;

public class SeguradoraGeneratorBuilder : ISeguradoraBuilder, IDadosBuilder<Seguradora>
{
    private Seguradora seguradora;

    public SeguradoraGeneratorBuilder()
    {
        DadosSeguradora();
    }
    public int Id => 1;

    public void DadosSeguradora()
    {
        seguradora = new Seguradora(Id, "Porto");
    }

    public Seguradora DeleteNotValid()
    {
        seguradora.Id = 0;
        return seguradora;
    }

    public Seguradora DeleteValid()
    {
        return Get();
    }

    public Seguradora Get()
    {
        seguradora.Id = Id;
        return seguradora;
    }

    public Seguradora Post()
    {
        return seguradora;
    }

    public Seguradora Put()
    {
        return Get();
    }
}
