using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFilmes.Model.Base;
using WebFilmes.Model.Context;

namespace WebFilmes.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MySqlContext _context;
        private DbSet<T> dataset;

        public GenericRepository(MySqlContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }


        public T AlteraFilme(T item)
        {
            var retorno = dataset.SingleOrDefault(p => p.Id == item.Id);
            try
            {
                _context.Entry(retorno).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public T CadastrarFilmes(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return item;
        }

        public void DeletarFilme(long Id)
        {
            var retorno = dataset.SingleOrDefault(p => p.Id == Id);
            try
            {
                if (retorno != null)
                {
                    dataset.Remove(retorno);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T> PesquisarFilmes()
        {
            return dataset.ToList();
        }

        public T PesquisarFilmesPorID(long Id)
        {
            return dataset.SingleOrDefault(f => f.Id == Id);
        }
    }
}
