using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WFAPI.Dtos.Perfil;
using Worflow.Dados.Interfaces;
using Worflow.Models;

namespace WFAPI.Controllers;

/// <summary>
/// Perfil controller
/// </summary>
[ApiController]
[Route("[controller]")]
public class PerfilController : Controller
{
    private readonly IPerfilService _perfilService;
    private readonly IMapper _mapper;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="perfilService"></param>
    /// <param name="mapper"></param>
    public PerfilController(IPerfilService perfilService, IMapper mapper)
    {
        _perfilService = perfilService;
        _mapper = mapper;
    }

    /// <summary>
    /// Busca todos os perfis
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<ReadPerfilDto> BuscarTodos()
    {
        return _mapper.Map<List<ReadPerfilDto>>(_perfilService.BuscarPerfilList());
    }

    /// <summary>
    /// Busca um perfil pelo id
    /// </summary>
    /// <param name="id">id do perfil</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(int id)
    {
        var perfil = _perfilService.BuscarPorId(id);

        if (perfil == null) return NotFound();

        return Ok(_mapper.Map<ReadPerfilDto>(perfil));
    }

    /// <summary>
    /// Adiciona um perfil ao banco de dados
    /// </summary>
    /// <param name="dto">Objeto com os campos necessários</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Inserção com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult Incluir([FromBody] CreatePerfilDto dto)
    {
        var perfil = _mapper.Map<Perfil>(dto);

        _perfilService.Incluir(perfil);

        return CreatedAtAction(nameof(BuscarPorId), new { id = perfil.Id }, perfil);
    }

    /// <summary>
    /// Atualiza um perfil no banco de dados
    /// </summary>
    /// <param name="id">id do perfil</param>
    /// <param name="dto">objeto com os campos necessários</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">NoContent</response>
    [HttpPut("{id}")]
    public IActionResult Alterar(int id, [FromBody] UpdatePerfilDto dto)
    {
        var perfil = _mapper.Map<Perfil>(dto);

        _perfilService.Alterar(perfil);

        return NoContent();
    }

    /// <summary>
    /// Exclui um perfil do banco de dados
    /// </summary>
    /// <param name="id">id do perfil</param>
    /// <returns></returns>
    /// <response code="204">NoContent</response>
    [HttpDelete("{id}")]
    public IActionResult Excluir(int id)
    {
        var perfil = _perfilService.BuscarPorId(id);

        _perfilService.Excluir(perfil);

        return NoContent();
    }
}
