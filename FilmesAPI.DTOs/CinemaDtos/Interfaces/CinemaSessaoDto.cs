using FilmesAPI.Models;

namespace FilmesAPI.Dtos.CinemaDtos.Interfaces
{
    public interface CinemaSessaoDto
    {
        public int Cod_Sessao { get; set; }
        public Filme Filme { get; set; }
        public DateTime HorarioDeInicio { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
    }
}
