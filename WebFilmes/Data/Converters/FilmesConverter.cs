using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFilmes.Data.Converter;
using WebFilmes.Data.VO;
using WebFilmes.Model;

namespace WebFilmes.Data.Converters
{
    public class FilmesConverter : IParser<FilmesVO, Filmes>, IParser<Filmes, FilmesVO>
    {
        public FilmesVO Parse(Filmes origem)
        {
            if (origem == null) return null;
            return new FilmesVO
            {
                Id = origem.Id,
                GuidID = origem.GuidID,
                Nome = origem.Nome,
                Slogan = origem.Slogan,
                Catalogo = origem.Catalogo,
                AnoLanc = origem.AnoLanc,
                Classificacao = origem.Classificacao,
                VisaoGeral = origem.VisaoGeral,
                Imagem = origem.Imagem
            };
        }

        public Filmes Parse(FilmesVO origem)
        {
            if (origem == null) return null;
            return new Filmes
            {
                Id = origem.Id,
                GuidID = origem.GuidID,
                Nome = origem.Nome,
                Slogan = origem.Slogan,
                Catalogo = origem.Catalogo,
                AnoLanc = origem.AnoLanc,
                Classificacao = origem.Classificacao,
                VisaoGeral = origem.VisaoGeral,
                Imagem = origem.Imagem
            };
        }

        // List
        public List<FilmesVO> ParseList(List<Filmes> origem)
        {
            if (origem == null) return new List<FilmesVO>();
            return origem.Select(item => Parse(item)).ToList();
        }

        public List<Filmes> ParseList(List<FilmesVO> origem)
        {
            if (origem == null) return new List<Filmes>();
            return origem.Select(item => Parse(item)).ToList();
        }
    }
}
