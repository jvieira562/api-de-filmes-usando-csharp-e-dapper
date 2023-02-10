using FilmesAPI.Dtos.CinemaDtos;
using FilmesAPI.Dtos.CinemaDtos.Interfaces;

namespace FilmesAPI.Data.Factories.CinemaFactory
{
    public class CinemaAbstractFactoryImpl : CinemaAbstractFactory
    {
        public CinemaSessaoDto CreateCinemaSessaoDto()
        {
            return new CinemaSessaoDtoImpl
            {

            };
        }

        public ReadCinemaDto CreateReadCinemaDto()
        {
            return new ReadCinemaDtoImpl
            {

            };
        }
    }
}
