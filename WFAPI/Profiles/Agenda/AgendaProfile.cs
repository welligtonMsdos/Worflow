using AutoMapper;
using WFAPI.Dtos.Agenda;

namespace WFAPI.Profiles.Agenda;

public class AgendaProfile : Profile
{
    public AgendaProfile()
    {
        CreateMap<Worflow.Models.Agenda, ReadAgendaDto>()
            .ForMember(x => x.UsuarioNome, x => x.MapFrom(x => x.Usuario.Nome)).ReverseMap();

        CreateMap<CreateAgendaDto, Worflow.Models.Agenda>().ReverseMap();
        CreateMap<UpdateAgendaDto, Worflow.Models.Agenda>().ReverseMap();
    }
}
