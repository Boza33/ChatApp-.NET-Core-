﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Models
{
    public class User : IdentityUser
    {
        public User() : base()
        {
            ChatUser = new List<ChatUser>();
        }
        public ICollection<ChatUser> ChatUser { get; set; }
    }
}
