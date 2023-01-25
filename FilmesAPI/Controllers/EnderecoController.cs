using EnderecosAPI.Services.Interfaces;
using FilmesAPI.Dtos.EnderecoDtos;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly EnderecoService _enderecoService;
        public EnderecoController(EnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpPost]
        public IActionResult SalvarEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            if(!ModelState.IsValid) return BadRequest("Endereço inválido.");
            
            _enderecoService.SalvarEndereco(enderecoDto);
            return NoContent();           
        }
        [HttpGet]
        public IActionResult BuscarEnderecos()
        {
            return Ok(_enderecoService.BuscarEnderecos());
        }
        [HttpGet("{cod_Endereco}")]
        public IActionResult BuscarEndereco(int cod_Endereco)
        {
            ReadEnderecoDto enderecoDto = _enderecoService.BuscarEndereco(cod_Endereco);
            if(enderecoDto != null) return Ok(enderecoDto);
            
            return NotFound($"Endereço com código {cod_Endereco} não foi encontrado.");
        }
        [HttpDelete("{cod_Endereco}")]
        public IActionResult ExcluitEndereco(int cod_Endereco)
        {
            string status = _enderecoService.ExcluirEndereco(cod_Endereco);

            if(String.IsNullOrEmpty(status)) return NoContent();

            return NotFound(status);
        }
        [HttpPut("{cod_Endereco}")]
        public IActionResult AtualizarEndereco(int cod_Endereco, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            string status = _enderecoService.AtualizarEndereco(cod_Endereco, enderecoDto);

            if (String.IsNullOrEmpty(status)) return NoContent();

            return NotFound(status);
        }
    }
}
