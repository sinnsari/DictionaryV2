using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictionaryV2.Core.DataAccess.EntityFramework {
    public class EfRepositoryBase<T> : IEntityRepository<T> 
        where T : class {

        private DbContext _context;
        public EfRepositoryBase(DbContext context) {
            _context = context;
        }

        public void Add(T entity) {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Delete(T entity) {
            var deletedEntry = _context.Entry(entity);
            deletedEntry.State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public List<T> GetAll() {
            return _context.Set<T>().ToList();
        }

        public T GetByFilter(Func<T, bool> filter) {
            return _context.Set<T>().SingleOrDefault(filter);
        }

        public void Update(T entity) {
            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Added;
            _context.SaveChanges();
        }
    }
}
