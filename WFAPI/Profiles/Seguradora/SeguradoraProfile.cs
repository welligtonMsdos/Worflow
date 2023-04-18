using AutoMapper;
using WFAPI.Dtos.Seguradora;

namespace WFAPI.Profiles.Seguradora;

public class SeguradoraProfile: Profile
{
    public SeguradoraProfile()
    {
        CreateMap<ReadSeguradoraDto, Worflow.Models.Seguradora>().ReverseMap();
        CreateMap<CreateSeguradoraDto, Worflow.Models.Seguradora>().ReverseMap();
        CreateMap<UpdateSeguradoraDto, Worflow.Models.Seguradora>().ReverseMap();
    }
}
