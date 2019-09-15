using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DataAccess.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetList();

        T GetById(int Id);

        void Create(T T);


        void Edit(T T);

        void Delete(int Id);
    }
}
