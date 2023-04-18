using AutoMapper;
using WFAPI.Dtos.Lead;

namespace WFAPI.Profiles.Lead;

public class LeadProfile: Profile
{
    public LeadProfile()
    {
        CreateMap<Worflow.Models.Lead, ReadLeadDto>()
           .ForMember(x => x.UsuarioNome, x => x.MapFrom(x => x.Usuario.Nome))
           .ForMember(x => x.ClienteRazaoSocial, x => x.MapFrom(x => x.Cliente.RazaoSocial))
           .ForMember(x => x.ClienteFantasia, x => x.MapFrom(x => x.Cliente.Fantasia))
           .ForMember(x => x.ProdutoNome, x => x.MapFrom(x => x.Produto.Descricao))
           .ForMember(x => x.SegmentoNome, x => x.MapFrom(x => x.Segmento.Descricao))
           .ForMember(x => x.StatusNome, x => x.MapFrom(x => x.Status.Descricao))
           .ReverseMap();

        CreateMap<CreateLeadDto, Worflow.Models.Lead>().ReverseMap();
        CreateMap<UpdateLeadDto, Worflow.Models.Lead>().ReverseMap();
    }
}
