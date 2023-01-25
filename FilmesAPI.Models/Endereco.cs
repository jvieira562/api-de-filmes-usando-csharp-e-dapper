namespace FilmesAPI.Models
{
    public class Endereco
    {
        public int Cod_Endereco { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        
        public Endereco()
        {

        }
        public Endereco(string cep)
        {
            var enderecos = new Correios.NET.CorreiosService().GetAddresses(cep);
            foreach (var endereco in enderecos)
            {
                this.Cep = endereco.ZipCode;
                this.Cidade = endereco.City;
                this.Bairro = endereco.District;
                this.Logradouro = endereco.Street;
            }            
        }
    }
}
