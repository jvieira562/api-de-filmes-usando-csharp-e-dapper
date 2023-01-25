using FilmesAPI.Models;

namespace FilmesAPI.Dtos.SessaoDtos
{
    public class ReadSessaoDto
    {
        public int Cod_Sessao { get; set; }
        public SessaoCinemaDto Cinema { get; set; }
        public Filme Filme { get; set; }
        public DateTime HorarioDeInicio { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }

        public ReadSessaoDto()
        {

        }

        public ReadSessaoDto(int cod_Sessao, SessaoCinemaDto cinema, Filme filme, DateTime horarioDeInicio)
        {
            Cod_Sessao = cod_Sessao;
            Cinema = cinema;
            Filme = filme;
            HorarioDeInicio = horarioDeInicio;
        }
    }
}
