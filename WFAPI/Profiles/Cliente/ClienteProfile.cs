using AutoMapper;
using WFAPI.Dtos.Cliente;

namespace WFAPI.Profiles.Cliente;

public class ClienteProfile: Profile
{
    public ClienteProfile()
    {
        CreateMap<Worflow.Models.Cliente, ReadClienteDto>()
           .ForMember(x => x.Rua, x => x.MapFrom(x => x.Endereco.Logadouro))
           .ForMember(x => x.Numero, x => x.MapFrom(x => x.Endereco.Numero))
           .ForMember(x => x.Bairro, x => x.MapFrom(x => x.Endereco.Bairro))
           .ForMember(x => x.Cidade, x => x.MapFrom(x => x.Endereco.Cidade))
           .ForMember(x => x.UF, x => x.MapFrom(x => x.Endereco.UF))
           .ReverseMap();

        CreateMap<CreateClienteDto, Worflow.Models.Cliente>().ReverseMap();
        CreateMap<UpdateClienteDto, Worflow.Models.Cliente>().ReverseMap();
    }
}
