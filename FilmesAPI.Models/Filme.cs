using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Filme
    {      
        public int Cod_Filme { get; set; }
        public string Titulo { get; set; }
        public string  Diretor { get; set; }
        public string Genero { get; set; }
        public int Duracao { get; set; }
        public int FaixaEtaria { get; set; }
    }
}
