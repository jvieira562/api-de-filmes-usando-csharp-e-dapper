namespace FilmesAPI.Dtos.SessaoDtos
{
    public class UpdateSessaoDto
    {
        public int Cod_Sessao { get; set; }
        public int Cod_Filme { get; set; }
        public int Cod_Cinema { get; set; }
        public DateTime HorarioInicio { get; set; }
    }
}
