using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryV2.Core.DataAccess {
    public interface IEntityRepository<T> {

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetByFilter(Func<T, bool> filter);
        List<T> GetAll();
    }
}
