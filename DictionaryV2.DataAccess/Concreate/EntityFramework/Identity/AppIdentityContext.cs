using DictionaryV2.Entity.Concreate.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DictionaryV2.DataAccess.Concreate.EntityFramework.Identity {
    public class AppIdentityContext : IdentityDbContext<AppIdentityUser, AppIdentityRole, string> {

        public AppIdentityContext(DbContextOptions<AppIdentityContext> options) : base(options) {

        }
    }
}
