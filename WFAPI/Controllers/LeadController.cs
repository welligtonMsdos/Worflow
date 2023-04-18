using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WFAPI.Dtos.Lead;
using Worflow.Dados.Interfaces;

namespace WFAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class LeadController : Controller
{
    private readonly ILeadService _service;
    private readonly IMapper _mapper;

    public LeadController(ILeadService service, IMapper mapper) => (_service, _mapper) = (service, mapper);

    [HttpGet]
    public IEnumerable<ReadLeadDto> BuscarTodos()
    {
        return _mapper.Map<List<ReadLeadDto>>(_service.BuscarTodos());
    }

    [HttpGet("{id}")]
    public IActionResult BuscarPorId(int id)
    {
        var lead = _service.BuscarPorId(id);

        if (lead == null) return NotFound();

        return Ok(_mapper.Map<ReadLeadDto>(lead));
    }
}
