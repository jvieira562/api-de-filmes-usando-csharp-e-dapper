using AutoMapper;
using FilmesAPI.data.Repository.Interfaces;
using FilmesAPI.Data.UnitOfWork.Interfaces;
using FilmesAPI.Dtos.GerenteDtos;
using FilmesAPI.Models;
using GerentesAPI.Services.Interfaces;

namespace FilmesAPI.Services
{
    public class GerenteServiceImpl : GerenteService
    {
        private readonly UnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly GerenteRepository _gerenteRepository;
        public GerenteServiceImpl(UnitOfWork uow, IMapper mapper, GerenteRepository gerenteRepository)
        {
            _uow = uow;
            _mapper = mapper;
            _gerenteRepository = gerenteRepository;
        }

        public string AtualizarGerente(int cod_Gerente, UpdateGerenteDto gerenteDto)
        {
            string mensagem = $"Gerente com código {cod_Gerente} não existe.";

            if(_gerenteRepository.GerenteExiste(cod_Gerente))
            {
                Gerente gerente = _mapper.Map<Gerente>(gerenteDto);
                gerente.Cod_Gerente = cod_Gerente;
                _gerenteRepository.AtualizarGerente(gerente);
                mensagem = "";
            }

            return mensagem;
        }

        public ReadGerenteDto BuscarGerente(int cod_Gerente)
        {
            ReadGerenteDto gerenteDto = _mapper.Map<ReadGerenteDto>(_gerenteRepository.BuscarGerente(cod_Gerente));
            
            return gerenteDto;
        }

        public IEnumerable<ReadGerenteDto> BuscarGerentes()
        {
            List<ReadGerenteDto> gerentes = _mapper.Map<List<ReadGerenteDto>>(_gerenteRepository.BuscarGerentes());

            return gerentes;
        }

        public string ExcluirGerente(int cod_Gerente)
        {
            string mensagem = $"Gerente com o código { cod_Gerente } não existe.";

            if(_gerenteRepository.GerenteExiste(cod_Gerente))
            {
                _gerenteRepository.ExcluirGerente(cod_Gerente);
                mensagem = "";
            }

            return mensagem;
        }

        public void SalvarGerente(CreateGerenteDto gerenteDto)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDto);
            _gerenteRepository.SalvarGerente(gerente);
        }
    }
}
