using DictionaryV2.Core.DataAccess.EntityFramework;
using DictionaryV2.Core.Extensions;
using DictionaryV2.DataAccess.Abstract;
using DictionaryV2.Entity.Concreate;
using DictionaryV2.Entity.Concreate.ApiPaging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictionaryV2.DataAccess.Concreate.EntityFramework {
    public class EfEngDictionaryDal : EfRepositoryBase<EngDictionary>, IEngDictionaryDal {
        private DbContext _context;
        public EfEngDictionaryDal(DictionaryContext context) : 
            base(context) {

            _context = context;
        }

        public List<EngDictionary> GetAllByRandom() {

            var list = _context.Set<EngDictionary>().ToList();
            list.Shuffle();

            return list;
        }

        public List<EngDictionary> GetAllByRandomAndDate(DateTime date) {

            var list = _context.Set<EngDictionary>().Where(x => x.InsertDate >= date).ToList();
            list.Shuffle();

            return list;
        }

        public PagedList<EngDictionary> GetByPaging(PagingParam param) {

            IQueryable<EngDictionary> query = _context.Set<EngDictionary>();

            if(param.StartDay > 0 && param.EndDay > 0) {
                DateTime startDate = DateTime.Now.AddDays(-1 * param.EndDay);
                DateTime filterStartDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0);

                DateTime endDate = DateTime.Now.AddDays(-1 * param.StartDay);
                DateTime filterEndDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59);
                query = query.Where(x=> x.InsertDate >= filterStartDate && x.InsertDate <= filterEndDate);
            }

            if (!string.IsNullOrEmpty(param.OrderBy)) {
                if (param.OrderBy.ToLower() == "desc")
                    query = query.OrderByDescending(x => x.InsertDate);
                else
                    query = query.OrderBy(x => x.InsertDate);

            }

            var pagedList = new PagedList<EngDictionary>(query, param.PageSize, param.PageNumber);

            return pagedList;
        }
    }
}
