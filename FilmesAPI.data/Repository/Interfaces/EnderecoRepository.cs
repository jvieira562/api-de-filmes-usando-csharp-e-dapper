using FilmesAPI.Models;

namespace FilmesAPI.data.Repository.Interfaces
{
    public interface EnderecoRepository
    {
        public void SalvarEndereco(Endereco endereco);
        public Endereco BuscarEndereco(int cod_Endereco);
        public IEnumerable<Endereco> BuscarEnderecos();
        public void ExcluirEndereco(int cod_Endereco);
        public void AtualizarEndereco(Endereco endereco);
        public bool EnderecoExiste(int cod_Endereco);
    }
}
