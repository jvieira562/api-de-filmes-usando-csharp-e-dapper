using AutoMapper;
using FilmesAPI.data.Repository.Interfaces;
using FilmesAPI.Data.Repository.Interfaces;
using FilmesAPI.Data.UnitOfWork.Interfaces;
using FilmesAPI.Dtos.CinemaDtos;
using FilmesAPI.Models;
using FilmesAPI.Services.Interfaces;

namespace FilmesAPI.Services
{
    public class CinemaServiceImpl : CinemaService
    {
        private readonly UnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly CinemaRepository _cinemaRepository;
        private readonly GerenteRepository _gerenteRepository;
        private readonly EnderecoRepository _enderecoRepository;
        private readonly SessaoRepository _sessaoRepository;
        public CinemaServiceImpl(UnitOfWork uow, IMapper mapper,
            GerenteRepository gerenteRepository, CinemaRepository cinemaRepository,
            EnderecoRepository enderecoRepository, SessaoRepository sessaoRepository)
        {
            _uow = uow;
            _mapper = mapper;
            _cinemaRepository = cinemaRepository;
            _gerenteRepository = gerenteRepository;
            _sessaoRepository = sessaoRepository;
            _enderecoRepository = enderecoRepository;
        }

        public string AtualizarCinema(int cod_Cinema, UpdateCinemaDto cinemaDto)
        {
            string mensagem = $"Cinema com código {cod_Cinema} não existe.";

            if(_cinemaRepository.CinemaExiste(cod_Cinema))
            {
                Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
                cinema.Cod_Cinema = cod_Cinema;
                _cinemaRepository.AtualizarCinema(cinema);
                mensagem = "";
            }
            return mensagem;
        }

        public ReadCinemaDto BuscarCinema(int cod_Cinema)
        {
            Cinema cinema = _cinemaRepository.BuscarCinema(cod_Cinema);
            ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
            cinemaDto.Gerente = _gerenteRepository.BuscarGerente(cinema.Cod_Gerente);
            cinemaDto.Endereco = _enderecoRepository.BuscarEndereco(cinema.Cod_Endereco);
            cinemaDto.Sessoes = _mapper.Map<List<CinemaSessaoDto>>(_sessaoRepository.BuscarSessoesNoCinema(cinema.Cod_Cinema));
            return cinemaDto;
        }

        public IEnumerable<ReadCinemaDto> BuscarCinemas()
        {
            List<Cinema> cinemas = _cinemaRepository.BuscarCinemas().ToList();
            IEnumerable<ReadCinemaDto> cinemasDto = new List<ReadCinemaDto>();
            foreach (Cinema cinema in cinemas)
            {

            }

            _mapper.Map<List<ReadCinemaDto>>(_cinemaRepository.BuscarCinemas());
            
            return cinemasDto;
        }

        public string ExcluirCinema(int cod_Cinema)
        {
            string mensagem = $"Cinema com o código {cod_Cinema} não existe.";

            if(_cinemaRepository.CinemaExiste(cod_Cinema))
            {
                _cinemaRepository.ExcluirCinema(cod_Cinema);
                mensagem = "";
            } 
            return mensagem;
        }

        public void SalvarCinema(CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _cinemaRepository.SalvarCinema(cinema);
        }
    }
}
