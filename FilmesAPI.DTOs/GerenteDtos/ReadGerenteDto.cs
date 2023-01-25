using FilmesAPI.Models;

namespace FilmesAPI.Dtos.GerenteDtos
{
    public class ReadGerenteDto
    {
        public int Cod_Gerente { get; set; }
        public string Nome { get; set; }
        public  List<Cinema>? Cinemas { get; set; }
    }
}
