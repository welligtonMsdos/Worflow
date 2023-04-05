using WFAPI.Dtos;
using WFAPI.Models;

namespace WFAPI.Interfaces;

public interface IBrasilApi
{
    Task<ResponseGenerico<Address>> BuscarEnderecosPorCep(string cep);
}
