
using FilmesAPI.Dtos.GerenteDtos;

namespace GerentesAPI.Services.Interfaces
{
    public interface GerenteService
    {
        public void SalvarGerente(CreateGerenteDto gerenteDto);
        public ReadGerenteDto BuscarGerente(int cod_Gerente);
        public IEnumerable<ReadGerenteDto> BuscarGerentes();
        public string ExcluirGerente (int cod_Gerente);
        public string AtualizarGerente(int cod_Gerente, UpdateGerenteDto gerenteDto);
    }
}
