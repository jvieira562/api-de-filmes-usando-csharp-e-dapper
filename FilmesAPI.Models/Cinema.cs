using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Models
{
    public class Cinema
    {
        public int Cod_Cinema { get; set; }
        public string Nome { get; set; }
        public int Cod_Endereco { get; set; }
        public int Cod_Gerente { get; set; }

    }
}
