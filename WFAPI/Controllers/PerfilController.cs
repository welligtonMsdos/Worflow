using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WFAPI.Dtos.Perfil;
using Worflow.Dados.Interfaces;
using Worflow.Models;

namespace WFAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PerfilController : Controller
    {
        private IPerfilService _perfilService;
        private IMapper _mapper;

        public PerfilController(IPerfilService perfilService, IMapper mapper)
        {
            _perfilService = perfilService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ReadPerfilDto> BuscarTodos()
        {
            return _mapper.Map<List<ReadPerfilDto>>(_perfilService.BuscarPerfilList());
        }
    }
}
