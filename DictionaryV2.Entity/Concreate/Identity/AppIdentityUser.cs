﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DictionaryV2.Entity.Concreate.Identity {
    public class AppIdentityUser : IdentityUser {

        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
