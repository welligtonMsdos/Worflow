using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WFAPI.Dtos.Usuario;
using Worflow.Dados.Interfaces;
using Worflow.Models;

namespace WFAPI.Controllers
{
    /// <summary>
    /// Usuário controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioService"></param>
        /// <param name="mapper"></param>
        public UsuarioController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        /// <summary>
        /// Busca todos os usuários
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ReadUsuarioDto> BuscarTodos()
        {
            return _mapper.Map<List<ReadUsuarioDto>>(_usuarioService.BuscarUsuarios());
        }

        /// <summary>
        /// Busca um usuário pelo id
        /// </summary>
        /// <param name="id">id do usuário</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var usuario = _usuarioService.BuscarPorId(id);

            if (usuario == null) return NotFound();

            return Ok(_mapper.Map<ReadUsuarioDto>(usuario));
        }

        /// <summary>
        /// Adiciona um usuário ao banco de dados
        /// verificando se a racf já existe
        /// </summary>
        /// <param name="dto">Objeto com os campos necessários</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Inserção com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Incluir([FromBody] CreateUsuarioDto dto)
        {
            var usuario = _mapper.Map<Usuario>(dto);

            _usuarioService.Incluir(usuario);

            return CreatedAtAction(nameof(BuscarPorId), new { id = usuario.Id }, usuario);
        }

        /// <summary>
        /// Atualiza um usuário no banco de dados
        /// </summary>
        /// <param name="id">id do usuário</param>
        /// <param name="dto">objeto com os campos necessários</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">NoContent</response>
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, [FromBody] UpdateUsuarioDto dto)
        {
            var usuario = _mapper.Map<Usuario>(dto);

            _usuarioService.Alterar(usuario);

            return NoContent();
        }

        /// <summary>
        /// Exclui um usuário do banco de dados
        /// </summary>
        /// <param name="id">id do usuário</param>
        /// <returns></returns>
        /// <response code="204">NoContent</response>
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            var usuario = _usuarioService.BuscarPorId(id);

            _usuarioService.Excluir(usuario);

            return NoContent();
        }
    }
}
