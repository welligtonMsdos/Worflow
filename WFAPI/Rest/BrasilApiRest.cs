
using System.Dynamic;
using System.Text.Json;
using WFAPI.Dtos;
using WFAPI.Interfaces;
using WFAPI.Models;

namespace WFAPI.Rest;

public class BrasilApiRest : IBrasilApi
{
    public async Task<ResponseGenerico<Address>> BuscarEnderecosPorCep(string cep)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/cep/v1/{cep}");

        var response = new ResponseGenerico<Address>();

        using(var client = new HttpClient())
        {
            var responseBrasilApi = await client.SendAsync(request);

            var contentResp = await responseBrasilApi.Content.ReadAsStringAsync();

            var objResponse = JsonSerializer.Deserialize<Address>(contentResp);

            if (responseBrasilApi.IsSuccessStatusCode)
            {
                response.CodigoHttp = responseBrasilApi.StatusCode;
                response.DadosRetorno = objResponse;
            }
            else
            {
                response.CodigoHttp = responseBrasilApi.StatusCode;
                response.ErroRetorno = JsonSerializer.Deserialize<ExpandoObject>(contentResp);
            }
        }

        return response;
    }
}
