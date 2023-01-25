using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Dtos.CinemaDtos
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres.")]
        [MinLength(1, ErrorMessage = "O Nome deve ter no mínimo 1 caractere.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Cod_Endereco(código do endereço) nome é obrigatório.")]
        public int Cod_Endereco { get; set; }

        [Required(ErrorMessage = "O Cod_Gerente(código do gerente) é obrigatório.")]
        public int Cod_Gerente { get; set; }
    }
}
