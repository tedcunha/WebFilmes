using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFilmes.Model;
using WebFilmes.Repository;
using WebFilmes.Repository.Generic;

namespace WebFilmes.Business.Implementations
{
    public class FilmesBusinessImpl : IFilmesBusiness
    {
        private readonly IRepository<Filmes> _repository;

        public FilmesBusinessImpl(IRepository<Filmes> repository)
        {
            _repository = repository;
        }

        public List<Filmes> PesquisarFilmes()
        {
            return _repository.PesquisarFilmes(); 
        }

        public Filmes PesquisarFilmesPorID(long Id)
        {
            return _repository.PesquisarFilmesPorID(Id);
        }

        public Menssagem CadastrarFilmes(Filmes filmes)
        {
            try
            {
                filmes.GuidID = Guid.NewGuid().ToString();
                _repository.CadastrarFilmes(filmes);
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

        public Menssagem AlteraFilme(Filmes filmes)
        {
            try
            {
                _repository.AlteraFilme(filmes);

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
