using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WFAPI.Dtos.Endereco;
using Worflow.Dados.Interfaces;

namespace WFAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : Controller
{
    private readonly IEnderecoService _service;
    private readonly IMapper _mapper;

    public EnderecoController(IEnderecoService service, IMapper mapper) => (_service, _mapper) = (service, mapper);

    [HttpGet]
    public IEnumerable<ReadEnderecoDto> BuscarTodos()
    {
        return _mapper.Map<List<ReadEnderecoDto>>(_service.BuscarTodos());
    }

    [HttpGet("{id}")]
    public IActionResult BuscarPorId(int id)
    {
        var endereco = _service.BuscarPorId(id);

        if (endereco == null) return NotFound();

        return Ok(_mapper.Map<ReadEnderecoDto>(endereco));
    }
}
