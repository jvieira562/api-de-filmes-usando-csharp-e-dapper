using FilmesAPI.Models;

namespace FilmesAPI.Dtos.CinemaDtos.Interfaces
{
    public interface ReadCinemaDto
    {
        public int Cod_Cinema { get; set; }
        public string Nome { get; set; }
        public Gerente Gerente { get; set; }
        public Endereco Endereco { get; set; }
        public List<CinemaSessaoDto> Sessoes { get; set; } 
        public List<Filme> Filmes { get; set; } 
    }
}
