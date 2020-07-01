using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFilmes.Model;

namespace WebFilmes.Business
{
    public interface IFilmesBusiness
    {
        List<Filmes> PesquisarFilmes();
        Filmes PesquisarFilmesPorID(long Id);
        Menssagem CadastrarFilmes(Filmes filmes);
        Menssagem AlteraFilme(Filmes filmes);
        Menssagem DeletarFilme(long Id);
    }
}
