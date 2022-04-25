﻿using System;
using System.Collections.Generic;

namespace Flexio.Data.Models.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime DateAdded { get; set; }

        public UserDetail UserDetail { get; set; }
        public UserDetail CreatorDetail { get; set; }
        public UserDetail ActualOwnerDetail { get; set; }
        public List<Comment> CommentsAddedByUser { get; set; }
        public List<Comment> CommentsAddedToUser { get; set; }
    }
}
