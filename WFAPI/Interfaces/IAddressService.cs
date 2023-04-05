using WFAPI.Dtos;
using WFAPI.Dtos.Address;
using WFAPI.Models;

namespace WFAPI.Interfaces;

public interface IAddressService
{
    Task<ResponseGenerico<AddressResponse>> BuscarEnderecosPorCep(string cep);
}
