using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Filme
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo título é obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo diretor é obrigatório")]
        public string Diretor { get; set; }
        [Required(ErrorMessage = "O campo gênero é obrigatório")]
        [StringLength(30, ErrorMessage = "O gênero deve ter no máximo 30 caracteres")]
        public string Genero { get; set; }
        [Range(100, 500, ErrorMessage = "A duração em minutos deve está entre 1 e 600")]
        public int Duracao { get; set; }

        public void ToString()
    {
            Console.WriteLine($"\nTítulo : {this.Titulo} \nDiretor : {this.Diretor} \nGênero : {this.Genero} \nDuração : {this.Duracao} minutos");
    }
    }

}
