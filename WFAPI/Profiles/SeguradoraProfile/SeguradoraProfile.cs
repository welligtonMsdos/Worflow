using AutoMapper;
using WFAPI.Dtos.Seguradora;

namespace WFAPI.Profiles.SeguradoraProfile;

public class SeguradoraProfile: Profile
{
    public SeguradoraProfile()
    {
        CreateMap<ReadSeguradoraDto, Worflow.Models.Seguradora>().ReverseMap();
        CreateMap<CreateSeguradoraDto, Worflow.Models.Seguradora>().ReverseMap();
        CreateMap<UpdateSeguradoraDto, Worflow.Models.Seguradora>().ReverseMap();
    }
}
