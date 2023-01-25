using FilmesAPI.Dtos.SessaoDtos;

namespace FilmesAPI.Data.Repository.ReadRepository.Interfaces
{
    public interface ReadSessaoRepository
    {
        public IEnumerable<ReadSessaoDto> BuscarSessoes(int cod_Sessao);
        public ReadSessaoDto BuscarSessao(int cod_Sessao);
    }
}
