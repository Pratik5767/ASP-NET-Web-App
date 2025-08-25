using ASP_NET_Web_app.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ASP_NET_Web_app.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _db;
        private readonly DbSet<T> _set;
        public EfRepository(AppDbContext db) { _db = db; _set = db.Set<T>(); }

        public IQueryable<T> All() => _set;
        public T Get(int id) => _set.Find(id);
        public void Add(T e) => _set.Add(e);
        public void Update(T e) { _db.Entry(e).State = EntityState.Modified; }
        public void Remove(T e) => _set.Remove(e);
        public void Save() => _db.SaveChanges();
        public IQueryable<T> Where(Expression<System.Func<T, bool>> p) => _set.Where(p);
    }
}