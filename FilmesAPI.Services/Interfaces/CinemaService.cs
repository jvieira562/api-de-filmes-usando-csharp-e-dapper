using FilmesAPI.Dtos.CinemaDtos;
using FilmesAPI.Dtos.CinemaDtos.Interfaces;

namespace FilmesAPI.Services.Interfaces
{
    public interface CinemaService
    {
        public void SalvarCinema(CreateCinemaDto cinemaDto);
        public ReadCinemaDto BuscarCinema(int cod_Cinema);
        public IEnumerable<ReadCinemaDto> BuscarCinemas();
        public string ExcluirCinema(int cod_Cinema);
        public string AtualizarCinema(int cod_Cinema, UpdateCinemaDto cinemaDto);

    }
}
