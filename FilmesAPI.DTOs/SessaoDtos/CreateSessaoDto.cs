namespace FilmesAPI.Dtos.SessaoDtos
{
    public class CreateSessaoDto
    {
        public int Cod_Filme { get; set; }
        public int Cod_Cinema { get; set; }
        public DateTime HorarioDeInicio { get; set; }
    }
}
