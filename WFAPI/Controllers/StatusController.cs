using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WFAPI.Dtos.Status;
using Worflow.Dados.Interfaces;
using Worflow.Models;

namespace WFAPI.Controllers;

/// <summary>
/// Status Controller
/// </summary>
[ApiController]
[Route("[controller]")]
public class StatusController : Controller
{
    private readonly IStatusService _statusService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Construtor StatusController
    /// </summary>
    /// <param name="statusService"></param>
    /// <param name="mapper"></param>
    public StatusController(IStatusService statusService, IMapper mapper)
    {
        _statusService = statusService;
        _mapper = mapper;
    }

    /// <summary>
    /// Buscar todos os status
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<ReadStatusDto> BuscarTodos()
    {
        return _mapper.Map<List<ReadStatusDto>>(_statusService.BuscarTodos());
    }

    /// <summary>
    /// Buscar status por id
    /// </summary>
    /// <param name="id">id do status</param>
    /// <returns>IActionResult</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(int id)
    {
        var status = _statusService.BuscarPorId(id);

        if (status == null) return NotFound();

        return Ok(_mapper.Map<ReadStatusDto>(status));
    }

    /// <summary>
    /// Adiciona um status ao banco de dados
    /// </summary>
    /// <param name="dto">Objeto com os campos necessários</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Inserção com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult Incluir([FromBody] CreateStatusDto dto)
    {
        var status = _mapper.Map<Status>(dto);

        _statusService.Incluir(status);

        return CreatedAtAction(nameof(BuscarPorId), new { id = status.Id }, status);
    }

    /// <summary>
    /// Atualiza um status no banco de dados
    /// </summary>
    /// <param name="id">id do status</param>
    /// <param name="dto">objeto com os campos necessários</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">NoContent</response>
    [HttpPut("{id}")]
    public IActionResult Alterar(int id, [FromBody] UpdateStatusDto dto)
    {
        var status = _mapper.Map<Status>(dto);

        _statusService.Alterar(status);

        return NoContent();
    }

    /// <summary>
    /// Exclui um status do banco de dados
    /// </summary>
    /// <param name="id">id do perfil</param>
    /// <returns></returns>
    /// <response code="204">NoContent</response>
    [HttpDelete("{id}")]
    public IActionResult Excluir(int id)
    {
        var status = _statusService.BuscarPorId(id);

        _statusService.Excluir(status);

        return NoContent();
    }
}
