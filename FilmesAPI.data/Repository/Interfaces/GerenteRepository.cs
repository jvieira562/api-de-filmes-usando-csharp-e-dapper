using FilmesAPI.Models;

namespace FilmesAPI.data.Repository.Interfaces
{
    public interface GerenteRepository
    {
        public void SalvarGerente(Gerente gerente);
        public IEnumerable<Gerente> BuscarGerentes();
        public Gerente BuscarGerente(int cod_Gerente);
        public void ExcluirGerente(int cod_Gerente);
        public void AtualizarGerente(Gerente gerente);
        public bool GerenteExiste(int cod_Gerente);

    }
}
