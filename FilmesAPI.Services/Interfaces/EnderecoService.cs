using FilmesAPI.Dtos.EnderecoDtos;

namespace EnderecosAPI.Services.Interfaces
{
    public interface EnderecoService
    {
        public void SalvarEndereco(CreateEnderecoDto enderecoDto);
        public ReadEnderecoDto BuscarEndereco(int cod_Endereco);
        public IEnumerable<ReadEnderecoDto> BuscarEnderecos();
        public string ExcluirEndereco (int cod_Endereco);
        public string AtualizarEndereco(int cod_Endereco, UpdateEnderecoDto enderecoDto);
    }
}
