using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WFAPI.Dtos.Agenda;
using Worflow.Dados.Interfaces;
using Worflow.Models;

namespace WFAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AgendaController : Controller
{
    private readonly IAgendaService _service;
    private readonly IMapper _mapper;

    public AgendaController(IAgendaService agendaService, IMapper mapper) => (_service,_mapper) = (agendaService,mapper);

    [HttpGet]
    public IEnumerable<ReadAgendaDto> BuscarTodos()
    {
        return _mapper.Map<List<ReadAgendaDto>>(_service.BuscarTodos());
    }

    [HttpGet("{id}")]
    public IActionResult BuscarPorId(int id)
    {
        var agenda = _service.BuscarPorId(id);

        if (agenda == null) return NotFound();

        return Ok(_mapper.Map<ReadAgendaDto>(agenda));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult Incluir([FromBody] CreateAgendaDto dto)
    {
        var agenda = _mapper.Map<Agenda>(dto);

        _service.Incluir(agenda);

        return CreatedAtAction(nameof(BuscarPorId), new { id = agenda.Id }, agenda);
    }

    [HttpPut("{id}")]
    public IActionResult Alterar(int id, [FromBody] UpdateAgendaDto dto)
    {
        var agenda = _mapper.Map<Agenda>(dto);

        _service.Alterar(agenda);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Excluir(int id)
    {
        var agenda = _service.BuscarPorId(id);

        _service.Excluir(agenda);

        return NoContent();
    }
}
