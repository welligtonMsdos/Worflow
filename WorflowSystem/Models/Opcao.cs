namespace Worflow.Models;

public class Opcao
{
    public Opcao(int id, string descricao)
    {
        Id = id;
        Descricao = descricao;
    }
    public int Id { get; set; }
    public string Descricao { get; set; }       
}
