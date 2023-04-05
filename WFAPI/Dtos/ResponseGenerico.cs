using System.Dynamic;
using System.Net;

namespace WFAPI.Dtos;

public class ResponseGenerico<T>
{
    public HttpStatusCode CodigoHttp { get; set; }

    public T? DadosRetorno { get; set; }
    public ExpandoObject? ErroRetorno { get; set; }
}
