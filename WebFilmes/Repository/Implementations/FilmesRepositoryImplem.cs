using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFilmes.Model;
using WebFilmes.Model.Context;

namespace WebFilmes.Repository.Implementations
{
    public class FilmesRepositoryImplem : IFilmesRepository
    {
        private readonly MySqlContext _mySqlContext;

        public FilmesRepositoryImplem(MySqlContext mySqlContext)
        {
            _mySqlContext = mySqlContext;
        }

        public List<Filmes> PesquisarFilmes()
        {
            return _mySqlContext.Filmes.ToList();
        }

        public Filmes PesquisarFilmesPorID(string Id)
        {
            return _mySqlContext.Filmes.SingleOrDefault(f => f.GuidID == Id);
        }

        public Menssagem CadastrarFilmes(Filmes filme)
        {
            Menssagem msg = new Menssagem();
            try
            {
                filme.GuidID = Guid.NewGuid().ToString();

                _mySqlContext.Add(filme);
                _mySqlContext.SaveChanges();

                msg.Status = "200";
                msg.Descricao = "Filme cadastrado com sucesso.";
                return msg;
            }
            catch (Exception ex)
            {
                msg.Status = "400";
                msg.Descricao = ex.Message.ToString();
                return msg;
            }
        }

        public Menssagem AlteraFilme(Filmes filmes)
        {
            Menssagem msg = new Menssagem();
            try
            {
                var retorno = _mySqlContext.Filmes.SingleOrDefault(p => p.GuidID == filmes.GuidID);
                if (retorno == null)
                {
                    msg.Status = "400";
                    msg.Descricao = "Filme inexistente impossivel alterar";
                    return msg;
                }

                _mySqlContext.Entry(retorno).CurrentValues.SetValues(filmes);
                _mySqlContext.SaveChanges();

                msg.Status = "200";
                msg.Descricao = "Filme alterado com sucesso.";
                return msg;
            }
            catch (Exception ex)
            {
                msg.Status = "400";
                msg.Descricao = ex.Message.ToString();
                return msg;
            }
        }

        public Menssagem DeletarFilme(string Id)
        {
            Menssagem msg = new Menssagem();
            try
            {
                var retorno = _mySqlContext.Filmes.SingleOrDefault(p => p.GuidID == Id);
                if (retorno == null)
                {
                    msg.Status = "400";
                    msg.Descricao = "Filme inexistente impossivel alterar";
                    return msg;
                }

                _mySqlContext.Filmes.Remove(retorno);
                _mySqlContext.SaveChanges();

                msg.Status = "200";
                msg.Descricao = "Filme foi excluido com sucesso.";
                return msg;
            }
            catch (Exception ex)
            {
                msg.Status = "400";
                msg.Descricao = ex.Message.ToString();
                return msg;
            }
        }
    }
}
