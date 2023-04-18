using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WFAPI.Dtos.Cliente;
using Worflow.Dados.Interfaces;

namespace WFAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : Controller
{
    private readonly IClienteService _service;
    private readonly IMapper _mapper;

    public ClienteController(IClienteService service, IMapper mapper) => (_service,_mapper) = (service,mapper);

    [HttpGet]
    public IEnumerable<ReadClienteDto> BuscarTodos()
    {
        return _mapper.Map<List<ReadClienteDto>>(_service.BuscarTodos());
    }

    [HttpGet("{id}")]
    public IActionResult BuscarPorId(int id)
    {
        var cliente = _service.BuscarPorId(id);

        if (cliente == null) return NotFound();

        return Ok(_mapper.Map<ReadClienteDto>(cliente));
    }
}
