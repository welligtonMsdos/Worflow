using AutoMapper;
using WFAPI.Dtos.Status;

namespace WFAPI.Profiles.Status;

public class StatusProfile: Profile
{
    public StatusProfile()
    {
        CreateMap<ReadStatusDto, Worflow.Models.Status>().ReverseMap();
        CreateMap<CreateStatusDto, Worflow.Models.Status>().ReverseMap();
        CreateMap<UpdateStatusDto, Worflow.Models.Status>().ReverseMap();
    }
}
