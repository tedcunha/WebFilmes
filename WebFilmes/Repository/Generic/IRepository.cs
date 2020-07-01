using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFilmes.Model.Base;

namespace WebFilmes.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        List<T> PesquisarFilmes();
        T PesquisarFilmesPorID(long Id);
        T CadastrarFilmes(T item);
        T AlteraFilme(T item);
        void DeletarFilme(long Id);
    }
}
