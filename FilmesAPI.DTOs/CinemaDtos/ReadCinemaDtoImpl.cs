using FilmesAPI.Dtos.CinemaDtos.Interfaces;
using FilmesAPI.Models;

namespace FilmesAPI.Dtos.CinemaDtos
{
    public class ReadCinemaDtoImpl : ReadCinemaDto
    {
        public int Cod_Cinema { get; set; }
        public string Nome { get; set; }
        public Gerente Gerente { get; set; }
        public Endereco Endereco { get; set; }
        public List<CinemaSessaoDtoImpl> Sessoes { get; set; } 
        public List<Filme> Filmes { get; set; } 
    }
}
