
using FilmesAPI.Dtos.FilmeDtos;

namespace FilmesAPI.Services.Interfaces
{
    public interface FilmeService
    {
        public void SalvarFilme(CreateFilmeDto filmeDto);
        public ReadFilmeDto BuscarFilme(int cod_Filme);
        public IEnumerable<ReadFilmeDto> BuscarFilmes();
        public string ExcluirFilme (int cod_Filme);
        public string AtualizarFilme(int cod_Filme, UpdateFilmeDto filmeDto);
    }
}
