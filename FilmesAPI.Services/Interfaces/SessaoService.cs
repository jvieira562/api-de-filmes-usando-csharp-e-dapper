using FilmesAPI.Dtos.SessaoDtos;

namespace FilmesAPI.Services.Interfaces
{
    public interface SessaoService
    {
        public void SalvarSessao(CreateSessaoDto sessaoDto);
        public ReadSessaoDtoImpl BuscarSessao(int cod_Sessao);
        public IEnumerable<ReadSessaoDtoImpl> BuscarSessoes();
        public string ExcluirSessao(int cod_Sessao);
        public string AtualizarSessao(int cod_Sessao, UpdateSessaoDto sessaoDto);
    }
}
