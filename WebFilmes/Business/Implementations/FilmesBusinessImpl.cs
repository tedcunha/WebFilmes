using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFilmes.Data.Converters;
using WebFilmes.Data.VO;
using WebFilmes.Model;
using WebFilmes.Repository;
using WebFilmes.Repository.Generic;

namespace WebFilmes.Business.Implementations
{
    public class FilmesBusinessImpl : IFilmesBusiness
    {
        private readonly IRepository<Filmes> _repository;
        private readonly FilmesConverter _converter;

        public FilmesBusinessImpl(IRepository<Filmes> repository)
        {
            _repository = repository;
            _converter = new FilmesConverter();
        }

        public List<FilmesVO> PesquisarFilmes()
        {
            return _converter.ParseList(_repository.PesquisarFilmes());
        }

        public FilmesVO PesquisarFilmesPorID(long Id)
        {
            return _converter.Parse(_repository.PesquisarFilmesPorID(Id));
        }

        public Menssagem CadastrarFilmes(FilmesVO filmes)
        {
            try
            {
                filmes.GuidID = Guid.NewGuid().ToString();
                var livroEntity = _converter.Parse(filmes);
                livroEntity = _repository.CadastrarFilmes(livroEntity);
                return new Menssagem
                {
                    Status = "200",
                    Descricao = "Filme cadastrado com sucesso."
                };
            }
            catch (Exception ex)
            {
                return new Menssagem
                {
                    Status = "404",
                    Descricao = ex.Message.ToString()
                };
            }
        }

        public Menssagem AlteraFilme(FilmesVO filmes)
        {
            try
            {
                var livroEntity = _converter.Parse(filmes);
                livroEntity = _repository.AlteraFilme(livroEntity);
                return new Menssagem
                {
                    Status = "200",
                    Descricao = "Filme alterado com sucesso."
                };
            }
            catch (Exception ex)
            {
                return new Menssagem
                {
                    Status = "404",
                    Descricao = ex.Message.ToString()
                };
            }
        }

        public Menssagem DeletarFilme(long Id)
        {
            try
            {
                _repository.DeletarFilme(Id);
                return new Menssagem
                {
                    Status = "200",
                    Descricao = "Filme excluido com sucesso."
                };
            }
            catch (Exception ex)
            {
                return new Menssagem
                {
                    Status = "404",
                    Descricao = ex.Message.ToString()
                };
            }
        }
    }
}
