using AutoMapper;
using WFAPI.Dtos.Usuario;

namespace WFAPI.Profiles.Usuario
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Worflow.Models.Usuario, ReadUsuarioDto>()
                .ForMember(x => x.PerfilDescricao, x => x.MapFrom(x => x.Perfil.Descricao)).ReverseMap();

            CreateMap<CreateUsuarioDto, Worflow.Models.Usuario>().ReverseMap();
            CreateMap<UpdateUsuarioDto, Worflow.Models.Usuario>().ReverseMap();
        }
    }
}
