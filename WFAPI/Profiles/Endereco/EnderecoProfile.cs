using AutoMapper;
using WFAPI.Dtos.Endereco;

namespace WFAPI.Profiles.Endereco;

public class EnderecoProfile: Profile
{
    public EnderecoProfile()
    {
        CreateMap<Worflow.Models.Endereco, ReadEnderecoDto>().ReverseMap();
        CreateMap<CreateEnderecoDto, Worflow.Models.Endereco>().ReverseMap();
        CreateMap<UpdateEnderecoDto, Worflow.Models.Endereco>().ReverseMap();
    }
}
