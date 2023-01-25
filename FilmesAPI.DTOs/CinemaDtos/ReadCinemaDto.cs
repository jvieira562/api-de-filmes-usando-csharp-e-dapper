using FilmesAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Dtos.CinemaDtos
{
    public class ReadCinemaDto
    {
        public int Cod_Cinema { get; set; }
        public string Nome { get; set; }
        public Gerente Gerente { get; set; }
        public Endereco Endereco { get; set; }
        public List<CinemaSessaoDto> Sessoes { get; set; } 
        public List<Filme> Filmes { get; set; } 
    }
}
