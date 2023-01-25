using AutoMapper;
using FilmesAPI.Data.Repository.Interfaces;
using FilmesAPI.Data.Repository.ReadRepository.Interfaces;
using FilmesAPI.Data.UnitOfWork.Interfaces;
using FilmesAPI.Dtos.SessaoDtos;
using FilmesAPI.Models;
using FilmesAPI.Services.Interfaces;

namespace FilmesAPI.Services
{
    public class SessaoServiceImpl : SessaoService
    {
        private readonly UnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly SessaoRepository _sessaoRepository;
        private readonly ReadSessaoRepository _readSessaoRepository;

        public SessaoServiceImpl(UnitOfWork uow, IMapper mapper, SessaoRepository sessaoRepository,
            ReadSessaoRepository readSessaoRepository)
        {
            _uow = uow;
            _mapper = mapper;
            _sessaoRepository = sessaoRepository;
            _readSessaoRepository = readSessaoRepository;
        }

        public string AtualizarSessao(int cod_Sessao, UpdateSessaoDto sessaoDto)
        {
            string mensagem = $"Sessão com código {cod_Sessao} não foi encontrada.";

            if(_sessaoRepository.SessaoExiste(cod_Sessao))
            {
                Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
                sessao.Cod_Sessao = cod_Sessao;
                _uow.BeginTransaction();
                _sessaoRepository.AtualizarSessao(sessao);
                mensagem = "";
                _uow.commit();
            }

            return mensagem;
        }

        public ReadSessaoDto BuscarSessao(int cod_Sessao)
        {
            var sessaoDto = _readSessaoRepository.BuscarSessao(cod_Sessao);

            return sessaoDto;
        }

        public IEnumerable<ReadSessaoDto> BuscarSessoes()
        {
            IEnumerable<ReadSessaoDto> sessoesDto = _mapper.Map<List<ReadSessaoDto>>(_sessaoRepository.BuscarSessoes());

            return sessoesDto;
        }

        public string ExcluirSessao(int cod_Sessao)
        {
            string mensagem = $"Sessão com código {cod_Sessao} não foi encontrada.";

            if(_sessaoRepository.SessaoExiste(cod_Sessao))
            {
                _sessaoRepository.ExcluirSessao(cod_Sessao);
                mensagem = "";
            }

            return mensagem;
        }

        public void SalvarSessao(CreateSessaoDto sessaoDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
            _sessaoRepository.SalvarSessao(sessao);
        }
    }
}
