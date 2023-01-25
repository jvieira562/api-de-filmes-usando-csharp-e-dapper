using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Dtos.FilmeDtos
{
    public class UpdateFilmeDto
    {
        [Required(ErrorMessage = "O campo título é obrigatório.")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo diretor é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo diretor pode ter no maximo 100 caracteres.")]
        public string Diretor { get; set; }
        [Required(ErrorMessage = "O campo gênero é obrigatório.")]
        public string Genero { get; set; }
        [Range(60, 500, ErrorMessage = "O campo duração deve ter no mínimo 60 e no máximo 500.")]
        public int Duracao { get; set; }
        [Range(0, 18, ErrorMessage = "O campo FaixaEtaria deve ter no mínimo 0 e no máximo 18.")]
        public int FaixaEtaria { get; set; }
    }
}