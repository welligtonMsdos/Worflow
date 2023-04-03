using Worflow.Dados.Builder.Interfaces;
using Worflow.Models;

namespace Worflow.Dados.Builder;

public class SegmentoGeneratorBuilder : ISegmentoBuilder, IDadosBuilder<Segmento>
{
    private Segmento segmento;
    public SegmentoGeneratorBuilder()
    {
        DadosSegmento();
    }

    public int Id => 1;

    public void DadosSegmento() => segmento = new Segmento(1, "Agro");

    public Segmento DeleteNotValid()
    {
        segmento.Id = 0;
        return segmento;
    }

    public Segmento DeleteValid() => Get();

    public Segmento Get()
    {
        segmento.Id = Id;
        return segmento;
    }

    public Segmento Post() => segmento;

    public Segmento Put() => Get();
}
