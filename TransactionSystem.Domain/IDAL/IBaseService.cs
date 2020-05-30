using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using $safeprojectname$.Model;

namespace $safeprojectname$.IDAL
{
   public interface IBaseService<T> : IDisposable where T : BaseEntity
    {
        void Create(T model);
        void Edit(T model);
        void Remove(Guid id);
        void Remove(T model);
        void Save();
        T GetOneById(Guid id);
        IQueryable<T> GetAll();
        IQueryable<T> GetAllByPage(int pageSize = 10, int pageIndex = 0);
        IQueryable<T> GetAllOrder(bool asc = true);
        IQueryable<T> GetAllByPageOrder(int pageSize = 10, int pageIndex = 0, bool asc = true);
    }
}
