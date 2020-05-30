using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using $safeprojectname$.IDAL;
using $safeprojectname$.Model;

namespace $safeprojectname$.DAL
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity, new()
    {
        private readonly TransactionContext _db;

        public BaseService(TransactionContext db)
        {
            _db = db;
        }

        public void Create(T model)
        {
            _db.Set<T>().Add(model);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Edit(T model)
        {
            _db.Configuration.ValidateOnSaveEnabled = false;
            _db.Entry(model).State = EntityState.Modified;
            _db.SaveChanges();
            _db.Configuration.ValidateOnSaveEnabled = true;
        }

        public IQueryable<T> GetAll()
        {
            return _db.Set<T>().Where(m => !m.IsRemove).AsNoTracking();
        }

        public IQueryable<T> GetAllByPage(int pageSize = 10, int pageIndex = 0)
        {
            return GetAll().Skip(pageSize * pageIndex).Take(pageSize);
        }

        public IQueryable<T> GetAllByPageOrder(int pageSize = 10, int pageIndex = 0, bool asc = true)
        {
            return GetAllOrder(asc).Skip(pageSize * pageIndex).Take(pageSize);
        }

        public IQueryable<T> GetAllOrder(bool asc = true)
        {
            var datas = GetAll();
            datas = asc ? datas.OrderBy(m => m.CreteTime) : datas.OrderByDescending(m => m.CreteTime);
            return datas;
        }

        public T GetOneById(Guid id)
        {
            return GetAll().First(m => m.Id == id);
        }

        public void Remove(Guid id)
        {
            _db.Configuration.ValidateOnSaveEnabled = false;
            var t = new T(){ Id = id};
            _db.Entry(t).State = EntityState.Unchanged;
            t.IsRemove = true;
            _db.SaveChanges();
            _db.Configuration.ValidateOnSaveEnabled = true;
        }

        public void Remove(T model)
        {
            Remove(model.Id);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
