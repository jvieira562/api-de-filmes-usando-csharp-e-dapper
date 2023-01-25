using AutoMapper;
using FilmesAPI.data.Repository.Interfaces;
using FilmesAPI.Data.UnitOfWork.Interfaces;
using FilmesAPI.Dtos.FilmeDtos;
using FilmesAPI.Models;
using FilmesAPI.Services.Interfaces;

namespace FilmesAPI.Services
{
    public class FilmeServiceImpl : FilmeService
    {
        private readonly UnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly FilmeRepository _filmeRepository;

        public FilmeServiceImpl(UnitOfWork uow, IMapper mapper, FilmeRepository filmeRepository)
        {
            _uow = uow;
            _mapper = mapper;
            _filmeRepository = filmeRepository;
        }

        public string AtualizarFilme(int cod_Filme, UpdateFilmeDto filmeDto)
        {
            string mensagem = $"Filme com código {cod_Filme} não existe.";

            if(_filmeRepository.FilmeExiste(cod_Filme))
            {
                Filme filme = _mapper.Map<Filme>(filmeDto);
                filme.Cod_Filme = cod_Filme;
                _filmeRepository.AtualizarFilme(filme);
                mensagem = "";
            }
            return mensagem;
        }

        public ReadFilmeDto BuscarFilme(int cod_Filme)
        {
            ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(_filmeRepository.BuscarFilme(cod_Filme));

            return filmeDto;
        }

        public IEnumerable<ReadFilmeDto> BuscarFilmes()
        {
            List<ReadFilmeDto> filmes = _mapper.Map<List<ReadFilmeDto>>(_filmeRepository.BuscarFilmes());
            
            return filmes;
        }

        public string ExcluirFilme(int cod_Filme)
        {
            string mensagem = $"Filme com código {cod_Filme} não existe.";

            if (_filmeRepository.FilmeExiste(cod_Filme))
            {
                _filmeRepository.ExcluirFilme(cod_Filme);
                mensagem = "";
            }

            return mensagem;
        }

        public void SalvarFilme(CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _filmeRepository.SalvarFilme(filme);
        }
    }
}
