using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Data;
using Repository.Data.Data;

namespace Repository.DataAccess.Repository
{
    public class RoleRepository : IRoleRepository,IDisposable
    {
        private EFContext _dbContext;
        private bool disposed = false;
        public RoleRepository(EFContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Create(Roles role)
        {
            _dbContext.Roles.Add(role);
        }

        public void Delete(int Id)
        {
            var u = _dbContext.Roles.Find(Id);
            if (u!=null)
            {
                _dbContext.Roles.Remove(u);
              
            }
        }


        public void Edit(Roles role)
        {
            _dbContext.Entry(role).State = EntityState.Modified;
        }

        public Roles GetById(int Id)
        {
           return _dbContext.Roles.Find(Id);
        }

        public IEnumerable<Roles> GetList()
        {
          return  _dbContext.Roles.ToList();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            //必须为true
            Dispose(disposing: true);
            //通知垃圾回收器不再调用终结器
            GC.SuppressFinalize(this);
        }

    }
}
