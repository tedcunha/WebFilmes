using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebFilmes.Data.VO
{
    [DataContract]
    public class FilmesVO
    {
        [DataMember(Order = 1)]
        public long? Id { get; set; }

        [DataMember(Order = 2)]
        public string GuidID { get; set; }

        [DataMember(Order = 3)]
        public string Catalogo { get; set; }

        [DataMember(Order = 4)]
        public string Nome { get; set; }

        [DataMember(Order = 5)]
        public int AnoLanc { get; set; }

        [DataMember(Order = 5)]
        public string Slogan { get; set; }

        [DataMember(Order = 6)]
        public string VisaoGeral { get; set; }

        [DataMember(Order = 7)]
        public int Classificacao { get; set; }

        [DataMember(Order = 8)]
        public string Imagem { get; set; }
    }
}
