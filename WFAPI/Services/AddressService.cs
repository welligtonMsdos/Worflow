using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WFAPI.Dtos;
using WFAPI.Dtos.Address;
using WFAPI.Interfaces;

namespace WFAPI.Services;

public class AddressService : IAddressService
{
    private readonly IMapper _mapper;
    private readonly IBrasilApi _brasilApi;

    public AddressService(IMapper mapper, IBrasilApi brasilApi) => (_mapper,_brasilApi) = (mapper,brasilApi);
   
    public async Task<ResponseGenerico<AddressResponse>> BuscarEnderecosPorCep(string cep)
    {
        var endereco = await _brasilApi.BuscarEnderecosPorCep(cep);

        return _mapper.Map<ResponseGenerico<AddressResponse>>(endereco);
    }
}
