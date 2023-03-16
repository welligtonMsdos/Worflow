namespace Worflow.Dtos;

public class SeguradoraDto
{
    public SeguradoraDto(string nome, string valor)
    {
        Nome = nome;
        Valor = valor;
    }

    public string Nome { get; set; }
    public string Valor { get; set; }
}
