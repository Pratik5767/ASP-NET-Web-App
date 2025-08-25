using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ASP_NET_Web_app.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> All();
        T Get(int id);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void Save();
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
    }
}
