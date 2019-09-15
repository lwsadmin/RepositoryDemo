using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Data;
using Repository.Data.Data;
using Repository.DataAccess.GenericRepository;
namespace Repository.DataAccess.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private EFContext _dbContext;
        private IGenericRepository<Roles> _roleRepository;
        private IGenericRepository<Users> _userRepository;
        private bool disposed = false;
        public UnitOfWork()
        {
            this._dbContext = new EFContext();
        }

        public IGenericRepository<Roles> RoleRepository
        {
            get
            {
                if (this._roleRepository == null)
                {
                    this._roleRepository = new GenericRepository<Roles>(_dbContext);
                }
                return _roleRepository;
            }
        }

        public IGenericRepository<Users> UserRepository
        {
            get
            {
                if (this._userRepository == null)
                {
                    this._userRepository = new GenericRepository<Users>(_dbContext);
                }
                return _userRepository;
            }
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
