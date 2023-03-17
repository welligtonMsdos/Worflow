using AutoMapper;
using WFAPI.Dtos.Perfil;

namespace WFAPI.Profiles.Perfil;

public class PerfilProfile : Profile
{
    public PerfilProfile()
    {
        CreateMap<ReadPerfilDto, Worflow.Models.Perfil>().ReverseMap();
    }
}
