﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc2.ViewModels
{
    public class UsersInRole
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}