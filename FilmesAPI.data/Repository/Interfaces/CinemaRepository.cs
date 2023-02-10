using FilmesAPI.Dtos.CinemaDtos.Interfaces;
using FilmesAPI.Models;

namespace FilmesAPI.data.Repository.Interfaces
{
    public interface CinemaRepository
    {
        public void SalvarCinema(Cinema cinema);
        public ReadCinemaDto BuscarCinema(int cod_Cinema);
        public IEnumerable<ReadCinemaDto> BuscarCinemas();
        public void ExcluirCinema(int cod_Cinema);
        public void AtualizarCinema(Cinema cinema);
        public bool CinemaExiste(int cod_Cinema);

    }
}
