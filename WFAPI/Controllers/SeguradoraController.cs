using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WFAPI.Dtos.Seguradora;
using Worflow.Dados.Interfaces;
using Worflow.Models;

namespace WFAPI.Controllers;

/// <summary>
/// SeguradoraController
/// </summary>
[ApiController]
[Route("[controller]")]
public class SeguradoraController : Controller
{
    private readonly ISeguradoraService _service;
    private readonly IMapper _mapper;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="seguradoraService"></param>
    /// <param name="mapper"></param>
    public SeguradoraController(ISeguradoraService seguradoraService, IMapper mapper)
        => (_service, _mapper) = (seguradoraService, mapper);


    /// <summary>
    /// Busca todas as seguradoras
    /// </summary>
    /// <returns>IEnumberable</returns>
    [HttpGet]
    public IEnumerable<ReadSeguradoraDto> BuscarTodos()
    {
        return _mapper.Map<List<ReadSeguradoraDto>>(_service.BuscarSeguradoras());
    }

    /// <summary>
    /// Busca uma seguradora pelo id
    /// </summary>
    /// <param name="id">Id da seguradora</param>
    /// <returns>IActionResult</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(int id)
    {
        var seguradora = _service.BuscarPorId(id);

        if (seguradora == null) return NotFound();

        return Ok(_mapper.Map<ReadSeguradoraDto>(seguradora));
    }

    /// <summary>
    /// Adiciona uma seguradora ao banco de dados
    /// </summary>
    /// <param name="dto">Objeto com os campos necessários</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Inserção com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult Incluir([FromBody] CreateSeguradoraDto dto)
    {
        var seguradora = _mapper.Map<Seguradora>(dto);

        _service.Incluir(seguradora);

        return CreatedAtAction(nameof(BuscarPorId), new { id = seguradora.Id }, seguradora);
    }

    /// <summary>
    /// Atualiza uma seguradora no banco de dados
    /// </summary>
    /// <param name="id">id da seguradora</param>
    /// <param name="dto">objeto com os campos necessários</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">NoContent</response>
    [HttpPut("{id}")]
    public IActionResult Alterar(int id, [FromBody] UpdateSeguradoraDto dto)
    {
        var seguradora = _mapper.Map<Seguradora>(dto);

        _service.Alterar(seguradora);

        return NoContent();
    }

    /// <summary>
    /// Exclui uma seguradora do banco de dados
    /// </summary>
    /// <param name="id">Id da seguradora</param>
    /// <returns></returns>
    /// <response code="204">NoContent</response>
    [HttpDelete("{id}")]
    public IActionResult Excluir(int id)
    {
        var seguradora = _service.BuscarPorId(id);

        _service.Excluir(seguradora);

        return NoContent();
    }
}
