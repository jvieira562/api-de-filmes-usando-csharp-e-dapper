using FilmesAPI.Dtos.SessaoDtos.Interfaces;
using FilmesAPI.Models;

namespace FilmesAPI.Data.Repository.Interfaces
{
    public interface SessaoRepository
    {
        public void SalvarSessao(Sessao sessao);
        public ReadSessaoDto BuscarSessao(int cod_Sessao);
        public IEnumerable<Sessao> BuscarSessoes();
        public void ExcluirSessao(int cod_Sessao);
        public void AtualizarSessao(Sessao sessao);
        public bool SessaoExiste(int cod_Sessao);
        public IEnumerable<Sessao> BuscarSessoesNoCinema(int cod_Cinema);


    }
}
