using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFilmes.Model;

namespace WebFilmes.Repository
{
    public interface IFilmesRepository
    {
        List<Filmes> PesquisarFilmes();
        Filmes PesquisarFilmesPorID(string Id);
        Menssagem CadastrarFilmes(Filmes filmes);
        Menssagem AlteraFilme(Filmes filmes);
        Menssagem DeletarFilme(string Id);
    }
}
