using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Dtos.CinemaDtos
{
    public class UpdateCinemaDto
    {
        public string Nome { get; set; }
        public int Cod_Endereco { get; set; }
        public int Cod_Gerente { get; set; }
        
    }
}
