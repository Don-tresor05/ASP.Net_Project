﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STUDENT_CRUD
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

    }
}