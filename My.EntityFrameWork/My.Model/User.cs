﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Model
{
    public class User
    {
        public User()
        {
            Roles = new List<Role>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public ICollection<Role> Roles { get; set; }
    }

    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
