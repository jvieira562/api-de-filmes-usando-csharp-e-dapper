using AutoMapper;
using EnderecosAPI.Services.Interfaces;
using FilmesAPI.data.Repository.Interfaces;
using FilmesAPI.Data.UnitOfWork.Interfaces;
using FilmesAPI.Dtos.EnderecoDtos;
using FilmesAPI.Models;

namespace FilmesAPI.Services
{
    public class EnderecoServiceImpl : EnderecoService
    {
        private readonly UnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly EnderecoRepository _enderecoRepository;

        public EnderecoServiceImpl(UnitOfWork uow, IMapper mapper, EnderecoRepository enderecoRepository)
        {
            _uow = uow;
            _mapper = mapper;
            _enderecoRepository = enderecoRepository;
        }

        public string AtualizarEndereco(int cod_Endereco, UpdateEnderecoDto enderecoDto)
        {
            string mensagem = $"Endereço com código {cod_Endereco} não existe.";

            if(_enderecoRepository.EnderecoExiste(cod_Endereco))
            {
                Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
                endereco.Cod_Endereco = cod_Endereco;
                _enderecoRepository.AtualizarEndereco(endereco);
                mensagem = "";
            }
            return mensagem;
        }

        public ReadEnderecoDto BuscarEndereco(int cod_Endereco)
        {
            ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(_enderecoRepository.BuscarEndereco(cod_Endereco));

            return enderecoDto;
        }

        public IEnumerable<ReadEnderecoDto> BuscarEnderecos()
        {
            List<ReadEnderecoDto> enderecos = _mapper.Map<List<ReadEnderecoDto>>(_enderecoRepository.BuscarEnderecos());

            return enderecos;
        }

        public string ExcluirEndereco(int cod_Endereco)
        {
            string mensagem = $"Endereço com código {cod_Endereco} não existe.";

            if(_enderecoRepository.EnderecoExiste(cod_Endereco))
            {
                _enderecoRepository.ExcluirEndereco(cod_Endereco);
                mensagem = "";
            }

            return mensagem;
        }

        public void SalvarEndereco(CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            _enderecoRepository.SalvarEndereco(endereco);
        }
    }
}
