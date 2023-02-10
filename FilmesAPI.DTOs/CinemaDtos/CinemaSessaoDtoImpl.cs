using FilmesAPI.Dtos.CinemaDtos.Interfaces;
using FilmesAPI.Models;

namespace FilmesAPI.Dtos.CinemaDtos
{
    public class CinemaSessaoDtoImpl : CinemaSessaoDto
    {
        public int Cod_Sessao { get; set; }
        public Filme Filme { get; set; }
        public DateTime HorarioDeInicio { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
    }
}
