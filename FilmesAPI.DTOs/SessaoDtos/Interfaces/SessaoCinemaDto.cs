using FilmesAPI.Models;

namespace FilmesAPI.Dtos.SessaoDtos.Interfaces
{
    public interface SessaoCinemaDto
    {
        public int Cod_Cinema { get; set; }
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public Gerente Gerente { get; set; }
    }
}
