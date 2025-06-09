﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagmentSystem.Model
{
    abstract class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public User(int id, string name, string password)
        {
            Id = id;
            Name = name;
            Password = password;
        }
        
    }
}
