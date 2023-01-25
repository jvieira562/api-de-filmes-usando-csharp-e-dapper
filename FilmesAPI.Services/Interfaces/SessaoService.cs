using FilmesAPI.Dtos.SessaoDtos;

namespace FilmesAPI.Services.Interfaces
{
    public interface SessaoService
    {
        public void SalvarSessao(CreateSessaoDto sessaoDto);
        public ReadSessaoDto BuscarSessao(int cod_Sessao);
        public IEnumerable<ReadSessaoDto> BuscarSessoes();
        public string ExcluirSessao(int cod_Sessao);
        public string AtualizarSessao(int cod_Sessao, UpdateSessaoDto sessaoDto);
    }
}
