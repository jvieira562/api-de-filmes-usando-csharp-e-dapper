using System.ComponentModel.DataAnnotations;
using System.Runtime.ConstrainedExecution;

namespace FilmesAPI.Dtos.EnderecoDtos
{
    public class CreateEnderecoDto
    {
        [Required(ErrorMessage = "O campo Cep é obrigatório.")]
        [StringLength(8, ErrorMessage = "O campo Cep deve ter no máximo 8 caracteres.")]
        public string Cep { get; set; }
        [Required(ErrorMessage = "O campo Numero é obrigatório.")]
        [Range(0, 9999999, ErrorMessage = "O número deve ter no mínimo 1 e no máximo 9999999.")]
        public int Numero { get; set; }
    }
}
