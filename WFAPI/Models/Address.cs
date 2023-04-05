using System.Text.Json.Serialization;

namespace WFAPI.Models;

public class Address
{
    [JsonPropertyName("cep")]
    public string? Cep { get; set; }

    [JsonPropertyName("state")]
    public string? Uf { get; set; }

    [JsonPropertyName("city")]
    public string? Cidade { get; set; }

    [JsonPropertyName("neighborhood")]
    public string? Bairro { get; set; }

    [JsonPropertyName("street")]
    public string? Rua { get; set; }

    [JsonPropertyName("service")]
    public string? Servico { get; set; }
}
