using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFilmes.Data.Converter
{
    public interface IParser<D,O>
    {
        D Parse(O origem);
        List<D> ParseList(List<O> origem);
    }
}
