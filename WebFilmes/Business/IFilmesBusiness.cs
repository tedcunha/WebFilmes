using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFilmes.Data.VO;
using WebFilmes.Model;

namespace WebFilmes.Business
{
    public interface IFilmesBusiness
    {
        List<FilmesVO> PesquisarFilmes();
        FilmesVO PesquisarFilmesPorID(long Id);
        Menssagem CadastrarFilmes(FilmesVO filmes);
        Menssagem AlteraFilme(FilmesVO filmes);
        Menssagem DeletarFilme(long Id);
    }
}
