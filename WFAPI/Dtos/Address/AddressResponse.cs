using System.Text.Json.Serialization;

namespace WFAPI.Dtos.Address;

public class AddressResponse
{
    public string? Cep { get; set; }

    public string? Uf { get; set; }

    public string? Cidade { get; set; }

    public string? Bairro { get; set; }

    public string? Rua { get; set; }

    [JsonIgnore]
    public string? Servico { get; set; }
}
