using Repository.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DataAccess.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private EFContext _dbContext;
        private DbSet<T> _dbSet;

        public GenericRepository(EFContext dbContext)
        {
            this._dbContext = dbContext;
            this._dbSet = dbContext.Set<T>();
        }
        public void Create(T t)
        {
            _dbSet.Add(t);
        }

        public void Delete(int Id)
        {
            var t = _dbSet.Find(Id);
            if (t != null)
            {
                _dbSet.Remove(t);

            }
        }
        public void Edit(T t)
        {
            _dbContext.Entry(t).State = EntityState.Modified;
        }

        public T GetById(int Id)
        {
            return _dbSet.Find(Id);
        }

        public IEnumerable<T> GetList()
        {
            return _dbSet.ToList();
        }
    }
}
