using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmesAPI.Dtos.SessaoDtos
{
    public class CreateSessaoDto
    {
        [Required(ErrorMessage = "O campo Cod_Filme(código do filme) é obrigatório.")]
        public int Cod_Filme { get; set; }

        [Required(ErrorMessage = "O campo Cod_Cinema(código do cinema) é obrigatório.")]
        public int Cod_Cinema { get; set; }
        [Required(ErrorMessage = "O campo HorarioDeEncerramento(Horário de inicio da sessão) é obrigatório.")]
        [DisplayFormat(DataFormatString = "yyyy-MM-ddThh:mm:ss")]
        public DateTime HorarioDeInicio { get; set; }
    }
}
