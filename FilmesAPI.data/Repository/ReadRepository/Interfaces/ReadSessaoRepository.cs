using FilmesAPI.Dtos.SessaoDtos;

namespace FilmesAPI.Data.Repository.ReadRepository.Interfaces
{
    public interface ReadSessaoRepository
    {
        public IEnumerable<ReadSessaoDtoImpl> BuscarSessoes(int cod_Sessao);
        public ReadSessaoDtoImpl BuscarSessao(int cod_Sessao);
    }
}
