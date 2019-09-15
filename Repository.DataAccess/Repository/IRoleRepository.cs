using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Data;
using Repository.Data.Data;
namespace Repository.DataAccess.Repository
{
    public interface IRoleRepository
    {
        IEnumerable<Roles> GetList();

        Roles GetById(int Id);

        void Create(Roles role);


        void Edit(Roles role);

        void Delete(int Id);
    }
}
