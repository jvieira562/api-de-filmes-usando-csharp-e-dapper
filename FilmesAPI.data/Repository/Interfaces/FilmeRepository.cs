using FilmesAPI.Models;

namespace FilmesAPI.data.Repository.Interfaces
{
    public interface FilmeRepository
    {
        public void SalvarFilme(Filme filme);
        public Filme BuscarFilme(int cod_Filme);
        public IEnumerable<Filme> BuscarFilmes();
        public void ExcluirFilme(int cod_Filme);
        public void AtualizarFilme(Filme filme);
        public bool FilmeExiste(int cod_Filme);

    }
}
