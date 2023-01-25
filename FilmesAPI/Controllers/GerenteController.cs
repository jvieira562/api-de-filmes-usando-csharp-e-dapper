using FilmesAPI.Dtos.GerenteDtos;
using GerentesAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private readonly GerenteService _gerenteService;

        public GerenteController(GerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }

        [HttpGet]
        public IActionResult BuscarGerentes()
        {
            return Ok(_gerenteService.BuscarGerentes());
        }

        [HttpGet("{cod_Gerente}")]
        public IActionResult BuscarGerente(int cod_Gerente)
        {
            ReadGerenteDto gerenteDto = _gerenteService.BuscarGerente(cod_Gerente);
            if(gerenteDto != null) return Ok(gerenteDto);

            return NotFound("Gerente não encontrado.");
        }

        [HttpPost]
        public IActionResult AdicionarGerente([FromBody] CreateGerenteDto gerenteDto)
        {
            if (!ModelState.IsValid) return BadRequest("Gerente inválido.");

            _gerenteService.SalvarGerente(gerenteDto);
            return NoContent();
        }

        [HttpPut("{cod_Gerente}")]
        public IActionResult AtualizarGerente(int cod_Gerente, [FromBody] UpdateGerenteDto gerenteDto)
        {
            string status = _gerenteService.AtualizarGerente(cod_Gerente, gerenteDto);

            if (String.IsNullOrEmpty(status)) return NoContent();

            return BadRequest(status);
        }

        [HttpDelete("{cod_Gerente}")]
        public IActionResult ExcluirGerente(int cod_Gerente)
        {
            string status = _gerenteService.ExcluirGerente(cod_Gerente);

            if(String.IsNullOrEmpty(status)) return NoContent();

            return BadRequest(status);
        }
    }
}
