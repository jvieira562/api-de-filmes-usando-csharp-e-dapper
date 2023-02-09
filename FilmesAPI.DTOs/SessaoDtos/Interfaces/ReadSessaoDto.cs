using FilmesAPI.Models;

namespace FilmesAPI.Dtos.SessaoDtos.Interfaces
{
    public interface ReadSessaoDto
    {
        public int Cod_Sessao { get; set; }
        public SessaoCinemaDto Cinema { get; set; }
        public Filme Filme { get; set; }
        public DateTime HorarioDeInicio { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
    }
}
