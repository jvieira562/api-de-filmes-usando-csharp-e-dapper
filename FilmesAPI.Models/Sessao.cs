using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmesAPI.Models
{
    public class Sessao
    {
        public int Cod_Sessao { get; set; }
        public int Cod_Cinema { get; set; }
        public int Cod_Filme { get; set; }
        public DateTime HorarioDeInicio { get; set; }
    }
}
