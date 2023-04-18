using AutoMapper;
using WFAPI.Dtos.Cotacao;

namespace WFAPI.Profiles.Cotacao;

public class CotacaoProfile: Profile
{
    public CotacaoProfile()
    {
        CreateMap<Worflow.Models.Cotacao, ReadCotacaoDto>()
           .ForMember(x => x.SeguradoraNome, x => x.MapFrom(x => x.Seguradora.Nome)).ReverseMap();

        CreateMap<CreateCotacaoDto, Worflow.Models.Cotacao>().ReverseMap();
        CreateMap<UpdateCotacaoDto, Worflow.Models.Cotacao>().ReverseMap();
    }
}
