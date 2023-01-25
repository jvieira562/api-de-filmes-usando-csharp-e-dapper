using FilmesAPI.Models;

namespace FilmesAPI.Dtos.SessaoDtos
{
    public class SessaoCinemaDto
    {

        public int Cod_Cinema { get; set; }
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public Gerente Gerente { get; set; }

        public SessaoCinemaDto()
        {

        }

        public SessaoCinemaDto(int cod_Cinema, string nome, Endereco endereco, Gerente gerente)
        {
            Cod_Cinema = cod_Cinema;
            Nome = nome;
            Endereco = endereco;
            Gerente = gerente;
        }
    }
}
