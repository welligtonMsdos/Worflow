using Microsoft.AspNetCore.Mvc;
using System.Net;
using WFAPI.Interfaces;

namespace WFAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : Controller
{
    private readonly IAddressService _addressService;

    public AddressController(IAddressService addressService) => (_addressService) = (addressService);

    [HttpGet("{cep}")]
    public async Task<IActionResult> BuscarEndereco([FromRoute] string cep)
    {
        var response = await _addressService.BuscarEnderecosPorCep(cep);

        if(response.CodigoHttp == HttpStatusCode.OK)
        {
            return Ok(response.DadosRetorno);
        }
        else
        {
            return StatusCode((int)response.CodigoHttp, response.ErroRetorno);
        }
    }
}
