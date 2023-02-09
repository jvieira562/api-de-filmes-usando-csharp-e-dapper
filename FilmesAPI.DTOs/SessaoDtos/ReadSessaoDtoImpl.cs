using FilmesAPI.Dtos.SessaoDtos.Interfaces;
using FilmesAPI.Models;

namespace FilmesAPI.Dtos.SessaoDtos
{
    public class ReadSessaoDtoImpl : ReadSessaoDto
    {
        public int Cod_Sessao { get; set; }
        public SessaoCinemaDto Cinema { get; set; }
        public Filme Filme { get; set; }
        public DateTime HorarioDeInicio { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }

        public ReadSessaoDtoImpl(int cod_Sessao, SessaoCinemaDtoImpl cinema, Filme filme, DateTime horarioDeInicio)
        {
            this.Cod_Sessao = cod_Sessao;
            this.Cinema = cinema;
            this.Filme = filme;
            this.HorarioDeInicio = horarioDeInicio;
            this.HorarioDeEncerramento = horarioDeInicio.AddMinutes(filme.Duracao);
        }
        public ReadSessaoDtoImpl()
        {

        }
    }
}
