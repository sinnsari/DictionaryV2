using DictionaryV2.Entity.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryV2.DataAccess.Concreate.EntityFramework {
    public class DictionaryContext : DbContext {

        public DictionaryContext(DbContextOptions<DictionaryContext> context) 
            : base(context) {

        }

        public DbSet<EngDictionary> EngDictionary { get; set; }

    }
}
