﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryV2.Entity.Models {
    public class RegisterModel {

        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
