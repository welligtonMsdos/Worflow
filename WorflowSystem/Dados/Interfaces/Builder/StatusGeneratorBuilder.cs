using Worflow.Models;

namespace Worflow.Dados.Interfaces.Builder;

public class StatusGeneratorBuilder : IStatusBuilder, IDadosBuilder<Status>
{
    private Status status;

    public StatusGeneratorBuilder()
    {
        DadosStatus();
    }

    public int Id => 1;

    public void DadosStatus()
    {
        status = new Status(Id, "Inicio");
    }

    public Status DeleteNotValid()
    {
        status.Id = 0;
        return status;
    }

    public Status DeleteValid()
    {
        status.Id = Id;
        return status;
    }

    public Status Get()
    {
        status.Id = Id;
        return status;
    }

    public Status Post()
    {        
        return status;
    }

    public Status Put()
    {
        status.Id = Id;
        return status;
    }
}
