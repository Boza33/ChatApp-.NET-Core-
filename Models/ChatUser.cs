﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Models
{
    public class ChatUser
    {
        public string UserId {  get; set; }
        public User User { get; set; }
        public int ChatId { get; set; }
        public Chat Chatss { get; set; }
    }
}
