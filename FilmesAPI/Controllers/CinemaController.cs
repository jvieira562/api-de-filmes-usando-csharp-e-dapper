using FilmesAPI.Dtos.CinemaDtos;
using FilmesAPI.Dtos.CinemaDtos.Interfaces;
using FilmesAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private readonly CinemaService _cinemaService;
        public CinemaController(CinemaService cinemaServicce)
        {
            _cinemaService = cinemaServicce;
        }

        [HttpPost]
        public IActionResult SalvarCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            if (!ModelState.IsValid) return BadRequest("Cinema inválido.");

            _cinemaService.SalvarCinema(cinemaDto);            
            return NoContent();
        }
        [HttpGet]
        public IActionResult BuscarCinemas()
        {
            return Ok(_cinemaService.BuscarCinemas());
        }
        [HttpGet("{cod_Cinema}")]
        public IActionResult BuscarCinema(int cod_Cinema)
        {
            ReadCinemaDto cinemaDto = _cinemaService.BuscarCinema(cod_Cinema);
            if(cinemaDto != null) return Ok(cinemaDto);

            return NotFound($"Cinema com código {cod_Cinema} não foi encontrado.");
        }
        [HttpDelete("{cod_Cinema}")]
        public IActionResult ExcluirCinema(int cod_Cinema)
        {
            string status = _cinemaService.ExcluirCinema(cod_Cinema);

            if (String.IsNullOrEmpty(status)) return NoContent();

            return BadRequest(status);
        }
        [HttpPut("{cod_Cinema}")]
        public IActionResult AtualizarCinema(int cod_Cinema, [FromBody] UpdateCinemaDto cinemaDto)
        {
            string status = _cinemaService.AtualizarCinema(cod_Cinema, cinemaDto);

            if (String.IsNullOrEmpty(status)) return NoContent();

            return BadRequest(status);
        }
    }
}
