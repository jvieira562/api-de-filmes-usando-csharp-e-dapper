using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmesAPI.Dtos.FilmeDtos
{
    public class ReadFilmeDto
    {
        public int Cod_Filme { get; set; }
        public string Titulo { get; set; }
        public string Diretor { get; set; }
        public string Genero { get; set; }
        public int Duracao { get; set; }
        public int FaixaEtaria { get; set; }
    }
}
