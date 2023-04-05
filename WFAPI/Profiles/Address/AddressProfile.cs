using AutoMapper;
using WFAPI.Dtos;
using WFAPI.Dtos.Address;

namespace WFAPI.Profiles.Address;

public class AddressProfile: Profile
{
    public AddressProfile()
    {
        CreateMap(typeof(ResponseGenerico<>), typeof(ResponseGenerico<>));

        CreateMap<AddressResponse, Models.Address>().ReverseMap();        
    }
}
