using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WFAPI.Dtos.Cotacao;
using Worflow.Dados.Interfaces;

namespace WFAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CotacaoController : Controller
{
    private readonly ICotacaoService _service;
    private readonly IMapper _mapper;

    public CotacaoController(ICotacaoService service, IMapper mapper) => (_service,_mapper) = (service,mapper);

    [HttpGet]
    public IEnumerable<ReadCotacaoDto> BuscarTodos()
    {
        return _mapper.Map<List<ReadCotacaoDto>>(_service.BuscarTodos());
    }

    [HttpGet("{id}")]
    public IActionResult BuscarPorId(int id)
    {
        var cotacao = _service.BuscarPorId(id);

        if (cotacao == null) return NotFound();

        return Ok(_mapper.Map<ReadCotacaoDto>(cotacao));
    }
}
