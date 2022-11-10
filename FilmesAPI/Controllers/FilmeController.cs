using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int _Id = 1;

        [HttpPost]
        public IActionResult  AdicionaFilme([FromBody] Filme filme)
        {

            if (!string.IsNullOrEmpty(filme.Diretor))
            {
                filme.Id = _Id++;
                filmes.Add(filme);
                filme.ToString();
                return CreatedAtAction(nameof(pergarFilmeAtravesDoId), new { Id = filme.Id }, filme);
            }
            else
            {
                Console.WriteLine("FILME NÃO É VALIDO!");
                return BadRequest();
            }

        }
        [HttpGet]
        public IActionResult BuscarFilmes()
        {
            return Ok(filmes);
        }
        [HttpGet("{id}")]
        public IActionResult pergarFilmeAtravesDoId(int id)
        {
       
            Filme filme =  filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme != null)
            {
                return Ok(filme);
            }
            return NotFound("Filme não encontrado.");
        }
    }
}
