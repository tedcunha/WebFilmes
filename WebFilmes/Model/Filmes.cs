using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFilmes.Model.Base;

namespace WebFilmes.Model
{
    public class Filmes : BaseEntity
    {
        public string GuidID { get; set; }
        public string Catalogo { get; set; }
        public string Nome { get; set; }
        public int AnoLanc { get; set; }
        public string Slogan { get; set; }
        public string VisaoGeral { get; set; }
        public int Classificacao { get; set; }
        public string Imagem { get; set; }
    }
}
