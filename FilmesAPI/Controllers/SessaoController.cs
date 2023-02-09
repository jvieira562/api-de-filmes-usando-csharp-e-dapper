using FilmesAPI.Dtos.SessaoDtos;
using FilmesAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private readonly SessaoService _sessaoService;
        public SessaoController(SessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        [HttpPost]
        public IActionResult SalvarCinema([FromBody] CreateSessaoDtoImpl sessaoDto)
        {
            if(ModelState.IsValid)
            {
                _sessaoService.SalvarSessao(sessaoDto);
                return NoContent();
            }
            return BadRequest("Sessão inválida.");
        }
        [HttpGet]
        public IActionResult BuscarSessoes()
        {
            return Ok(_sessaoService.BuscarSessoes());
        }
        [HttpGet("{cod_Sessao}")]
        public IActionResult BuscarSessao(int cod_Sessao)
        {
            var sessaoDto = _sessaoService.BuscarSessao(cod_Sessao);
            if (sessaoDto != null) return Ok(sessaoDto);

            return NotFound($"Sessão com código {cod_Sessao} não foi encontrada.");
        }
        [HttpDelete("{cod_Sessao}")]
        public IActionResult ExcluirSessao(int cod_Sessao)
        {
            string status = _sessaoService.ExcluirSessao(cod_Sessao);
            if (String.IsNullOrEmpty(status)) return NoContent();

            return NotFound(status);
        }
        [HttpPut("{cod_Sessao}")]
        public IActionResult AtualizarSessao(int cod_Sessao, [FromBody] UpdateSessaoDto sessaoDto)
        {
            string status = _sessaoService.AtualizarSessao(cod_Sessao, sessaoDto);

            if (String.IsNullOrEmpty(status)) return NoContent();

            return NotFound(status);
        }
    }
}
