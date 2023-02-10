using FilmesAPI.Dtos.CinemaDtos.Interfaces;

namespace FilmesAPI.Data.Factories.CinemaFactory
{
    public interface CinemaAbstractFactory
    {
        public ReadCinemaDto CreateReadCinemaDto();
        public CinemaSessaoDto CreateCinemaSessaoDto();
    }
}
