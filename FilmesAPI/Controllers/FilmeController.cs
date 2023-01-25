using FilmesAPI.Dtos.FilmeDtos;
using FilmesAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly FilmeService _filmeService;

        public FilmeController(FilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] CreateFilmeDto filmeDto)
        {
            if (!ModelState.IsValid) return BadRequest("Filme invalido.");
            
            _filmeService.SalvarFilme(filmeDto);            
            return NoContent();                     
        }

        [HttpGet]
        public IActionResult BuscarFilmes()
        {
            return Ok(_filmeService.BuscarFilmes());
        }

        [HttpGet("{cod_Filme}")]
        public IActionResult BuscarFilme(int cod_Filme)
        {
            ReadFilmeDto filmeDto = _filmeService.BuscarFilme(cod_Filme);
            if (filmeDto != null) return Ok(filmeDto);
            
            return NotFound("Filme não encontrado.");
        }

        [HttpDelete("{cod_Filme}")]
        public IActionResult ExcluirFilme(int cod_Filme)
        {
            string status = _filmeService.ExcluirFilme(cod_Filme);
            if (String.IsNullOrEmpty(status))
            {
                return NoContent();
            }

            return NotFound(status);
        }
        [HttpPut("{cod_Filme}")]
        public IActionResult AtualizarFilme(int cod_Filme, [FromBody] UpdateFilmeDto filmeDto)
        {
            string status = _filmeService.AtualizarFilme(cod_Filme, filmeDto);

            if(String.IsNullOrEmpty(status)) return NoContent();
            
            return BadRequest(status);
        }
    }
}
